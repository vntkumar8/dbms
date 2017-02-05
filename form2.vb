
Public Class Form2
    Public serialNum As Integer
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deptBox.SelectedIndexChanged
        Dim deptName = deptBox.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (deptBox.Text = "" Or nameBox.Text = "" Or contactNo.Text = "") Then
            MsgBox("Please Fill in All Boxes", , "Alert")
            Return
        End If
        Dim rollFromFile As Integer = My.Computer.FileSystem.ReadAllText("roll_count.txt")
        serialNum = rollFromFile + 1
        My.Computer.FileSystem.WriteAllText("adm_register.txt", serialNum & "$" & deptBox.Text & "$" & nameBox.Text & "$" & dobPick1.Text & "$" & contactNo.Text & vbCrLf, True)
        Dim msg As String = nameBox.Text & " admitted succesfully, Roll No is :" & serialNum
        Dim title = "Admission Success"
        Me.ResetText()
        Dim response = MsgBox(msg, , title)
        If response = MsgBoxResult.Ok Then
            Me.Close()
            Me.Close()
        End If
        My.Computer.FileSystem.WriteAllText("roll_count.txt", serialNum, False)
        MsgBox(msg)

    End Sub

    Private Sub dobPick1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dobPick1.ValueChanged

        Dim dob = dobPick1.Text
    End Sub

    Private Sub contactNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contactNo.TextChanged
        Dim number = contactNo.Text
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nameBox.TextChanged
        'My.Computer.FileSystem.WriteAllText("reg.txt", deptBox.Text, True)
    End Sub

End Class


