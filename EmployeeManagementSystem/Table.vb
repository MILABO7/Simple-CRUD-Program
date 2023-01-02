Imports System.Data.SqlClient

Public Class Table
    Dim connect As New SqlConnection("Data Source=DESKTOP-094DMEA;Initial Catalog=Employee Management;Integrated Security=true")
    Public Sub bindData()
        Dim viewQuery As String = "SELECT * FROM tblEmployees"
        Dim command As SqlCommand = New SqlCommand(viewQuery, connect)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)
        dgvEmployeesTable.DataSource = table

    End Sub

    Private Sub Table_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        bindData()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs)
        PrintPreviewDialog1.ShowDialog()
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bitmap As New Bitmap(Me.dgvEmployeesTable.Width, Me.dgvEmployeesTable.Height)
        Dim font As New Font("Arial", 20, FontStyle.Bold)
        dgvEmployeesTable.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.dgvEmployeesTable.Width, Me.dgvEmployeesTable.Height))
        e.Graphics.DrawString("EMPLOYEES TABLE", font, Brushes.Maroon, 300, 50)
        font.Dispose()
        e.Graphics.DrawImage(bitmap, 150, 100)
    End Sub

End Class