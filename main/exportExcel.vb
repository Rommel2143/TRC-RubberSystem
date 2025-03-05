Imports ClosedXML.Excel
Imports System.IO

Module exportExcel

    Public Sub exporttoExcel(datagrid As Object) 'Guna.UI2.WinForms.Guna2DataGridView
        Try
            If datagrid.Rows.Count = 0 Then
                MessageBox.Show("No data available to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dt As New DataTable()

            ' Adding the Columns
            For Each column As DataGridViewColumn In datagrid.Columns
                dt.Columns.Add(column.HeaderText, GetType(String)) ' Force all columns as String
            Next

            ' Adding the Rows
            For Each row As DataGridViewRow In datagrid.Rows
                If Not row.IsNewRow Then
                    Dim newRow As DataRow = dt.NewRow()
                    For Each cell As DataGridViewCell In row.Cells
                        ' Convert all values to String, handling NULL values
                        newRow(cell.ColumnIndex) = If(cell.Value IsNot Nothing AndAlso Not IsDBNull(cell.Value), cell.Value.ToString(), "")
                    Next
                    dt.Rows.Add(newRow)
                End If
            Next

            ' Save the data to an Excel file
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Excel Workbook|*.xlsx"
                sfd.Title = "Save an Excel File"
                sfd.FileName = "" ' Default file name

                If sfd.ShowDialog() = DialogResult.OK AndAlso Not String.IsNullOrWhiteSpace(sfd.FileName) Then
                    ' Check if file already exists
                    If File.Exists(sfd.FileName) Then
                        Dim result As DialogResult = MessageBox.Show("The file already exists. Do you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result <> DialogResult.Yes Then Return
                    End If

                    Using wb As New XLWorkbook()
                        wb.Worksheets.Add(dt, "Sheet1")
                        wb.SaveAs(sfd.FileName)
                    End Using

                    MessageBox.Show("Data successfully exported to Excel.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module