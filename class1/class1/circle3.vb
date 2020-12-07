
Imports System.Math
Public Class Circle3
    Event RadiusErr(sender As Object)
    Dim mR As Single
    'ReadOnly Property ObjName As String
    '    Get
    '        Return "圆"
    '    End Get
    'End Property
    Public Property Radius() As Single
        Get
            Return mR
        End Get
        Set(value As Single)
            If value < 0 Then
                RaiseEvent RadiusErr(Me)
                Exit Property
            Else
                mR = value
            End If
        End Set
    End Property
    Friend Overridable Function Area() As Double
        Area = PI * mR * mR
    End Function
    Friend Function Circum() As Double
        Circum = 2 * PI * mR
    End Function
End Class

Public Class Cylinder
    Inherits Circle3
    Event HeigErr(Sender As Object)
    Dim mHeight As Double
    Property Height As Double
        Get
            Return mHeight
        End Get
        Set(value As Double)
            If value < 0 Then
                RaiseEvent HeigErr(Me)
            Else
                mHeight = value
            End If
        End Set
    End Property
    Friend Overrides Function Area() As Double
        Return 2 * Math.PI * Radius * (Radius + mHeight)
    End Function
    Function Volume() As Double
        Return MyBase.Area() * mHeight
    End Function

End Class

Public Class boll
    Inherits Circle3
    Friend Overrides Function Area() As Double
        Return 4 * Math.PI * Radius * Radius
    End Function
    Function Volume() As Double
        Return 4 / 3 * Math.PI * Radius * Radius * Radius
    End Function
End Class



