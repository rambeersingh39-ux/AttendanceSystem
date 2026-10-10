Imports System.Data.SqlClient
Imports System.Configuration

Public Class Database
    Private con As New SqlConnection(ConfigurationManager.ConnectionStrings("DbConnection").ConnectionString)
    Public Function GetConnection() As SqlConnection
        Return con
    End Function

End Class
