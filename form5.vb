Imports System.IO

Public Class Form5
    Function ReadLineWithNumberFrom(ByVal filePath As String, ByVal lineNumber As Integer) As String
        Using file As New StreamReader(filePath)
            ' Skip all preceding lines: '
            For i As Integer = 1 To lineNumber - 1
                If file.ReadLine() Is Nothing Then
                    Throw New ArgumentOutOfRangeException("lineNumber")
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim roll As Integer = rollBox1.Text
        Dim line As String
        Dim flag As Integer = 9
        'Dim newline As String
        Dim choice As String
        Dim filePath As String = "adm_register.txt"
        Dim lineNumber As Integer = My.Computer.FileSystem.ReadAllText("roll_count.txt")
        If (roll <= lineNumber) Then
            Using file As New StreamReader(filePath)
                ' Skip all preceding lines: '
                Dim lines() As String
                For i As Integer = 1 To lineNumber
                    line = file.ReadLine()
                    Dim CheckArray() As String = Split(line, "$", -1)
                    lines = System.IO.File.ReadAllLines(filePath)
                    flag = 0
                    If (CheckArray(0) = roll) Then
                        choice = MsgBox("Student with Roll No " & roll & " Name " & CheckArray(2) & " found." & vbCrLf & "Do you really want to delete this record?", vbYesNo)
                        'lines = System.IO.File.ReadAllLines(filePath)
                        If (choice = vbYes) Then
                            lines(i - 1) = "-1"
                            System.IO.File.WriteAllLines("temp.txt", lines)
                            MsgBox("DELETE LOGIC HERE", , "Alert")
                            flag = 9
                        ElseIf (choice = vbNo) Then
                            MsgBox("Nevermind!", , " ")
                            flag = 0
                        End If



                    End If

                Next
                ' Attempt to read the line you're interested in: '
                'Dim line As String = file.ReadLine()
                If line Is Nothing Then
                    Throw New ArgumentOutOfRangeException("lineNumber")
                End If
                ' Succeded!
            End Using

            ''insert code here
            'If (flag = 9) Then
            My.Computer.FileSystem.DeleteFile("adm_register.txt")
            My.Computer.FileSystem.RenameFile("temp.txt", "adm_register.txt")
            'End If
        Else : MsgBox("Roll Number NOT FOUND", , "Alert")
        End If

    End Sub
End Class
