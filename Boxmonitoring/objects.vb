Imports Guna.UI2.WinForms
Module objects


    Public Sub addobject_group(parentPanel As Panel, partname As String, partcode As String, qty As Integer, count As Integer)
        ' Create a new panel
        Dim childPanel As New Guna2Panel()

        ' Set properties for the child panel
        With childPanel

            .Width = 400
            .Height = 120
            .FillColor = Color.White
            .Margin = New Padding(10)
            .BorderThickness = 1
            .BorderRadius = 5
            .BorderColor = Color.MidnightBlue
        End With

        Dim partnameLabel As New Label()
        With partnameLabel
            .Font = New Font("Segoe UI", 14, FontStyle.Bold)
            .BackColor = Color.White
            .ForeColor = Color.Black
            .AutoSize = True
            .Text = partname

            .Location = New Point(10, 20)
        End With

        Dim partcodeLabel As New Label()
        With partcodeLabel
            .Font = New Font("Segoe UI", 14)
            .BackColor = Color.White
            .ForeColor = Color.Black
            .AutoSize = True
            .Text = partcode

            .Location = New Point(10, 40)
        End With

        Dim qtyLabel As New Label()
        With qtyLabel
            .Font = New Font("Segoe UI", 15)
            .BackColor = Color.White
            .ForeColor = Color.Black
            .AutoSize = True
            .Text = "Total : " & qty.ToString
            .Location = New Point(15, 75)
        End With

        Dim countLabel As New Label()
        With countLabel
            .Font = New Font("Segoe UI", 15)
            .BackColor = Color.White
            .ForeColor = Color.Black
            .AutoSize = True
            .Text = "Box Count : " & count.ToString
            .Location = New Point(200, 75)
        End With

        childPanel.Controls.Add(partnameLabel)
        childPanel.Controls.Add(partcodeLabel)
        childPanel.Controls.Add(qtyLabel)
        childPanel.Controls.Add(countLabel)
        parentPanel.Controls.Add(childPanel)
    End Sub

    Public Sub addobject_line(parentPanel As Panel, line As String, status As String)
        ' Create a new panel
        Dim childPanel As New Guna2Panel()

        ' Set properties for the child panel
        With childPanel
            .Width = 300
            .Height = 120
            .FillColor = Color.White
            .Margin = New Padding(10)
            .BorderThickness = 1
            .BorderRadius = 5
            .BorderColor = Color.MidnightBlue
        End With

        ' Create and configure the line name label
        Dim linename As New Label()
        With linename
            .Font = New Font("Segoe UI", 14, FontStyle.Bold)
            .BackColor = Color.White
            .ForeColor = Color.Black
            .AutoSize = True
            .Text = line
            .Location = New Point(10, 20)
        End With

        ' Create and configure the status label
        Dim statuslabel As New Label()
        With statuslabel
            .Font = New Font("Segoe UI", 14)
            .BackColor = Color.White
            .ForeColor = Color.Black
            .AutoSize = True
            .Text = status
            .Location = New Point(10, 40)
        End With

        ' Add labels to the child panel
        childPanel.Controls.Add(linename)
        childPanel.Controls.Add(statuslabel)

        ' Add the child panel to the parent panel
        parentPanel.Controls.Add(childPanel)

        ' Attach a Click event handler to the child panel
        AddHandler childPanel.Click, AddressOf ChildPanel_Click
    End Sub

    Private Sub ChildPanel_Click(sender As Object, e As EventArgs)
        ' Cast the sender to a Guna2Panel
        'Dim clickedPanel As Guna2Panel = TryCast(sender, Guna2Panel)

        'If clickedPanel IsNot Nothing Then

        '    Dim lineNameLabel As Label = TryCast(clickedPanel.Controls(0), Label)
        '    If lineNameLabel IsNot Nothing Then
        '        Dim lineName As String = lineNameLabel.Text
        '        Dim partsform As New parts_line_scan
        '        partsform.loadparts(lineName)
        '        partsform.ShowDialog()

        '    End If
        'End If
    End Sub

End Module
