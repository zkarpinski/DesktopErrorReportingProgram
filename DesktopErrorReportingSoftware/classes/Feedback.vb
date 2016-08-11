Public Class Feedback

    Public ReadOnly Property Rep As String
    Public Property AccountNumber As String
    Public Property CustomerNumber As String
    Public Property Region As Int16
    Public Property ContactType As String

    Public Property Agent As String
    Public Property Agent_ID As String
    Public Property Vendor As Int16

    Public Property F_Category As Int16
    Public Property F_Function As Int16
    Public F_ERROR(16) As Int16

    Public Property ErrorDate As Date?

    Public Property Comments As String


    Private m_Timestamp As Date

    Public Sub New(sAccount As String, sCustomer As String, iVendor As Integer, sAgent As String, sAgentID As String,
        iCategory As Integer, iFunction As Integer, iErrorArray() As Int16, dErrorDate As String, sComments As String)

        AccountNumber = sAccount
        CustomerNumber = sCustomer

        Vendor = iVendor
        Agent = sAgent
        Agent_ID = sAgentID

        F_Category = iCategory
        F_Function = iFunction
        F_ERROR = iErrorArray

        Comments = sComments

        'Store the Rep
        Rep = Environment.UserName.ToUpper

        'Generate the feedback time stamp
        Dim dDate As DateTime = Now()
        m_Timestamp = New DateTime(dDate.Year, dDate.Month, dDate.Day, dDate.Hour, dDate.Minute, dDate.Second)
    End Sub

    Public Sub New()

        Rep = Environment.UserName.ToUpper

        'Generate the feedback time stamp
        Dim dDate As DateTime = Now()
        m_Timestamp = New DateTime(dDate.Year, dDate.Month, dDate.Day, dDate.Hour, dDate.Minute, dDate.Second)
    End Sub

    'Public Function Get_Timestamp() As String
    'Return Format(m_Timestamp, "MM/DD/YYYY HH:MM:SS")
    'End Function

    Public Function Get_Timestamp() As DateTime
        Return m_Timestamp
    End Function

End Class
