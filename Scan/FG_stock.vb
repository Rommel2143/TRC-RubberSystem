﻿Imports MySql.Data.MySqlClient
Imports ClosedXML.Excel
Imports Guna.Charts.WinForms
Public Class FG_stock
    Private Sub export_excel_Click(sender As Object, e As EventArgs) Handles export_excel.Click
        Try
            If datagrid1.Rows.Count > 0 Then
                Dim dt As New DataTable()

                ' Adding the Columns
                For Each column As DataGridViewColumn In datagrid1.Columns
                    dt.Columns.Add(column.HeaderText, column.ValueType)
                Next

                ' Adding the Rows
                For Each row As DataGridViewRow In datagrid1.Rows
                    If Not row.IsNewRow Then
                        dt.Rows.Add()
                        For Each cell As DataGridViewCell In row.Cells
                            dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
                        Next
                    End If
                Next

                ' Save the data to an Excel file
                Using sfd As New SaveFileDialog()
                    sfd.Filter = "Excel Workbook|*.xlsx"
                    sfd.Title = "Save an Excel File"
                    sfd.ShowDialog()

                    If sfd.FileName <> "" Then
                        Using wb As New XLWorkbook()
                            wb.Worksheets.Add(dt, "Sheet1")
                            wb.SaveAs(sfd.FileName)
                        End Using
                        MessageBox.Show("Data successfully exported to Excel.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Else
                MessageBox.Show("No data available to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FG_stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rubber_stock()
    End Sub

    Private Sub rubber_stock()
        Try
            con.Close()
            con.Open()
            Dim cmdrubber_stock As New MySqlCommand("SELECT fm.partname,fs.partcode,SUM(fs.qty) AS TOTAL_Stock FROM `rubber_stock` fs 
                                                    JOIN rubber_masterlist fm ON fm.partcode=fs.partcode
                                                    WHERE fs.status='IN'
                                                    GROUP BY fs.partcode", con)

            Dim da As New MySqlDataAdapter(cmdrubber_stock)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid1.DataSource = dt


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            con.Close()
        End Try
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            con.Close()
            con.Open()
            Dim cmdrubber_stock As New MySqlCommand("SELECT fm.partname,fs.partcode,SUM(fs.qty) AS TOTAL_Stock FROM `rubber_stock` fs 
                                                    JOIN rubber_masterlist fm ON fm.partcode=fs.partcode
                                                    WHERE fs.status='IN' and (fm.partname REGEXP '" & txt_search.Text & "' or fs.partcode REGEXP '" & txt_search.Text & "')
                                                    GROUP BY fs.partcode", con)

            Dim da As New MySqlDataAdapter(cmdrubber_stock)
            Dim dt As New DataTable
            da.Fill(dt)
            datagrid1.DataSource = dt


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            con.Close()
        End Try
    End Sub
    Private Sub GunaChart1_Load(sender As Object, e As EventArgs) Handles GunaChart1.Load
        ' Clear previous data
        GunaChart1.Datasets.Clear()

        ' Dictionary to hold datasets for each partcode
        Dim datasets As New Dictionary(Of String, Guna.Charts.WinForms.GunaStackedHorizontalBarDataset)

        ' Database query to get dateout and SUM(qty)
        Dim query As String = "SELECT pm.partname, DATE_FORMAT(ps.dateout, '%m/%d/%Y') AS dateout, SUM(ps.qty) AS TotalQty " &
                      "FROM rubber_stock ps " &
                      "JOIN rubber_masterlist pm ON pm.partcode = ps.partcode " &
                      "WHERE ps.dateout IS NOT NULL " &
                      "GROUP BY dateout, pm.partname " &
                      "ORDER BY dateout DESC"


        Try
            con.Open()
            Using cmd As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Get partcode and formatted dateout
                        Dim partname As String = reader("partname").ToString()
                        Dim dateout As String = reader("dateout").ToString()
                        Dim qty As Integer = Convert.ToInt32(reader("TotalQty"))

                        ' Create a new dataset for the partcode if it doesn't exist
                        If Not datasets.ContainsKey(partname) Then
                            Dim dataset As New Guna.Charts.WinForms.GunaStackedHorizontalBarDataset()
                            dataset.Label = partname
                            datasets(partname) = dataset
                            GunaChart1.Datasets.Add(dataset) ' Add to the chart
                        End If

                        ' Add the quantity to the respective dataset
                        datasets(partname).DataPoints.Add(dateout, qty)





                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' Update the chart
        GunaChart1.Update()
    End Sub

    'Private Sub GunaChart2_Load(sender As Object, e As EventArgs) Handles GunaChart2.Load
    '    ' Clear previous data
    '    GunaChart2.Datasets.Clear()

    '    ' Dictionary to hold datasets for each partcode
    '    Dim datasets As New Dictionary(Of String, Guna.Charts.WinForms.GunaStackedHorizontalBarDataset)

    '    ' Database query to get dateout and SUM(qty)
    '    Dim query As String = "SELECT pm.partname, DATE_FORMAT(ps.datein, '%m/%d/%Y') AS DateIN, SUM(ps.qty) AS TotalQty " &
    '                  "FROM rubber_stock ps " &
    '                  "JOIN rubber_masterlist pm ON pm.partcode = ps.partcode " &
    '                  "WHERE ps.datein IS NOT NULL " &
    '                  "GROUP BY datein, pm.partname " &
    '                  "ORDER BY datein DESC"


    '    Try
    '        con.Open()
    '        Using cmd As New MySqlCommand(query, con)
    '            Using reader As MySqlDataReader = cmd.ExecuteReader()
    '                While reader.Read()
    '                    ' Get partcode and formatted dateout
    '                    Dim partname As String = reader("partname").ToString()
    '                    Dim dateout As String = reader("datein").ToString()
    '                    Dim qty As Integer = Convert.ToInt32(reader("TotalQty"))

    '                    ' Create a new dataset for the partcode if it doesn't exist
    '                    If Not datasets.ContainsKey(partname) Then
    '                        Dim dataset As New Guna.Charts.WinForms.GunaStackedHorizontalBarDataset()
    '                        dataset.Label = partname
    '                        datasets(partname) = dataset
    '                        GunaChart2.Datasets.Add(dataset) ' Add to the chart

    '                    End If

    '                    ' Add the quantity to the respective dataset
    '                    datasets(partname).DataPoints.Add(dateout, qty)

    '                    ' Add total quantity as a tooltip
    '                    datasets(partname).DataPoints.Last().Tooltip = "Total Qty: " & qty.ToString()

    '                End While
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Error loading data: " & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try

    '    ' Update the chart
    '    GunaChart2.Update()
    'End Sub
    Private Sub GunaChart2_Load(sender As Object, e As EventArgs) Handles GunaChart2.Load
        ' Clear previous data
        GunaChart2.Datasets.Clear()

        ' Dictionary to hold datasets for each partname
        Dim datasets As New Dictionary(Of String, Guna.Charts.WinForms.GunaStackedHorizontalBarDataset)

        ' Database query to get dateout and SUM(qty)
        Dim query As String = "SELECT pm.partname, DATE_FORMAT(ps.datein, '%m/%d/%Y') AS DateIN, SUM(ps.qty) AS TotalQty " &
                          "FROM rubber_stock ps " &
                          "JOIN rubber_masterlist pm ON pm.partcode = ps.partcode " &
                          "WHERE ps.datein IS NOT NULL " &
                          "GROUP BY datein, pm.partname " &
                          "ORDER BY datein DESC"

        Try
            con.Open()
            Using cmd As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Get partname and formatted datein
                        Dim partname As String = reader("partname").ToString()
                        Dim datein As String = reader("DateIN").ToString()
                        Dim qty As Integer

                        ' Use TryParse for safe conversion
                        If Not Integer.TryParse(reader("TotalQty").ToString(), qty) Then
                            MessageBox.Show("Invalid quantity data for part: " & partname)
                            Continue While ' Skip to the next record
                        End If

                        ' Create a new dataset for the partname if it doesn't exist
                        If Not datasets.ContainsKey(partname) Then
                            Dim dataset As New Guna.Charts.WinForms.GunaStackedHorizontalBarDataset()
                            dataset.Label = partname
                            datasets(partname) = dataset
                            GunaChart2.Datasets.Add(dataset) ' Add to the chart
                        End If

                        ' Add the quantity to the respective dataset
                        datasets(partname).DataPoints.Add(datein, qty)

                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' Update the chart
        GunaChart2.Update()
    End Sub

End Class