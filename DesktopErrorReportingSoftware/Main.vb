Public Class Main

    Public mySettings As Settings

    Private metricMode As Boolean
    Private sContactType As String
    Private bIgnoreSelectedItemIndex As Boolean = False

    Private Enum ClearMode
        Full = 0
        UI = 1
    End Enum
	
	Private Enum OutputType
		General = 0
		Success = 1
		Failure = 2
		Alert = 3
	End Enum

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mySettings = New Settings()

        If mySettings.Vaid = False Then
            MsgBox(mySettings.ErrorMessage, MsgBoxStyle.Critical, "A settings error has occurred.")
        Else
            PopulateListboxes()
        End If

        ClearForm(ClearMode.Full)
        dgvDetails.RowTemplate.MinimumHeight = 15

        'Set the autoclose timer to 4hours and start it.
        timerAutoClose.Interval = 1000 * 60 * 60 * 4
        timerAutoClose.Start()
    End Sub

    'Output messages to the user using the bottom OutputMessage label.
    Private Sub OutputMessageToUser(Optional msg As String = "", Optional oType As OutputType = 0)
        Dim c As Color
        Select Case oType
            Case OutputType.Success
                c = Color.DarkGreen
            Case OutputType.Failure
                c = Color.DarkRed
            Case OutputType.Alert
                c = Color.DarkOrange
            Case Else
                c = Color.Black
        End Select

        lblOutputMessage.Text = msg
        lblOutputMessage.ForeColor = c
    End Sub

    Private Sub PopulateListboxes()
        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblCategories", "Select * FROM tblCATEGORIES WHERE IS_HIDDEN = 0 Order By CATEGORY_NAME;", mySettings.GetConnectionString)
        lbCategories.DataSource = myDerpDataSet.Tables("dtblCategories")
        lbCategories.DisplayMember = "CATEGORY_NAME"
        lbCategories.ValueMember = "CATEGORY_ID"

        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblCompanies", "Select * FROM tblCOMPANIES WHERE IS_HIDDEN = 0 OR COMPANY_ID = 0 Order By COMPANY_FRIENDLY;", mySettings.GetConnectionString)
        cmbRegion.DataSource = myDerpDataSet.Tables("dtblCompanies")
        cmbRegion.DisplayMember = "COMPANY_FRIENDLY"
        cmbRegion.ValueMember = "COMPANY_ID"


        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblVendors", "Select * FROM tblVENDORS WHERE IS_HIDDEN = 0 OR KY_VENDOR_ID = 0 Order By VENDOR_SHORT;", mySettings.GetConnectionString)
        cmbVendor.DataSource = myDerpDataSet.Tables("dtblVendors")
        cmbVendor.ValueMember = "KY_VENDOR_ID"
        cmbVendor.DisplayMember = "VENDOR_SHORT"




        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblFunctions", "Select * FROM tblFUNCTIONS WHERE IS_HIDDEN = 0;", mySettings.GetConnectionString)
        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblDetails", "Select * FROM tblDETAILS WHERE IS_HIDDEN = 0;", mySettings.GetConnectionString)
        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblDetailRelations", "Select * FROM tblDetailRelations;", mySettings.GetConnectionString)

    End Sub

    Private Sub FillFormWithContactInfo()
        If (System.Windows.Forms.Clipboard.ContainsText) Then
            Dim contact As New Contact(System.Windows.Forms.Clipboard.GetText)
            If contact.Valid Then
                Dim contactSrc As String
                ResetAccountCustomerFields()
                Me.txtAccountNumber.Text = contact.AccountNumber
                Me.txtAgent.Text = contact.Agent
                Me.txtAgentID.Text = contact.AgentID
                Me.dtpErrorDate.Value = contact.DateOccurred
                Me.dtpErrorDate.Checked = True
                Me.cmbVendor.SelectedValue = contact.Vendor

                Me.sContactType = contact.ContactType

                If contact.Source = ContactSource.CS_ACCOUNT Then
                    ValidateTxtControl(Me.txtAccountNumber)
                    contactSrc = "Account"
                Else
                    contactSrc = "Customer"
                    If Not ValidateTxtControl(Me.txtCustomerNumber) Then Me.txtCustomerNumber.Focus()
                End If

                OutputMessageToUser(contactSrc & " contact successfully filled", OutputType.Success)
            Else
                OutputMessageToUser("Contact parsing error: Please try again.", OutputType.Alert)
            End If
        Else
            OutputMessageToUser("Contact parsing error: Please try again.", OutputType.Alert)
        End If

    End Sub

    Private Sub UpdateFunctionsList()
        If Not IsNothing(lbCategories.SelectedValue) AndAlso lbCategories.SelectedValue.GetType = GetType(Integer) Then
            Dim selc As Integer = lbCategories.SelectedValue
            Dim query =
                From task In myDerpDataSet.Tables("dtblFunctions")
                Where task.Field(Of Integer)("PARENT_CATEGORY") = selc
                Order By task.Field(Of String)("FUNCTION_NAME") Ascending
                Select task
            If query.Count > 0 Then
                bIgnoreSelectedItemIndex = True
                lbTasks.DataSource = query.CopyToDataTable
                lbTasks.DisplayMember = "FUNCTION_NAME"
                lbTasks.ValueMember = "FUNCTION_ID"
                lbTasks.SelectedIndex = -1
                Debug.Print(lbTasks.DataSource)
                lbTasks.Enabled = True
                bIgnoreSelectedItemIndex = False
            End If
        End If
        dgvDetails.DataSource = Nothing
    End Sub

    Private Sub UpdateDetailsList()
        If Not IsNothing(lbTasks.SelectedValue) AndAlso lbTasks.SelectedValue.GetType = GetType(Integer) Then
            Dim selc As Integer = lbTasks.SelectedValue
            Dim query =
                From detail In myDerpDataSet.Tables("dtblDetails")
                Join relation In myDerpDataSet.Tables("dtblDetailRelations") On detail.Field(Of Integer)("KY_DETAIL_ID") Equals relation.Field(Of Integer)("FUNCTION_DETAIL")
                Where relation.Field(Of Integer)("FUNCTION_REF") = selc
                Order By detail.Field(Of String)("DETAIL_NAME") Ascending
                Select detail
            If query.Count > 0 Then
                dgvDetails.DataSource = query.CopyToDataTable
                'column(0) = checkbox
                dgvDetails.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgvDetails.Columns(1).ReadOnly = True
                'Hide the other fields not used.
                For i As Integer = 2 To dgvDetails.ColumnCount - 1
                    dgvDetails.Columns(i).Visible = False
                Next
                dgvDetails.Refresh()
            Else
                dgvDetails.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub ClearForm(Optional cMode As ClearMode = ClearMode.Full)

        Me.txtAccountNumber.Text = vbNullString
        Me.txtCustomerNumber.Text = vbNullString

        sContactType = vbNullString

        ResetAccountCustomerFields()
        ResetComboBoxFields()

        Me.dtpErrorDate.MaxDate = DateAdd("d", 1, Date.Now)
        Me.dtpErrorDate.Value = Date.Now()
        Me.dtpErrorDate.Checked = False
        Me.cmbVendor.SelectedValue = 0 'default to blank
        Me.txtAgent.Text = vbNullString
        Me.txtAgentID.Text = vbNullString

        Me.txtComments.Text = vbNullString

        Me.chkPositiveFeedback.Checked = False

        UpdateDetailsList()
        UpdateMetricModeState()
        UpdateViewForPositiveFeedback(False)

        If cMode = ClearMode.Full Then
            OutputMessageToUser()
            Me.dgvDetails.DataSource = Nothing

            'Clear tasks/functions
            Me.lbTasks.ClearSelected()
            Me.lbTasks.DataSource = Nothing
            Me.lbTasks.Enabled = False

            Me.lbCategories.ClearSelected()
        End If
    End Sub


    Private Sub SubmitFeedback()

        'Check if it's Postive Feedback or Negative Feedback
        If (metricMode AndAlso chkPositiveFeedback.Checked) Then
            Dim listsToTest() As Object = {Me.lbCategories, Me.lbTasks}
            If ValidateListboxes(listsToTest) And ValidateComboBox(Me.cmbRegion) Then
                Dim pFeedback As Feedback = New Feedback()
                pFeedback.F_Category = Me.lbCategories.SelectedValue
                pFeedback.F_Function = Me.lbTasks.SelectedValue
                pFeedback.Region = cmbRegion.SelectedValue

                'Add positive feedback and details to the database
                Dim signal As Boolean = DB_Connection.Insert_PositiveFeedback(pFeedback, mySettings.GetConnectionString)
                If (signal) Then
                    ClearForm(ClearMode.UI)
                    OutputMessageToUser("Your positive feedback has been successfully submitted.", OutputType.Success)
                Else
                    OutputMessageToUser("An error has occurred. Feedback was not sent.", OutputType.Failure)
                End If
            Else
                OutputMessageToUser("Required information is missing.", OutputType.Alert)
            End If
        Else
            'Treat as "negative" feedback
            If ValidateForm() Then
                Dim fback As Feedback = New Feedback()

                fback.AccountNumber = Me.txtAccountNumber.Text
                fback.CustomerNumber = Me.txtCustomerNumber.Text
                fback.ContactType = sContactType
                fback.Agent = (Me.txtAgent.Text).ToUpper
                fback.Agent_ID = (Me.txtAgentID.Text).ToUpper
                fback.Vendor = Me.cmbVendor.SelectedValue
                fback.Region = Me.cmbRegion.SelectedValue
                fback.Comments = Me.txtComments.Text

                If Me.dtpErrorDate.Checked = False Then
                    fback.ErrorDate = vbNullString
                Else
                    fback.ErrorDate = dtpErrorDate.Value
                End If

                fback.F_Category = Me.lbCategories.SelectedValue
                fback.F_Function = Me.lbTasks.SelectedValue

                fback.F_ERROR = Me.dgvDetails.Rows.Cast(Of DataGridViewRow).Where(Function(r) r.Cells(0).Value = -1).Select(Of Int16)(Function(r) r.Cells("KY_DETAIL_ID").Value).ToArray

                'Add feedback and details to the database
                Dim signal As Boolean = DB_Connection.Insert_NewRecord(fback, mySettings.GetConnectionString)
                If (signal) Then
                    ClearForm(ClearMode.UI)
                    OutputMessageToUser("Your feedback has been successfully submitted.", OutputType.Success)
                Else
                    OutputMessageToUser("An error has occurred. Feedback was not sent.", OutputType.Failure)
                End If
            Else
                OutputMessageToUser("Required information is missing.", OutputType.Alert)
            End If
        End If
    End Sub

    Private Function ValidateForm() As Boolean
        Dim txtsToTest() As Object = {}
        '{Me.txtAccountNumber, Me.txtCustomerNumber}
        Dim listsToTest() As Object = {Me.lbCategories, Me.lbTasks}
        Dim comboboxesToTest() As Object = {Me.cmbRegion, Me.cmbVendor}
        Dim selectedDetails As List(Of Int16) = Me.dgvDetails.Rows.Cast(Of DataGridViewRow).Where(Function(r) r.Cells(0).Value = -1).Select(Of Int16)(Function(r) r.Cells("KY_DETAIL_ID").Value).ToList
        'Test Bill Account and Customer Number
        Dim bAccount = ValidateTxtControl(Me.txtAccountNumber) OrElse ValidateTxtControl(Me.txtCustomerNumber)
        If (bAccount) Then ResetAccountCustomerFields()
        Return ValidateTextboxes(txtsToTest) And ValidateListboxes(listsToTest) And ValidateComboBoxes(comboboxesToTest) And (selectedDetails.Count() > 0) And bAccount
    End Function

    Private Sub ResetAccountCustomerFields()
        Me.txtAccountNumber.BackColor = SystemColors.Window
        Me.txtCustomerNumber.BackColor = SystemColors.Window
    End Sub

    Private Sub ResetComboBoxFields()
        Me.cmbVendor.BackColor = SystemColors.Window
        Me.cmbRegion.BackColor = SystemColors.Window
    End Sub

    Private Sub UpdateMetricModeState()
        Me.chkPositiveFeedback.Visible = MetricModeToolStripMenuItem.Checked
        Me.chkPositiveFeedback.Checked = False
        metricMode = MetricModeToolStripMenuItem.Checked
    End Sub

    Private Sub UpdateViewForPositiveFeedback(Optional isPositive As Boolean = True)
        Me.txtAccountNumber.Enabled = Not isPositive
        Me.txtCustomerNumber.Enabled = Not isPositive
        Me.txtComments.Enabled = Not isPositive

        Me.dtpErrorDate.Enabled = Not isPositive
        Me.txtAgent.Enabled = Not isPositive
        Me.txtAgentID.Enabled = Not isPositive
        Me.cmbVendor.Enabled = Not isPositive

        Me.dgvDetails.Enabled = Not isPositive

        Me.btnFillForm.Enabled = Not isPositive
    End Sub

    'Automatically close the application if no feedback in X time..
    Private Sub timerAutoClose_Tick(sender As Object, e As EventArgs) Handles timerAutoClose.Tick
        Me.Close()
        End
    End Sub
    Private Sub ResetAutoCloseTimer()
        'Reset the timer
        timerAutoClose.Stop()
        timerAutoClose.Start()
    End Sub


    'UI Interactions

    'Listbox Selections
    Private Sub lbCategories_SelectedValueChanged(sender As Object, e As EventArgs) Handles lbCategories.SelectedValueChanged
        UpdateFunctionsList()
    End Sub
    Private Sub lbTasks_SelectedValueChanged(sender As Object, e As EventArgs) Handles lbTasks.SelectedValueChanged
        If bIgnoreSelectedItemIndex Then Return
        UpdateDetailsList()
    End Sub

    'General Interactions
    Private Sub btnFillForm_Click(sender As Object, e As EventArgs) Handles btnFillForm.Click
        FillFormWithContactInfo()
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        ResetAutoCloseTimer()
        SubmitFeedback()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm(ClearMode.Full)
    End Sub
    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
        End
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub
    Private Sub MetricModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MetricModeToolStripMenuItem.Click
        UpdateMetricModeState()
    End Sub

    'Quality of Life UI
    Private Sub dgvDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetails.KeyDown
        If e.KeyCode = Keys.Space Then
            If dgvDetails.SelectedRows.Count = 1 Then
                dgvDetails.Item(0, dgvDetails.SelectedRows(0).Index).Value = Not dgvDetails.Item(0, dgvDetails.SelectedRows(0).Index).Value
            End If
        End If
    End Sub
    Private Sub dgvDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetails.CellValueChanged
        If e.ColumnIndex = 0 AndAlso dgvDetails.ColumnCount >= 2 Then
            Dim c As Color
            c = IIf(dgvDetails.Item(0, e.RowIndex).Value = -1, Color.Blue, Color.Black)
            dgvDetails.Item(1, e.RowIndex).Style.ForeColor = c
        End If
    End Sub
    Private Sub dgvDetails_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDetails.CellMouseClick
        If e.ColumnIndex > 0 Then
            dgvDetails.Item(0, e.RowIndex).Value = Not dgvDetails.Item(0, e.RowIndex).Value
        End If
    End Sub

    'Label Clicks
    Private Sub lblCustomer_Click(sender As Object, e As EventArgs) Handles lblCustomer.Click
        Me.txtCustomerNumber.Focus()
    End Sub

    Private Sub lblAccount_Click(sender As Object, e As EventArgs) Handles lblAccount.Click
        Me.txtAccountNumber.Focus()
    End Sub

    Private Sub lblDate_Click(sender As Object, e As EventArgs) Handles lblDate.Click
        Me.lblDate.Focus()
    End Sub

    Private Sub lblVendor_Click(sender As Object, e As EventArgs) Handles lblVendor.Click
        Me.cmbVendor.Focus()
    End Sub

    Private Sub lblAgent_Click(sender As Object, e As EventArgs) Handles lblAgent.Click
        Me.txtAgent.Focus()
    End Sub

    Private Sub lblAgentID_Click(sender As Object, e As EventArgs) Handles lblAgentID.Click
        Me.txtAgentID.Focus()
    End Sub

    Private Sub chkPositiveFeedback_Click(sender As Object, e As EventArgs) Handles chkPositiveFeedback.Click
        UpdateViewForPositiveFeedback(chkPositiveFeedback.Checked)
    End Sub
    'END UI Interactions

End Class
