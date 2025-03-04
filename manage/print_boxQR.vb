Imports QRCoder
Imports System.IO
Public Class print_boxQR
    Dim dt_small As New DataTable
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        small_initializedata()
    End Sub

    Private Sub loadrpt_small()
        'Dim myrpt As New print_serial
        Dim myrpt As New boxQR
        ' Check if dt_records contains data
        If dt_small Is Nothing OrElse dt_small.Rows.Count = 0 Then
            MessageBox.Show("No data available for the report.")
            Exit Sub
        End If

        ' Clear existing report source
        CrystalReportViewer1.ReportSource = Nothing

        Try
            myrpt.SetDataSource(dt_small)
            CrystalReportViewer1.ReportSource = myrpt
        Catch ex As Exception
            MessageBox.Show("Error setting report data source: " & ex.Message)
        End Try
    End Sub
    Private Sub small_initializedata()
        Try
            Dim startNum, endNum As Integer
            If Not Integer.TryParse(txt_start.Text, startNum) OrElse Not Integer.TryParse(txt_end.Text, endNum) Then
                MessageBox.Show("Invalid start or end number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim content As String = "TRC-" & cmb_section.Text.Substring(0, 1) & cmb_size.Text.Substring(0, 1)
            dt_small.Clear()

            ' Generate QR codes and fill DataTable
            For i As Integer = startNum To endNum
                Dim contentqr As String = content & "-" & i
                Dim qrImage As Image = GenerateQRCode(contentqr)
                Dim qrImageBytes As Byte() = ImageToByteArray(qrImage)
                dt_small.Rows.Add(content, qrImageBytes, i)
            Next

            ' Load the report
            loadrpt_small()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Function GenerateQRCode(serial As String) As Bitmap
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(serial, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)
        Return qrCode.GetGraphic(20)
    End Function
    Private Function ImageToByteArray(image As Image) As Byte()
        Using ms As New MemoryStream()
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub print_boxQR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt_small.Columns.Add("content", GetType(String))
        dt_small.Columns.Add("qrcode", GetType(Byte()))
        dt_small.Columns.Add("serial", GetType(String))
    End Sub

End Class