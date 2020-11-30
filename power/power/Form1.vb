Imports System.Math
Public Class Form1
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

    Function CMDS(ByVal Rad As Double) As String
        Dim valuesign As Integer
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        Dim DEG As Double
        valuesign = Sign(Rad)
        Rad = valuesign * Rad
        DEG = Rad * 180 / PI
        DD = Int(DEG)
        MM = Int((DEG - DD) * 60)
        SS = ((DEG - DD) * 60 - MM) * 60
        SS = String.Format("{0:00.0}", SS)

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
    Function Nn(a As Double, B As Double, f As Double) As Double
        Dim e2 As Double
        Dim w As Double
        e2 = 2 * f - f * f
        w = Sqrt(1 - e2 * Sin(B) ^ 2)
        Return (a / w)
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Double
        Dim f As Double
        Dim b1 As Double
        Dim e1 As Double
        Dim x1 As Double
        Dim textout As String = "CGCS2000"
        If (TextBox_B.TextLength > 0 And TextBox_H.TextLength > 0 And TextBox_L.TextLength > 0) Then

            If (RadioButton1.Checked) Then
                a = 6378137
                x1 = 298.257222101
                b1 = 6356752.31414036
                e1 = 0.0818191910428081
                textout = "CGCS2000"
            ElseIf (RadioButton2.Checked) Then
                a = 6378137
                x1 = 298.257223563
                b1 = 6356752.31424518
                e1 = 0.0818191908426203
                textout = "WGS84"
            ElseIf (RadioButton3.Checked) Then
                a = 6378140
                x1 = 298.257
                b1 = 6356755.28815753
                e1 = 0.0818192214555198
                textout = "IUGG75"
            ElseIf (RadioButton4.Checked) Then
                a = 6378245
                x1 = 298.3
                b1 = 6356863.01877305
                e1 = 0.081813334016926
                textout = "Krassovsky"
            End If
            f = 1 / x1
            If RadioButton5.Checked Then
                Dim B As Double = CRad(TextBox_B.Text)
                Dim L As Double = CRad(TextBox_L.Text)
                Dim H As Double = Val(TextBox_H.Text)
                Dim N As Double = Nn(a, B, f)
                Dim X, Y, Z As Double
                X = (N + H) * Cos(B) * Cos(L)
                Y = (N + H) * Cos(B) * Sin(L)
                Z = (N * (1 - (2 * f - f * f)) + H) * Sin(B)
                TextBox4.Text = vbCrLf & "Elipsoid Name: " & textout & vbCrLf
                TextBox4.Text &= "a=" & a & vbCrLf & "b=" & b1 & vbCrLf
                TextBox4.Text &= vbCrLf & "f=" & f & vbCrLf & "e=" & e1 & vbCrLf
                TextBox4.Text &= vbCrLf & "L=" & CMDS(L) & vbCrLf & "B=" & CMDS(B) & vbCrLf & "H=" & H & "M" & vbCrLf
                TextBox4.Text &= vbCrLf & "X=" & String.Format("{0:0.000}", X) & vbCrLf & "Y=" & String.Format("{0:0.000}", Y) & vbCrLf & "Z=" & String.Format("{0:0.000}", Z) & vbCrLf
            ElseIf RadioButton6.Checked Then
                Dim X As Double = TextBox_L.Text
                Dim Y As Double = TextBox_B.Text
                Dim Z As Double = TextBox_H.Text
                Dim e2 As Double = 2 * f - f ^ 2
                Dim tanB0, tanB1 As Double
                Dim L, H As Double
                L = Atan(Y / X)
                tanB0 = Z / (Sqrt(X ^ 2 + Y ^ 2))
                tanB1 = (1 / Sqrt(X ^ 2 + Y ^ 2)) * (Z + (a * e2 * tanB0) / (Sqrt(1 + tanB0 ^ 2 - e2 * tanB0 ^ 2)))
                Do While Abs(tanB1 - tanB0) >= 0.0000001
                    tanB0 = tanB1
                    tanB1 = (1 / Sqrt(X ^ 2 + Y ^ 2)) * (Z + (a * e2 * tanB0) / (Sqrt(1 + tanB0 ^ 2 - e2 * tanB0 ^ 2)))
                Loop
                Dim B As Double = Atan(tanB1)
                H = Sqrt(X ^ 2 + Y ^ 2) / Cos(B) - Nn(a, B, f)
                TextBox4.Text = vbCrLf & "Elipsoid Name: " & textout & vbCrLf
                TextBox4.Text &= "a=" & a & vbCrLf & "b=" & b1 & vbCrLf
                TextBox4.Text &= vbCrLf & "f=1/" & x1 & vbCrLf & "e=" & e1 & vbCrLf
                TextBox4.Text &= vbCrLf & "L=" & CMDS(L + PI) & vbCrLf & "B=" & CMDS(B) & vbCrLf & "H=" & String.Format("{0:0.000}", H) & "M" & vbCrLf
                TextBox4.Text &= vbCrLf & "X=" & X & vbCrLf & "Y=" & Y & vbCrLf & "Z=" & Z & vbCrLf
            End If
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Label2.Text = "L:"
        Label3.Text = "B:"
        Label4.Text = "H:"
        Label5.Text = "D.MMSS"
        Label6.Text = "D.MMSS"
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Label2.Text = "X:"
        Label3.Text = "Y:"
        Label4.Text = "Z:"
        Label5.Text = "M"
        Label6.Text = "M"
    End Sub

    Private Sub TextBox_L_TextChanged(sender As Object, e As EventArgs) Handles TextBox_L.TextChanged

    End Sub
End Class
