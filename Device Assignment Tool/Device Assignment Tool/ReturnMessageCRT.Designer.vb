'
' Created by SharpDevelop.
' User: GMAN
' Date: 18/11/2018
' Time: 5:17 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class ReturnMessageCRT
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
		Me.lable = New System.Windows.Forms.Label()
		Me.picture = New System.Windows.Forms.PictureBox()
		Me.buttonConfirm = New System.Windows.Forms.Button()
		Me.buttonCancel = New System.Windows.Forms.Button()
		CType(Me.picture,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'lable
		'
		Me.lable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.lable.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lable.Location = New System.Drawing.Point(58, 15)
		Me.lable.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
		Me.lable.Name = "lable"
		Me.lable.Size = New System.Drawing.Size(192, 40)
		Me.lable.TabIndex = 0
		Me.lable.Text = "Are you sure you want to return  XXX  ?"
		Me.lable.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'picture
		'
		Me.picture.Location = New System.Drawing.Point(12, 12)
		Me.picture.Name = "picture"
		Me.picture.Size = New System.Drawing.Size(38, 38)
		Me.picture.TabIndex = 1
		Me.picture.TabStop = false
		'
		'buttonConfirm
		'
		Me.buttonConfirm.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.buttonConfirm.Location = New System.Drawing.Point(54, 61)
		Me.buttonConfirm.Margin = New System.Windows.Forms.Padding(30, 0, 0, 15)
		Me.buttonConfirm.Name = "buttonConfirm"
		Me.buttonConfirm.Size = New System.Drawing.Size(75, 23)
		Me.buttonConfirm.TabIndex = 2
		Me.buttonConfirm.Text = "Confirm"
		Me.buttonConfirm.UseVisualStyleBackColor = true
		'
		'buttonCancel
		'
		Me.buttonCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.buttonCancel.Location = New System.Drawing.Point(145, 63)
		Me.buttonCancel.Margin = New System.Windows.Forms.Padding(0, 0, 30, 3)
		Me.buttonCancel.Name = "buttonCancel"
		Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
		Me.buttonCancel.TabIndex = 1
		Me.buttonCancel.Text = "Cancel"
		Me.buttonCancel.UseVisualStyleBackColor = true
		'
		'ReturnMessageCRT
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(274, 96)
		Me.Controls.Add(Me.buttonCancel)
		Me.Controls.Add(Me.buttonConfirm)
		Me.Controls.Add(Me.picture)
		Me.Controls.Add(Me.lable)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "ReturnMessageCRT"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Confirmation"
		CType(Me.picture,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private buttonCancel As System.Windows.Forms.Button
	Private buttonConfirm As System.Windows.Forms.Button
	Private picture As System.Windows.Forms.PictureBox
	Private lable As System.Windows.Forms.Label
End Class
