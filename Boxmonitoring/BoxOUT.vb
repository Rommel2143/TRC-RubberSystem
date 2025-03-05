
Imports MySql.Data.MySqlClient
Public Class BoxOUT


    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub


    Private Sub UpdateBox()
        Try
            ' Check if the boxqr exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM rubber_box WHERE boxqr = @boxqr"
            Dim checkCmd As New MySqlCommand(checkQuery, con)
            checkCmd.Parameters.AddWithValue("@boxqr", txtqr.Text.Trim)

            con.Close()
            con.Open()
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            con.Close()

            ' If no record found, display error
            If count = 0 Then
                display_error("Box QR not found.", 1)
                Exit Sub
            End If

            ' Proceed with updating if record exists
            Dim query As String = "UPDATE rubber_box SET `date_out` = CURDATE(), `status` = 0 WHERE boxqr = @boxqr"
            Dim cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@boxqr", txtqr.Text.Trim)

            con.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try


                If txtqr.Text.Substring(0, 5) = "TRC-R" Or txtqr.Text.Substring(0, 5) = "TRC-T" Then
                    UpdateBox()
                Else
                    display_error("QR not Valid", 1)
                End If

            Catch ex As Exception
                display_error("Invalid QR", 1)
            Finally
                loaddata()
                con.Close()

                txtqr.Clear()
                txtqr.Focus()

            End Try
        End If
    End Sub

    Private Sub BoxIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub

    Private Sub loaddata()
        reload("SELECT  boxqr AS 'Box QR' FROM `rubber_box` WHERE date_out=CURDATE()", datagrid1)

        getdata_out()
    End Sub

    Private Sub getdata_out()
        Try
            Dim query As String = "SELECT COUNT(id) FROM rubber_box WHERE date_out=CURDATE()"

            Dim cmd As New MySqlCommand(query, con)

            con.Close()
            con.Open()
            dr = cmd.ExecuteReader
            If dr.Read = True Then
                lbl_total.Text = "Boxes Delivered Today : " & dr.GetInt32(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub
End Class