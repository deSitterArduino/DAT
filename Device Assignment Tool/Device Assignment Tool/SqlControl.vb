Imports System.Data.SqlClient
Public Class SqlControl
	
	Public _exception As String
	Public _dataTable As System.Data.DataTable
	Public _recordCount As Integer
	
	Private _connection As New SqlConnection("Server=192.168.1.103;Database=Device_Assignments;User Id=DeviceAssignmentApp;Password=password123;")
	Private _command As SqlCommand
	Private _dataAdapter As SqlDataAdapter
	Private _params As New List(Of SqlParameter)
	
	Public Sub New()
	End Sub
	
	Public Function checkConnection() As Boolean
		Try
			_connection.Open()
			If _connection.State = System.Data.ConnectionState.Open Then
				_connection.Close()
				Return True
			End If
		Catch ex As Exception
			_exception = "Connection Error: " & vbNewLine & ex.Message
		Finally
			If _connection.State = System.Data.ConnectionState.Open Then _connection.Close()
		End Try
		Return False
	End Function
	
	Public Sub execQuery(query As String, Optional insert As Boolean = False)
		_recordCount = 0
		_exception = ""
		'MessageBox.Show(query, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Try
			_connection.Open()
			_command = New SqlCommand(query, _connection)
			'params.ForEach(Sub(p) command.Parameters.Add(p))
			For Each p As SqlParameter In _params
				_command.Parameters.Add(p)
			Next p
			_params.Clear()
			_dataTable = New System.Data.DataTable
			If insert = True Then
				_recordCount = _command.ExecuteNonQuery()
			Else
				_dataAdapter = New SqlDataAdapter(_command)
				_recordCount = _dataAdapter.Fill(_dataTable)
			End If
			_connection.Close()
		Catch ex As Exception	
			_exception = "execQuery Error: " & vbNewLine & ex.Message
		Finally	
			If _connection.State = System.Data.ConnectionState.Open Then _connection.Close()
		End Try
	End Sub
	
	Public Sub AddParam(name As String, value As Object)
		Dim newParam As New SqlParameter(name, value)
		_params.Add(newParam)
	End Sub
	
	Public Sub reportError(message As String, code As String)
		MessageBox.Show(message & " Please contact your ICT Administrator and provide the following error code." & vbNewLine & "Error Code: " & code, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
	End Sub
	
	Public Function hasException(Optional report As Boolean = False) As Boolean
		If String.IsNullOrEmpty(_exception) Then Return False
		If report = True Then MsgBox(_exception, MsgBoxStyle.Critical, "Exception")
		Return True
	End Function
	
End Class
