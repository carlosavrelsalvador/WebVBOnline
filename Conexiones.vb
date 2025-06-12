Imports System.Web
Imports System.Data.SqlClient
Public Class Conexiones
    Public Shared Cnn As SqlClient.SqlConnection
    Public Shared Validar As String = "0"

    Public Shared Sub AbrirConexion()
        Cnn = New SqlConnection("Server=DESKTOP-CCJ3LLB\SQLEXPRESS;Database=escuela;User Id=sa;Password=123456;")
        'Cnn = New SqlConnection("workstation id=carlosavr.mssql.somee.com;packet size=4096;user id=carlosavr_SQLLogin_2;pwd=41ydmx59a8;data source=carlosavr.mssql.somee.com;persist security info=False;initial catalog=carlosavr;TrustServerCertificate=True")
    End Sub


End Class
