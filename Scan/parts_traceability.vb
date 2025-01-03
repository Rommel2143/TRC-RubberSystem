Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class parts_traceability
    Dim qrlenght As Integer
    Dim serialNumber As String = ""

    Dim partno As String
    Dim qty As String
    Dim customerno As String
    Dim color As String
    Dim prod As String
    Dim shift As String
    Dim process As String
    Dim line As String
    Dim series As String


    Private Function processQRcode(type As String, txtqr As Guna.UI2.WinForms.Guna2TextBox) As Boolean
        Try

            serialNumber = txtqr.Text

            'Qr Lenght
            qrlenght = serialNumber.Length
            Dim productionDateRaw As String = ""
            con.Close()
            con.Open()
            Dim cmdselect As New MySqlCommand("SELECT `id`, `qrtype`, `qrlenght`, `partno`, `qty`, `customer`, `color`, `proddate`, `shift`, `process`, `line`, `series` FROM `denso_qrtype`
                                                WHERE qrlenght= '" & qrlenght & "' and qrtype  = '" & type & "'", con)
            dr = cmdselect.ExecuteReader()
            If dr.Read = True Then
                Dim partnoraw As String = ""
                getcoordinates(dr.GetString("partno"), partnoraw)
                partno = partnoraw.Replace("-", "")
                getcoordinates(dr.GetString("qty"), qty)
                getcoordinates(dr.GetString("customer"), customerno)
                getcoordinates(dr.GetString("color"), color)
                getcoordinates(dr.GetString("proddate"), productionDateRaw)
                getcoordinates(dr.GetString("shift"), shift)
                getcoordinates(dr.GetString("process"), process)
                getcoordinates(dr.GetString("line"), line)
                getcoordinates(dr.GetString("series"), series)

                Dim year As Integer = Integer.Parse(productionDateRaw.Substring(0, 2))
                Dim month As Integer = Integer.Parse(productionDateRaw.Substring(2, 2))
                Dim day As Integer = Integer.Parse(productionDateRaw.Substring(4, 2))
                Dim productionDateDateTime As New DateTime(2000 + year, month, day)
                prod = productionDateDateTime.ToString("yyyy-MM-dd")
                Return True

            Else
                ' showerror("No Qrtype Detected! Please Register first")
                txtqr.Clear()
                txtqr.Focus()
                Return False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub displaygrid(datagrid As Guna2DataGridView)
        'Filter Duplicate on QR
        For Each row As DataGridViewRow In datagrid.Rows
            If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = serialNumber Then
                '  labelerror.Visible = True
                '  texterror.Text = "QR Already Scanned Please check the Table!"
                soundduplicate()
                Exit Sub
            End If
        Next

        'Filter Duplicate on Partno and CustomerNO
        If datagrid.Rows.Count > 0 Then
            Dim firstPartno As String = datagrid.Rows(0).Cells(1).Value.ToString()
            Dim firstCustomerno As String = datagrid.Rows(0).Cells(3).Value.ToString()

            If partno <> firstPartno OrElse customerno <> firstCustomerno Then
                '   labelerror.Visible = True
                '  texterror.Text = "Part Number or Customer Number does not match. Please check the Table!"
                soundduplicate()
                Exit Sub
            End If
        End If
        'display grid
        Dim newrow As String() = New String() {serialNumber, partno, qty, customerno, color, prod, shift, process, line, series}
        datagrid.Rows.Add(newrow)
        '  labelerror.Visible = False
        UpdateRowCountAndTotalQty(datagrid, lbl_count, lbl_qty)
    End Sub

    Private Sub UpdateRowCountAndTotalQty(datagrid As Guna2DataGridView, labelRowCount As Label, labelTotalQty As Label)
        ' Update row count
        labelRowCount.Text = datagrid.Rows.Count.ToString()

        ' Calculate total quantity
        Dim totalQty As Integer = 0
        For Each row As DataGridViewRow In datagrid.Rows
            If row.Cells(2).Value IsNot Nothing Then
                totalQty += Convert.ToInt32(row.Cells(2).Value)
            End If
        Next

        ' Update total quantity label
        labelTotalQty.Text = totalQty.ToString()
    End Sub

    Private Sub getcoordinates(partdb As String, ByRef txtstring As String)

        Dim partno() As String = partdb.Split(",")
        Dim partget1 As Integer = partno(0)
        Dim partget2 As Integer = partno(1)

        ' Extract parts based on fixed positions
        txtstring = serialNumber.Substring(partget1, partget2)

    End Sub
    Private controlIndex As Integer = 0
    Private Sub txtqr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("SELECT innertag, userin, datein FROM `denso_dmtn_innertag`
                                                WHERE innertag = '" & txtqr.Text & "'", con)
                dr = cmdselect.ExecuteReader()
                If dr.Read = True Then
                    'duplicate
                    '   showduplicate(dr.GetString("userin"), dr.GetDateTime("datein").ToString("yyy-MM-dd"))

                Else

                    If processQRcode("DMTN-IT", txtqr) Then

                        displaygrid(datagrid1)
                        Select Case controlIndex
                            Case 0
                                inner_1.Show()
                            Case 1
                                inner_2.Show()
                            Case 2
                                inner_3.Show()
                            Case 3
                                inner_4.Show()
                            Case 4
                                inner_5.Show()
                            Case 5
                                inner_6.Show()
                            Case 6
                                inner_7.Show()
                            Case 7
                                inner_8.Show()
                            Case Else
                                ' If all controls have been shown, do nothing
                                Return
                        End Select

                        ' Increment the controlIndex to show the next control on the next key press
                        controlIndex += 1




                    End If

                End If
                txtqr.Clear()
                txtqr.Focus()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqr_fg.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                con.Close()
                con.Open()
                Dim cmdselect As New MySqlCommand("SELECT dmtn, userin, datein FROM `denso_dmtn`
                                                WHERE dmtn = '" & txtqr_fg.Text & "'", con)
                dr = cmdselect.ExecuteReader()
                If dr.Read = True Then
                    'duplicate
                    '   showduplicate(dr.GetString("userin"), dr.GetDateTime("datein").ToString("yyy-MM-dd"))

                Else
                    If processQRcode("DMTN", txtqr_fg) Then
                        'saveqr
                        Dim partno_inner As String = datagrid1.Rows(0).Cells(1).Value.ToString()

                        If partno_inner = partno Then
                            If lbl_qty.Text = qty Then
                                saveqr()
                                '   labelerror.Visible = False
                                txtqr_fg.Clear()
                                txtqr_fg.Enabled = False
                                txtqr.Enabled = True
                                btndelete.PerformClick()
                                txtqr.Clear()
                                txtqr.Focus()
                            Else
                                '   showerror("QTY does'nt match the given Inner Tags!")
                            End If

                        Else
                            '  showerror("QR does'nt match the given Inner Tags!")

                        End If
                        End If
                    End If

            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub
    Private Sub saveqr()
        Try
            ' Define your MySQL connection string


            For Each row As DataGridViewRow In datagrid1.Rows
                ' Skip new or empty rows
                If row.IsNewRow Then Continue For

                ' Retrieve data from the DataGridView row

                Dim grid_innertag As String = row.Cells(0).Value.ToString()
                Dim grid_partno As String = row.Cells(1).Value.ToString()
                Dim grid_qty As Integer = Convert.ToInt32(row.Cells(2).Value)
                Dim grid_customerno As String = row.Cells(3).Value.ToString()
                Dim grid_color As String = row.Cells(4).Value.ToString()
                Dim grid_proddate As String = row.Cells(5).Value.ToString()
                Dim grid_shift As String = row.Cells(6).Value.ToString()
                Dim grid_process As String = row.Cells(7).Value.ToString()
                Dim grid_line As String = row.Cells(8).Value.ToString()
                Dim grid_serial As String = row.Cells(9).Value.ToString()

                Dim fglabel As String = txtqr_fg.Text

                con.Close()
                con.Open()
                ' Create the SQL command to insert the data
                Dim cmdinsert As New MySqlCommand("INSERT INTO denso_dmtn_innertag (innertag, partno, qty, customerno, color, proddate, shift, process, line, serial, fglabel, userin, datein) " &
                                          "VALUES (@innertag, @partno, @qty, @customerno, @color, @proddate, @shift, @process, @line, @serial, @fglabel, @userin, @datein)", con)
                With cmdinsert.Parameters
                    .AddWithValue("@innertag", grid_innertag)
                    .AddWithValue("@partno", grid_partno)
                    .AddWithValue("@qty", grid_qty)
                    .AddWithValue("@customerno", grid_customerno)
                    .AddWithValue("@color", grid_color)
                    .AddWithValue("@proddate", grid_proddate)
                    .AddWithValue("@shift", grid_shift)
                    .AddWithValue("@process", grid_process)
                    .AddWithValue("@line", grid_line)
                    .AddWithValue("@serial", grid_serial)
                    .AddWithValue("@fglabel", fglabel)
                    .AddWithValue("@userin", idno)
                    .AddWithValue("@datein", datedb)
                    cmdinsert.ExecuteNonQuery()
                End With
            Next
            con.Close()
            con.Open()

            Dim cmdinsertdmtn As New MySqlCommand("INSERT INTO denso_dmtn (dmtn, partno, qty, customerno, color, proddate, shift, process, line, serial,userin, datein) " &
                                      "VALUES (@dmtn, @partno, @qty, @customerno, @color, @proddate, @shift, @process, @line, @serial, @userin, @datein)", con)
            With cmdinsertdmtn.Parameters
                .AddWithValue("@dmtn", txtqr_fg.Text)
                .AddWithValue("@partno", partno)
                .AddWithValue("@qty", qty)
                .AddWithValue("@customerno", datagrid1.Rows(0).Cells(3).Value.ToString())
                .AddWithValue("@color", color)
                .AddWithValue("@proddate", prod)
                .AddWithValue("@shift", shift)
                .AddWithValue("@process", process)
                .AddWithValue("@line", line)
                .AddWithValue("@serial", series)
                .AddWithValue("@userin", idno)
                .AddWithValue("@datein", datedb)
            End With
            cmdinsertdmtn.ExecuteNonQuery()
            reload("SELECT `dmtn`, `partno`, `customerno`, `color`, `proddate`, `qty`, `shift`, `process`, `line`, `serial` FROM `denso_dmtn` WHERE datein='" & datedb & "'", datagrid2)
            datagrid1.Rows.Clear()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub



    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        datagrid1.Rows.Clear()

        inner_1.Hide()

        inner_2.Hide()

        inner_3.Hide()

        inner_4.Hide()

        inner_5.Hide()

        inner_6.Hide()

        inner_7.Hide()

        inner_8.Hide()
        controlIndex = 0
        lbl_count.Text = "0"
        lbl_qty.Text = "0"
    End Sub


    Private Sub lbl_count_TextChanged(sender As Object, e As EventArgs) Handles lbl_count.TextChanged
        If lbl_count.Text = "8" Then
            txtqr_fg.Enabled = True
            txtqr.Enabled = False

        Else
            txtqr_fg.Enabled = False
            txtqr.Enabled = True
        End If
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtqr_TextChanged(sender As Object, e As EventArgs) Handles txtqr.TextChanged

    End Sub

    Private Sub lbl_count_Click(sender As Object, e As EventArgs) Handles lbl_count.Click

    End Sub

    Private Sub txtqr_fg_TextChanged(sender As Object, e As EventArgs) Handles txtqr_fg.TextChanged

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class