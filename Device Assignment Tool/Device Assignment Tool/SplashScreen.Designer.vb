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
		Me.pictureBox1 = New System.Windows.Forms.PictureBox()
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'label1
		'
		Me.label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.label1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.label1.Location = New System.Drawing.Point(-3, 67)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(191, 28)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Waiting for response from Server..."
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'pictureBox1
		'
		Me.pictureBox1.Location = New System.Drawing.Point(40, 5)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(99, 60)
		Me.pictureBox1.TabIndex = 1
		Me.pictureBox1.TabStop = false
		'
		'SplashScreen
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(185, 95)
		Me.Controls.Add(Me.pictureBox1)
		Me.Controls.Add(Me.label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "SplashScreen"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		AddHandler Load, AddressOf Me.SplashScreenLoad
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private pictureBox1 As System.Windows.Forms.PictureBox
	Private label1 As System.Windows.Forms.Label
End Class
