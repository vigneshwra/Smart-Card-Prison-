Public Class Form5


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = System.DateTime.Now.ToString
        Label2.Text = Form1.TextBox1.Text.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form1.GroupBox1.Visible = True
    End Sub

    Private Sub RectangleShape1_Click(sender As Object, e As EventArgs) Handles RectangleShape1.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class