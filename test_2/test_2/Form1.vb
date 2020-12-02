Public Class 坐标反算
    Dim addpoint1 As New ControlPoint
    Dim addpoint2 As New ControlPoint
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox4.Text = "" Then
            addpoint1.Name = TextBox2.Text
            addpoint1.PtType = CheckBox1.CheckState
            addpoint1.CoorX = Val(TextBox1.Text)
            addpoint1.CoorY = Val(TextBox3.Text)
            TextBox4.Text = addpoint1.PtInfo() & vbCrLf
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Else
            addpoint2.Name = TextBox2.Text
            addpoint2.PtType = CheckBox1.CheckState
            addpoint2.CoorX = Val(TextBox1.Text)
            addpoint2.CoorY = Val(TextBox3.Text)
            TextBox4.Text &= addpoint2.PtInfo() & vbCrLf
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim side1 As New Side
        side1.StaPt = addpoint1
        side1.EndPt = addpoint2
        TextBox4.Text &= "边名：" & side1.Name & vbCrLf
        TextBox4.Text &= "边长：" & side1.Length & vbCrLf
        TextBox4.Text &= "方位角：" & AngConver.RadToDMSstr(side1.Azimuth) & vbCrLf
        Button2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox4.Text = ""
    End Sub
End Class
