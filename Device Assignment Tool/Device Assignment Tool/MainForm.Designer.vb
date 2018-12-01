'
' Created by SharpDevelop.
' User: GMAN
' Date: 17/11/2018
' Time: 9:03 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class MainForm
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
		Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim dataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.panelNelson = New System.Windows.Forms.Panel()
		Me.buttonHistory = New System.Windows.Forms.Button()
		Me.labelTitle = New System.Windows.Forms.Label()
		Me.pictureNelson = New System.Windows.Forms.PictureBox()
		Me.crtPicture = New System.Windows.Forms.PictureBox()
		Me.crtPanel = New System.Windows.Forms.Panel()
		Me.crtLable = New System.Windows.Forms.Label()
		Me.camPanel = New System.Windows.Forms.Panel()
		Me.camLable = New System.Windows.Forms.Label()
		Me.camPicture = New System.Windows.Forms.PictureBox()
		Me.crtCombo = New System.Windows.Forms.ComboBox()
		Me.crtText1 = New System.Windows.Forms.TextBox()
		Me.crtText2 = New System.Windows.Forms.TextBox()
		Me.crtButton = New System.Windows.Forms.Button()
		Me.crtTextPassword = New System.Windows.Forms.TextBox()
		Me.crtButtonPrint = New System.Windows.Forms.Button()
		Me.crtDGV = New System.Windows.Forms.DataGridView()
		Me.crtLabelCRT = New System.Windows.Forms.Label()
		Me.crtLabelReplacing = New System.Windows.Forms.Label()
		Me.crtLablePassword = New System.Windows.Forms.Label()
		Me.crtLabelLaptop = New System.Windows.Forms.Label()
		Me.camLabelCamera = New System.Windows.Forms.Label()
		Me.camLableBorrower = New System.Windows.Forms.Label()
		Me.camDGV = New System.Windows.Forms.DataGridView()
		Me.camButton = New System.Windows.Forms.Button()
		Me.camText1 = New System.Windows.Forms.TextBox()
		Me.camCombo = New System.Windows.Forms.ComboBox()
		Me.camDTP = New System.Windows.Forms.DateTimePicker()
		Me.camLabelDue = New System.Windows.Forms.Label()
		Me.panelNelson.SuspendLayout
		CType(Me.pictureNelson,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.crtPicture,System.ComponentModel.ISupportInitialize).BeginInit
		Me.crtPanel.SuspendLayout
		Me.camPanel.SuspendLayout
		CType(Me.camPicture,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.crtDGV,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.camDGV,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'panelNelson
		'
		Me.panelNelson.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.panelNelson.BackColor = System.Drawing.Color.LightBlue
		Me.panelNelson.Controls.Add(Me.buttonHistory)
		Me.panelNelson.Controls.Add(Me.labelTitle)
		Me.panelNelson.Controls.Add(Me.pictureNelson)
		Me.panelNelson.Location = New System.Drawing.Point(0, 0)
		Me.panelNelson.Margin = New System.Windows.Forms.Padding(0)
		Me.panelNelson.Name = "panelNelson"
		Me.panelNelson.Size = New System.Drawing.Size(631, 60)
		Me.panelNelson.TabIndex = 1000
		'
		'buttonHistory
		'
		Me.buttonHistory.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.buttonHistory.Location = New System.Drawing.Point(496, 15)
		Me.buttonHistory.Name = "buttonHistory"
		Me.buttonHistory.Size = New System.Drawing.Size(125, 29)
		Me.buttonHistory.TabIndex = 1002
		Me.buttonHistory.Text = "Assignment History"
		Me.buttonHistory.UseVisualStyleBackColor = true
		AddHandler Me.buttonHistory.Click, AddressOf Me.ButtonHistoryClick
		'
		'labelTitle
		'
		Me.labelTitle.BackColor = System.Drawing.Color.Transparent
		Me.labelTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.labelTitle.Location = New System.Drawing.Point(117, 15)
		Me.labelTitle.Name = "labelTitle"
		Me.labelTitle.Size = New System.Drawing.Size(250, 30)
		Me.labelTitle.TabIndex = 1001
		Me.labelTitle.Text = "Device Assignment Tool"
		Me.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'pictureNelson
		'
		Me.pictureNelson.BackColor = System.Drawing.Color.Transparent
		Me.pictureNelson.Location = New System.Drawing.Point(15, 0)
		Me.pictureNelson.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
		Me.pictureNelson.Name = "pictureNelson"
		Me.pictureNelson.Size = New System.Drawing.Size(99, 60)
		Me.pictureNelson.TabIndex = 1
		Me.pictureNelson.TabStop = false
		'
		'crtPicture
		'
		Me.crtPicture.BackColor = System.Drawing.Color.Transparent
		Me.crtPicture.Location = New System.Drawing.Point(15, 0)
		Me.crtPicture.Name = "crtPicture"
		Me.crtPicture.Size = New System.Drawing.Size(38, 38)
		Me.crtPicture.TabIndex = 1
		Me.crtPicture.TabStop = false
		'
		'crtPanel
		'
		Me.crtPanel.Controls.Add(Me.crtLable)
		Me.crtPanel.Controls.Add(Me.crtPicture)
		Me.crtPanel.Location = New System.Drawing.Point(0, 71)
		Me.crtPanel.Name = "crtPanel"
		Me.crtPanel.Size = New System.Drawing.Size(244, 38)
		Me.crtPanel.TabIndex = 1002
		'
		'crtLable
		'
		Me.crtLable.BackColor = System.Drawing.Color.Transparent
		Me.crtLable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtLable.Location = New System.Drawing.Point(57, 8)
		Me.crtLable.Name = "crtLable"
		Me.crtLable.Size = New System.Drawing.Size(144, 23)
		Me.crtLable.TabIndex = 1003
		Me.crtLable.Text = "CRT Assignments"
		Me.crtLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'camPanel
		'
		Me.camPanel.Controls.Add(Me.camLable)
		Me.camPanel.Controls.Add(Me.camPicture)
		Me.camPanel.Location = New System.Drawing.Point(0, 345)
		Me.camPanel.Name = "camPanel"
		Me.camPanel.Size = New System.Drawing.Size(244, 38)
		Me.camPanel.TabIndex = 1004
		'
		'camLable
		'
		Me.camLable.BackColor = System.Drawing.Color.Transparent
		Me.camLable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camLable.Location = New System.Drawing.Point(57, 8)
		Me.camLable.Name = "camLable"
		Me.camLable.Size = New System.Drawing.Size(170, 23)
		Me.camLable.TabIndex = 1005
		Me.camLable.Text = "Camera Assignments"
		Me.camLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'camPicture
		'
		Me.camPicture.BackColor = System.Drawing.Color.Transparent
		Me.camPicture.Location = New System.Drawing.Point(15, 0)
		Me.camPicture.Name = "camPicture"
		Me.camPicture.Size = New System.Drawing.Size(38, 38)
		Me.camPicture.TabIndex = 1
		Me.camPicture.TabStop = false
		'
		'crtCombo
		'
		Me.crtCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.crtCombo.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtCombo.FormattingEnabled = true
		Me.crtCombo.Location = New System.Drawing.Point(7, 135)
		Me.crtCombo.Name = "crtCombo"
		Me.crtCombo.Size = New System.Drawing.Size(120, 27)
		Me.crtCombo.TabIndex = 1
		AddHandler Me.crtCombo.SelectionChangeCommitted, AddressOf Me.crtSelectionChanged
		'
		'crtText1
		'
		Me.crtText1.BackColor = System.Drawing.SystemColors.Window
		Me.crtText1.Enabled = false
		Me.crtText1.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtText1.Location = New System.Drawing.Point(134, 135)
		Me.crtText1.Name = "crtText1"
		Me.crtText1.Size = New System.Drawing.Size(200, 27)
		Me.crtText1.TabIndex = 2
		Me.crtText1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.crtText1.TextChanged, AddressOf Me.crtTextChanged
		AddHandler Me.crtText1.KeyDown, AddressOf Me.crtFieldKeyPressed
		'
		'crtText2
		'
		Me.crtText2.Enabled = false
		Me.crtText2.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtText2.Location = New System.Drawing.Point(340, 135)
		Me.crtText2.Name = "crtText2"
		Me.crtText2.Size = New System.Drawing.Size(200, 27)
		Me.crtText2.TabIndex = 3
		Me.crtText2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.crtText2.TextChanged, AddressOf Me.crtTextChanged
		AddHandler Me.crtText2.KeyDown, AddressOf Me.crtFieldKeyPressed
		'
		'crtButton
		'
		Me.crtButton.Enabled = false
		Me.crtButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtButton.Location = New System.Drawing.Point(546, 134)
		Me.crtButton.Name = "crtButton"
		Me.crtButton.Size = New System.Drawing.Size(75, 29)
		Me.crtButton.TabIndex = 4
		Me.crtButton.Text = "Allocate"
		Me.crtButton.UseVisualStyleBackColor = true
		AddHandler Me.crtButton.Click, AddressOf Me.crtButtonClick
		AddHandler Me.crtButton.KeyDown, AddressOf Me.crtFieldKeyPressed
		'
		'crtTextPassword
		'
		Me.crtTextPassword.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtTextPassword.Location = New System.Drawing.Point(440, 84)
		Me.crtTextPassword.Name = "crtTextPassword"
		Me.crtTextPassword.ReadOnly = true
		Me.crtTextPassword.Size = New System.Drawing.Size(100, 27)
		Me.crtTextPassword.TabIndex = 5
		Me.crtTextPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'crtButtonPrint
		'
		Me.crtButtonPrint.Enabled = false
		Me.crtButtonPrint.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtButtonPrint.Location = New System.Drawing.Point(546, 83)
		Me.crtButtonPrint.Name = "crtButtonPrint"
		Me.crtButtonPrint.Size = New System.Drawing.Size(75, 29)
		Me.crtButtonPrint.TabIndex = 6
		Me.crtButtonPrint.Text = "Print"
		Me.crtButtonPrint.UseVisualStyleBackColor = true
		'
		'crtDGV
		'
		Me.crtDGV.AllowUserToAddRows = false
		Me.crtDGV.AllowUserToDeleteRows = false
		Me.crtDGV.AllowUserToResizeColumns = false
		Me.crtDGV.AllowUserToResizeRows = false
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.crtDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
		Me.crtDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
		dataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.crtDGV.DefaultCellStyle = dataGridViewCellStyle2
		Me.crtDGV.Location = New System.Drawing.Point(7, 175)
		Me.crtDGV.MultiSelect = false
		Me.crtDGV.Name = "crtDGV"
		Me.crtDGV.ReadOnly = true
		Me.crtDGV.RowHeadersVisible = false
		Me.crtDGV.Size = New System.Drawing.Size(614, 155)
		Me.crtDGV.TabIndex = 1006
		Me.crtDGV.TabStop = false
		AddHandler Me.crtDGV.RowPrePaint, AddressOf Me.DGV_RowPrePaint
		'
		'crtLabelCRT
		'
		Me.crtLabelCRT.BackColor = System.Drawing.SystemColors.Info
		Me.crtLabelCRT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.crtLabelCRT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtLabelCRT.Location = New System.Drawing.Point(134, 119)
		Me.crtLabelCRT.Name = "crtLabelCRT"
		Me.crtLabelCRT.Size = New System.Drawing.Size(200, 17)
		Me.crtLabelCRT.TabIndex = 1008
		Me.crtLabelCRT.Text = "CRT"
		Me.crtLabelCRT.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'crtLabelReplacing
		'
		Me.crtLabelReplacing.BackColor = System.Drawing.SystemColors.Info
		Me.crtLabelReplacing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.crtLabelReplacing.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtLabelReplacing.Location = New System.Drawing.Point(340, 119)
		Me.crtLabelReplacing.Name = "crtLabelReplacing"
		Me.crtLabelReplacing.Size = New System.Drawing.Size(200, 17)
		Me.crtLabelReplacing.TabIndex = 1009
		Me.crtLabelReplacing.Text = "Replacing"
		Me.crtLabelReplacing.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'crtLablePassword
		'
		Me.crtLablePassword.BackColor = System.Drawing.SystemColors.Info
		Me.crtLablePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.crtLablePassword.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtLablePassword.Location = New System.Drawing.Point(440, 68)
		Me.crtLablePassword.Name = "crtLablePassword"
		Me.crtLablePassword.Size = New System.Drawing.Size(100, 17)
		Me.crtLablePassword.TabIndex = 1010
		Me.crtLablePassword.Text = "Password"
		Me.crtLablePassword.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'crtLabelLaptop
		'
		Me.crtLabelLaptop.BackColor = System.Drawing.SystemColors.Info
		Me.crtLabelLaptop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.crtLabelLaptop.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.crtLabelLaptop.Location = New System.Drawing.Point(7, 119)
		Me.crtLabelLaptop.Name = "crtLabelLaptop"
		Me.crtLabelLaptop.Size = New System.Drawing.Size(120, 17)
		Me.crtLabelLaptop.TabIndex = 1007
		Me.crtLabelLaptop.Text = "Laptop"
		Me.crtLabelLaptop.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'camLabelCamera
		'
		Me.camLabelCamera.BackColor = System.Drawing.SystemColors.Info
		Me.camLabelCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.camLabelCamera.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camLabelCamera.Location = New System.Drawing.Point(7, 396)
		Me.camLabelCamera.Name = "camLabelCamera"
		Me.camLabelCamera.Size = New System.Drawing.Size(120, 17)
		Me.camLabelCamera.TabIndex = 1015
		Me.camLabelCamera.Text = "Camera"
		Me.camLabelCamera.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'camLableBorrower
		'
		Me.camLableBorrower.BackColor = System.Drawing.SystemColors.Info
		Me.camLableBorrower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.camLableBorrower.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camLableBorrower.Location = New System.Drawing.Point(134, 396)
		Me.camLableBorrower.Name = "camLableBorrower"
		Me.camLableBorrower.Size = New System.Drawing.Size(200, 17)
		Me.camLableBorrower.TabIndex = 1016
		Me.camLableBorrower.Text = "Borrower"
		Me.camLableBorrower.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'camDGV
		'
		Me.camDGV.AllowUserToAddRows = false
		Me.camDGV.AllowUserToDeleteRows = false
		Me.camDGV.AllowUserToResizeColumns = false
		Me.camDGV.AllowUserToResizeRows = false
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
		dataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.camDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3
		Me.camDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
		dataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.camDGV.DefaultCellStyle = dataGridViewCellStyle4
		Me.camDGV.Location = New System.Drawing.Point(7, 452)
		Me.camDGV.MultiSelect = false
		Me.camDGV.Name = "camDGV"
		Me.camDGV.ReadOnly = true
		Me.camDGV.RowHeadersVisible = false
		Me.camDGV.Size = New System.Drawing.Size(614, 155)
		Me.camDGV.TabIndex = 1014
		Me.camDGV.TabStop = false
		AddHandler Me.camDGV.RowPrePaint, AddressOf Me.DGV_RowPrePaint
		'
		'camButton
		'
		Me.camButton.Enabled = false
		Me.camButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camButton.Location = New System.Drawing.Point(546, 410)
		Me.camButton.Name = "camButton"
		Me.camButton.Size = New System.Drawing.Size(75, 29)
		Me.camButton.TabIndex = 10
		Me.camButton.Text = "Allocate"
		Me.camButton.UseVisualStyleBackColor = true
		AddHandler Me.camButton.Click, AddressOf Me.camButtonClick
		'
		'camText1
		'
		Me.camText1.BackColor = System.Drawing.SystemColors.Window
		Me.camText1.Enabled = false
		Me.camText1.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camText1.Location = New System.Drawing.Point(134, 412)
		Me.camText1.Name = "camText1"
		Me.camText1.Size = New System.Drawing.Size(200, 27)
		Me.camText1.TabIndex = 8
		Me.camText1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		AddHandler Me.camText1.TextChanged, AddressOf Me.camTextChanged
		AddHandler Me.camText1.KeyDown, AddressOf Me.camFieldKeyPressed
		'
		'camCombo
		'
		Me.camCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.camCombo.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camCombo.FormattingEnabled = true
		Me.camCombo.Location = New System.Drawing.Point(7, 412)
		Me.camCombo.Name = "camCombo"
		Me.camCombo.Size = New System.Drawing.Size(120, 27)
		Me.camCombo.TabIndex = 7
		AddHandler Me.camCombo.SelectionChangeCommitted, AddressOf Me.camSelectionChanged
		'
		'camDTP
		'
		Me.camDTP.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camDTP.Enabled = false
		Me.camDTP.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camDTP.Location = New System.Drawing.Point(340, 412)
		Me.camDTP.Name = "camDTP"
		Me.camDTP.Size = New System.Drawing.Size(200, 23)
		Me.camDTP.TabIndex = 9
		AddHandler Me.camDTP.ValueChanged, AddressOf Me.camDTPChanged
		'
		'camLabelDue
		'
		Me.camLabelDue.BackColor = System.Drawing.SystemColors.Info
		Me.camLabelDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.camLabelDue.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.camLabelDue.Location = New System.Drawing.Point(340, 396)
		Me.camLabelDue.Name = "camLabelDue"
		Me.camLabelDue.Size = New System.Drawing.Size(200, 17)
		Me.camLabelDue.TabIndex = 1018
		Me.camLabelDue.Text = "Due"
		Me.camLabelDue.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(630, 616)
		Me.Controls.Add(Me.camLabelDue)
		Me.Controls.Add(Me.camDTP)
		Me.Controls.Add(Me.camLabelCamera)
		Me.Controls.Add(Me.camLableBorrower)
		Me.Controls.Add(Me.camDGV)
		Me.Controls.Add(Me.camButton)
		Me.Controls.Add(Me.camText1)
		Me.Controls.Add(Me.camCombo)
		Me.Controls.Add(Me.crtLabelLaptop)
		Me.Controls.Add(Me.crtLablePassword)
		Me.Controls.Add(Me.crtLabelReplacing)
		Me.Controls.Add(Me.crtLabelCRT)
		Me.Controls.Add(Me.crtDGV)
		Me.Controls.Add(Me.crtButtonPrint)
		Me.Controls.Add(Me.crtTextPassword)
		Me.Controls.Add(Me.crtButton)
		Me.Controls.Add(Me.crtText2)
		Me.Controls.Add(Me.crtText1)
		Me.Controls.Add(Me.crtCombo)
		Me.Controls.Add(Me.camPanel)
		Me.Controls.Add(Me.crtPanel)
		Me.Controls.Add(Me.panelNelson)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.Name = "MainForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Device Assignment Tool"
		AddHandler Load, AddressOf Me.MainFormLoad
		Me.panelNelson.ResumeLayout(false)
		CType(Me.pictureNelson,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.crtPicture,System.ComponentModel.ISupportInitialize).EndInit
		Me.crtPanel.ResumeLayout(false)
		Me.camPanel.ResumeLayout(false)
		CType(Me.camPicture,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.crtDGV,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.camDGV,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private buttonHistory As System.Windows.Forms.Button
	Private camLabelDue As System.Windows.Forms.Label
	Private camDTP As System.Windows.Forms.DateTimePicker
	Private camCombo As System.Windows.Forms.ComboBox
	Private camText1 As System.Windows.Forms.TextBox
	Private camButton As System.Windows.Forms.Button
	Private camDGV As System.Windows.Forms.DataGridView
	Private camLableBorrower As System.Windows.Forms.Label
	Private camLabelCamera As System.Windows.Forms.Label
	Private crtLabelLaptop As System.Windows.Forms.Label
	Private crtLablePassword As System.Windows.Forms.Label
	Private crtLabelReplacing As System.Windows.Forms.Label
	Private crtLabelCRT As System.Windows.Forms.Label
	Private crtDGV As System.Windows.Forms.DataGridView
	Private crtButtonPrint As System.Windows.Forms.Button
	Private crtTextPassword As System.Windows.Forms.TextBox
	Private crtButton As System.Windows.Forms.Button
	Private crtText2 As System.Windows.Forms.TextBox
	Private crtText1 As System.Windows.Forms.TextBox
	Private crtCombo As System.Windows.Forms.ComboBox
	Private camPicture As System.Windows.Forms.PictureBox
	Private camLable As System.Windows.Forms.Label
	Private camPanel As System.Windows.Forms.Panel
	Private crtLable As System.Windows.Forms.Label
	Private crtPanel As System.Windows.Forms.Panel
	Private crtPicture As System.Windows.Forms.PictureBox
	Private labelTitle As System.Windows.Forms.Label
	Private pictureNelson As System.Windows.Forms.PictureBox
	Private panelNelson As System.Windows.Forms.Panel
End Class
