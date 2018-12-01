Public Partial Class ReturnMessageCRT
	Public Sub New(deviceName As String)
		Me.InitializeComponent()
		'Me.TopMost = True   'TODO Remove this in final build
		MaximizeBox = False
		MinimizeBox = False
		lable.Text = "Are you sure you want to return " & deviceName & "?"
		buttonConfirm.DialogResult = DialogResult.OK
		buttonCancel.DialogResult = DialogResult.Cancel
		Dim resourceManager As New System.Resources.ResourceManager("Device_Assignment_Tool.Icons",  System.Reflection.Assembly.GetExecutingAssembly)
		picture.Image = resourceManager.GetObject("Laptop")
	End Sub
End Class
