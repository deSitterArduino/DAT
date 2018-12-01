Public Class DatabaseControl
	
	Private sql As SqlControl = new SqlControl
	Public Enum selectionEnum
		CRT
		CAM
	End Enum
	
	Public Sub New()
	End Sub
		
	'=====================================================================================
	'======================================== CRT ========================================
	'=====================================================================================
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="combo"></param>
	''' <q1>
	''' SELECT AssetNumber, SUBSTRING(AssignedUserId, CHARINDEX('\', AssignedUserId) + 1, LEN(AssignedUserId)) AS AssignedUserId
	''' FROM [Disco].[dbo].[Devices] AS A
	''' INNER JOIN [Disco].[dbo].[DeviceProfiles] AS B
	''' ON A.DeviceProfileId = B.Id
	''' WHERE B.ShortName = 'CRT' AND A.DecommissionedDate IS NULL
	''' ORDER BY A.AssetNumber
	''' </q1>
	Public Sub crtSetComboSource(ByRef combo As ComboBox)
		sql.execQuery("SELECT AssetNumber, SUBSTRING(AssignedUserId, CHARINDEX('\', AssignedUserId) + 1, LEN(AssignedUserId)) AS AssignedUserId FROM [Disco].[dbo].[Devices] as A INNER JOIN [Disco].[dbo].[DeviceProfiles] as B ON A.DeviceProfileId = B.Id WHERE B.ShortName = 'CRT' AND A.DecommissionedDate IS NULL ORDER BY A.AssetNumber;")
		If sql.hasException() Or sql._recordCount < 1 Then
			sql.reportError("Database Error: Unable to load CRT profile.", "02")
			Application.Exit() 'if we can't set the combo source then there is little point going on. Something would have to be wrong with the database/connection.
			End
		End If
		combo.DataSource = sql._dataTable
		combo.DisplayMember = "AssetNumber"
		combo.ValueMember = "AssignedUserId"
		combo.SelectedIndex = -1
	End Sub
	
	''' <summary>v
	''' 
	''' </summary>
	''' <param name="dgv"></param>
	''' <q1>
	''' SELECT * FROM [Device_Assignments].[dbo].[crtAssignments] ORDER BY Device
	''' </q1>
	Public Sub crtSetDgvSource(ByRef dgv As DataGridView, ByRef interfaceControl As InterfaceControl)
		sql.execQuery("SELECT * FROM [Device_Assignments].[dbo].[crtAssignments] ORDER BY Device;")
		If sql.hasException() Then
			sql.reportError("Database Error: Unable to source CRT Assignments.", "03")
			Application.Exit() 'again must be database/connection error. Though we will not terminate if select returns zero rows, this is to be expected.
			End
		End If
		dgv.DataSource = sql._dataTable 'lets free up some memory here by removing datatable once it's been used??
		dgv.ClearSelection()
		interfaceControl.crtRebuildDateTimeTable(3) 'TODO make these delegets, but currently calling from here so we never forget them when dgv source changes
		interfaceControl.RebuildIndexLists(selectionEnum.crt)
		interfaceControl.dateTimeCheck() 'colours rows immediately so we don't have to wait for the next tick
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <q1>
	''' IF NOT EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device)
	''' INSERT INTO [Device_Assignments].[dbo].[crtAssignments] (Device, CRT, Replacing, Allocated, Allocated_By)
	''' VALUES (@device, @txt1, @txt2, @dt,	@user);
	''' </q1>
	Public Sub crtAllocate(device As String, txt1 As String, txt2 As String, dt As String)
		sql.AddParam("@device", device)
		sql.AddParam("@txt1", txt1)
		sql.AddParam("@txt2", txt2)
		sql.AddParam("@dt", dt)
		sql.AddParam("@user", Environment.UserName)
		sql.execQuery("IF NOT EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device) INSERT INTO [Device_Assignments].[dbo].[crtAssignments] (Device, CRT, Replacing, Allocated, Allocated_By) VALUES ( @device, @txt1, @txt2, @dt, @user );", True)
		If sql.hasException() Then
			MessageBox.Show("Database Error: Unable to allocate. Please try again. If the error persists, please contact your ICT Administrator and provide the following error code." & vbNewLine & "Error Code: 04", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Exit Sub 'If we can't allocate we can just exit sub and let them try again.
		End If
		If sql._recordCount = -1 Then
			MessageBox.Show("Device has been allocated since last update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <q1>
	''' IF EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device)
	''' INSERT INTO [Device_Assignments].[dbo].[crtHistory] (Device, CRT, Replacing, Allocated, Allocated_By, Returned, Returned_By)
	''' SELECT Device, CRT, Replacing, Allocated, Allocated_By, @dt, @user FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device;
	''' </q1>
	''' <q2>
	''' DELETE FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = comboCRT.Text;
	''' </q2>
	Public Sub crtReturn(device As String, dt As String)
		sql.AddParam("@device", device)
		sql.AddParam("@dt", dt)
		sql.AddParam("@user", Environment.UserName)
		sql.execQuery("IF EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device) INSERT INTO [Device_Assignments].[dbo].[crtHistory] (Device, CRT, Replacing, Allocated, Allocated_By, Returned, Returned_By) SELECT Device, CRT, Replacing, Allocated, Allocated_By, @dt, @user FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device;", True)
		If sql.hasException() Then
			MessageBox.Show("Database Error: Unable to return. Please try again. If the error persists, please contact your ICT Administrator and provide the following error code." & vbNewLine & "Error Code: 05", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Exit Sub 'again exit sub here, let them try again.
		End If
		If sql._recordCount = -1 Then
			MessageBox.Show("The device you are attempting to return has already been logged as returned.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Else
			sql.AddParam("@device", device)
			sql.execQuery("DELETE FROM [Device_Assignments].[dbo].[crtAssignments] WHERE Device = @device;", True)
			If sql.hasException() Then
				sql.reportError("Database Error: Unable to finalize return.", "05")
				Application.Exit() 'might be best to just close here and let ICT follow up. If it was inserted into the history table, but not cleared from the assignments table, then letting them try again may fill histoy with duplicates.
				End
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <q1>
	''' SELECT Password FROM [eduhub].[dbo].[UserDetails] WHERE UserId = @userId
	''' </q1>
	''' <param name="txt1"></param>
	Public Sub crtPassword(ByRef txt1 As TextBox, device As String)
		sql.AddParam("@userId", device)
		sql.execQuery("SELECT Password From [eduhub].[dbo].[UserDetails] WHERE UserId = @userId")
		If sql.hasException() Or sql._recordCount <> 1 Then 'we should only be expecting one record
			sql.reportError("Database Error: Unable to fetch password.", "06")
		Else
			txt1.Text = sql._dataTable.Rows(0).Item(0).ToString
		End If	
	End Sub
	
	'=====================================================================================
	'======================================== CAM ========================================
	'=====================================================================================
	
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="combo"></param>
	''' <q1>
	''' SELECT AssetNumber
	''' FROM [Disco].[dbo].[Devices] AS A
	''' INNER JOIN [Disco].[dbo].[DeviceProfiles] AS B
	''' ON A.DeviceProfileId = B.Id
	''' WHERE B.ShortName = 'DC' AND A.DecommissionedDate IS NULL
	''' ORDER BY AssetNumber
	''' </q1>
	Public Sub camSetComboSource(ByRef combo As ComboBox)
		sql.execQuery("SELECT AssetNumber FROM [Disco].[dbo].[Devices] as A INNER JOIN [Disco].[dbo].[DeviceProfiles] as B ON A.DeviceProfileId = B.Id WHERE B.ShortName = 'DC' AND A.DecommissionedDate IS NULL ORDER BY AssetNumber;")
		If sql.hasException() Or sql._recordCount < 1 Then
			sql.reportError("Database Error: Unable to load CAM profile.", "07")
			Application.Exit() 'if we can't set the combo source then there is little point going on. Something would have to be wrong with the database/connection.
			End
		End If
		combo.DataSource = sql._dataTable
		combo.DisplayMember = "AssetNumber"
		combo.SelectedIndex = -1
	End Sub
	
	''' <summary>v
	''' 
	''' </summary>
	''' <param name="dgv"></param>
	''' <q1>
	''' SELECT * FROM [Device_Assignments].[dbo].[camAssignments] ORDER BY Device
	''' </q1>
	Public Sub camSetDgvSource(ByRef dgv As DataGridView, ByRef interfaceControl As InterfaceControl)
		sql.execQuery("SELECT * FROM [Device_Assignments].[dbo].[camAssignments] ORDER BY Device;")
		If sql.hasException() Then
			sql.reportError("Database Error: Unable to source CAM Assignments.", "08")
			Application.Exit()
			End
		End If
		dgv.DataSource = sql._dataTable
		dgv.ClearSelection()
		interfaceControl.camRebuildDateTimeTable(2)
		interfaceControl.RebuildIndexLists(selectionEnum.cam)
		interfaceControl.dateTimeCheck()
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <q1>
	''' IF NOT EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device)
	''' INSERT INTO [Device_Assignments].[dbo].[camAssignments] (Device, Borrower, Due, Allocated, Allocated_By)
	''' VALUES (@device, @txt1, @dueDate, @dt, @user);
	''' </q1>
	Public Sub camAllocate(device As String, txt1 As String, dueDate As String, dt As String)
		sql.AddParam("@device", device)
		sql.AddParam("@txt1", txt1)
		sql.AddParam("@dueDate", dueDate)
		sql.AddParam("@dt", dt)
		sql.AddParam("@user", Environment.UserName)
		sql.execQuery("IF NOT EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device) INSERT INTO [Device_Assignments].[dbo].[camAssignments] (Device, Borrower, Due, Allocated, Allocated_By) VALUES ( @device, @txt1, @dueDate, @dt, @user );", True)
		If sql.hasException(True) Then
			MessageBox.Show("Database Error: Unable to allocate. Please try again. If the error persists, please contact your ICT Administrator and provide the following error code." & vbNewLine & "Error Code: 09", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Exit Sub 'If we can't allocate we can just exit sub and let them try again.
		End If
		If sql._recordCount = -1 Then
			MessageBox.Show("Device has been allocated since last update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <q1>
	''' IF EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device)
	''' INSERT INTO [Device_Assignments].[dbo].[camHistory] (Device, Borrower, Due, Allocated, Allocated_By, Returned, Returned_By)
	''' SELECT Device, Borrower, Due, Allocated, Allocated_By, @dt, @user FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device;
	''' </q1>
	''' <q2>
	''' DELETE FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = comboCRT.Text;
	''' </q2>
	Public Sub camReturn(device As String, dt As String)
		sql.AddParam("@device", device)
		sql.AddParam("@dt", dt)
		sql.AddParam("@user", Environment.UserName)
		sql.execQuery("IF EXISTS(SELECT Device FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device) INSERT INTO [Device_Assignments].[dbo].[camHistory] (Device, Borrower, Due, Allocated, Allocated_By, Returned, Returned_By) SELECT Device, Borrower, Due, Allocated, Allocated_By, @dt, @user FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device;", True)
		If sql.hasException() Then
			MessageBox.Show("Database Error: Unable to return. Please try again. If the error persists, please contact your ICT Administrator and provide the following error code." & vbNewLine & "Error Code: 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Exit Sub
		End If
		If sql._recordCount = -1 Then
			MessageBox.Show("The device you are attempting to return has already been logged as returned.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Else
			sql.AddParam("@device", device)
			sql.execQuery("DELETE FROM [Device_Assignments].[dbo].[camAssignments] WHERE Device = @device;", True)
			If sql.hasException() Then
				sql.reportError("Database Error: Unable to finalize return.", "11")
				Application.Exit()
				End
			End If
		End If
	End Sub
	
	'=====================================================================================
	'====================================== HISTORY ======================================
	'=====================================================================================
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="table"></param>
	''' <param name="combo"></param>
	Public Sub historySetColumnSource(table As String, combo As ComboBox)
		sql.execQuery("SELECT TOP 1 * FROM [Device_Assignments].[dbo].[" & table & "History];")
		If sql.hasException() Then
			sql.reportError("Database Error: Unable to Unable to load Assignments.", "12")
			Exit Sub	
		End If
		For Each column As System.Data.DataColumn In sql._dataTable.Columns
			If column.ColumnName <> "Id" Then combo.Items.Add(column.ColumnName)
		Next column
		If combo.Items.Count > 0 Then combo.SelectedIndex = 0
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="comboTable"></param>
	''' <param name="comboColumn"></param>
	''' <param name="searchTerm"></param>
	''' <param name="dgv"></param>
	Public Sub historySearch(comboTable As String, comboColumn As String, searchTerm As String, ByRef dgv As DataGridView)
		sql.AddParam("@searchTerm", "%" & searchTerm & "%")
		sql.execQuery("SELECT * FROM [Device_Assignments].[dbo].[" & comboTable & "History] WHERE " & comboColumn & " LIKE @searchTerm ORDER BY Allocated;")
		If sql.hasException() Then
			sql.reportError("Database Error: Unable to perform search.", "13")
			Exit Sub
		End If
		If sql._dataTable.Columns.Contains("Id") Then sql._dataTable.Columns.Remove("Id")
		dgv.DataSource = sql._dataTable
		dgv.ClearSelection()
	End Sub
	
End Class
