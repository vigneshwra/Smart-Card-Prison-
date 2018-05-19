Imports System.Data.SqlClient
Imports System.IO



Public Class Form3

    Dim jk As New Data.SqlClient.SqlConnection("Data Source=SURYAMADHAN;Initial Catalog=detailmaster;Integrated Security=True")
    Dim updated_bal As Integer
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = System.DateTime.Now.ToString
        Label2.Text = Form1.TextBox1.Text.ToString
        GroupBox2.Visible = False
        'PrintPreviewControl1.Document = PrintDocument1
        GroupBox1.Visible = False
        SerialPort1.PortName = "COM7"
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Encoding = System.Text.Encoding.Default
        GroupBox2.Hide()
        ' GroupBox5.Visible = False
        Timer1.Enabled = True



        PrintDocument1.PrinterSettings.PrinterName = "POS-58-Series"
        PrintPreviewControl1.Document = PrintDocument1

        ' GroupBox5.Visible = False
        Timer1.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.GroupBox1.Visible = True


    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        TextBox12.Text = Label19.Text
        TextBox13.Text = Label18.Text
        ' TextBox15.Text = ComboBox2.Text
        TextBox17.Text = TextBox2.Text
        TextBox16.Text = ComboBox2.Text


    End Sub


    Private Sub Panel1_Click(sender As Object, e As EventArgs)
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        TextBox12.Text = Label19.Text
        TextBox13.Text = Label18.Text
        ' TextBox15.Text = ComboBox2.Text
        TextBox17.Text = TextBox2.Text
        TextBox16.Text = ComboBox2.Text

    End Sub


    Private Sub Panel6_Click(sender As Object, e As EventArgs)
        GroupBox1.Visible = False

    End Sub




    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage


        Dim receipt As Font = New Drawing.Font("Times new roman", 10)
        Dim receipt1 As Font = New Drawing.Font("Times new roman", 11, FontStyle.Bold)
        Dim receipt2 As Font = New Drawing.Font("Times new roman", 13, FontStyle.Bold)
        Dim listviewcount As Integer = 1
        e.Graphics.DrawString("Tamilnadu Prison Department", receipt, Brushes.Black, 5, 10)
        e.Graphics.DrawString("Name : " & Label19.Text & "", receipt, Brushes.Black, 5, 80)
        e.Graphics.DrawString("Prisoner ID :  " & Label18.Text & " ", receipt, Brushes.Black, 5, 60)
        e.Graphics.DrawString("Credit Amount : Rs." & TextBox15.Text & "", receipt, Brushes.Black, 5, 140)
        e.Graphics.DrawString("Date : " & Label37.Text & "", receipt, Brushes.Black, 5, 40)
        e.Graphics.DrawString("Item : " & ComboBox2.Text & "", receipt, Brushes.Black, 5, 100)
        e.Graphics.DrawString("Quantity : " & TextBox2.Text & "", receipt, Brushes.Black, 5, 120)
        e.Graphics.DrawString("Balance : Rs." & updated_bal & "", receipt, Brushes.Black, 5, 160)
        e.Graphics.DrawString("---------------------------------------", receipt, Brushes.Black, 5, 175)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintDocument1.Print()
        GroupBox2.Hide()
        GroupBox3.Hide()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'GroupBox2.SendToBack()
        GroupBox2.Hide()


    End Sub








    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        jk.Open()
        Dim com As New SqlCommand("select * from item_details where item = '" & ComboBox2.Text & "'", jk)
        Dim reader As SqlDataReader
        reader = com.ExecuteReader
        While reader.Read
            TextBox8.Text = reader.Item("cost")
        End While
        jk.Close()

    End Sub




    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click

        Dim rfid As String = " "
        SerialPort1.Open()
        rfid = SerialPort1.ReadLine()
        'rfid.Replace(":", "")
        SerialPort1.Close()
        ' MsgBox(rfid)
        TextBox9.Text = rfid
        Dim com As SqlCommand
        Dim reader As SqlDataReader
        If rfid <> "" Then
            Try
                jk.Open()
                com = New SqlCommand("select * from prisoner_profile where rfid = '" & TextBox9.Text & "'", jk)
                reader = com.ExecuteReader
                While reader.Read
                    Label18.Text = reader.Item("prisoner_id")
                    Label19.Text = reader.Item("name")
                    Label20.Text = reader.Item("block")
                    Label21.Text = reader.Item("bloodgroup")
                    Label22.Text = reader.Item("gender")
                    Label24.Text = reader.Item("dob")
                    Label9.Text = reader.Item("balance")
                End While
                jk.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Invalid ID")
        End If

    End Sub





    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label37.Text = DateAndTime.Now
    End Sub



    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        TextBox12.Text = Label19.Text
        TextBox13.Text = Label18.Text
        ' TextBox15.Text = ComboBox2.Text
        TextBox17.Text = TextBox2.Text
        TextBox16.Text = ComboBox2.Text


    End Sub

    Private Sub Button4_Click_2(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
        TextBox12.Text = Label19.Text
        TextBox13.Text = Label18.Text
        TextBox17.Text = TextBox2.Text
        TextBox16.Text = ComboBox2.Text
        TextBox15.Text = CInt(TextBox8.Text) * CInt(TextBox17.Text)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GroupBox1.Visible = False
        GroupBox1.BringToFront()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GroupBox2.Visible = True
        Dim balance As Integer
        jk.Open()
        Dim cmd As New SqlCommand("select * from prisoner_profile where prisoner_id ='" & TextBox13.Text & "' ", jk)
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader
        While reader.Read
            balance = reader.Item("balance")
        End While
        jk.Close()
        '  MsgBox(balance)
        updated_bal = balance + TextBox15.Text
        '  MsgBox(updated_bal)
        jk.Open()
        Dim command As New SqlCommand("update prisoner_profile set balance='" & updated_bal & "' where prisoner_id ='" & TextBox13.Text & "' ", jk)
        command.ExecuteNonQuery()
        jk.Close()

        jk.Open()
        Dim comm As New SqlCommand("insert into wages_details(prisonerid,name,quantity,item,amount,date) values('" & TextBox13.Text & "','" & TextBox12.Text & "','" & TextBox17.Text & "','" & TextBox16.Text & "','" & TextBox15.Text & "','" & Label37.Text & "')", jk)
        comm.ExecuteNonQuery()
        jk.Close()


    End Sub
End Class