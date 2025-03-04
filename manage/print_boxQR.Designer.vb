<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class print_boxQR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmb_section = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmb_size = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txt_start = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txt_end = New Guna.UI2.WinForms.Guna2TextBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_section
        '
        Me.cmb_section.BackColor = System.Drawing.Color.Transparent
        Me.cmb_section.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_section.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_section.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_section.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmb_section.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmb_section.ItemHeight = 30
        Me.cmb_section.Items.AddRange(New Object() {"R : Rubber", "T : Tubepump"})
        Me.cmb_section.Location = New System.Drawing.Point(42, 34)
        Me.cmb_section.Name = "cmb_section"
        Me.cmb_section.Size = New System.Drawing.Size(172, 36)
        Me.cmb_section.TabIndex = 0
        '
        'cmb_size
        '
        Me.cmb_size.BackColor = System.Drawing.Color.Transparent
        Me.cmb_size.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_size.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_size.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmb_size.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmb_size.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmb_size.ItemHeight = 30
        Me.cmb_size.Items.AddRange(New Object() {"B : Big", "M : Medium", "S : Small"})
        Me.cmb_size.Location = New System.Drawing.Point(235, 34)
        Me.cmb_size.Name = "cmb_size"
        Me.cmb_size.Size = New System.Drawing.Size(172, 36)
        Me.cmb_size.TabIndex = 1
        '
        'txt_start
        '
        Me.txt_start.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_start.DefaultText = ""
        Me.txt_start.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_start.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_start.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_start.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_start.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_start.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_start.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_start.Location = New System.Drawing.Point(535, 34)
        Me.txt_start.Name = "txt_start"
        Me.txt_start.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_start.PlaceholderText = ""
        Me.txt_start.SelectedText = ""
        Me.txt_start.Size = New System.Drawing.Size(97, 36)
        Me.txt_start.TabIndex = 2
        '
        'txt_end
        '
        Me.txt_end.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_end.DefaultText = ""
        Me.txt_end.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_end.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_end.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_end.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_end.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_end.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_end.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_end.Location = New System.Drawing.Point(662, 34)
        Me.txt_end.Name = "txt_end"
        Me.txt_end.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_end.PlaceholderText = ""
        Me.txt_end.SelectedText = ""
        Me.txt_end.Size = New System.Drawing.Size(97, 36)
        Me.txt_end.TabIndex = 3
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 126)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1195, 596)
        Me.CrystalReportViewer1.TabIndex = 4
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.Guna2Button1)
        Me.Guna2Panel1.Controls.Add(Me.Label4)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Controls.Add(Me.txt_end)
        Me.Guna2Panel1.Controls.Add(Me.txt_start)
        Me.Guna2Panel1.Controls.Add(Me.cmb_size)
        Me.Guna2Panel1.Controls.Add(Me.cmb_section)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1195, 126)
        Me.Guna2Panel1.TabIndex = 5
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BorderRadius = 3
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.Color.MidnightBlue
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(789, 34)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(99, 36)
        Me.Guna2Button1.TabIndex = 8
        Me.Guna2Button1.Text = "Create Sticker"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(659, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "End no."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Start no."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(232, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Box type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Section"
        '
        'print_boxQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 722)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "print_boxQR"
        Me.Text = "print_boxQR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmb_section As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmb_size As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txt_start As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txt_end As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
End Class
