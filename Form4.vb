
Imports System.Data.SqlClient
Imports System.IO

Public Class Form4
    Dim jk As New Data.SqlClient.SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
    Dim updated_bal As Integer
    Dim wages_id As Integer
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Me.Hide()
        Form1.GroupBox1.Visible = True

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SerialPort1.PortName = "COM7"
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Encoding = System.Text.Encoding.Default
        GroupBox6.BringToFront()
        GroupBox6.Visible = False






        GroupBox7.Visible = False

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label5.Text = TextBox1.Text
        Label37.Text = DateAndTime.Today
        Label23.Text = Label10.Text
        Label7.Text = TextBox3.Text
        Label24.Text = Label2.Text

        GroupBox6.Visible = True
        GroupBox6.BringToFront()




    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs)
        GroupBox7.Visible = True
        GroupBox7.BringToFront()
        PrintPreviewControl1.Document = PrintDocument1

    End Sub



    Private Sub Panel5_Click(sender As Object, e As EventArgs)
        GroupBox7.Visible = True
        GroupBox7.BringToFront()
    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs)
        GroupBox6.Visible = False


    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox7.Visible = False
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form1.GroupBox1.Show()
        Form1.GroupBox1.BringToFront()

        Form1.TextBox1.Text = String.Empty
        Form1.TextBox2.Text = String.Empty

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim jk As New Data.SqlClient.SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
        Dim rfid As String = ""
        SerialPort1.Open()
        rfid = SerialPort1.ReadLine()
        SerialPort1.Close()
        TextBox6.Text = rfid
        Dim reader As SqlDataReader
        Dim com As SqlCommand
        Try
            jk.Open()

            com = New SqlCommand("select * from prisoner_profile where rfid= '" & TextBox6.Text & "'", jk)
            reader = com.ExecuteReader


            While reader.Read
                Label2.Text = reader.Item("name")
                Label10.Text = reader.Item("prisoner_id")
                Label4.Text = reader.Item("dob")
                Label11.Text = reader.Item("gender")
            End While

            '  MsgBox(str)
            '      If str = "male" Then
            '     RadioButton1.Checked = True
            '    ElseIf str = "female" Then
            '   RadioButton3.Checked = True
            '  ElseIf str = "others" Then
            ' RadioButton2.Checked = True




            ' TextBox6.Text = table.Rows(0)(9).ToString
            'Label7.Text = table.Rows(0)(14).ToString

            ' Dim byte1() As Byte
            ' byte1 = reader.Item("photo")

            'Dim memory As New MemoryStream(byte1)
            'PictureBox3.Image = Image.FromStream(memory)
            ' TextBox11.Text = TextBox1.Text

            ' Label37.Text = System.DateTime.Now.ToString
            jk.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim con As New SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")

        Dim table As New DataTable
        Dim trans_id As Integer
        con.Open()
        Dim com As New SqlCommand("select max(transaction_id) from transaction_details", con)
        com.ExecuteNonQuery()
        Dim adp As New SqlDataAdapter(com)
        adp.Fill(table)
        trans_id = table.Rows(0)(0).ToString
        con.Close()
        Dim receipt As Font = New Drawing.Font("Times new roman", 10)
        Dim receipt1 As Font = New Drawing.Font("Times new roman", 11, FontStyle.Bold)
        Dim receipt2 As Font = New Drawing.Font("Times new roman", 13, FontStyle.Bold)
        Dim str As String = Date.Today
        e.Graphics.DrawString("Tamilnadu Prison Department", receipt, Brushes.Black, 5, 10)
        e.Graphics.DrawString("Date :" & str & "", receipt, Brushes.Black, 5, 40)
        e.Graphics.DrawString("Transaction_ID :" & trans_id & "", receipt, Brushes.Black, 5, 60)
        e.Graphics.DrawString("Remitter's Name :" & TextBox1.Text & "", receipt, Brushes.Black, 5, 80)
        e.Graphics.DrawString("Credit Amount : Rs." & TextBox3.Text & "", receipt, Brushes.Black, 5, 100)
        e.Graphics.DrawString("Balance : Rs." & updated_bal & "", receipt, Brushes.Black, 5, 120)
        ' e.Graphics.DrawString("Wages_ID : " & wages_id & "", receipt, Brushes.Black, 5, 140)

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintDocument1.Print()
        ' GroupBox6.Hide()
        'GroupBox7.Hide()

    End Sub

    Private Sub Panel5_Paint_2(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim con As New SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
        Dim table As New DataTable
        Dim balance As Integer
        ' Dim cm As String = "jagan"
        Try
            con.Open()
            Dim com As New SqlCommand("insert into transaction_details(prisoner_id,prisoner_name,remitter_name,credit_amount,contact_no,date_time) values('" & Label10.Text & "','" & Label2.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & Label37.Text & "')", con)
            'MsgBox(com.ExecuteNonQuery)
            If com.ExecuteNonQuery = 1 Then
                MsgBox("Done!!")
                GroupBox7.Visible = True
                GroupBox7.BringToFront()
                PrintPreviewControl1.Document = PrintDocument1
            Else
                MsgBox("Not Done!!")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Open()
        Dim cmd As New SqlCommand("select * from prisoner_profile where prisoner_id ='" & Label10.Text & "' ", con)
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            balance = reader.Item("balance")
        End While
        con.Close()
        '  MsgBox(balance)
        updated_bal = balance + CInt(TextBox3.Text)
        '  MsgBox(updated_bal)
        con.Open()
        Dim command As New SqlCommand("update prisoner_profile set balance='" & updated_bal & "' where prisoner_id ='" & Label10.Text & "' ", con)
        command.ExecuteNonQuery()
        con.Close()
        con.Open()
        Dim com2 As New SqlCommand("select wages_id from wages_details where prisoner_id='" & Label10.Text & "'", con)
        Dim reader1 As SqlDataReader
        reader1 = com2.ExecuteReader

        While reader1.Read
            wages_id = reader1.Item("wages_id")
        End While
        con.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox6.Hide()

    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Label2.ResetText()
        Label4.ResetText()
        Label10.ResetText()
        Label11.ResetText()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox6.Clear()
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click

    End Sub
End Class