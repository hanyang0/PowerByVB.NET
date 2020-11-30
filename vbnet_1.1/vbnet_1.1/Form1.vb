Imports System.Math
Public Class Form1
    Dim a As Double = 6378137.0
    Dim b As Double = 6356752.3412
    Dim FlatRate As Double
    Dim Eccentricity_1 As Double
    Dim Eccentricity_2 As Double
    Sub Ellipsoid()
        a = 6378137.0
        b = 6356752.3412
        FlatRate = (a - b) / b
        Eccentricity_1 = Sqrt(a * a - b * b) / a
        Eccentricity_2 = Sqrt(a * a - b * b) / b
    End Sub
End Class