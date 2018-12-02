Imports System.Reflection
Public Partial Class History
	
	Private _databaseControl As DatabaseControl
	
	Public Sub New(ByRef databaseControl As DatabaseControl)
		Me.InitializeComponent()
		MinimizeBox = False
		_databaseControl = databaseControl
		comboTable.Items.Add("CRT")
		comboTable.Items.Add("CAM")
		comboTable.SelectedIndex = 0
		comboTableSelectionChanged(comboTable, Nothing)
		dgv.EnableHeadersVisualStyles = False
		dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		setDoubleBuffered(dgv, True)
	End Sub
	
	Sub comboTableSelectionChanged(sender As Object, e As EventArgs)
		comboColumn.Items.Clear()
		textSearch.Clear()
		buttonSearch.Enabled = False
		dgv.DataSource = Nothing
		_databaseControl.historySetColumnSource(comboTable.Text, comboColumn)
	End Sub
	
	Sub ButtonSearchClick(sender As Object, e As EventArgs)
		_databaseControl.historySearch(comboTable.Text, comboColumn.Text, textSearch.Text, dgv)
		For Each column As DataGridViewColumn In dgv.Columns
			dgv.Columns(column.Index).MinimumWidth = 116
			dgv.Columns(column.Index).AutoSizeMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
		Next column
	End Sub
	
	Sub searchTextChanged(sender As Object, e As EventArgs)
		If Me.ActiveControl.Equals(sender) Then
			If textSearch.Text <> Nothing Then
				buttonSearch.Enabled = True
			Else
				buttonSearch.Enabled = False
			End If
		End If
	End Sub
	
	Sub textSearchClick()
		'textSearch.Clear()
	End Sub
	
	Sub textSearchKeyPressed(sender As Object, e As KeyEventArgs)
		If e.KeyCode = Keys.Escape Then
			textSearch.Clear()
			e.SuppressKeyPress = True
		Else
			If e.KeyCode = Keys.Enter Then
				If textSearch.Text <> "" Then
					ButtonSearchClick(buttonSearch, Nothing)
					e.SuppressKeyPress = True
				End If
			End If
		End If
	End Sub
	
	Public Sub setDoubleBuffered(dgv As DataGridView, setting As Boolean)
		Dim dgvType As Type = dgv.[GetType]()
		Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
		pi.SetValue(dgv, setting, Nothing)
	End Sub
End Class
