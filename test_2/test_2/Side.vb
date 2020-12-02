Imports System.Math
Public Class Side
    Friend StaPt As controlpoint
    Friend EndPt As controlpoint
    ReadOnly Property Name As String
        Get
            Return StaPt.Name & "_" & EndPt.Name
        End Get
    End Property

    ReadOnly Property Length() As Double
        Get
            Return Sqrt((EndPt.coorX - StaPt.coorX) ^ 2 + (EndPt.coorY - StaPt.coorY) ^ 2)
        End Get
    End Property

    ReadOnly Property Azimuth() As Double
        Get
            Dim DX, DY As Double
            DX = EndPt.coorX - StaPt.coorX
            DY = EndPt.coorY - StaPt.coorY
            If DX = 0 Then
                If DY = 0 Then
                    MsgBox("两个点相同，错误！")
                    Return -1
                ElseIf DY < 0 Then
                    Return 3 * PI / 2
                Else
                    Return PI / 2
                End If
            End If
            If DY = 0 Then
                If DX > 0 Then
                    Return 0
                Else
                    Return PI
                End If
            End If
            If DX < 0 Then
                Return Atan(DY / DX) + PI
            Else
                If DY < 0 Then
                    Return Atan(DY / DX) + 2 * PI
                Else
                    Return Atan(DY / DX)
                End If
            End If
        End Get
    End Property
End Class
