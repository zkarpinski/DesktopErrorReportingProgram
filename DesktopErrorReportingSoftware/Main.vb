Public Class Main

    Public mySettings As Settings

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

        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblCompanies", "Select * FROM tblCOMPANIES WHERE IS_HIDDEN = 0 Order By COMPANY;", mySettings.GetConnectionString)
        cmbCompany.DataSource = myDerpDataSet.Tables("dtblCompanies")
        cmbCompany.DisplayMember = "COMPANY_SHORT"
        cmbCompany.ValueMember = "COMPANY_ID"


        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblRegions", "Select * FROM tblREGIONS WHERE IS_HIDDEN = 0 Order By COMPANY;", mySettings.GetConnectionString)
        cmbCompany.DataSource = myDerpDataSet.Tables("dtblCompanies")
        cmbCompany.DisplayMember = "COMPANY_SHORT"
        cmbCompany.ValueMember = "COMPANY_ID"


        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblFunctions", "Select * FROM tblFUNCTIONS WHERE IS_HIDDEN = 0;", mySettings.GetConnectionString)
        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblDetails", "Select * FROM tblDETAILS WHERE IS_HIDDEN = 0;", mySettings.GetConnectionString)
        DB_Connection.Populate_Datatable(myDerpDataSet, "dtblDetailRelations", "Select * FROM tblDetailRelations;", mySettings.GetConnectionString)

    End Sub

    Private Sub FillFormWithContactInfo()
        If (System.Windows.Forms.Clipboard.ContainsText) Then
            Dim contact As New Contact(System.Windows.Forms.Clipboard.GetText)
            If contact.Valid Then
                Dim contactSrc As String
                ResetAccountCustsomerFields()
                Me.txtAccountNumber.Text = contact.AccountNumber
                Me.txtAgent.Text = contact.Agent
                Me.txtAgentID.Text = contact.AgentID
                Me.dtpErrorDate.Value = contact.DateOccurred
                Me.dtpErrorDate.Checked = True
                Me.cmbCompany.SelectedValue = contact.Company

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
                Join relation In myDerpDataSet.Tables("dtblDetailRelations") On detail.Field(Of Integer)("ERROR_ID") Equals relation.Field(Of Integer)("FUNCTION_ERROR")
                Where relation.Field(Of Integer)("FUNCTION_REF") = selc
                Order By detail.Field(Of String)("ERROR_NAME") Ascending
                Select detail
            If query.Count > 0 Then
                dgvDetails.DataSource = query.CopyToDataTable
                dgvDetails.Columns(3).Visible = False
                dgvDetails.Columns(2).Visible = False
                dgvDetails.Columns(4).Visible = False
                dgvDetails.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgvDetails.Columns(1).ReadOnly = True
                dgvDetails.Refresh()
            Else
                dgvDetails.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub ClearForm(Optional cMode As ClearMode = ClearMode.Full)

        Me.txtAccountNumber.Text = vbNullString
        Me.txtCustomerNumber.Text = vbNullString

        ResetAccountCustsomerFields()

        Me.dtpErrorDate.MaxDate = DateAdd("d", 1, Date.Now)
        Me.dtpErrorDate.Value = Date.Now()
        Me.dtpErrorDate.Checked = False
        Me.cmbCompany.SelectedValue = 1
        Me.txtAgent.Text = vbNullString
        Me.txtAgentID.Text = vbNullString

        Me.txtComments.Text = vbNullString
        UpdateDetailsList()

        If cMode = ClearMode.Full Then
            OutputMessageToUser()
            Me.dgvDetails.DataSource = Nothing

            Me.lbTasks.ClearSelected()
            Me.lbTasks.DataSource = Nothing
            Me.lbTasks.Enabled = False

            Me.lbCategories.ClearSelected()
        End If
    End Sub
	
	
	Private Sub SubmitFeedback()
		If ValidateForm() Then
            Dim fback As Feedback = New Feedback()
			
            fback.AccountNumber = Me.txtAccountNumber.Text
            fback.CustomerNumber = Me.txtCustomerNumber.Text
            fback.ContactType = ""
            fback.Agent = (Me.txtAgent.Text).ToUpper
            fback.Agent_ID = (Me.txtAgentID.Text).ToUpper
            fback.Company = Me.cmbCompany.SelectedValue
            fback.Comments = Me.txtComments.Text
            fback.ErrorDate = "#" & Me.dtpErrorDate.Value.ToString & "#"

            fback.F_Category = Me.lbCategories.SelectedValue
            fback.F_Function = Me.lbTasks.SelectedValue

            fback.F_ERROR = Me.dgvDetails.Rows.Cast(Of DataGridViewRow).Where(Function(r) r.Cells(0).Value = -1).Select(Of Int16)(Function(r) r.Cells("ERROR_ID").Value).ToArray



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
	End Sub

    Private Function ValidateForm() As Boolean
        Dim txtsToTest() As Object = {}
        '{Me.txtAccountNumber, Me.txtCustomerNumber}
        Dim listsToTest() As Object = {Me.cmbCompany, Me.lbCategories, Me.lbTasks}
        Dim selectedDetails As List(Of Int16) = Me.dgvDetails.Rows.Cast(Of DataGridViewRow).Where(Function(r) r.Cells(0).Value = -1).Select(Of Int16)(Function(r) r.Cells("ERROR_ID").Value).ToList

        Dim bAccount = ValidateTxtControl(Me.txtAccountNumber) OrElse ValidateTxtControl(Me.txtCustomerNumber)
        If (bAccount) Then ResetAccountCustsomerFields()
        Return ValidateTextboxes(txtsToTest) And ValidateListboxes(listsToTest) And (selectedDetails.Count() > 0) And bAccount
    End Function

    Private Sub ResetAccountCustsomerFields()
        Me.txtAccountNumber.BackColor = SystemColors.Window
        Me.txtCustomerNumber.BackColor = SystemColors.Window
    End Sub



    'UI Interactions

    'Listbox Selections
    Private Sub lbCategories_SelectedValueChanged(sender As Object, e As EventArgs) Handles lbCategories.SelectedValueChanged
		UpdateFunctionsList
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

    Private Sub lblCompany_Click(sender As Object, e As EventArgs) Handles lblCompany.Click
        Me.cmbCompany.Focus()
    End Sub

    Private Sub lblAgent_Click(sender As Object, e As EventArgs) Handles lblAgent.Click
        Me.txtAgent.Focus()
    End Sub

    Private Sub lblAgentID_Click(sender As Object, e As EventArgs) Handles lblAgentID.Click
        Me.txtAgentID.Focus()
    End Sub
    'END UI Interactions

End Class
