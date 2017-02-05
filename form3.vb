
Imports System.IO

Public Class Form3
    Function ReadLineWithNumberFrom(ByVal filePath As String, ByVal lineNumber As Integer) As String
        Using file As New StreamReader(filePath)
            ' Skip all preceding lines: '
            For i As Integer = 1 To lineNumber - 1
                If file.ReadLine() Is Nothing Then
                    '
                    Throw New ArgumentOutOfRangeException("lineNumber")
                    'MsgBox("Nothing")
                End If
            Next
            ' Attempt to read the line you're interested in: '
            Dim line As String = file.ReadLine()
            If line Is Nothing Then
                Throw New ArgumentOutOfRangeException("lineNumber")
            End If
            ' Succeded!
            Return line
        End Using
    End Function

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (rollBox1.Text = "") Then
            MsgBox("Please Fill in Roll Number", , "Alert")
            Return
        End If
        Dim rollFromFile As Integer = My.Computer.FileSystem.ReadAllText("roll_count.txt")
        If (rollBox1.Text <= rollFromFile) Then

            Dim msg As String = ReadLineWithNumberFrom("adm_register.txt", rollBox1.Text)
            Dim TestArray() As String = Split(msg, "$", -1)

            If TestArray(0) = -1 Then
                MsgBox("Roll Number NOT FOUND", , "Alert")
                Return
            End If

            rollField.Text = TestArray(0)
            deptBox.SelectedItem = TestArray(1)
            nameBox.Text = TestArray(2)
            dobPick1.Text = TestArray(3)
            contactNo.Text = TestArray(4)

        Else : MsgBox("Roll Number NOT FOUND", , "Alert")
        End If

    End Sub

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If (rollField.Text = "") Then
            MsgBox("Please Fill in All Boxes", , "Alert")
            Return
        End If

        Dim val As Integer = rollField.Text
        Dim filepath As String = "adm_register.txt"
        Dim lines() As String = System.IO.File.ReadAllLines(filepath)
        lines(val - 1) = rollField.Text & "$" & deptBox.Text & "$" & nameBox.Text & "$" & dobPick1.Text & "$" & contactNo.Text
        System.IO.File.WriteAllLines(filepath, lines)
        MsgBox("Modified", , "Success")
        Me.Close()

    End Sub
End Class

