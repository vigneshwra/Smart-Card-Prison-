Public Class Form13
    Private Sub RectangleShape1_Click(sender As Object, e As EventArgs) Handles RectangleShape1.Click

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox5.BringToFront()
        GroupBox5.Controls.Clear()
        GroupBox5.Visible = True
        Form9.TopLevel = False
        Form9.TopMost = True

        GroupBox5.Controls.Add(Form9)
        Form9.Show()
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox5.Visible = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox5.Visible = False

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GroupBox5.BringToFront()

        GroupBox5.Controls.Clear()


        GroupBox5.Visible = True


        Form10.TopLevel = False
        Form10.TopMost = True

        GroupBox5.Controls.Add(Form10)
        Form10.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox5.BringToFront()

        GroupBox5.Controls.Clear()


        GroupBox5.Visible = True


        Form11.TopLevel = False
        Form11.TopMost = True

        GroupBox5.Controls.Add(Form11)
        Form11.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
End Class