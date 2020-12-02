Imports System.Math
Public Class AngConver
    Shared Function CRad(ByVal DMS As Double) As Double
        Dim ValuSign As Integer
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        ValuSign = Sign(DMS)
        DMS = ValuSign * DMS
        DD = Int(DMS)
        MM = Int((DMS - DD) * 100)
        SS = ((DMS - DD) * 100 - MM) * 100
        Return (DD + MM / 60 + SS / 3600) * PI / 180 * ValuSign
    End Function

    Shared Function CDMS(ByVal Rad As Double) As Double
        Dim ValuSign As Integer
        Dim Deg As Double
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        ValuSign = Sign(Rad)
        Rad = ValuSign * Rad
        Deg = Rad * 180 / PI
        DD = Int(Deg)
        MM = Int((Deg - DD) * 60)
        SS = Format(((Deg - DD) * 60 - MM) * 60, "00.000")
        If SS >= 60 Then
            SS -= 60
            MM += 1
        End If
        If MM >= 60 Then
            MM -= 60
            DD += 1
        End If
        Return (DD + MM / 100 + SS / 10000) * ValuSign
    End Function

    Shared Function RadToDMSstr(ByVal Rad As Double) As String
        Dim ValuSign As Integer
        Dim Deg As Double
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        ValuSign = Sign(Rad)
        Rad = ValuSign * Rad
        Deg = Rad * 180 / PI
        DD = Int(Deg)
        MM = Int((Deg - DD) * 60)
        SS = Format(((Deg - DD) * 60 - MM) * 60, "00.000")
        If SS >= 60 Then
            SS -= 60
            MM += 1
        End If
        If MM >= 60 Then
            MM -= 60
            DD += 1
        End If
        If ValuSign = -1 Then
            Return String.Format("-{0}°{1}′{2}″", DD, MM, SS)
        Else
            Return String.Format("{0}°{1}′{2}″", DD, MM, SS)
        End If
    End Function

    Shared Function DMSToDMSstr(ByVal DMS As Double) As String
        Dim ValuSign As Integer
        Dim DD As Integer
        Dim MM As Integer
        Dim SS As Single
        ValuSign = Sign(DMS)
        DMS = ValuSign * DMS
        DD = Int(DMS)
        MM = Int((DMS - DD) * 100)
        SS = ((DMS - DD) * 100 - MM) * 100
        If SS >= 60 Then
            SS -= 60
            MM += 1
        End If
        If MM >= 60 Then
            MM -= 60
            DD += 1
        End If
        If ValuSign = -1 Then
            Return String.Format("-{0}°{1}′{2}″", DD, MM, SS)
        Else
            Return String.Format("{0}°{1}′{2}″", DD, MM, SS)
        End If
    End Function
End Class
