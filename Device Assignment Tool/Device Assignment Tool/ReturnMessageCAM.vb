Public Partial Class ReturnMessageCAM
	Public Sub New(deviceName As String)
		Me.InitializeComponent()
		'Me.TopMost = True   'TODO Remove this in final build
		MaximizeBox = False
		MinimizeBox = False
		lable.Text = "Please confirm that the following items are also being retuned with" & vbNewLine & deviceName & "."
		buttonConfirm.DialogResult = DialogResult.OK
		buttonCancel.DialogResult = DialogResult.Cancel
		Dim resourceManager As New System.Resources.ResourceManager("Device_Assignment_Tool.Icons",  System.Reflection.Assembly.GetExecutingAssembly)
		picture.Image = resourceManager.GetObject("Camera")
	End Sub
	
	Sub checkChanged(sender As Object, e As EventArgs)
		If battery.Checked = True And sdCard.Checked = True Then 
			buttonConfirm.Enabled = True
		Else
			buttonConfirm.Enabled = False
		End If
	End Sub
End Class
