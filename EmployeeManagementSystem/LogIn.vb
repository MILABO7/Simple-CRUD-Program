Public Class LogIn
    Public isLoggedIn As Boolean
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtUsername.Text = "admin" And txtPassword.Text = "1234" Then
            isLoggedIn = True
            Me.Close()
        Else
            isLoggedIn = False
            MessageBox.Show("Wrong Username or Password. Try Again.")

            txtUsername.Clear()
            txtPassword.Clear()
        End If

    End Sub


    
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txtPassword.UseSystemPasswordChar = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.UseSystemPasswordChar = True
    End Sub
End Class