Imports System.Data.SqlClient

Public Class Main
    Dim connect As New SqlConnection("Data Source=DESKTOP-094DMEA;Initial Catalog=Employee Management;Integrated Security=true")

    Public Sub ExecuteQuery(ByVal query As String)
        Dim command As New SqlCommand(query, connect)
        connect.Open()
        command.ExecuteNonQuery()
        connect.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addQuery As String = "INSERT INTO tblEmployees(FIRSTNAME, LASTNAME, MIDDLENAME,POSITION)VALUES('" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" & txtMiddleName.Text & "', '" & txtPosition.Text & "')"
        ExecuteQuery(addQuery)
        MessageBox.Show("Adding Successful.")

        txtSearch.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtMiddleName.Clear()
        txtPosition.Clear()

        Table.bindData()
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim command As New SqlCommand("SELECT * FROM tblEmployees WHERE ID=@ID", connect)
        command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = txtSearch.Text
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)
        If table.Rows.Count > 0 Then
            txtFirstName.Text = table.Rows(0)(1).ToString
            txtLastName.Text = table.Rows(0)(2).ToString
            txtMiddleName.Text = table.Rows(0)(3).ToString
            txtPosition.Text = table.Rows(0)(4).ToString
        Else
            MessageBox.Show("ID cannot be found.")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim updateQuery As String = "UPDATE tblEmployees SET FIRSTNAME='" & txtFirstName.Text & "', LASTNAME='" & txtLastName.Text & "', MIDDLENAME= '" & txtMiddleName.Text & "', POSITION= '" & txtPosition.Text & "' WHERE ID='" & txtSearch.Text & "'"
        ExecuteQuery(updateQuery)

        MessageBox.Show("Update Successful.")

        txtFirstName.Clear()
        txtLastName.Clear()
        txtMiddleName.Clear()
        txtPosition.Clear()

        Table.bindData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim deleteQuery As String = "DELETE FROM tblEmployees WHERE ID='" & txtSearch.Text & "' DECLARE @NewSeed NUMERIC(10) SELECT @NewSeed = (SELECT MAX(ID) FROM tblEmployees) DBCC CHECKIDENT(tblEmployees, reseed, @NewSeed)"
        ExecuteQuery(deleteQuery)
        MessageBox.Show("Delete Successful")

        txtFirstName.Clear()
        txtLastName.Clear()
        txtMiddleName.Clear()
        txtPosition.Clear()
        Table.bindData()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Table.Show()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        LogIn.ShowDialog()
        If LogIn.isLoggedIn Then
            Me.Show()
        Else
            Me.Close()
        End If

    End Sub
End Class
