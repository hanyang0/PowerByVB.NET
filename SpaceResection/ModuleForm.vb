Imports System.Math
Module ModuleForm  '导入输出
    Public DataStream As String
    Public DataStr() As String
    Public CmputRst As String

    Public Sub InputDataFile(OpenFile As OpenFileDialog)
        OpenFile.Filter = "Text Files|*.txt|All Files|*.*"
        OpenFile.FilterIndex = 0
        If OpenFile.ShowDialog = DialogResult.OK Then
            Dim StrmR As New System.IO.StreamReader(OpenFile.FileName)
            DataStream = StrmR.ReadToEnd
            StrmR.Close()
        Else
            Exit Sub
        End If
        DataStream = DataStream.Replace(vbCrLf, ",")
        DataStream = DataStream.Trim(",")
        DataStr = DataStream.Split(",")
    End Sub

    Public Sub OutputRsutFile(SaveFile As SaveFileDialog)
        SaveFile.Filter = "Text Files|*.txt|All Files|*.*"
        SaveFile.FilterIndex = 0
        If SaveFile.ShowDialog = DialogResult.OK Then
            Dim StrmW As New System.IO.StreamWriter(SaveFile.OpenFile())
            StrmW.Write(CmputRst)
            StrmW.Close()
        Else
            Exit Sub
        End If
    End Sub

End Module

