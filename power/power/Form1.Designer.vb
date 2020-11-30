<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox_H = New System.Windows.Forms.TextBox()
        Me.TextBox_B = New System.Windows.Forms.TextBox()
        Me.TextBox_L = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 250)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "坐标系"
        '
        'RadioButton4
        '
        Me.RadioButton4.Location = New System.Drawing.Point(28, 192)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.RadioButton4.Size = New System.Drawing.Size(400, 50)
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Krassovsky"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(28, 136)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.RadioButton3.Size = New System.Drawing.Size(400, 50)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "IUGG75"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(28, 80)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.RadioButton2.Size = New System.Drawing.Size(400, 50)
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.Text = "WGS84"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(28, 24)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.RadioButton1.Size = New System.Drawing.Size(400, 50)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "CGCS2000"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox_H)
        Me.GroupBox2.Controls.Add(Me.TextBox_B)
        Me.GroupBox2.Controls.Add(Me.TextBox_L)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 318)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(450, 208)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "输入"
        '
        'TextBox_H
        '
        Me.TextBox_H.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_H.Location = New System.Drawing.Point(134, 163)
        Me.TextBox_H.Name = "TextBox_H"
        Me.TextBox_H.Size = New System.Drawing.Size(200, 25)
        Me.TextBox_H.TabIndex = 1
        '
        'TextBox_B
        '
        Me.TextBox_B.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_B.Location = New System.Drawing.Point(134, 91)
        Me.TextBox_B.Name = "TextBox_B"
        Me.TextBox_B.Size = New System.Drawing.Size(200, 25)
        Me.TextBox_B.TabIndex = 1
        '
        'TextBox_L
        '
        Me.TextBox_L.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_L.Location = New System.Drawing.Point(134, 24)
        Me.TextBox_L.Name = "TextBox_L"
        Me.TextBox_L.Size = New System.Drawing.Size(200, 25)
        Me.TextBox_L.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(28, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "H："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(28, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "B："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(344, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(100, 25)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "M"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(340, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "D.MMSS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(340, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "D.MMSS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(28, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "L："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(39, 38)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox4.Size = New System.Drawing.Size(390, 440)
        Me.TextBox4.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Location = New System.Drawing.Point(525, 551)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(456, 80)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "计算"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Location = New System.Drawing.Point(525, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(456, 498)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "输出"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton6)
        Me.GroupBox4.Controls.Add(Me.RadioButton5)
        Me.GroupBox4.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox4.Location = New System.Drawing.Point(30, 551)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(450, 80)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "命令"
        '
        'RadioButton6
        '
        Me.RadioButton6.Location = New System.Drawing.Point(225, 24)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.RadioButton6.Size = New System.Drawing.Size(225, 50)
        Me.RadioButton6.TabIndex = 0
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "XYZ to LBH"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Location = New System.Drawing.Point(0, 24)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Padding = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.RadioButton5.Size = New System.Drawing.Size(225, 50)
        Me.RadioButton5.TabIndex = 0
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "LBH to XYZ"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1006, 643)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "坐标转换"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox_H As TextBox
    Friend WithEvents TextBox_B As TextBox
    Friend WithEvents TextBox_L As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
End Class
