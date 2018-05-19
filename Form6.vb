Imports System.Data.SqlClient
Imports System.IO


Public Class Form6
    Dim jk As New Data.SqlClient.SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
        Try
            con.Open()
            Dim str As String = " "
            If RadioButton1.Checked Then
                str = RadioButton1.Text
            ElseIf RadioButton2.Checked Then
                str = RadioButton2.Text
            Else
                str = RadioButton3.Text
            End If
            Dim com As New SqlCommand("insert into prisoner_profile(rfid,name,bloodgroup,nationality,dob,gender,age,birthmark,address,balance,block,cell_id,height,start_year,end_year,temp_address,photo) values('" & TextBox2.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox5.Text & "','" & DateTimePicker1.Value & "','" & str & "','" & TextBox4.Text & "','" & TextBox3.Text & "','" & TextBox8.Text & "','" & TextBox10.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & TextBox5.Text & "','" & DateTimePicker2.Value & "','" & DateTimePicker3.Value & "','" & TextBox9.Text & "',@photo)", con)
            Dim ms As New MemoryStream
            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)
            com.Parameters.Add("@photo", SqlDbType.Image).Value = ms.ToArray()
            If com.ExecuteNonQuery = 1 Then
                MsgBox("Done")
                TextBox1.Clear()
                TextBox2.Clear()
                ComboBox1.ResetText()
                ComboBox5.ResetText()
                DateTimePicker1.ResetText()
                RadioButton1.Refresh()
                RadioButton2.Refresh()
                RadioButton3.Refresh()
                TextBox4.Clear()
                TextBox3.Clear()
                TextBox8.Clear()
                TextBox10.Clear()
                ComboBox3.ResetText()
                ComboBox4.ResetText()
                TextBox5.Clear()
                DateTimePicker2.ResetText()
                DateTimePicker3.ResetText()
                PictureBox3.Image = Nothing
                TextBox9.Clear()
            Else
                MsgBox("Not Done")
            End If
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim open As New OpenFileDialog
        open.Filter = "choose file(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
        If open.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(open.FileName)
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Visible = False
        SerialPort1.PortName = "COM7"
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Encoding = System.Text.Encoding.Default
        GroupBox4.Visible = False
        GroupBox4.BringToFront()

    End Sub



    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        GroupBox1.Visible = True
        GroupBox1.BringToFront()


    End Sub



    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click



        Dim rfid As String = ""
        '  SerialPort1.Open()
        ' rfid = SerialPort1.ReadLine()
        'If rfid <> "" Then
        'MsgBox(rfid)
        'End If
        'SerialPort1.Close()
        'Label19.Text = rfid
        'rfid = ""

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        Dim rfid As String = ""
        SerialPort1.Open()
        rfid = SerialPort1.ReadLine()
        SerialPort1.Close()
        TextBox2.Text = rfid
        'Label19.Text = rfid
        'rfid = ""


        ' GroupBox1.Visible = True
        'GroupBox1.BringToFront()

        'extBox6.Text = TextBox1.Text
        'DateTimePicker4.Text = DateTimePicker1.Text

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        GroupBox1.Visible = False

    End Sub



    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox2.Text = Label19.Text
        GroupBox1.Visible = False


    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GroupBox4.Visible = True

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GroupBox4.Visible = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.ResetText()
        ComboBox5.ResetText()
        DateTimePicker1.ResetText()
        RadioButton1.Refresh()
        RadioButton2.Refresh()
        RadioButton3.Refresh()
        TextBox4.Clear()
        TextBox3.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        ComboBox3.ResetText()
        ComboBox4.ResetText()
        TextBox5.Clear()
        DateTimePicker2.ResetText()
        DateTimePicker3.ResetText()
        TextBox9.Clear()
        PictureBox3.Image = Nothing



    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim con As New SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
        Dim str As String
        Try
            con.Open()
            Dim com As New SqlCommand("select * from prisoner_profile where prisoner_id='" & TextBox7.Text.Trim & "'", con)
            Dim reader As SqlDataReader
            reader = com.ExecuteReader
            While reader.Read
                TextBox1.Text = reader.Item("name")
                TextBox2.Text = reader.Item("rfid")
                ComboBox1.Text = reader.Item("bloodgroup")
                ComboBox5.Text = reader.Item("nationality")
                DateTimePicker1.Value = reader.Item("dob")
                str = reader.Item("gender")
                If RadioButton1.Text = str Then
                    RadioButton1.Select()
                ElseIf RadioButton2.Text = str Then
                    RadioButton2.Select()
                Else
                    RadioButton3.Select()
                End If
                TextBox4.Text = reader.Item("age")
                TextBox3.Text = reader.Item("birthmark")
                TextBox8.Text = reader.Item("address")
                TextBox10.Text = reader.Item("balance")
                ComboBox3.Text = reader.Item("block")
                ComboBox4.Text = reader.Item("cell_id")
                TextBox5.Text = reader.Item("height")
                DateTimePicker2.Value = reader.Item("start_year")
                DateTimePicker3.Value = reader.Item("end_year")
                TextBox9.Text = reader.Item("temp_address")
            End While
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class