Imports System.Math
Module Cal  '计算外方位元素
    Public RepeatNumber As Integer = 0, m As Integer = 40000, GCPNUMBER As Integer = 4
    Public x0 As Double = 0, y0 As Double = 0
    Public Unknownum(5) As Double '外方位元素
    Public UnKnown(5, 5) As Double '误差方程
    Public UnKnow() As Double = {1, 1, 1, 1, 1, 1}   '外方位元素改正数
    Public NN As Integer = 6   '阶数
    Public f As Double '摄影机主距
    Sub Calculat()
        Dim Xxy(GCPNUMBER - 1, 1) As Double  '存放控制点像点坐标
        Dim WXYZ(GCPNUMBER - 1, 2) As Double '存放控制点物点坐标
        Dim i%, j%, k%

        For i = 0 To GCPNUMBER - 1
            For j = 0 To 1
                Xxy(i, j) = Val(DataStr$(6 * i + j + 2))
            Next
        Next

        For i = 0 To GCPNUMBER - 1
            For j = 0 To 2
                WXYZ(i, j) = Val(DataStr$(6 * i + j + 4))
            Next
        Next
        Dim sunXYZ(3) As Double      '物点XYZ平均值
        For i = 0 To 2
            For j = 0 To GCPNUMBER - 1
                sunXYZ(i) += WXYZ(j, i)
            Next
            For j = 0 To 1
                Unknownum(i) = sunXYZ(i) / GCPNUMBER 'XY初始值
            Next
        Next
        Unknownum(2) = m * f + sunXYZ(2) / GCPNUMBER 'Z初始值
        Unknownum(3) = 0  '外方位初始值
        Unknownum(4) = 0
        Unknownum(5) = 0

        Do

            Dim R(2, 2) As Double  '旋转矩阵
            R(0, 0) = Cos(Unknownum(3)) * Cos(Unknownum(5)) - Sin(Unknownum(3)) * Sin(Unknownum(4)) * Sin(Unknownum(5))
            R(0, 1) = -Cos(Unknownum(3)) * Sin(Unknownum(5)) - Sin(Unknownum(3)) * Sin(Unknownum(4)) * Cos(Unknownum(5))
            R(0, 2) = -Sin(Unknownum(3)) * Cos(Unknownum(4))
            R(1, 0) = Cos(Unknownum(4)) * Sin(Unknownum(5))
            R(1, 1) = Cos(Unknownum(4)) * Cos(Unknownum(5))
            R(1, 2) = -Sin(Unknownum(4))
            R(2, 0) = Sin(Unknownum(3)) * Cos(Unknownum(5)) + Cos(Unknownum(3)) * Sin(Unknownum(4)) * Sin(Unknownum(5))
            R(2, 1) = -Sin(Unknownum(3)) * Sin(Unknownum(5)) + Cos(Unknownum(3)) * Sin(Unknownum(4)) * Cos(Unknownum(5))
            R(2, 2) = Cos(Unknownum(3)) * Cos(Unknownum(4))
            Dim Xgang(GCPNUMBER - 1) As Double
            For i = 0 To GCPNUMBER - 1
                Xgang(i) = R(0, 0) * (WXYZ(i, 0) - Unknownum(0)) + R(1, 0) * (WXYZ(i, 1) - Unknownum(1)) + R(2, 0) * (WXYZ(i, 2) - Unknownum(2))
            Next
            Dim Ygang(GCPNUMBER - 1) As Double
            For i = 0 To GCPNUMBER - 1
                Ygang(i) = R(0, 1) * (WXYZ(i, 0) - Unknownum(0)) + R(1, 1) * (WXYZ(i, 1) - Unknownum(1)) + R(2, 1) * (WXYZ(i, 2) - Unknownum(2))
            Next
            Dim Zgang(GCPNUMBER - 1) As Double
            For i = 0 To GCPNUMBER - 1
                Zgang(i) = R(0, 2) * (WXYZ(i, 0) - Unknownum(0)) + R(1, 2) * (WXYZ(i, 1) - Unknownum(1)) + R(2, 2) * (WXYZ(i, 2) - Unknownum(2))
            Next
            Dim approxxy(GCPNUMBER - 1, 1) As Double
            For i = 0 To GCPNUMBER - 1
                approxxy(i, 0) = -f * Xgang(i) / Zgang(i)
                approxxy(i, 1) = -f * Ygang(i) / Zgang(i)
            Next
            Dim A(GCPNUMBER * 2 - 1, 5) As Double    'A
            For i = 0 To GCPNUMBER - 1
                A(i * 2, 0) = (R(0, 0) * f + R(0, 2) * approxxy(i, 0)) / Zgang(i)
                A(i * 2, 1) = (R(1, 0) * f + R(1, 2) * approxxy(i, 0)) / Zgang(i)
                A(i * 2, 2) = (R(2, 0) * f + R(2, 2) * approxxy(i, 0)) / Zgang(i)
                A(i * 2, 3) = (approxxy(i, 0) * approxxy(i, 1)) * R(1, 0) / f - (f + Pow(approxxy(i, 0), 2) / f) * R(1, 1) - approxxy(i, 1) * R(1, 2)
                A(i * 2, 4) = -Pow(approxxy(i, 0), 2) * Sin(Unknownum(5)) / f - (approxxy(i, 0) * approxxy(i, 1)) / f * Cos(Unknownum(5)) - f * Sin(Unknownum(5))
                A(i * 2, 5) = approxxy(i, 1)
                A(i * 2 + 1, 0) = (R(0, 1) * f + R(0, 2) * approxxy(i, 1)) / Zgang(i)
                A(i * 2 + 1, 1) = (R(1, 1) * f + R(1, 2) * approxxy(i, 1)) / Zgang(i)
                A(i * 2 + 1, 2) = (R(2, 1) * f + R(2, 2) * approxxy(i, 1)) / Zgang(i)
                A(i * 2 + 1, 3) = -(approxxy(i, 0) * approxxy(i, 1)) * R(1, 1) / f + (f + Pow(approxxy(i, 1), 2) / f) * R(1, 0) - approxxy(i, 0) * R(1, 2)
                A(i * 2 + 1, 4) = -Pow(approxxy(i, 1), 2) * Cos(Unknownum(5)) / f - (approxxy(i, 0) * approxxy(i, 1)) / f * Cos(Unknownum(5)) - f * Sin(Unknownum(5))
                A(i * 2 + 1, 5) = -approxxy(i, 0)
            Next
            Dim L(GCPNUMBER * 2 - 1) As Double
            For i = 0 To GCPNUMBER * 2 - 1
                If i Mod 2 = 0 Then
                    L(i) = Xxy(i \ 2, 0) - approxxy(i \ 2, 0)
                Else
                    L(i) = Xxy(i \ 2, 1) - approxxy(i \ 2, 1)   'L
                End If
            Next
            Dim AT(5, GCPNUMBER * 2 - 1) As Double       'AT
            For i = 0 To 5
                For j = 0 To GCPNUMBER * 2 - 1
                    AT(i, j) = A(j, i)
                Next
            Next
            Dim Naa(5, 5) As Double     'NAA
            For i = 0 To 5
                For j = 0 To 5
                    For k = 0 To GCPNUMBER * 2 - 1
                        Naa(i, j) += AT(i, k) * A(k, j)
                    Next
                Next
            Next

            Dim NaaInv(5, 5) As Double
            Dim inverse As Boolean = GetMatrixInverse(Naa, NN, NaaInv)    '求NAA的逆
            Dim temp(5) As Double
            For i = 0 To 5
                For j = 0 To GCPNUMBER * 2 - 1
                    temp(i) += AT(i, j) * L(j)
                Next
            Next
            For i = 0 To 5
                UnKnow(i) = 0.0
                For j = 0 To 5
                    UnKnow(i) += NaaInv(i, j) * temp(j)
                Next
            Next
            For i = 0 To 5
                Unknownum(i) = Unknownum(i) + UnKnow(i)     '误差方程
            Next

            RepeatNumber += 1
        Loop While (UnKnow(3) >= 0.00002908882087 Or UnKnow(4) >= 0.00002908882087 Or UnKnow(5) >= 0.00002908882087) '迭代



    End Sub
    Function GetMatrixInverse(ByVal src(,) As Double, n As Integer, ByVal des(,) As Double) As Boolean
        Dim flag As Double = GetA(src, n)
        Dim t(NN - 1, NN - 1) As Double
        If 0 = flag Then
            Return False
        Else
            GetAStart(src, n, t)
            For i = 0 To n - 1
                For j = 0 To n - 1
                    des(i, j) = t(i, j) / flag
                Next
            Next
        End If
        Return True
    End Function

    Function GetA(ByVal arcs(,) As Double, n As Integer) As Double
        If n = 1 Then
            Return arcs(0, 0)
        End If
        Dim ans As Double = 0
        Dim temp(NN - 1, NN - 1) As Double
        For i = 0 To n - 1
            For j = 0 To n - 2
                For k = 0 To n - 2
                    If k >= i Then
                        temp(j, k) = arcs(j + 1, k + 1)
                    Else temp(j, k) = arcs(j + 1, k)
                    End If
                Next
            Next
            Dim t As Double = GetA(temp, n - 1)
            If i Mod 2 = 0 Then
                ans += arcs(0, i) * t
            Else
                ans -= arcs(0, i) * t
            End If
        Next
        Return ans
    End Function
    Sub GetAStart(ByVal arcs(,) As Double, n As Integer, ByVal ans(,) As Double)
        If n = 1 Then
            ans(0, 0) = 1
            Return
        End If
        Dim i%, j%, k%, t%
        Dim temp(NN - 1, NN - 1) As Double

        For i = 0 To n - 1
            For j = 0 To n - 1
                For k = 0 To n - 2
                    For t = 0 To n - 2
                        If k >= i Then
                            If t >= j Then
                                temp(k, t) = arcs(k + 1, t + 1)
                            Else
                                temp(k, t) = arcs(k + 1, t)
                            End If
                        Else
                            If t >= j Then
                                temp(k, t) = arcs(k, t + 1)
                            Else
                                temp(k, t) = arcs(k, t)
                            End If
                        End If
                    Next
                Next
                ans(j, i) = GetA(temp, n - 1)
                If (i + j) Mod 2 = 1 Then
                    ans(j, i) = -ans(j, i)
                End If
            Next
        Next
    End Sub

End Module
