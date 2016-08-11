Imports System.Data.OleDb

Module DB_Connection


    'https://msdn.microsoft.com/en-us/library/vstudio/bh8kx08z(v=vs.100).aspx?cs-save-lang=1&cs-lang=vb#code-snippet-2
    Public Sub Populate_Datatable(ByRef dSet As DataSet, dTableName As String, strSQL As String, strConnection As String)

        ' Assumes that customerConnection is a valid SqlConnection object.
        ' Assumes that orderConnection is a valid OleDbConnection object.

        Dim ordAdapter As OleDbDataAdapter = New OleDbDataAdapter(strSQL, strConnection)

        Dim customerOrders As DataSet = New DataSet()
        ordAdapter.Fill(dSet, dTableName)

        'Dim relation As DataRelation =
        'customerOrders.Relations.Add("CustOrders",
        'customerOrders.Tables("Customers").Columns("CustomerID"),
        'customerOrders.Tables("Orders").Columns("CustomerID"))


        ordAdapter.Dispose()
        ordAdapter = Nothing
    End Sub

    Public Function Insert_PositiveFeedback(pFeedback As Feedback, strConn As String) As Boolean
        Dim query As String = "Insert Into PositiveFeedback (F_REGION, REP_PROVIDER, F_CATEGORY, F_FUNCTION, FEEDBACK_TIMESTAMP) " &
        "Values (region, rep, cat, func, dFeed);"
        Try
            Using conn As New OleDbConnection(strConn)
                Using cmd As New OleDbCommand(query, conn)
                    cmd.Parameters.AddWithValue("region", pFeedback.Region)
                    cmd.Parameters.AddWithValue("rep", pFeedback.Rep)
                    cmd.Parameters.AddWithValue("cat", pFeedback.F_Category)
                    cmd.Parameters.AddWithValue("func", pFeedback.F_Function)
                    cmd.Parameters.AddWithValue("dFeed", pFeedback.Get_Timestamp)

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Insert_NewRecord(fBack As Feedback, strConn As String) As Boolean
        Dim query As String = "Insert Into Feedback (ACCOUNT_NUMBER, CUSTOMER_NUMBER, F_REGION, REP_PROVIDER, AGENT, AGENT_ID, " &
        "Vendor, F_CATEGORY, F_FUNCTION, ERROR_DATE, FEEDBACK_TIMESTAMP, COMMENTS, CONTACT_TYPE) Values (acc, cust, region, rep, agent, agent_id, " &
        "vend, cat, func, dErr, dFeed, comm, con_type);"
        Dim query2 As String = "Select @@Identity"
        Dim qryInsertDetails As String = "Insert Into ReportedErrors (fID, DETAIL) " &
            "Values (id, det);"
        Dim uID As Integer

        Try
            Using conn As New OleDbConnection(strConn)
                Using cmd As New OleDbCommand(query, conn)
                    cmd.Parameters.AddWithValue("acc", fBack.AccountNumber)
                    cmd.Parameters.AddWithValue("cust", fBack.CustomerNumber)
                    cmd.Parameters.AddWithValue("region", fBack.Region)
                    cmd.Parameters.AddWithValue("rep", fBack.Rep)
                    cmd.Parameters.AddWithValue("agent", fBack.Agent)
                    cmd.Parameters.AddWithValue("agent_id", fBack.Agent_ID)
                    cmd.Parameters.AddWithValue("vend", fBack.Vendor)
                    cmd.Parameters.AddWithValue("cat", fBack.F_Category)
                    cmd.Parameters.AddWithValue("func", fBack.F_Function)
                    'cmd.Parameters.AddWithValue("dErr", fBack.ErrorDate)
                    cmd.Parameters.AddWithValue("dErr", If(fBack.ErrorDate, DBNull.Value))
                    cmd.Parameters.AddWithValue("dFeed", fBack.Get_Timestamp)
                    cmd.Parameters.AddWithValue("comm", fBack.Comments)
                    cmd.Parameters.AddWithValue("con_type", If(fBack.ContactType, DBNull.Value))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = query2
                    uID = cmd.ExecuteScalar()
                End Using
                For Each detail As Int16 In fBack.F_ERROR
                    Using cmd As New OleDbCommand(qryInsertDetails, conn)
                        cmd.Parameters.AddWithValue("id", uID)
                        cmd.Parameters.AddWithValue("det", detail)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
                conn.Close()
            End Using
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

End Module
