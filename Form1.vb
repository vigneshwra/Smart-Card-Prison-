
Imports System.Data.SqlClient

Public Class Form1

    Dim jk As New Data.SqlClient.SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
    Dim a As New Data.SqlClient.SqlCommand()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
        Timer1.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            jk.Open()

            Dim b As New Data.SqlClient.SqlDataAdapter("select * from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)

            Dim c As New DataTable()

            b.Fill(c)
            Dim D As String
            D = b.Fill(c)

            'RichTextBox1.Text = D

            If c.Rows.Count() <= 0 Then
                MsgBox("Login Invalid!!!")
                jk.Close()

            Else

                'Me.Hide()
                Form2.Show()
                ' MsgBox("Welcome!!")

            End If


            Dim outsiders As New SqlCommand("select outsiders from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)
            Dim wages As New SqlCommand("select wages from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)
            Dim store As New SqlCommand("select store from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)
            Dim superuser As New SqlCommand("select superuser from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)
            Dim localuser As New SqlCommand("select localuser from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)
            Dim admin_rights As New SqlCommand("select admin_rig from login where username='" & TextBox1.Text & "' and  password ='" & TextBox2.Text & "'", jk)
            Dim admin1 As Integer
            admin1 = admin_rights.ExecuteScalar
            Dim localuser1 As Integer
            localuser1 = localuser.ExecuteScalar
            Dim store1 As Integer
            store1 = store.ExecuteScalar
            Dim wages1 As Integer
            wages1 = wages.ExecuteScalar
            Dim outsiders1 As Integer
            outsiders1 = outsiders.ExecuteScalar


            If (admin1 = 1) Then
                Form8.Show()

                Form8.BringToFront()
                ' GroupBox1.Hide()
                Form8.Label2.Text = Me.TextBox1.Text.ToString
                Me.Show()

            ElseIf (localuser1 = 1 And store1 = 1) Then

                Form3.BringToFront()
                Form3.Show()
                Form3.Label1.Text = Me.TextBox1.Text.ToString
                GroupBox1.Hide()
                Me.Show()
            ElseIf (localuser1 = 1 And wages1 = 1) Then
                Form4.BringToFront()
                Form4.Show()
                ' Form4.Label25.Text = Me.TextBox1.Text.ToString
                GroupBox1.Hide()
                Me.Show()
            ElseIf (localuser1 = 1 And outsiders1 = 1) Then
                Form5.BringToFront()
                Form5.Show()

                GroupBox1.Hide()
                Me.Show()
            End If
            'Form8.Label2.Text = System.DateTime.Now.ToString

            jk.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Form8.Label3.Text = Date.Now.ToString("dd-mm-yyyy hh:mm:ss")
        Form3.Label2.Text = Date.Now.ToString("dd-mm-yyyy hh:mm:ss")
        'Form4.Label26.Text = Date.Now.ToString("dd-mm-yyyy hh:mm:ss")
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
