Module Validation
    Private Const ERROR_BORDER_COLOR = 255
    Private Const VALID_BORDER_COLOR = 0

    Public Function ValidateTextboxes(ctrls() As Object)
        Dim bIsValid As Boolean = True
        Dim lastCtrlToFail As String

        On Error Resume Next


        'Accept either Customer or Account Number
        'If (Not ValidateTxtControl(Me.ACCOUNT_NUMBER)) Then
        '    bIsValid = ValidateTxtControl(Me.CUSTOMER_NUMBER)
        '    If (bIsValid) Then : Me.ACCOUNT_NUMBER.BorderColor = vbBlack
        '    Else
        '        Me.CUSTOMER_NUMBER.BorderColor = vbBlack
        '    End If

        'bIsValid = IIf(bIsValid, ValidateTxtControl(Me.F_FUNCTION), bIsValid)




        For Each txt As Object In ctrls
            If Not ValidateTxtControl(txt) Then
                bIsValid = False
                'lastFailCtrl = txt.Name
            End If
        Next
        Return bIsValid
    End Function

    Public Function ValidateListboxes(ctrls() As Object)
        Dim bIsValid As Boolean = True
        Dim lastCtrlToFail As String

        On Error Resume Next

        For Each lstb As Object In ctrls
            If Not ValidateListControl(lstb) Then
                bIsValid = False
                'lastFailCtrl = txt.Name
            End If
        Next
        Return bIsValid
    End Function

    Public Function ValidateListControl(ctrl As Object) As Boolean
        Dim isValid As Boolean = True

        'Check if null for all controls.
        If IsNothing(ctrl) Then
            isValid = False

        Else
            'Check controls, by name, for any specific tests
            Select Case ctrl.Name
                Case Else
                    If Not IsNumeric(ctrl.SelectedValue) Then
                        isValid = False
                    End If
            End Select
        End If
        Return isValid
    End Function


    Public Function ValidateTxtControl(ctrl As Object) As Boolean
        Dim isValid As Boolean = True

        'Check if null for all controls.
        If IsNothing(ctrl) And ctrl.Name <> "F_ERROR" Then
            isValid = False

        Else
            'Check controls, by name, for any specific tests
            Select Case ctrl.Name
                Case "txtAccountNumber" 'Account Number Must Be 10 Digits
                    If Len(ctrl.text) <> 10 OrElse Not IsNumeric(ctrl.text) Then isValid = False
                Case "txtCustomerNumber" 'Customer Number Must be 9 Digits
                    If Len(ctrl.text) <> 9 OrElse Not IsNumeric(ctrl.text) Then isValid = False
                Case Else
                    If Len(ctrl.text) < 1 Then isValid = False
            End Select
        End If

        'Output Pass/Fail when in debug mode.
        '#If DEBUG_MODE Then
        'Debug.Print ctrl.Name & " validity test: " & IIf(isValid, "PASS!", "FAIL!")
        '#End If

        'Change textbox backcolor to valid or error color
        ctrl.BackColor = IIf(isValid, SystemColors.Window, Color.Yellow)
        Return isValid
    End Function

    Public Function ValidateAccount(ctrl As Object) As Boolean
		Dim bAccountValid As Boolean
		If Len(ctrl.text) <> 10 OrElse Not IsNumeric(ctrl.text) Then bAccountValid = False
		ctrl.BackColor = IIf(bAccountValid, SystemColors.Window, Color.Yellow)
		return bAccountValid
    End Function

	
    Private Sub ValidateInputs()

    End Sub

End Module
