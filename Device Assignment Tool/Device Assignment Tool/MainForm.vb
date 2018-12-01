Imports System.Reflection
Public Partial Class MainForm
	Dim dtFormat As String = "dd-MM-yy  h:mm tt"
	Dim interfaceControl As InterfaceControl
	Dim databaseControl As DatabaseControl
	Dim DTPChanged As Boolean = False
	
	Public Enum selectionEnum
		CRT
		CAM
	End Enum

	''' <summary>
	''' 
	''' </summary>
	Public Sub New()
		Me.InitializeComponent()
		interfaceControl = New InterfaceControl(dtFormat, crtCombo, crtDGV, camCombo, camDGV)
		databaseControl = New DatabaseControl()
		'Me.TopMost = True
		setDoubleBuffered(crtDGV, True) 'reduces flicker in datagridview's when drawing
		setDoubleBuffered(camDGV, True)
		crtDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		crtDGV.EnableHeadersVisualStyles = False 'if true ColumnHeadersDefaultCellStyle is ignored
		crtDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
		
		camDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
		camDTP.Format = DateTimePickerFormat.Custom 'there is no .value = Null for a DTP, so set the format to a blank string, and only accept the provided date after a value changed event has fired (where the format will also be set back to visible).
		camDTP.CustomFormat = " "
		camDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		camDGV.EnableHeadersVisualStyles = False
		camDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub MainFormLoad(sender As Object, e As EventArgs)
		drawBanners()
		databaseControl.crtSetComboSource(crtCombo)
		databaseControl.camSetComboSource(camCombo)
		RemoveHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged 'we need to remove this handler around any call that clears/updates the selection or datasource of the dgv; Lest it fire.
		databaseControl.crtSetDgvSource(crtDGV, interfaceControl)
		AddHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
		RemoveHandler camDGV.SelectionChanged, AddressOf camSelectionChanged 'we need to remove this handler around any call that clears/updates the selection or datasource of the dgv; Lest it fire.
		databaseControl.camSetDgvSource(camDGV, interfaceControl)
		AddHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
		For Each column As DataGridViewColumn In crtDGV.Columns
			crtDGV.Columns(column.Index).MinimumWidth = 116
			crtDGV.Columns(column.Index).SortMode = DataGridViewColumnSortMode.NotSortable
		Next column
		For Each column As DataGridViewColumn In camDGV.Columns
			camDGV.Columns(column.Index).MinimumWidth = 116
			camDGV.Columns(column.Index).SortMode = DataGridViewColumnSortMode.NotSortable
		Next column
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub crtSelectionChanged(sender As Object, e As EventArgs) 'fired from combo and dgv selection changed/commited events.
		If sender Is crtDGV Then
			interfaceControl.SetSelectCombo(selectionEnum.CRT)
		Else
			If sender Is crtCombo Then
				RemoveHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
				interfaceControl.SetSelectDgv(selectionEnum.CRT)
				AddHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
			End If
		End If
		interfaceControl.crtUpdate(crtText1, crtText2, crtButton, crtTextPassword, databaseControl)
	End Sub
	
	Sub camSelectionChanged(sender As Object, e As EventArgs)
		If sender Is camDGV Then
			interfaceControl.SetSelectCombo(selectionEnum.CAM)
		Else
			If sender Is camCombo Then
				RemoveHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
				interfaceControl.SetSelectDgv(selectionEnum.CAM)
				AddHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
			End If
		End If
		interfaceControl.camUpdate(camText1, camDTP, camButton, DTPChanged)
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub crtButtonClick(sender As Button, e As EventArgs)
		Dim dt As String = DateTime.Now.ToString(dtFormat)
		If sender.Text = "Allocate" Then 
			'====================================== Allocate Button ======================================
			If crtText2.Text = Nothing Then crtText2.Text = "N/A"
			databaseControl.crtAllocate(crtCombo.Text, crtText1.Text, crtText2.Text, dt)
			RemoveHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
			databaseControl.crtSetDgvSource(crtDGV, interfaceControl) 'refresh the dgv source
			interfaceControl.SetSelectDgv(selectionEnum.CRT) 'set selection to new entry in the dgv
			interfaceControl.NewRow(selectionEnum.CRT) 'specify that the selection is a new row for colouring purposes
			interfaceControl.crtUpdate(crtText1, crtText2, crtButton, crtTextPassword, databaseControl) 'update fields to reflect the new selection
			AddHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
			crtCombo.Select()
		Else
			'====================================== Return Button ======================================
			Dim confirmationBox As ReturnMessageCRT = New ReturnMessageCRT(crtCombo.Text)
			confirmationBox.ShowDialog()
			If confirmationBox.DialogResult = DialogResult.OK Then
				databaseControl.crtReturn(crtCombo.Text, dt)
				RemoveHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
				databaseControl.crtSetDgvSource(crtDGV, interfaceControl) 'refresh the dgv source
				interfaceControl.RemoveSelect(selectionEnum.CRT) 'remove and combo or dgv selection
				AddHandler crtDGV.SelectionChanged, AddressOf crtSelectionChanged
				interfaceControl.crtUpdate(crtText1, crtText2, crtButton, crtTextPassword, databaseControl) 'update fields to reflect selection state
				crtCombo.Select()
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub camButtonClick(sender As Button, e As EventArgs)
		Dim dt As String = DateTime.Now.ToString(dtFormat)
		If sender.Text = "Allocate" Then 
			'====================================== Allocate Button ======================================
			If DTPChanged = True Then
				If camDTP.Value > DateTime.Now Then
					databaseControl.camAllocate(camCombo.Text, camText1.Text, camDTP.value.ToString("dd-MM-yy"), dt)
					RemoveHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
					databaseControl.camSetDgvSource(camDGV, interfaceControl)
					interfaceControl.SetSelectDgv(selectionEnum.CAM)
					interfaceControl.NewRow(selectionEnum.CAM)
					interfaceControl.camUpdate(camText1, camDTP, camButton, DTPChanged)
					AddHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
					camCombo.Select()
				Else
					MessageBox.Show("The due date must be a future date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Else
				MessageBox.Show("Please select a due date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		Else
			'====================================== Return Button ======================================
			Dim confirmationBox As ReturnMessageCAM = New ReturnMessageCAM(camCombo.Text)
			confirmationBox.ShowDialog()
			If confirmationBox.DialogResult = DialogResult.OK Then
				databaseControl.camReturn(camCombo.Text, dt)
				RemoveHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
				databaseControl.camSetDgvSource(camDGV, interfaceControl)
				interfaceControl.RemoveSelect(selectionEnum.CAM)
				AddHandler camDGV.SelectionChanged, AddressOf camSelectionChanged
				interfaceControl.camUpdate(camText1, camDTP, camButton, DTPChanged)
				camCombo.Select()
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub crtTextChanged(sender As Object, e As EventArgs)
		If Me.ActiveControl.Equals(sender) Then
			If crtText1.Text <> Nothing Then
				crtButton.Enabled = True
			Else
				crtButton.Enabled = False
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub camTextChanged(sender As Object, e As EventArgs)
		If Me.ActiveControl.Equals(sender) Then
			If camText1.Text <> Nothing Then
				camButton.Enabled = True
			Else
				camButton.Enabled = False
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub crtFieldKeyPressed(sender As Object, e As KeyEventArgs) 'let's let escape work from the dgv and comboBox too. TODO
		If e.KeyCode = Keys.Escape Then
			crtCombo.SelectedIndex = -1
			interfaceControl.crtUpdate(crtText1, crtText2, crtButton, crtTextPassword, databaseControl)
			crtCombo.Select()
			e.SuppressKeyPress = True
		Else
			If e.KeyCode = Keys.Enter And TypeOf sender Is TextBox Then
				GetNextControl(sender, True).Select()
				e.SuppressKeyPress = True
			End If
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub camFieldKeyPressed(sender As Object, e As KeyEventArgs)
		If e.KeyCode = Keys.Escape Then
			camCombo.SelectedIndex = -1
			interfaceControl.camUpdate(camText1, camDTP, camButton, DTPChanged)
			camCombo.Select()
			e.SuppressKeyPress = True
		End If
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub camDTPChanged(sender As DateTimePicker, e As EventArgs)
		DTPChanged = True
		camDTP.Format = DateTimePickerFormat.Long
		camDTP.CustomFormat = dtFormat
	End Sub
	
	Sub ButtonHistoryClick(sender As Object, e As EventArgs)
		Dim history As History = New History(databaseControl)
		history.ShowDialog()
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Sub drawBanners()
		Try
			Dim resourceManager As New System.Resources.ResourceManager("Device_Assignment_Tool.Icons",  System.Reflection.Assembly.GetExecutingAssembly)
			pictureNelson.Image = resourceManager.GetObject("NelsonLogo")
			crtPicture.Image = resourceManager.GetObject("Laptop")
			camPicture.Image = resourceManager.GetObject("Camera")
			
        	Dim imageBackground As New Bitmap(panelNelson.Width, panelNelson.Height)
        	Dim graphics As Graphics = Graphics.FromImage(imageBackground)
        	graphics.FillRectangle(New Drawing2D.LinearGradientBrush(panelNelson.ClientRectangle, Color.LightSkyBlue, Color.LightCoral, 0), panelNelson.ClientRectangle)
        	panelNelson.BackgroundImage = imageBackground
        	
        	imageBackground = New Bitmap(crtPanel.Width, crtPanel.Height)
        	graphics = Graphics.FromImage(imageBackground)
        	graphics.FillRectangle(New Drawing2D.LinearGradientBrush(crtPanel.ClientRectangle, SystemColors.ActiveCaption, SystemColors.Control, 0), crtPanel.ClientRectangle)
        	crtPanel.BackgroundImage = imageBackground
        	        	
        	imageBackground = New Bitmap(camPanel.Width, camPanel.Height)
        	graphics = Graphics.FromImage(imageBackground)
        	graphics.FillRectangle(New Drawing2D.LinearGradientBrush(camPanel.ClientRectangle, SystemColors.ActiveCaption, SystemColors.Control, 0), camPanel.ClientRectangle)
        	camPanel.BackgroundImage = imageBackground
        	graphics.Dispose()
		Catch ex As Exception
			MessageBox.Show(String.Format("Error: {0}", ex.Message))
			Exit Sub
		End Try
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	''' <param name="dgv"></param>
	''' <param name="setting"></param>
	Public Sub setDoubleBuffered(dgv As DataGridView, setting As Boolean)
		Dim dgvType As Type = dgv.[GetType]()
		Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
		pi.SetValue(dgv, setting, Nothing)
	End Sub
	
	''' <summary>
	''' 
	''' </summary>
	Private Sub DGV_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
		Dim sEnum As selectionEnum
		If sender Is crtDGV Then
			sEnum = selectionEnum.CRT
		Else
			If sender Is camDGV Then sEnum = selectionEnum.CAM
		End If
		If interfaceControl.isColoured(sEnum, e.RowIndex) Then
			sender.Rows(e.rowIndex).DefaultCellStyle.BackColor = Color.Transparent
			Dim rowBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, sender.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - sender.HorizontalScrollingOffset + 1, e.RowBounds.Height)
			Dim backBrush As Brush = New System.Drawing.Drawing2D.LinearGradientBrush(rowBounds, Color.LightCoral, SystemColors.Window, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
			e.Graphics.FillRectangle(backBrush, rowBounds)
		Else
			sender.Rows(e.rowIndex).DefaultCellStyle.BackColor = SystemColors.Window
		End If
	End Sub
	
'	Private Sub comboCRT_DrawItem(ByVal sender As ComboBox, ByVal e As System.Windows.Forms.DrawItemEventArgs)
'		Dim myFont As System.Drawing.Font = sender.Font
'        Dim TextColor As New System.Drawing.Color
'
'        TextColor = SystemColors.WindowText
'        Dim myBrush As SolidBrush = New SolidBrush(TextColor)
'        ' Draw the background of the item.
'        e.DrawBackground()
'        
'        'For Each cbItem As System.Data.DataRowView In sender.Items
'        	
'        'Next cbItem
'        
'        If e.Index >=0 Then
'        	e.Graphics.DrawString(DirectCast(sender.Items(e.Index), System.Data.DataRowView).Item("name").ToString, myFont, myBrush, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
'        End If
'
'        ' Draw the focus rectangle if the mouse hovers over an item.
'        e.DrawFocusRectangle()
'    End Sub
End Class
