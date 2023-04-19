
Imports System.Diagnostics

Partial Class Views_Authentication_RecoverPassword
    Inherits Page

#Region "Recover Password Functions"
    Private Function GetUserId() As Integer
        Dim user As New User()

        Try
            With user.Search(email:=txtEmail.Text)
                If .Rows.Count > 0 Then
                    Dim userId As Integer = .Rows(0)("Id")
                    Return userId
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

        Return Nothing
    End Function

    Private Function GenerateToken() As Boolean
        Dim user As New User(GetUserId())
        Dim token As New Token()
        Dim sender As New EmailSender()
        Dim templatePath As String = "C:\\Users\\SEDUC\\Documents\\VB.NET - Projects\\LibraryApplication\\App_Code\\Utils\\EmailTemplates\\PasswordRecover.html"

        Try
            With token
                .UserId = GetUserId()
                .Save()
                sender.Send("Teste", user, token, templatePath)
                Return True
            End With
        Catch ex As Exception
            If token.Search(userId:=GetUserId()) IsNot Nothing Then
                lblErrorMessage.Text = "Um E-mail já foi enviado para essa conta."
            End If

            If GetUserId() = 0 Then
                lblErrorMessage.Text = "E-mail não encontrado."
            End If

            Return False
        End Try
    End Function
#End Region

#Region "Recover Password Events"
    Protected Sub btnRecoverPassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRecoverPassword.Click
        If GenerateToken() Then
            Response.Redirect(GetRouteUrl("LoginRoute", Nothing))
        End If
    End Sub
#End Region

End Class
