Class form1

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label2.Visible = False
        TextBox2.Visible = False
        RadioButton1.Checked = True
        PictureBox1.Image = class1.My.Resources.Resources.圆
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Label2.Visible = False
        TextBox2.Visible = False
        PictureBox1.Image = class1.My.Resources.Resources.球
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label2.Visible = False
        TextBox2.Visible = False
        PictureBox1.Image = class1.My.Resources.Resources.圆
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label2.Visible = True
        TextBox2.Visible = True
        PictureBox1.Image = class1.My.Resources.Resources.圆柱
    End Sub
    WithEvents circleradius As Circle3
    WithEvents Cylinder As Cylinder
    WithEvents boll As New boll
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) > 0 Then
            If RadioButton1.Checked Then
                circleradius = New Circle3
                circleradius.Radius = TextBox1.Text
                TextBox3.Text = "圆的半径：" & circleradius.Radius & vbCrLf
                TextBox3.Text &= "面积：" & circleradius.Area & vbCrLf
                circleradius = Nothing
            End If
            If RadioButton2.Checked And Len(TextBox2.Text) > 0 Then
                Cylinder = New Cylinder
                Cylinder.Radius = TextBox1.Text
                Cylinder.Height = TextBox2.Text
                TextBox3.Text = "圆柱的半径：" & Cylinder.Radius & vbCrLf
                TextBox3.Text &= "表面积：" & Cylinder.Area & vbCrLf
                TextBox3.Text &= "体积：" & Cylinder.Volume & vbCrLf
                Cylinder = Nothing
            End If
            If RadioButton3.Checked Then
                boll = New boll
                boll.Radius = TextBox1.Text
                TextBox3.Text = "球的半径：" & boll.Radius & vbCrLf
                TextBox3.Text &= "表面积：" & boll.Area & vbCrLf
                TextBox3.Text &= "体积：" & boll.Volume & vbCrLf
                boll = Nothing
            End If
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub circleradius_RadiusErr(sender As Object) Handles circleradius.RadiusErr
        Dim mRadius As Double
        Do
            MsgBox("半径负值错误！"， 0 + 16 + 0)
            mRadius = Val(InputBox("请输入半径：", "数据输入框"))
            TextBox1.Text = mRadius
        Loop Until mRadius >= 0
        sender.Radius = mRadius
    End Sub

    Private Sub Cylinder_RadiusErr(sender As Object) Handles Cylinder.RadiusErr
        Dim mRadius As Double
        Do
            MsgBox("半径负值错误！"， 0 + 16 + 0)
            mRadius = Val(InputBox("请输入半径：", "数据输入框"))
            TextBox1.Text = mRadius
        Loop Until mRadius >= 0
        sender.Radius = mRadius
    End Sub

    Private Sub Cylinder_HeigErr(Sender As Object) Handles Cylinder.HeigErr
        Dim mheight As Double
        Do
            MsgBox("高度负值错误！"， 0 + 16 + 0)
            mheight = Val(InputBox("请输入高度：", "数据输入框"))
            TextBox2.Text = mheight
        Loop Until mheight >= 0
        Sender.Height = mheight
    End Sub

    Private Sub boll_RadiusErr(sender As Object) Handles boll.RadiusErr
        Dim mRadius As Double
        Do
            MsgBox("半径负值错误！"， 0 + 16 + 0)
            mRadius = Val(InputBox("请输入半径：", "数据输入框"))
            TextBox1.Text = mRadius
        Loop Until mRadius >= 0
        sender.Radius = mRadius
    End Sub
End Class
