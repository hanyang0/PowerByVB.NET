Imports System.Math
Public Class MainForm
    Dim PtA, PtB, PtC, PtD As ControlPoint '控制点
    Dim HelpString As String
    Dim PutinDataStr() As String
    Dim PutDataStr(24) As String

    Sub ModeChange()  '输入模式改变事件
        If RadioButton1.Checked = True Then
            Button1.Text = "开始导入"
            Label1.Text = "请按开始导入数据"
            GroupBox5.Text = "输入(导入文件)"
            ToolStripStatusLabel2.Text = "输入模式：导入文件模式。请单击开始导入按钮开始导入数据"
        Else
            Button1.Text = "开始输入"
            Label1.Text = "请按提示依次输入"
            GroupBox5.Text = "输入(手动输入)"
            ToolStripStatusLabel2.Text = "输入模式：手动输入模式。请单击开始输入按钮，按照提示开始输入数据"
        End If
        TextBox1.Enabled = False
        TextBox1.Visible = False
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub



    Sub OutputData()    'textbox2输出
        TextBox2.Text = vbCrLf + "               ----- 输入数据表 -----" + vbCrLf + vbCrLf
        TextBox2.Text &= String.Format("摄影机主距 f：{0}", f) + vbCrLf + vbCrLf
        TextBox2.Text &= PtA.PtInfo() & PtB.PtInfo() & PtC.PtInfo() & PtD.PtInfo()
    End Sub
    Sub AutoOutputData()  '导入文件的数据存放
        Call InputDataFile(New OpenFileDialog)
        If DataStream = Nothing Then
            Exit Sub
        End If
        If DataStr.Length <> 25 Then
            MsgBox("数据格式不匹配！" + vbCrLf + "请检查并重新组织数据。", 0 + 16 + 0, "错误提示")
            Exit Sub
        End If
        f = Val(DataStr$(0))
        PtA = New ControlPoint : PtB = New ControlPoint : PtC = New ControlPoint : PtD = New ControlPoint
        PtA.Name = Val(DataStr$(1)) : PtA.XCoorX = Val(DataStr$(2)) : PtA.XCoorY = Val(DataStr$(3)) : PtA.WCoorX = Val(DataStr$(4)) : PtA.WCoorY = Val(DataStr$(5)) : PtA.WCoorZ = Val(DataStr$(6))
        PtB.Name = Val(DataStr$(7)) : PtB.XCoorX = Val(DataStr$(8)) : PtB.XCoorY = Val(DataStr$(9)) : PtB.WCoorX = Val(DataStr$(10)) : PtB.WCoorY = Val(DataStr$(11)) : PtB.WCoorZ = Val(DataStr$(12))
        PtC.Name = Val(DataStr$(13)) : PtC.XCoorX = Val(DataStr$(14)) : PtC.XCoorY = Val(DataStr$(15)) : PtC.WCoorX = Val(DataStr$(16)) : PtC.WCoorY = Val(DataStr$(17)) : PtC.WCoorZ = Val(DataStr$(18))
        PtD.Name = Val(DataStr$(19)) : PtD.XCoorX = Val(DataStr$(20)) : PtD.XCoorY = Val(DataStr$(21)) : PtD.WCoorX = Val(DataStr$(22)) : PtD.WCoorY = Val(DataStr$(23)) : PtD.WCoorZ = Val(DataStr$(24))
        Call OutputData()  '导入结果输出
        Button1.Text = "开始计算"
        ToolStripStatusLabel2.Text = "导入文件完成。请检查导入数据表后，单击开始计算按钮开始计算"
    End Sub



    Sub OutPut()    '计算结果输出
        TextBox3.Text &= vbCrLf & String.Format("外方位元素:") & vbCrLf
        For i = 0 To 5
            TextBox3.Text &= Unknownum(i) & "   "
        Next


        TextBox3.Text &= vbCrLf & String.Format("精度评价方程") & vbCrLf
        For j = 0 To 5
            For i = 0 To 5
                UnKnown(j, i) = Sqrt(Abs(UnKnow(j) * UnKnow(i)) / (2 * GCPNUMBER - 6))
                TextBox3.Text &= UnKnown(j, i) & "   "
            Next
            TextBox3.Text &= vbCrLf
        Next

        ToolStripStatusLabel2.Text = "计算完成，请保存结果"
        CmputRst = TextBox2.Text & vbCrLf & TextBox3.Text
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click '快捷栏开始计算事件
        If Button1.Text = "开始计算" Then
            Call Calculat()
            Call OutPut()
        Else MsgBox("请输入数据后点击", vbOKOnly, "提示")
        End If
    End Sub

    Private Sub 导出文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出文件ToolStripMenuItem.Click '菜单栏导出事件
        If TextBox3.Text <> "" Then
            OutputRsutFile(New SaveFileDialog)
        End If
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click '菜单栏退出事件
        If MsgBox("你确认要退出程序吗？", MsgBoxStyle.OkCancel, "退出提示") = MsgBoxResult.Cancel Then
        Else End
        End If
    End Sub

    Private Sub 关于应用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于应用ToolStripMenuItem.Click '菜单栏关于事件
        MsgBox("《VB.NET测量程序设计》课程设计题目" & vbCrLf & "空间后方交会解影像方位元素" & vbCrLf & "2018011第11组作品" & vbCrLf & "组员：" & vbCrLf & "201801131常志鹏" & vbCrLf & "201801132黄义超" & vbCrLf & "201801133韩    洋" & vbCrLf & "201801134廉年刚", vbOKOnly, "关于应用")
    End Sub

    Private Sub 帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 帮助ToolStripMenuItem.Click '菜单栏帮助事件
        MsgBox("请根据左下角提示完成操作", vbOKOnly, "帮助")
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load '窗口初始化
        ModeChange()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ModeChange()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ModeChange()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click '快捷栏导出文件事件
        If TextBox3.Text <> "" Then
            OutputRsutFile(New SaveFileDialog)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click '快捷栏重新输入事件
        ModeChange()
    End Sub

    Private Sub 重新输入ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重新输入ToolStripMenuItem.Click '菜单栏重新输入事件
        ModeChange()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case Button1.Text
            Case Is = "开始输入" '手动输入模式，开始输入
                TextBox1.Enabled = True
                TextBox1.Visible = True
                Button1.Text = "确认"
                HelpString = "摄影机主距 f"
                Label1.Text = HelpString
                ToolStripStatusLabel2.Text = "请输入" & HelpString & ",并点击确认"
            Case Is = "开始导入"   '文件导入模式，导入文件
                Call AutoOutputData()
            Case Is = "开始计算"
                Call Calculat()   '文件导入模式，计算外方元素
                Call OutPut()
            Case Is = "确认"
                If TextBox1.Text <> "" Then
                    Select Case Label1.Text
                        Case "摄影机主距 f"

                            f = Val(TextBox1.Text) '手动输入f
                            TextBox2.Text = vbCrLf + "               ----- 输入数据表 -----" + vbCrLf + vbCrLf
                            TextBox2.Text &= String.Format("摄影机主距 f：{0}", f) + vbCrLf + vbCrLf
                            TextBox1.Text = ""
                            HelpString = "控制点1信息"
                            Label1.Text = HelpString
                            ToolStripStatusLabel2.Text = "请输入" & HelpString & ",并点击确认。" & "格式：控制点号,像点x,像点y,物点X,物点Y,物点Z"
                            PutDataStr(0) = f
                        Case "控制点1信息"
                            PutinDataStr = TextBox1.Text.Split(",")
                            PtA = New ControlPoint  '手动输入控制点1信息
                            PtA.Name = Val(PutinDataStr$(0)) : PtA.XCoorX = Val(PutinDataStr$(1)) : PtA.XCoorY = Val(PutinDataStr$(2)) : PtA.WCoorX = Val(PutinDataStr$(3)) : PtA.WCoorY = Val(PutinDataStr$(4)) : PtA.WCoorZ = Val(PutinDataStr$(5))
                            For i = 0 To 5
                                PutDataStr(i + 1) = PutinDataStr(i)
                            Next
                            TextBox2.Text &= PtA.PtInfo()
                            TextBox1.Text = ""
                            HelpString = "控制点2信息"
                            Label1.Text = HelpString
                            ToolStripStatusLabel2.Text = "请输入" & HelpString & ",并点击确认。" & "格式：控制点号,像点x,像点y,物点X,物点Y,物点Z"
                        Case "控制点2信息"
                            PutinDataStr = TextBox1.Text.Split(",") '手动输入控制点2信息
                            PtB = New ControlPoint
                            PtB.Name = Val(PutinDataStr$(0)) : PtB.XCoorX = Val(PutinDataStr$(1)) : PtB.XCoorY = Val(PutinDataStr$(2)) : PtB.WCoorX = Val(PutinDataStr$(3)) : PtB.WCoorY = Val(PutinDataStr$(4)) : PtB.WCoorZ = Val(PutinDataStr$(5))
                            For i = 0 To 5
                                PutDataStr(i + 7) = PutinDataStr(i)
                            Next
                            TextBox2.Text &= PtB.PtInfo()
                            TextBox1.Text = ""
                            HelpString = "控制点3信息"
                            Label1.Text = HelpString
                            ToolStripStatusLabel2.Text = "请输入" & HelpString & ",并点击确认。" & "格式：控制点号,像点x,像点y,物点X,物点Y,物点Z"
                        Case "控制点3信息"
                            PutinDataStr = TextBox1.Text.Split(",") '手动输入控制点3信息
                            PtC = New ControlPoint
                            PtC.Name = Val(PutinDataStr$(0)) : PtC.XCoorX = Val(PutinDataStr$(1)) : PtC.XCoorY = Val(PutinDataStr$(2)) : PtC.WCoorX = Val(PutinDataStr$(3)) : PtC.WCoorY = Val(PutinDataStr$(4)) : PtC.WCoorZ = Val(PutinDataStr$(5))
                            For i = 0 To 5
                                PutDataStr(i + 13) = PutinDataStr(i)
                            Next
                            TextBox2.Text &= PtC.PtInfo()
                            TextBox1.Text = ""
                            HelpString = "控制点4信息"
                            Label1.Text = HelpString
                        Case "控制点4信息"
                            PutinDataStr = TextBox1.Text.Split(",") '手动输入控制点4信息
                            PtD = New ControlPoint
                            PtD.Name = Val(PutinDataStr$(0)) : PtD.XCoorX = Val(PutinDataStr$(1)) : PtD.XCoorY = Val(PutinDataStr$(2)) : PtD.WCoorX = Val(PutinDataStr$(3)) : PtD.WCoorY = Val(PutinDataStr$(4)) : PtD.WCoorZ = Val(PutinDataStr$(5))
                            For i = 0 To 5
                                PutDataStr(i + 19) = PutinDataStr(i)
                            Next
                            TextBox2.Text &= PtD.PtInfo()
                            TextBox1.Text = ""
                            TextBox1.Enabled = False
                            TextBox1.Visible = False
                            HelpString = "输入完成"
                            Label1.Text = HelpString
                            Button1.Text = "开始计算"
                            DataStr = PutDataStr
                    End Select

                End If

        End Select
    End Sub

End Class
