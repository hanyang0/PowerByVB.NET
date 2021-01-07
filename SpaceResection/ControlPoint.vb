Public Class ControlPoint   '控制点属性
    Property Name As String
    Property XCoorX As Double
    Property XCoorY As Double
    Property WCoorX As Double
    Property WCoorY As Double
    Property WCoorZ As Double

    ReadOnly Property PtInfo() As String
        Get
            Dim mPtInfo$ = "控制点号：" & Name & vbCrLf
            mPtInfo &= "像点x = " & CStr(_XCoorX) & vbCrLf
            mPtInfo &= "像点y = " & CStr(_XCoorY) & vbCrLf & vbCrLf
            mPtInfo &= "物点X = " & CStr(_WCoorX) & vbCrLf
            mPtInfo &= "物点Y = " & CStr(_WCoorY) & vbCrLf
            mPtInfo &= "物点Z = " & CStr(_WCoorZ) & vbCrLf & vbCrLf
            Return mPtInfo
        End Get
    End Property
End Class
