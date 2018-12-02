Public Class InterfaceControl
	
	Private _crtNewRow As Integer = -1
	Private _camNewRow As Integer = -1
	Private _crtDgvIndexList As List(Of Integer)
	Private _crtComboIndexList As List(Of Integer)
	Private _camDgvIndexList As List(Of Integer)
	Private _camComboIndexList As List(Of Integer)
	Private _crtCombo As ComboBox
	Private _crtDGV As DataGridView
	Private _camCombo As ComboBox
	Private _camDGV As DataGridView
	
	Private _dtFormat As String
	Private _timer As Timer
	Private _timerInterval As Integer = 1000 'ms
	Private _crtDateTimeTable As System.Data.DataTable
	Private _camDateTimeTable As System.Data.DataTable
	
	
	Public Enum selectionEnum
		CRT
		CAM
	End Enum
		
	Public Sub New(dtFormat As String, ByRef crtCombo As ComboBox, ByRef crtDGV As DataGridView, ByRef camCombo As ComboBox, ByRef camDGV As DataGridView)
		_dtFormat = dtFormat
		_crtCombo = crtCombo
		_crtDGV = crtDGV
		_camCombo = camCombo
		_camDGV = camDGV
		createDateTimeTable(_crtDateTimeTable)
		createDateTimeTable(_camDateTimeTable)
		_timer = New Timer With{.Interval = _timerInterval}
		AddHandler _timer.Tick, AddressOf timerTick
		_timer.Start()
	End Sub
	
	''' <summary>
	''' In order to save on realtime searching for combo/row indices each time a selection is made, list's for index matching are prepared when dataGridView datasource changes.
	''' Dgv list index = _dgv.rowIndex, while the integer is the index of the corresponding device in the _combo. e.g item(2) = 4 is the third dgv row mapped to the fifth combo box item.
	''' the reverse of above for Combo list. index = _combo index, while the integer is the index of the corresponding row in _dgv, -1 for rows that do not exist in the dgv.
	''' </summary>
	Public Sub RebuildIndexLists(sEnum As selectionEnum)
		Dim comboIndexList As List(Of Integer)
		Dim dgvIndexList As List(Of Integer)
		Dim combo As ComboBox
		Dim dgv As DataGridView
		Select Case sEnum
			Case selectionEnum.CRT
				_crtComboIndexList = New List(Of Integer)
				_crtDGVIndexList = New List(Of Integer)
				dgvIndexList = _crtDgvIndexList
				comboIndexList = _crtComboIndexList
				combo = _crtCombo
				dgv = _crtDGV
			Case selectionEnum.CAM
				_camComboIndexList = New List(Of Integer)
				_camDGVIndexList = New List(Of Integer)
				dgvIndexList = _camDgvIndexList
				comboIndexList = _camComboIndexList
				combo = _camCombo
				dgv = _camDGV
		End Select
		For Each item In combo.Items
			comboIndexList.Add(-1)
		Next item
		For Each row As DataGridViewRow In dgv.Rows
			Dim shitter As String = row.Cells(0).Value.ToString
			Dim index As Integer = combo.FindStringExact(row.Cells(0).Value.ToString)
			If index > -1 Then dgvIndexList.Add(index)
			comboIndexList.Item(index) = row.Index
		Next row
	End Sub
		
	''' <summary>
	''' 
	''' </summary>
	Public Sub SetSelectCombo(sEnum As selectionEnum)
		Dim dgv As DataGridView
		Dim combo As ComboBox
		Dim dgvIndexList As List(Of Integer)
		Select Case sEnum
			Case selectionEnum.CRT
				combo = _crtCombo
				dgv = _crtDGV
				dgvIndexList = _crtDgvIndexList
			Case selectionEnum.CAM
				combo = _camCombo
				dgv = _camDGV
				dgvIndexList = _camDgvIndexList
		End Select
		If dgv.SelectedRows.Count > 0 Then
			Dim rowIndex As Integer = dgv.SelectedCells.Item(0).RowIndex
			If rowIndex > -1 Then
				combo.SelectedIndex = dgvIndexList.Item(rowIndex)
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Public Sub SetSelectDgv(sEnum As selectionEnum)
		Dim dgv As DataGridView
		Dim rowIndex As Integer
		Select Case sEnum
			Case selectionEnum.CRT
				dgv = _crtDGV
				rowIndex = GetDgvRowIndex(selectionEnum.crt, _crtCombo.SelectedIndex)				
			Case selectionEnum.CAM
				dgv = _camDGV
				rowIndex = GetDgvRowIndex(selectionEnum.cam, _camCombo.SelectedIndex)
		End Select
		dgv.ClearSelection()
		If rowIndex > -1 Then
			dgv.CurrentCell = dgv.Rows(rowIndex).Cells(0)
			dgv.Rows(rowIndex).Selected = True
		End If
	End Sub
	
	Public Sub RemoveSelect(sEnum As selectionEnum)
		Dim combo As ComboBox
		Dim dgv As DataGridView
		Select Case sEnum
			Case selectionEnum.CRT
				combo = _crtCombo
				dgv = _crtDGV
			Case selectionEnum.CAM
				combo = _camCombo
				dgv = _camDGV
		End Select
		combo.SelectedIndex = -1
		dgv.ClearSelection()
	End Sub
	
	Public Function GetDgvRowIndex(sEnum As selectionEnum, comboIndex As Integer) As Integer
		Dim comboIndexList As List(Of Integer)
		Select Case sEnum
			Case selectionEnum.CRT
				comboIndexList = _crtComboIndexList
			Case selectionEnum.CAM
				comboIndexList = _camComboIndexList
		End Select
		Dim rowIndex As Integer = comboIndexList.Item(comboIndex)
		Return rowIndex
	End Function
	
	Public Sub NewRow(sEnum As selectionEnum)
		Select Case sEnum
			Case selectionEnum.CRT
				_crtNewRow = 0
			Case selectionEnum.CAM
				_camNewRow = 0
		End Select
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Public Sub crtUpdate(ByRef textBox1 As TextBox, ByRef textBox2 As TextBox, ByRef button As Button, ByRef txtPassword As TextBox, ByRef buttonPrint As Button, ByRef dbControl As DatabaseControl)
		If _crtCombo.SelectedIndex > -1 Then
			Dim rowIndex As Integer = GetDgvRowIndex(selectionEnum.CRT, _crtCombo.SelectedIndex)
			If rowIndex > -1 Then
				'Allocated Selection
				textBox1.Text = _crtDGV.Rows(rowIndex).Cells(1).Value.ToString
				textBox2.Text = _crtDGV.Rows(rowIndex).Cells(2).Value.ToString
				textBox1.Enabled = False
				textBox2.Enabled = False
				button.Text = "Return"
				button.ForeColor = Color.Red
				button.Enabled = True
				If isColoured(selectionEnum.CRT, rowIndex) = False Then
					dbControl.crtPassword(txtPassword, _crtCombo.SelectedValue.ToString)
					txtPassword.BackColor = SystemColors.Control
					buttonPrint.Enabled = True
				Else
					txtPassword.Text = "OVERDUE"
					txtPassword.BackColor = Color.LightCoral
					buttonPrint.Enabled = False
				End If
			Else
				'Non-Allocated Selection
				crtClear(textBox1, textBox2, button, txtPassword, buttonPrint)
			End If
		Else
			crtClear(textBox1, textBox2, button, txtPassword, buttonPrint, True)
		End If
		If _crtNewRow > -1 Then
			_crtDGV.DefaultCellStyle.SelectionBackColor = Color.LightGreen
			_crtDGV.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
			_crtNewRow = -2
		Else
			If _crtNewRow = -2 Then
				_crtDGV.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
				_crtDGV.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
				_crtNewRow = -1
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Private Sub crtClear(ByRef textBox1 As TextBox, ByRef textBox2 As TextBox, ByRef button As Button, ByRef txtPassword As TextBox, ByRef buttonPrint As Button, Optional fullClear As Boolean = False)
		If fullClear = True Then
			textBox1.Enabled = False
			textBox2.Enabled = False
		Else
			textBox1.Enabled = True
			textBox2.Enabled = True
		End If
		textBox1.Clear()
		textBox2.Clear()
		button.Text = "Allocate"
		button.ForeColor = SystemColors.ControlText
		button.Enabled = False
		txtPassword.Clear()
		txtPassword.BackColor = SystemColors.Control
		buttonPrint.Enabled = False
	End Sub
	
	Public Sub camUpdate(ByRef textBox1 As TextBox, ByRef dtp As DateTimePicker, ByRef button As Button, ByRef DTPChanged As Boolean)
		If _camCombo.SelectedIndex > -1 Then
			Dim rowIndex As Integer = GetDgvRowIndex(selectionEnum.CAM, _camCombo.SelectedIndex)
			If rowIndex > -1 Then
				'Allocated Selection
				textBox1.Text = _camDGV.Rows(rowIndex).Cells(1).Value.ToString
				textBox1.Enabled = False
				dtp.Format = DateTimePickerFormat.Long
				dtp.Value = DateTime.ParseExact(_camDGV.Rows(rowIndex).Cells(2).Value.ToString, "dd-MM-yy", Nothing)
				dtp.Enabled = False
				button.Text = "Return"
				button.ForeColor = Color.Red
				button.Enabled = True
			Else
				'Non-Allocated Selection
				camClear(textBox1, dtp, button, DTPChanged)
			End If
		Else
			camClear(textBox1, dtp, button, DTPChanged, True)
		End If
		If _camNewRow > -1 Then
			_camDGV.DefaultCellStyle.SelectionBackColor = Color.LightGreen
			_camDGV.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
			_camNewRow = -2
		Else
			If _camNewRow = -2 Then
				_camDGV.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
				_camDGV.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
				_camNewRow = -1
			End If
		End If
	End Sub
	
	Private Sub camClear(ByRef textBox1 As TextBox, ByRef dtp As DateTimePicker, ByRef button As Button, ByRef DTPChanged As Boolean, Optional fullClear As Boolean = False)
		If fullClear = True Then
			textBox1.Enabled = False
			dtp.Enabled = False
		Else
			textBox1.Enabled = True
			dtp.Enabled = True
		End If
		dtp.Format = DateTimePickerFormat.Custom
		dtp.CustomFormat = " "
		DTPChanged = False
		textBox1.Clear()
		button.Text = "Allocate"
		button.ForeColor = SystemColors.ControlText
		button.Enabled = False
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="columnIndex"></param>
	Public Sub crtRebuildDateTimeTable(columnIndex As Integer)
		_crtDateTimeTable.Clear()
		If _crtDGV.Rows.Count > 0 Then
			For Each row As DataGridViewRow In _crtDGV.Rows
				Dim newRow As System.Data.DataRow = _crtDateTimeTable.NewRow()
				newRow.Item("dateTime") = DateTime.ParseExact(row.Cells(columnIndex).Value.ToString, _dtFormat, Nothing)
				newRow.Item("rowIndex") = row.Index
				newRow.Item("set") = False
				_crtDateTimeTable.Rows.Add(newRow)
			Next row
			'_crtDateTimeTable.DefaultView.Sort = "dateTime ASC"
			'_crtDateTimeTable = _crtDateTimeTable.DefaultView.ToTable
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="columnIndex"></param>
	Public Sub camRebuildDateTimeTable(columnIndex As Integer)
		_camDateTimeTable.Clear()
		If _camDGV.Rows.Count > 0 Then
			For Each row As DataGridViewRow In _camDGV.Rows
				Dim newRow As System.Data.DataRow = _camDateTimeTable.NewRow()
				newRow.Item("dateTime") = Date.ParseExact(row.Cells(columnIndex).Value.ToString, "dd-MM-yy", Nothing)
				newRow.Item("rowIndex") = row.Index
				newRow.Item("set") = False
				_camDateTimeTable.Rows.Add(newRow)
			Next row
			'_crtDateTimeTable.DefaultView.Sort = "dateTime ASC"
			'_crtDateTimeTable = _crtDateTimeTable.DefaultView.ToTable
		End If
	End Sub
	
	''' <summary>
	''' Initializes _dataTable upon construction. Note: Column info is not removed by future _dataTable.clear() calls.
	''' </summary>
	Private Sub createDateTimeTable(ByRef table As System.Data.DataTable)
		table = New System.Data.DataTable
		Dim column1 As System.Data.DataColumn = New System.Data.DataColumn("dateTime")
		column1.DataType = System.Type.GetType("System.DateTime")
		Dim column2 As System.Data.DataColumn = New System.Data.DataColumn("rowIndex")
		column2.DataType = System.Type.GetType("System.Int32")
		Dim column3 As System.Data.DataColumn = New System.Data.DataColumn("set")
		column3.DataType = System.Type.GetType("System.Boolean")
		table.Columns.Add(column1)
		table.Columns.Add(column2)
		table.Columns.Add(column3)
	End Sub
	
	Private Sub timerTick(sender As Object, e As EventArgs)
		Dim interval = _timerInterval - DateTime.Now.Millisecond 'try and keep the timer tick in sync with the system clock
		If interval >= 0 Then
			_timer.Interval = interval
		Else
			_timer.Interval = _timerInterval
		End If
		dateTimeCheck()
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Public Sub dateTimeCheck()
		If _crtDateTimeTable.Rows.Count > 0 Then
			For i As Integer = 0 To _crtDateTimeTable.Rows.Count - 1
				If CType(_crtDateTimeTable.Rows(i).Item(2), Boolean) = False Then
					Dim dt As DateTime = CType(_crtDateTimeTable.Rows(i).Item(0), DateTime)
					If dt.Day <> DateTime.Now.Day Then 'if an allocation is left for a month, and the day comes back around, then this will not be coloured. Added fix but could be better TODO
						_crtDateTimeTable.Rows(i).Item(2) = True
					Else
						If dt.Month <> DateTime.Now.Month Then
							_crtDateTimeTable.Rows(i).Item(2) = True
						Else
							If dt.Year <> DateTime.Now.Year Then
								_crtDateTimeTable.Rows(i).Item(2) = True
							End If
						End If
					End If
				End If
			Next
		End If
		If _camDateTimeTable.Rows.Count > 0 Then
			For i As Integer = 0 To _camDateTimeTable.Rows.Count - 1
				If CType(_camDateTimeTable.Rows(i).Item(2), Boolean) = False Then
					Dim dt As Date = CType(_camDateTimeTable.Rows(i).Item(0), Date)
					If dt < Date.Now.ToString("dd-MM-yy") Then
						_camDateTimeTable.Rows(i).Item(2) = True
					End If
				End If
			Next
		End If
	End Sub
	
	Function isColoured(sEnum As selectionEnum, rowIndex As Integer) As Boolean
		Dim table As System.Data.DataTable
		Select Case sEnum
			Case selectionEnum.crt
				table = _crtDateTimeTable
			Case selectionEnum.cam
				table = _camDateTimeTable
		End Select
		If table.Rows.Count > rowIndex Then
			Return table.Rows(rowIndex).Item(2).ToString
			Else Return False
		End If
	End Function
	
End Class
