Imports System
Imports System.Data.SqlClient
Imports System.IO
Public Class _Default
    Inherits System.Web.UI.Page
    'Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim reader As New IO.StreamReader(Request.InputStream)
        Dim data As String = reader.ReadToEnd()

        Response.Write("Method: " & Request.HttpMethod & "<br/>")
        Response.Write("  ContentType =" & Request.ContentType & "<br/>")
        System.IO.File.AppendAllText("C:\temp\requestlog.txt",
DateTime.Now.ToString() & "  " & Request.HttpMethod & " " & Request.RawUrl & Environment.NewLine)
        'Response.Write("<pre>" & body & "</pre>")
        'System.IO.File.WriteAllText("C:\Temp\k40.txt", body)

        '        Dim folder As String = "C:\Temp"
        '        If Not Directory.Exists(folder) Then
        '            Directory.CreateDirectory(folder)
        '        End If
        '        Dim body As String = New IO.StreamReader(Request.InputStream).ReadToEnd()
        '        File.AppendAllText("C:\temp\k40log.txt",
        '"Time:" & DateTime.Now.ToString & Environment.NewLine &
        '"Method: " & Request.HttpMethod & Environment.NewLine &
        '"ContentType: " & Request.ContentType & Environment.NewLine &
        '"Body: " & body & Environment.NewLine &
        '"------------------------------------------------" & Environment.NewLine)
        Response.Write("ok")
        Response.End()

        'Response.End()

        'System.IO.File.AppendAllText("c:\logs\test.txt", DateTime.Now.ToString() & "Page called" & Environment.NewLine)
        ''If Not IsPostBack Then
        ''    Return
        ''End If
        'Dim host As String = "192.168.1.3"
        'Dim port As Int32 = 8081



        'Dim reader As New StreamReader(Request.InputStream)
        'Dim data As String = reader.ReadToEnd()
        'Response.Write(data.ToString())
        'If data <> "" Then
        '    Dim lines() As String = data.Split(ControlChars.Lf)
        '    For Each line As String In lines
        '        line = line.Trim()
        '        If line <> "" Then
        '            Dim fields() As String = line.Split(","c)
        '            If fields.Length >= 4 Then
        '                Dim EmployeeCode As String = fields(0).Trim()
        '                Dim logtime As DateTime = Convert.ToDateTime(fields(1))
        '                Dim verifymode As Integer = Convert.ToInt32(fields(2))
        '                Dim inOutMode As Integer = Convert.ToInt32(fields(3))
        '                Dim deviceId As String = Request.UserHostAddress
        '                SaveAttendance(EmployeeCode, verifymode, inOutMode, logtime, deviceId)
        '            End If
        '        End If
        '    Next


        'End If
        Response.Write("ok")




    End Sub
    Private Sub SaveAttendance(emp As String, verify As Integer, io As Integer, dt As DateTime, device As String)
        Dim db As New Database()
        Using con As SqlConnection = db.GetConnection()
            con.Open()
            Dim sql As String = "insert into attendance(employeecode,verifymode,inoutmode,longtime,deviceid) values(@employeecode,@verifymode,@inoutmode,@longtime,@deviceid)"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@employeecode", emp)
                cmd.Parameters.AddWithValue("@verifycode", verify)
                cmd.Parameters.AddWithValue("@inoutmode", io)
                cmd.Parameters.AddWithValue("@longtime", dt)
                cmd.Parameters.AddWithValue("@deviceid", device)
                cmd.ExecuteNonQuery()


            End Using
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class