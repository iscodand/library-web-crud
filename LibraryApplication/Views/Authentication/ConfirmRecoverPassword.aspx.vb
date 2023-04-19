
Imports System.Diagnostics
Imports System.Web.Helpers

Partial Class Views_Authentication_ConfirmRecoverPassword
    Inherits System.Web.UI.Page

    Private myUri As String = HttpContext.Current.Request.Url.AbsoluteUri
    Private token As String = myUri.Substring(myUri.IndexOf("Password/") + 9)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Debug.WriteLine(token)
    End Sub

#Region "Confirm Recover Password Functions"

    Private Function GetUserId() As Integer
        Dim objUser As New User()
        Dim objToken As New Token()

        Try
            With objToken.Search(token:=token)
                If .Rows.Count > 0 Then
                    Return .Rows(0)("UserId")
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

        Return Nothing
    End Function

    Private Function ValidatePassword(ByVal password As String, ByVal passwordConfirm As String) As Boolean
        Dim user As New User(GetUserId())

        If Crypto.VerifyHashedPassword(user.Password, password) Then
            lblInvalid.Text = "Sua senha precisa ser diferente da atual."
            Return False
        End If

        If password.Length < 8 Then
            lblInvalid.Text = "Sua senha precisa conter mais de 8 caracteres."
            Return False
        End If

        If password <> passwordConfirm Then
            lblInvalid.Text = "As senhas não correspondem."
            Return False
        End If

        Return True
    End Function

    Private Function ChangePassword() As Boolean
        Dim objUser As New User(GetUserId())
        Dim objToken As New Token()

        If Not ValidatePassword(txtPassword.Text, txtPasswordConfirm.Text) Then
            Return False
        Else
            With objToken.Search(token:=token)
                If .Rows.Count > 0 Then
                    objToken.Delete(.Rows(0)("Id"))
                End If
            End With

            With objUser
                .Password = txtPassword.Text
                .Save()
            End With
        End If

        Return True
    End Function

#End Region

#Region "Confirm Recover Password Events"

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirm.Click
        If ChangePassword() Then
            Response.Redirect(GetRouteUrl("LoginRoute", Nothing))
        End If
    End Sub

#End Region

End Class
