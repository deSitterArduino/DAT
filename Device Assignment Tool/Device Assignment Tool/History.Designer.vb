'
' Created by SharpDevelop.
' User: GMAN
' Date: 1/12/2018
' Time: 8:17 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class History
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
		Me.textSearch = New System.Windows.Forms.TextBox()
		Me.dgv = New System.Windows.Forms.DataGridView()
		Me.comboTable = New System.Windows.Forms.ComboBox()
		Me.comboColumn = New System.Windows.Forms.ComboBox()
		Me.buttonSearch = New System.Windows.Forms.Button()
		CType(Me.dgv,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'textSearch
		'
		Me.textSearch.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.textSearch.Location = New System.Drawing.Point(13, 13)
		Me.textSearch.Name = "textSearch"
		Me.textSearch.Size = New System.Drawing.Size(150, 23)
		Me.textSearch.TabIndex = 0
		AddHandler Me.textSearch.Click, AddressOf Me.textSearchClick
		AddHandler Me.textSearch.TextChanged, AddressOf Me.searchTextChanged
		AddHandler Me.textSearch.KeyDown, AddressOf Me.textSearchKeyPressed
		'
		'dgv
		'
		Me.dgv.AllowUserToAddRows = false
		Me.dgv.AllowUserToDeleteRows = false
		Me.dgv.AllowUserToResizeColumns = false
		Me.dgv.AllowUserToResizeRows = false
		Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
		dataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
		Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
		dataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgv.DefaultCellStyle = dataGridViewCellStyle2
		Me.dgv.Location = New System.Drawing.Point(13, 44)
		Me.dgv.Name = "dgv"
		Me.dgv.ReadOnly = true
		Me.dgv.RowHeadersVisible = false
		Me.dgv.Size = New System.Drawing.Size(839, 580)
		Me.dgv.TabIndex = 4
		'
		'comboTable
		'
		Me.comboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboTable.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.comboTable.FormattingEnabled = true
		Me.comboTable.Location = New System.Drawing.Point(169, 13)
		Me.comboTable.Name = "comboTable"
		Me.comboTable.Size = New System.Drawing.Size(54, 23)
		Me.comboTable.TabIndex = 1
		AddHandler Me.comboTable.SelectionChangeCommitted, AddressOf Me.comboTableSelectionChanged
		'
		'comboColumn
		'
		Me.comboColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboColumn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.comboColumn.FormattingEnabled = true
		Me.comboColumn.Location = New System.Drawing.Point(230, 13)
		Me.comboColumn.Name = "comboColumn"
		Me.comboColumn.Size = New System.Drawing.Size(121, 23)
		Me.comboColumn.TabIndex = 2
		'
		'buttonSearch
		'
		Me.buttonSearch.Enabled = false
		Me.buttonSearch.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.buttonSearch.Location = New System.Drawing.Point(358, 13)
		Me.buttonSearch.Name = "buttonSearch"
		Me.buttonSearch.Size = New System.Drawing.Size(75, 23)
		Me.buttonSearch.TabIndex = 3
		Me.buttonSearch.Text = "Search"
		Me.buttonSearch.UseVisualStyleBackColor = true
		AddHandler Me.buttonSearch.Click, AddressOf Me.ButtonSearchClick
		'
		'History
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(864, 636)
		Me.Controls.Add(Me.buttonSearch)
		Me.Controls.Add(Me.comboColumn)
		Me.Controls.Add(Me.comboTable)
		Me.Controls.Add(Me.dgv)
		Me.Controls.Add(Me.textSearch)
		Me.Name = "History"
		Me.Text = "Assignment History"
		CType(Me.dgv,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private comboColumn As System.Windows.Forms.ComboBox
	Private comboTable As System.Windows.Forms.ComboBox
	Private dgv As System.Windows.Forms.DataGridView
	Private buttonSearch As System.Windows.Forms.Button
	Private textSearch As System.Windows.Forms.TextBox
End Class
