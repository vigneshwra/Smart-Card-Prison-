Public Class Form8
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Panel1.Location = New Point(-237, -1)
        Do Until Panel1.Location.X = -10
            Panel1.Location = New Point(Panel1.Location.X + 1, -1)
            Refresh()


        Loop
        Do Until Panel1.Location.X = -1
            Panel1.Location = New Point(Panel1.Location.X + 1, -1)

            System.Threading.Thread.Sleep(20)



        Loop
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Panel1.Location = New Point(-1, -1)
        Do Until Panel1.Location.X = -227
            Panel1.Location = New Point(Panel1.Location.X - 1, -1)
            Refresh()


        Loop
        Do Until Panel1.Location.X = -237
            Panel1.Location = New Point(Panel1.Location.X - 1, -1)
            Refresh()
            System.Threading.Thread.Sleep(20)
        Loop
        Form6.Show()
        Me.Hide()

    End Sub



    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox1.BringToFront()

        GroupBox1.Controls.Clear()


        GroupBox1.Visible = True
        Form6.TopLevel = False
        '  Form6.TopMost = True

        GroupBox1.Controls.Add(Form6)
        Form6.Show()










    End Sub


    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form1.TextBox1.Text = String.Empty
        Form1.TextBox2.Text = String.Empty

    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox1.BringToFront()

        GroupBox1.Controls.Clear()


        GroupBox1.Visible = True


        Form7.TopLevel = False
        Form7.TopMost = True

        GroupBox1.Controls.Add(Form7)
        Form7.Show()








    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Form1.TextBox1.Text = String.Empty
        Form1.TextBox2.Text = String.Empty

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox1.BringToFront()

        GroupBox1.Controls.Clear()


        GroupBox1.Visible = True


        Form12.TopLevel = False
        Form12.TopMost = True

        GroupBox1.Controls.Add(Form12)
        Form12.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox1.BringToFront()

        GroupBox1.Controls.Clear()


        GroupBox1.Visible = True


        Form2.TopLevel = False
        Form2.TopMost = True

        GroupBox1.Controls.Add(Form2)
        Form2.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox1.BringToFront()

        GroupBox1.Controls.Clear()


        GroupBox1.Visible = True


        Form13.TopLevel = False
        Form13.TopMost = True

        GroupBox1.Controls.Add(Form13)
        Form13.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        GroupBox1.BringToFront()

        GroupBox1.Controls.Clear()


        GroupBox1.Visible = True


        Form14.TopLevel = False
        Form14.TopMost = True

        GroupBox1.Controls.Add(Form14)
        Form14.Show()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class