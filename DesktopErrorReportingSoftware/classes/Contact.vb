Public Enum ContactSource
    CS_ERROR = 0
    CS_ACCOUNT = 1
    CS_CUSTOMER = 2
End Enum

'Matches the company table
Public Enum Vendors
    COMP_ERR = 0
    COMP_OTHER = 1
    COMP_NationalGrid = 2
    COMP_LICallCenter = 3
    COMP_IQOR = 4
    COMP_NCI = 5
    COMP_COV = 6
    COMP_NorthboroCallCenter = 7
End Enum

Public Class Contact
    Property Agent As String
    Property AgentID As String
    Property Vendor As Vendors
    Property ContactType As String
    Property DateOccurred As String
    Property PremiseAddress As String
    Property AccountNumber As String

    ReadOnly Property Valid As Boolean = False
    Property Source As ContactSource

    ReadOnly Property OrignalContactString As String

    'UNUSED
    Property CompanyCenter As String
    Property ContactGUID As String
    Property ContactTimestamp As String


    Public Sub New(contactStr As String)
        Me.OrignalContactString = contactStr
        Me.Valid = CParseString()
    End Sub


    Private Function CParseString() As Boolean
        'Account: 10/24/15 {\t} General Collections Contact {\t} 123 APPPLE ST SYRACUSE NY 13219 {\t} JOHN DOE
        '{\t} Syracu {\t} 99999999 {\t} 2015-10-24-09.12.07.572093 {\t} E09677 {\t} 123456700 {\t} 1,234,567,890 {\t}

        'Customer: 08/08/14 {\t} Contact Type {\t} JANE DOE {\t} {\t} 999999999 {\t} 2014-08-08-15.23.06.099340 {\t} NCIR99

        Dim splits As String()
        If InStr(Me.OrignalContactString, Chr(9), vbTextCompare) Then
            splits = Split(OrignalContactString, Chr(9))
            If UBound(splits) = 11 Then
                Me.DateOccurred = splits(0)
                Me.ContactType = splits(1)

                If splits(2) = "" Then
                    Me.Source = ContactSource.CS_CUSTOMER
                Else
                    Me.Source = ContactSource.CS_ACCOUNT
                    Me.PremiseAddress = splits(2)
                End If

                Me.Agent = splits(3)
                Me.CompanyCenter = splits(4)
                Me.ContactGUID = splits(5)
                Me.ContactTimestamp = splits(6)
                Me.AgentID = splits(7)
                Me.Vendor = DetermineAgentsCompany(Me.AgentID)

                If (Me.Source = ContactSource.CS_ACCOUNT) Then
                    'Me.PremiseNumber = AddLeadingZeroes(splits(8), 9)
                    Me.AccountNumber = AddLeadingZeroes(Replace(splits(9), ",", ""), 10)
                End If

                Return True
            End If
        End If
        Return False
    End Function


    Private Function DetermineAgentsCompany(agentID As String) As Vendors
        Dim vendor As Vendors
        If Len(agentID) < 3 Then
            vendor = Vendors.COMP_ERR
        Else

            Dim prefix As String
            prefix = Left(agentID, 3)
            If Left(agentID, 1) = "E" And IsNumeric(Right(prefix, 2)) Then
                'E09677
                vendor = Vendors.COMP_NationalGrid
            ElseIf Left(agentID, 3) = "LIC" And IsNumeric(Mid(agentID, 4, 5)) Then
                'LIC000
                vendor = Vendors.COMP_LICallCenter
            ElseIf prefix = "NCI" Or prefix = "ICN" Then
                'NCIL00 or NCIR00
                vendor = Vendors.COMP_NCI
            ElseIf prefix = "IQO" Or prefix = "OQI" Then
                'IQO00 or OQI000
                vendor = Vendors.COMP_IQOR
            ElseIf prefix = "COV" Then
                'COV099
                vendor = Vendors.COMP_COV
            ElseIf prefix = "NBR" Then
                'NBR099
                vendor = Vendors.COMP_NorthboroCallCenter
            Else
                vendor = Vendors.COMP_OTHER
            End If
        End If
        Return vendor
    End Function

    Private Function AddLeadingZeroes(txt As String, length As String) As String
        While (Len(txt) < length)
            txt = "0" + txt
        End While
        Return txt
    End Function

End Class
