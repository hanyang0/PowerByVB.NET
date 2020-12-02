Imports System.Math
Public Class Form2

    Dim angeA, angeB, angeC As Double
    Dim XP, YP As Double
    Dim X0, Y0 As Double
    Dim R As Double
    Dim D As Double
    Dim N As Double

    Private Function getange(Xa#, Xb#, Ya#, Yb#)
        Dim ange As Double
        ange = Atan((Yb - Ya) / (Xb - Xa))

        If (Xb - Xa > 0 And Yb - Ya > 0) Then
            Return PI / 2 - ange
        ElseIf (Xb - Xa > 0 And Yb - Ya < 0) Then
            Return PI / 2 - ange
        ElseIf (Xb - Xa < 0 And Yb - Ya < 0) Then
            Return 3 * PI / 2 - ange
        ElseIf (Xb - Xa < 0 And Yb - Ya > 0) Then
            Return 3 * PI / 2 - ange
        ElseIf (Xb - Xa > 0 And Yb - Ya = 0) Then
            Return PI / 2
        ElseIf (Xb - Xa < 0 And Yb - Ya = 0) Then
            Return 3 * PI / 2
        ElseIf (Xb - Xa = 0 And Yb - Ya > 0) Then
            Return 0
        ElseIf (Xb - Xa = 0 And Yb - Ya < 0) Then
            Return 2 * PI
        Else
            Return ange
        End If
    End Function

    Function CRad(ByVal DMS As Double) As Double
        Dim valuesign As Integer
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        Dim DEG As Double
        valuesign = Sign(DMS)
        DMS = DMS * valuesign
        DD = Int(DMS)
        MM = Int(((DMS) - DD) * 100)
        SS = ((DMS - DD) * 100 - MM) * 100
        DEG = DD + MM / 60 + SS / 3600
        Return (DEG * PI / 180) * valuesign
    End Function

    Private Function radtodms(rad#) As String
        Dim valuesign As Integer
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        Dim DEG As Double
        valuesign = Sign(rad)
        rad = valuesign * rad
        DEG = rad * 180 / PI
        DD = Int(DEG)
        MM = Int((DEG - DD) * 60)
        SS = ((DEG - DD) * 60 - MM) * 60
        SS = String.Format("{0:f2}", SS)

        If SS >= 60 Then
            SS -= 60
            MM += 1

        End If
        If MM >= 60 Then
            MM -= 60
            DD += 1

        End If
        If valuesign = -1 Then
            Return String.Format("-{0}°{1}′{2}″", DD, MM, SS)
        Else
            Return String.Format("{0}°{1}′{2}″", DD, MM, SS)
        End If
    End Function


    Private Function getP(ange1#, ange2#, ange3#, Xa#, Xb#, Xc#, Ya#, Yb#, Yc#) As Double
        Dim PA, PB, PC As Double
        angeA = (getange(Xa, Xc, Ya, Yc) - getange(Xa, Xb, Ya, Yb))
        angeB = (getange(Xb, Xa, Yb, Ya) - getange(Xb, Xc, Yb, Yc))
        angeC = (getange(Xc, Xb, Yc, Yb) - getange(Xc, Xa, Yc, Ya))
        PA = 1 / ((Cos(angeA) / Sin(angeA)) - (Cos(ange1) / Sin(ange1)))
        PB = 1 / ((Cos(angeB) / Sin(angeB)) - (Cos(ange2) / Sin(ange2)))
        PC = 1 / ((Cos(angeC) / Sin(angeC)) - (Cos(ange3) / Sin(ange3)))
        XP = (PA * Xa + PB * Xb + PC * Xc) / (PA + PB + PC)
        YP = (PA * Ya + PB * Yb + PC * Yc) / (PA + PB + PC)
        Return 0
    End Function

    Private Function circle(Xa#, Xb#, Xc#, Ya#, Yb#, Yc#) As Double
        Dim RA, RB, RC As Double
        RA = Xa ^ 2 + Ya ^ 2
        RB = Xb ^ 2 + Yb ^ 2
        RC = Xc ^ 2 + Yc ^ 2
        X0 = -((Ya * (RB - RC) + Yb * (RC - RA) + Yc * (RA - RB)) / (2 * (Xa * (Yb - Yc) + Xb * (Yc - Ya) + Xc * (Ya - Yb))))
        Y0 = -((Xa * (RB - RC) + Xb * (RC - RA) + Xc * (RA - RB)) / (2 * (Ya * (Xb - Xc) + Yb * (Xc - Xa) + Yc * (Xa - Xb))))
        R = Sqrt((X0 - Xa) ^ 2 + (Y0 - Ya) ^ 2)
        D = Sqrt((X0 - XP) ^ 2 + (Y0 - YP) ^ 2)
        N = Abs(D - R)
        Return 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Xa As Double = TextBoxXA.Text
        Dim Xb As Double = TextBoxXB.Text
        Dim Ya As Double = TextBoxYA.Text
        Dim Yb As Double = TextBoxYB.Text
        Dim Xc As Double = TextBoXXC.Text
        Dim Yc As Double = TextBoxYC.Text
        Dim ange1 As Double = CRad(TextBox6.Text)
        Dim ange2 As Double = CRad(TextBox7.Text)
        Dim ange3 As Double
        Dim text As String
        ange3 = 2 * PI - ange1 - ange2
        Call getP(ange1, ange2, ange3, Xa, Xb, Xc, Ya, Yb, Yc)
        Call circle(Xa, Xb, Xc, Ya, Yb, Yc)
        text = vbCrLf
        text &= "已知点坐标：" + vbCrLf
        text &= String.Format("    XA={0}", Xa) + vbCrLf
        text &= String.Format("    YA={0}", Ya) + vbCrLf + vbCrLf
        text &= String.Format("    XB={0}", Xb) + vbCrLf
        text &= String.Format("    YB={0}", Yb) + vbCrLf + vbCrLf
        text &= String.Format("    XC={0}", Xc) + vbCrLf
        text &= String.Format("    YC={0}", Yc) + vbCrLf + vbCrLf
        text &= vbCrLf
        text &= "观测角值：" + vbCrLf
        text &= String.Format("   α={0}", radtodms(ange1)) + vbCrLf
        text &= String.Format("   β={0}", radtodms(ange2)) + vbCrLf
        text &= vbCrLf
        text &= "P点坐标：" + vbCrLf
        text &= String.Format("   XP={0:f3}", XP) + vbCrLf
        text &= String.Format("   YP={0:f3}", YP) + vbCrLf
        text &= vbCrLf
        text &= "危险圆圆心坐标：" + vbCrLf
        text &= String.Format("   X0={0:f3}", X0) + vbCrLf
        text &= String.Format("   Y0={0:f3}", Y0) + vbCrLf
        text &= vbCrLf
        text &= "危险圆半径：" + vbCrLf
        text &= String.Format("   R={0}", R) + vbCrLf
        text &= vbCrLf
        text &= "P点距危险圆圆心距离DOP：" + vbCrLf
        text &= String.Format("   Dop={0}", D) + vbCrLf
        text &= vbCrLf
        text &= "差值|DOP-r|：" + vbCrLf
        text &= String.Format("   |DOP-r|={0}", N) + vbCrLf
        If (N <= R / 5) Then
            text &= vbCrLf
            text &= "不合格" + vbCrLf
        Else
            text &= vbCrLf
            text &= "合格" + vbCrLf
        End If


        TextBox1.Text = text

    End Sub


End Class
