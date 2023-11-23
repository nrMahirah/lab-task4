Imports System.Data.SqlClient
Public Class FormSoftware
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application.Exit() 'Form will be exit when user click this button
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show() 'will show about form
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim connectionString As String = "Server=localhost;Database=softwareRespositorySystem;User Id=sa;Password=478101;"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim command As SqlCommand
        Dim da As New SqlDataAdapter
        command = New SqlCommand("SELECT software.id, software.title, author.author_name FROM software 
                                    INNER JOIN author ON software.id = author.id")
        command.Connection = connection ' Set the connection object for the command
        da.SelectCommand = command

        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        DataGridSoftware.DataSource = dt
        connection.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Home.Show() 'Show the home form
        Me.Hide()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim id As Integer = txtId.Text
        Dim authorName As String = txtAuthorName.Text
        Dim title As String = txtTitle.Text

        Dim connectionString As String = "Server=localhost;Database=softwareRespositorySystem;User Id=sa;Password=478101;"
        Dim softwareQuery As String = "INSERT INTO software VALUES(@id,@title)"

        Dim authorQuery As String = "INSERT INTO author VALUES(@id,@author_name)"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()

        'Insert into software table
        Using softwareCommand As New SqlCommand(softwareQuery, connection)
            softwareCommand.Parameters.AddWithValue("@id", id)
            softwareCommand.Parameters.AddWithValue("@title", title)
            softwareCommand.ExecuteNonQuery()
        End Using

        'Insert into author table
        Using authorCommand As New SqlCommand(authorQuery, connection)
            authorCommand.Parameters.AddWithValue("@id", id)
            authorCommand.Parameters.AddWithValue("@author_name", authorName)
            authorCommand.ExecuteNonQuery()
        End Using

        MsgBox("Successful Add!", MessageBoxIcon.Information) 'When user want to add data
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAuthorName.Clear()
        txtId.Clear()
        txtTitle.Clear()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim id As Integer = txtId.Text
        Dim authorName As String = txtAuthorName.Text
        Dim title As String = txtTitle.Text

        Dim connectionString As String = "Server=localhost;Database=softwareRespositorySystem;User Id=sa;Password=478101;"
        Dim softwareQuery As String = "UPDATE software SET ID =@id,title =@title WHERE ID=@id"

        Dim authorQuery As String = "UPDATE author SET ID =@id,author_name =@author_name WHERE ID=@id"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()

        'Insert into software table
        Using softwareCommand As New SqlCommand(softwareQuery, connection)
            softwareCommand.Parameters.AddWithValue("@id", id)
            softwareCommand.Parameters.AddWithValue("@title", title)
            softwareCommand.ExecuteNonQuery()
        End Using

        'Insert into author table
        Using authorCommand As New SqlCommand(authorQuery, connection)
            authorCommand.Parameters.AddWithValue("@id", id)
            authorCommand.Parameters.AddWithValue("@author_name", authorName)
            authorCommand.ExecuteNonQuery()
        End Using

        MsgBox("Successful Update!", MessageBoxIcon.Information) 'When user want update the data
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim id As Integer = txtId.Text

        Dim connectionString As String = "Server=localhost;Database=softwareRespositorySystem;User Id=sa;Password=478101;"
        Dim softwareQuery As String = "DELETE FROM software WHERE ID=@id"

        Dim authorQuery As String = "DELETE FROM author WHERE ID=@id"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()

        'Insert into software table
        Using softwareCommand As New SqlCommand(softwareQuery, connection)
            softwareCommand.Parameters.AddWithValue("@id", id)
            softwareCommand.ExecuteNonQuery()
        End Using

        'Insert into author table
        Using authorCommand As New SqlCommand(authorQuery, connection)
            authorCommand.Parameters.AddWithValue("@id", id)
            authorCommand.ExecuteNonQuery()
        End Using

        MsgBox("Successful Delete!", MessageBoxIcon.Information) 'When user want to delete data from database
    End Sub
End Class