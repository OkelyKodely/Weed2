Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Public Sub New()
        InitializeComponent()
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        con = New SqlConnection("server=localhost;database=test;integrated security=true")
        con.Open()
        cmd = New SqlCommand("select name from weeds", con)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            ComboBox1.Items.Add(reader.GetValue(0).ToString)
        End While
        con.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim bg = Image.FromFile(Environment.CurrentDirectory & "\" & ComboBox1.SelectedItem.ToString)

        Dim bmp As New Bitmap(bg, New Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height))

        Me.BackgroundImage = bmp

    End Sub

End Class