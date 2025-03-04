Imports MySql.Data.MySqlClient
Public Class BoxIN


    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub


    Private Sub insertOrUpdateBox()
        Try
            Dim query As String = "INSERT INTO `rubber_box` (`id`, `boxqr`, `date_in`, `date_out`, `status`, `date_registered`) 
                               VALUES (NULL, @boxqr, CURDATE(), NULL, 1, CURDATE()) 
                               ON DUPLICATE KEY UPDATE `date_in` = CURDATE(), `status` = 1, `date_registered` = CURDATE()"

            Dim cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@boxqr", txtqr.Text.Trim)

            con.Close()
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
                    insertOrUpdateBox()
                Else
                    display_error("QR not Valid", 1)
                End If

            Catch ex As Exception
                display_error("Invalid QR", 1)
            Finally
                reload("SELECT `boxqr` FROM `rubber_box` WHERE date_in =CURDATE()", datagrid1)
                getdata_IN()
                con.Close()

                txtqr.Clear()
                txtqr.Focus()

            End Try
        End If
    End Sub

    Private Sub BoxIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reload("SELECT `boxqr` FROM `rubber_box` WHERE date_in =CURDATE()", datagrid1)
        getdata_IN()
    End Sub

    Private Sub getdata_IN()
        Try
            Dim query As String = "SELECT COUNT(id) FROM rubber_box WHERE date_in=CURDATE()"

            Dim cmd As New MySqlCommand(query, con)

            con.Close()
            con.Open()
            dr = cmd.ExecuteReader
            If dr.Read = True Then
                lbl_total.Text = "Boxes Recieved Today : " & dr.GetInt32(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


End Class