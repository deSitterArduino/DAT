'
' Created by SharpDevelop.
' User: GMAN
' Date: 28/11/2018
' Time: 9:35 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class ReturnMessageCAM
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
		Me.picture = New System.Windows.Forms.PictureBox()
		Me.buttonCancel = New System.Windows.Forms.Button()
		Me.buttonConfirm = New System.Windows.Forms.Button()
		Me.lable = New System.Windows.Forms.Label()
		Me.battery = New System.Windows.Forms.CheckBox()
		Me.sdCard = New System.Windows.Forms.CheckBox()
		CType(Me.picture,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'picture
		'
		Me.picture.Location = New System.Drawing.Point(12, 12)
		Me.picture.Name = "picture"
		Me.picture.Size = New System.Drawing.Size(38, 38)
		Me.picture.TabIndex = 0
		Me.picture.TabStop = false
		'
		'buttonCancel
		'
		Me.buttonCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.buttonCancel.Location = New System.Drawing.Point(145, 110)
		Me.buttonCancel.Margin = New System.Windows.Forms.Padding(0, 0, 30, 3)
		Me.buttonCancel.Name = "buttonCancel"
		Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
		Me.buttonCancel.TabIndex = 1
		Me.buttonCancel.Text = "Cancel"
		Me.buttonCancel.UseVisualStyleBackColor = true
		'
		'buttonConfirm
		'
		Me.buttonConfirm.Enabled = false
		Me.buttonConfirm.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.buttonConfirm.Location = New System.Drawing.Point(54, 110)
		Me.buttonConfirm.Margin = New System.Windows.Forms.Padding(30, 0, 0, 15)
		Me.buttonConfirm.Name = "buttonConfirm"
		Me.buttonConfirm.Size = New System.Drawing.Size(75, 23)
		Me.buttonConfirm.TabIndex = 4
		Me.buttonConfirm.Text = "Confirm"
		Me.buttonConfirm.UseVisualStyleBackColor = true
		'
		'lable
		'
		Me.lable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.lable.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lable.Location = New System.Drawing.Point(58, 15)
		Me.lable.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
		Me.lable.Name = "lable"
		Me.lable.Size = New System.Drawing.Size(192, 62)
		Me.lable.TabIndex = 3
		Me.lable.Text = "..."
		Me.lable.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'battery
		'
		Me.battery.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.battery.Location = New System.Drawing.Point(60, 80)
		Me.battery.Name = "battery"
		Me.battery.Size = New System.Drawing.Size(104, 24)
		Me.battery.TabIndex = 2
		Me.battery.Text = "Battery"
		Me.battery.UseVisualStyleBackColor = true
		AddHandler Me.battery.CheckedChanged, AddressOf Me.checkChanged
		'
		'sdCard
		'
		Me.sdCard.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.sdCard.Location = New System.Drawing.Point(152, 80)
		Me.sdCard.Name = "sdCard"
		Me.sdCard.Size = New System.Drawing.Size(104, 24)
		Me.sdCard.TabIndex = 3
		Me.sdCard.Text = "SD Card"
		Me.sdCard.UseVisualStyleBackColor = true
		AddHandler Me.sdCard.CheckedChanged, AddressOf Me.checkChanged
		'
		'ReturnMessageCAM
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(274, 146)
		Me.Controls.Add(Me.sdCard)
		Me.Controls.Add(Me.battery)
		Me.Controls.Add(Me.buttonCancel)
		Me.Controls.Add(Me.buttonConfirm)
		Me.Controls.Add(Me.lable)
		Me.Controls.Add(Me.picture)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "ReturnMessageCAM"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Confirmation"
		CType(Me.picture,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private sdCard As System.Windows.Forms.CheckBox
	Private battery As System.Windows.Forms.CheckBox
	Private lable As System.Windows.Forms.Label
	Private buttonConfirm As System.Windows.Forms.Button
	Private buttonCancel As System.Windows.Forms.Button
	Private picture As System.Windows.Forms.PictureBox
End Class
