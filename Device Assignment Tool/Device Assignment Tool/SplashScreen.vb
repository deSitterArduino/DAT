Public Partial Class SplashScreen
	Dim _sql As SqlControl = New SqlControl
	Dim _timer1 As Timer = New Timer With {.Interval = 1000}
	Dim _timer2 As Timer
	
	Public Sub New()
		Me.InitializeComponent()
		MaximizeBox = False
		MinimizeBox = False
		AddHandler _timer1.Tick, AddressOf timer1Tick
		_timer1.Start()
	End Sub
	
	Sub SplashScreenLoad(sender As Object, e As EventArgs)
		Dim resourceManager As New System.Resources.ResourceManager("Device_Assignment_Tool.Icons",  System.Reflection.Assembly.GetExecutingAssembly)
		pictureBox1.Image = resourceManager.GetObject("NelsonLogo")
	End Sub
	
	Private Sub timer2Tick(sender As Object, e As EventArgs)
		_timer2.Stop()
		My.Forms.MainForm.Show()
		Me.Close()
	End Sub
	
	Private Sub timer1Tick(sender As Object, e As EventArgs)
		_timer1.Stop()
		If _sql.checkConnection() = True Then
			label1.Text = "Server is live."
			_timer2 = New Timer With{.Interval = 1000}
			AddHandler _timer2.Tick, AddressOf timer2Tick
			_timer2.Start()			
		Else
			_sql.hasException(True)
			'MessageBox.Show("Unable to connect to Database. Your account may not have the correct permissions, or the server is unreachable. If the problem persists, please contact your ICT Administrator and provide the following error code." & vbNewLine & "Error Code: 01", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Application.Exit()
			End
		End If
	End Sub
End Class
