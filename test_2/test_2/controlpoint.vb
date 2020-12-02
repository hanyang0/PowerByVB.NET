Public Class ControlPoint
    Property Name As String
    Property PtType As Boolean
    Property CoorX As Double
    Property CoorY As Double
    ReadOnly Property PtInfo() As String
        Get
            Dim mPtInfo$ = "点名：" & Name
            If PtType Then
                mPtInfo &= " ,  类型：已知点。" & vbCrLf
            Else
                mPtInfo &= " ,  类型：待定点。" & vbCrLf
            End If
            mPtInfo &= "Xp = " & CStr(CoorX) & vbCrLf
            mPtInfo &= "Yp = " & CStr(CoorY) & vbCrLf
            Return mPtInfo
        End Get
    End Property

End Class

