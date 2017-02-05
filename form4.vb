Public Class Form4
    Dim flag As Integer = 5
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (flag <> 0) Then

            If My.Computer.FileSystem.FileExists("adm_register.txt") Then
                For Each line As String In System.IO.File.ReadAllLines("adm_register.txt")
                    Dim str = line.Split("$")
                    Dim roll As Integer = str(0)
                    If (roll > 0) Then
                        DataGridView1.Rows.Add(str)
                        flag = 0
                    End If
                Next
            End If
        Else : MsgBox("Adm Register Not Found!")
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
