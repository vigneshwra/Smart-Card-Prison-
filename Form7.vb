
Imports System.Data.SqlClient
Imports System.IO
Public Class Form7


    Dim id As Integer
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim receipt As Font = New Drawing.Font("Times new roman", 14)
        e.Graphics.DrawString(Form3.Text, receipt, Brushes.Black, 100, 100)


    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox5.Visible = False

        Me.Show()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        PrintDocument1.Print()
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox5.BringToFront()

        GroupBox5.Controls.Clear()


        GroupBox5.Visible = True


        Form9.TopLevel = False
        Form9.TopMost = True

        GroupBox5.Controls.Add(Form9)
        Form9.Show()

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox5.Visible = False

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Clear()
        TextBox2.Clear()
        DateTimePicker3.ResetText()
        ComboBox4.ResetText()
        ComboBox2.ResetText()
        ComboBox5.ResetText()
        ComboBox1.ResetText()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox3.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox1.Clear()
        TextBox13.Clear()
        RadioButton1.Refresh()
        RadioButton2.Refresh()
        RadioButton3.Refresh()
        TextBox10.Clear()
        PictureBox3.Image = Nothing


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim con As New SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
        Try
            con.Open()
            Dim s As String = ""
            If RadioButton1.Checked Then
                s = "Male"
            ElseIf RadioButton2.Checked Then
                s = "Female"
            ElseIf RadioButton3.Checked Then
                s = "Others"
            End If

            Dim command As String
            command = "insert into staff_profile(firstname,lastname,dob,gender,age,marital_status,category,qualification,address,town,district,pincode,phone_number,pancard_no,aadhar_no,alternate_phnno,nationality,hometown,picture) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker3.Text & "','" & s & "','" & TextBox10.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox3.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & ComboBox2.Text & "','" & TextBox13.Text & "',@photo)"
            Dim ms As New MemoryStream
            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)
            Dim com As New SqlCommand(command, con)
            com.Parameters.Add("@photo", SqlDbType.Image).Value = ms.ToArray()
            If com.ExecuteNonQuery = 1 Then
                MsgBox("Done!!!")
                TextBox1.Clear()
                TextBox2.Clear()
                DateTimePicker3.ResetText()
                ComboBox4.ResetText()
                ComboBox2.ResetText()
                ComboBox5.ResetText()
                ComboBox1.ResetText()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox3.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox1.Clear()
                TextBox13.Clear()
                TextBox10.Clear()
                RadioButton1.Refresh()
                RadioButton2.Refresh()
                RadioButton3.Refresh()
                PictureBox3.Image = Nothing

            Else
                MsgBox("Not done!!")
            End If
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim con As New SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
        Try
            con.Open()
            Dim com As New SqlCommand("select * from staff_profile where employee_id = '" & TextBox6.Text & "'", con)
            Dim reader As SqlDataReader
            reader = com.ExecuteReader
            Dim str As String
            While reader.Read
                Label11.Text = reader.Item("employee_id")
                TextBox1.Text = reader.Item("firstname")
                TextBox2.Text = reader.Item("lastname")
                DateTimePicker3.Value = reader.Item("dob")
                TextBox10.Text = reader.Item("age")
                str = reader.Item("gender")
                If RadioButton1.Text = str Then
                    RadioButton1.Select()
                ElseIf RadioButton2.Text = str Then
                    RadioButton2.Select()
                Else
                    RadioButton3.Select()
                End If
                ComboBox4.Text = reader.Item("marital_status")
                ComboBox5.Text = reader.Item("category")
                ComboBox1.Text = reader.Item("qualification")
                TextBox4.Text = reader.Item("address")
                TextBox5.Text = reader.Item("town")
                TextBox11.Text = reader.Item("district")
                TextBox12.Text = reader.Item("pincode")
                TextBox3.Text = reader.Item("phone_number")
                TextBox7.Text = reader.Item("pancard_no")
                TextBox8.Text = reader.Item("aadhar_no")
                TextBox9.Text = reader.Item("alternate_phnno")
                ComboBox2.Text = reader.Item("nationality")
                TextBox13.Text = reader.Item("hometown")

            End While
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim open As New OpenFileDialog
        open.Filter = "choose file(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
        If open.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(open.FileName)
        End If
    End Sub
End Class