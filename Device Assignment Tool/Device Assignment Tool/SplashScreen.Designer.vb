'
' Created by SharpDevelop.
' User: GMAN
' Date: 26/11/2018
' Time: 9:19 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class SplashScreen
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(8, 30)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(197, 16)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Waiting for response from SQL Server."
		Me.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'SplashScreen
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(214, 81)
		Me.Controls.Add(Me.label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "SplashScreen"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		AddHandler Load, AddressOf Me.SplashScreenLoad
		Me.ResumeLayout(false)
	End Sub
	Private label1 As System.Windows.Forms.Label
End Class
