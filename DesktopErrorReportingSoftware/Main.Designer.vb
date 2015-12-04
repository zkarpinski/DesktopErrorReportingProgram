<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.lbCategories = New System.Windows.Forms.ListBox()
        Me.myDerpDataSet = New System.Data.DataSet()
        Me.dtblCategories = New System.Data.DataTable()
        Me.dtblFunctions = New System.Data.DataTable()
        Me.dtblDetails = New System.Data.DataTable()
        Me.dtblDetailRelations = New System.Data.DataTable()
        Me.dtblCompanies = New System.Data.DataTable()
        Me.lbTasks = New System.Windows.Forms.ListBox()
        Me.btnFillForm = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtAccountNumber = New System.Windows.Forms.MaskedTextBox()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAgentID = New System.Windows.Forms.TextBox()
        Me.txtAgent = New System.Windows.Forms.TextBox()
        Me.lblAgentID = New System.Windows.Forms.Label()
        Me.lblAgent = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.USER_CHECKED = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dtpErrorDate = New System.Windows.Forms.DateTimePicker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblOutputMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtCustomerNumber = New System.Windows.Forms.MaskedTextBox()
        Me.dtblVendors = New System.Data.DataTable()
        CType(Me.myDerpDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtblCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtblFunctions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtblDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtblDetailRelations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtblCompanies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dtblVendors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbCategories
        '
        Me.lbCategories.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCategories.FormattingEnabled = True
        Me.lbCategories.Location = New System.Drawing.Point(11, 44)
        Me.lbCategories.Name = "lbCategories"
        Me.lbCategories.Size = New System.Drawing.Size(134, 56)
        Me.lbCategories.Sorted = True
        Me.lbCategories.TabIndex = 1
        '
        'myDerpDataSet
        '
        Me.myDerpDataSet.DataSetName = "myDerpDataSet"
        Me.myDerpDataSet.Tables.AddRange(New System.Data.DataTable() {Me.dtblCategories, Me.dtblFunctions, Me.dtblDetails, Me.dtblDetailRelations, Me.dtblCompanies, Me.dtblVendors})
        '
        'dtblCategories
        '
        Me.dtblCategories.TableName = "dtblCategories"
        '
        'dtblFunctions
        '
        Me.dtblFunctions.TableName = "dtblFunctions"
        '
        'dtblDetails
        '
        Me.dtblDetails.TableName = "dtblDetails"
        '
        'dtblDetailRelations
        '
        Me.dtblDetailRelations.TableName = "dtblDetailRelations"
        '
        'dtblCompanies
        '
        Me.dtblCompanies.TableName = "dtblCompanies"
        '
        'lbTasks
        '
        Me.lbTasks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTasks.FormattingEnabled = True
        Me.lbTasks.Location = New System.Drawing.Point(151, 44)
        Me.lbTasks.Name = "lbTasks"
        Me.lbTasks.Size = New System.Drawing.Size(196, 56)
        Me.lbTasks.TabIndex = 2
        '
        'btnFillForm
        '
        Me.btnFillForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFillForm.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnFillForm.Location = New System.Drawing.Point(57, 281)
        Me.btnFillForm.Name = "btnFillForm"
        Me.btnFillForm.Size = New System.Drawing.Size(46, 23)
        Me.btnFillForm.TabIndex = 4
        Me.btnFillForm.TabStop = False
        Me.btnFillForm.Text = "Fill"
        Me.btnFillForm.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Location = New System.Drawing.Point(144, 405)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(71, 31)
        Me.btnSend.TabIndex = 19
        Me.btnSend.Text = "Submit"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(296, 410)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(43, 23)
        Me.btnClear.TabIndex = 99
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountNumber.HidePromptOnLeave = True
        Me.txtAccountNumber.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.txtAccountNumber.Location = New System.Drawing.Point(70, 215)
        Me.txtAccountNumber.Mask = "00000-99999"
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(74, 21)
        Me.txtAccountNumber.TabIndex = 5
        Me.txtAccountNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(6, 218)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(60, 13)
        Me.lblAccount.TabIndex = 4
        Me.lblAccount.Text = "&Account #:"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(13, 29)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(74, 13)
        Me.lblCategory.TabIndex = 12
        Me.lblCategory.Text = "CATEGORY"
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.Location = New System.Drawing.Point(192, 29)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(89, 13)
        Me.lblTask.TabIndex = 13
        Me.lblTask.Text = "TASK/ERROR"
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(6, 240)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(64, 13)
        Me.lblCustomer.TabIndex = 6
        Me.lblCustomer.Text = "&Customer #:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(6, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(359, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(185, 218)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(58, 13)
        Me.lblDate.TabIndex = 8
        Me.lblDate.Text = "Error Date:"
        '
        'cmbCompany
        '
        Me.cmbCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.ItemHeight = 13
        Me.cmbCompany.Location = New System.Drawing.Point(70, 19)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(75, 21)
        Me.cmbCompany.Sorted = True
        Me.cmbCompany.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAgentID)
        Me.GroupBox1.Controls.Add(Me.txtAgent)
        Me.GroupBox1.Controls.Add(Me.lblAgentID)
        Me.GroupBox1.Controls.Add(Me.lblAgent)
        Me.GroupBox1.Controls.Add(Me.lblCompany)
        Me.GroupBox1.Controls.Add(Me.cmbCompany)
        Me.GroupBox1.Location = New System.Drawing.Point(175, 246)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(172, 94)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Erroronous Agent"
        '
        'txtAgentID
        '
        Me.txtAgentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgentID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgentID.Location = New System.Drawing.Point(64, 64)
        Me.txtAgentID.MaxLength = 30
        Me.txtAgentID.Name = "txtAgentID"
        Me.txtAgentID.Size = New System.Drawing.Size(100, 21)
        Me.txtAgentID.TabIndex = 16
        '
        'txtAgent
        '
        Me.txtAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgent.Location = New System.Drawing.Point(64, 42)
        Me.txtAgent.MaxLength = 50
        Me.txtAgent.Name = "txtAgent"
        Me.txtAgent.Size = New System.Drawing.Size(100, 21)
        Me.txtAgent.TabIndex = 14
        '
        'lblAgentID
        '
        Me.lblAgentID.AutoSize = True
        Me.lblAgentID.Location = New System.Drawing.Point(8, 66)
        Me.lblAgentID.Name = "lblAgentID"
        Me.lblAgentID.Size = New System.Drawing.Size(52, 13)
        Me.lblAgentID.TabIndex = 15
        Me.lblAgentID.Text = "Agent ID:"
        '
        'lblAgent
        '
        Me.lblAgent.AutoSize = True
        Me.lblAgent.Location = New System.Drawing.Point(8, 45)
        Me.lblAgent.Name = "lblAgent"
        Me.lblAgent.Size = New System.Drawing.Size(38, 13)
        Me.lblAgent.TabIndex = 13
        Me.lblAgent.Text = "Agent:"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(7, 22)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(54, 13)
        Me.lblCompany.TabIndex = 11
        Me.lblCompany.Text = "Company:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(12, 346)
        Me.txtComments.MaxLength = 255
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(335, 50)
        Me.txtComments.TabIndex = 18
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New System.Drawing.Point(13, 331)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(59, 13)
        Me.lblComments.TabIndex = 17
        Me.lblComments.Text = "Comments:"
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(13, 103)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(46, 13)
        Me.lblDetails.TabIndex = 21
        Me.lblDetails.Text = "Details"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToResizeColumns = False
        Me.dgvDetails.AllowUserToResizeRows = False
        Me.dgvDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetails.ColumnHeadersVisible = False
        Me.dgvDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.USER_CHECKED})
        Me.dgvDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDetails.EnableHeadersVisualStyles = False
        Me.dgvDetails.Location = New System.Drawing.Point(12, 119)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetails.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetails.RowTemplate.Height = 19
        Me.dgvDetails.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetails.ShowEditingIcon = False
        Me.dgvDetails.ShowRowErrors = False
        Me.dgvDetails.Size = New System.Drawing.Size(335, 90)
        Me.dgvDetails.TabIndex = 3
        '
        'USER_CHECKED
        '
        Me.USER_CHECKED.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.USER_CHECKED.HeaderText = "USER_CHECKED"
        Me.USER_CHECKED.Name = "USER_CHECKED"
        Me.USER_CHECKED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.USER_CHECKED.Width = 25
        '
        'dtpErrorDate
        '
        Me.dtpErrorDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpErrorDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpErrorDate.Location = New System.Drawing.Point(246, 215)
        Me.dtpErrorDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpErrorDate.MaxDate = New Date(2015, 11, 26, 0, 0, 0, 0)
        Me.dtpErrorDate.MinDate = New Date(1991, 10, 24, 0, 0, 0, 0)
        Me.dtpErrorDate.Name = "dtpErrorDate"
        Me.dtpErrorDate.ShowCheckBox = True
        Me.dtpErrorDate.Size = New System.Drawing.Size(99, 20)
        Me.dtpErrorDate.TabIndex = 9
        Me.dtpErrorDate.Value = New Date(2015, 11, 4, 0, 0, 0, 0)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblOutputMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 445)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 11, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(359, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 24
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblOutputMessage
        '
        Me.lblOutputMessage.AutoSize = False
        Me.lblOutputMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputMessage.Name = "lblOutputMessage"
        Me.lblOutputMessage.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.lblOutputMessage.Size = New System.Drawing.Size(358, 17)
        Me.lblOutputMessage.Text = "Your feedback was successfully submitted"
        '
        'txtCustomerNumber
        '
        Me.txtCustomerNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerNumber.HidePromptOnLeave = True
        Me.txtCustomerNumber.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.txtCustomerNumber.Location = New System.Drawing.Point(70, 237)
        Me.txtCustomerNumber.Mask = "000000000"
        Me.txtCustomerNumber.Name = "txtCustomerNumber"
        Me.txtCustomerNumber.Size = New System.Drawing.Size(74, 21)
        Me.txtCustomerNumber.TabIndex = 7
        Me.txtCustomerNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'dtblVendors
        '
        Me.dtblVendors.TableName = "dtblVendors"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 467)
        Me.Controls.Add(Me.txtCustomerNumber)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dtpErrorDate)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.btnFillForm)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.lblTask)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblAccount)
        Me.Controls.Add(Me.txtAccountNumber)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.lbTasks)
        Me.Controls.Add(Me.lbCategories)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Desktop Error Reporting Program"
        CType(Me.myDerpDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtblCategories, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtblFunctions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtblDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtblDetailRelations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtblCompanies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dtblVendors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbCategories As ListBox
    Friend WithEvents lbTasks As ListBox
    Friend WithEvents btnFillForm As Button
    Friend WithEvents btnSend As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents myDerpDataSet As DataSet
    Friend WithEvents dtblCategories As DataTable
    Friend WithEvents dtblFunctions As DataTable
    Friend WithEvents dtblDetails As DataTable
    Friend WithEvents txtAccountNumber As MaskedTextBox
    Friend WithEvents dtblDetailRelations As DataTable
    Friend WithEvents lblAccount As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblTask As Label
    Friend WithEvents lblCustomer As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblDate As Label
    Friend WithEvents cmbCompany As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAgentID As TextBox
    Friend WithEvents txtAgent As TextBox
    Friend WithEvents lblAgentID As Label
    Friend WithEvents lblAgent As Label
    Friend WithEvents lblCompany As Label
    Friend WithEvents txtComments As TextBox
    Friend WithEvents lblComments As Label
    Friend WithEvents dtblCompanies As DataTable
    Friend WithEvents lblDetails As Label
    Friend WithEvents dgvDetails As DataGridView
    Friend WithEvents USER_CHECKED As DataGridViewCheckBoxColumn
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dtpErrorDate As DateTimePicker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblOutputMessage As ToolStripStatusLabel
    Friend WithEvents txtCustomerNumber As MaskedTextBox
    Friend WithEvents dtblVendors As DataTable
End Class
