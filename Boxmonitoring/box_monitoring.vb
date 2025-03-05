Imports MySql.Data.MySqlClient
Public Class box_monitoring
    Private Sub box_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_Rbig.Text = "BIG Box : " & getCount("-RB-")
        lbl_Rmedium.Text = "MEDUIM Box : " & getCount("-RM-")
        lbl_Tmedium.Text = "MEDUIM Box : " & getCount("-TM-")
        lbl_Tsmall.Text = "SMALL Box : " & getCount("-TS-")

    End Sub

    Private Function getCount(text As String) As String
        Dim result As String = "0 out of 0" ' Default value

        Try
            Dim query As String = "SELECT 
                                (SELECT COUNT(id) FROM rubber_box WHERE boxqr LIKE '%" & text & "%' AND status = 1) AS active_count, 
                                (SELECT COUNT(id) FROM rubber_box WHERE boxqr LIKE '%" & text & "%') AS total_count"

            Dim cmd As New MySqlCommand(query, con)

            con.Close()
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                result = dr.GetInt32(0) & " out of " & dr.GetInt32(1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

        Return result
    End Function

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged
        If txtqr.Text.Trim = "" Then
            reload("SELECT `boxqr`, `date_in`, `date_out`, 
               CASE 
                   WHEN `status` = 1 THEN 'IN' 
                   WHEN `status` = 0 THEN 'OUT' 
                   ELSE 'UNKNOWN' 
               END AS `status`, 
               `date_registered` 
               FROM `rubber_box`", datagrid1)

        End If
    End Sub

    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown
        If e.KeyCode = Keys.Enter Then

            reload("SELECT `boxqr`, `date_in`, `date_out`, 
               CASE 
                   WHEN `status` = 1 THEN 'IN' 
                   WHEN `status` = 0 THEN 'OUT' 
                   ELSE 'UNKNOWN' 
               END AS `status`, 
               `date_registered` 
               FROM `rubber_box` WHERE boxqr REGEXP '" & txtqr.Text & "'", datagrid1)

        End If
    End Sub

    Private Sub export_excel_Click(sender As Object, e As EventArgs) Handles export_excel.Click
        exporttoExcel(datagrid1)
    End Sub
End Class