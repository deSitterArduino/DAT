'
' Created by SharpDevelop.
' User: GMAN
' Date: 17/11/2018
' Time: 9:03 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
	' This file controls the behaviour of the application.
	Partial Class MyApplication
		Public Sub New()
			MyBase.New(AuthenticationMode.Windows)
			Me.IsSingleInstance = False
			Me.EnableVisualStyles = True
			Me.SaveMySettingsOnExit = True
			Me.ShutDownStyle = ShutdownMode.AfterAllFormsClose
		End Sub
		
		Protected Overrides Sub OnCreateMainForm()
			Me.MainForm = My.Forms.SplashScreen
		End Sub
	End Class
End Namespace
