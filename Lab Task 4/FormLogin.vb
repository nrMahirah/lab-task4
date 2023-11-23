Imports System.Data.SqlClient
Public Class Login
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim connectionString As String = "Server=localhost;Database=softwareRespositorySystem;User Id=sa;Password=478101;"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim query As String = "SELECT * FROM login WHERE username=@nama AND password=@katalaluan"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@nama", txtUsername.Text)
        command.Parameters.AddWithValue("@katalaluan", txtPassword.Text)
        connection.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            Home.Show()
            Me.Hide()
        Else
            MsgBox("Unauthorized User", MsgBoxStyle.Critical, "Software Respository System")
        End If

    End Sub
End Class
