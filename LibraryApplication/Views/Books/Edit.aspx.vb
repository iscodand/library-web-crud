
Imports System.Data
Imports System.Diagnostics

Partial Class Views_Books_Edit
    Inherits System.Web.UI.Page

    Private myUri As String = HttpContext.Current.Request.Url.AbsoluteUri
    Private Property Book As Integer = myUri.Substring(myUri.IndexOf("Edit") + 5)

    Private objBook As New Book(Book)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            lblBookTitle.Text = objBook.Title

            txtTitle.Text = objBook.Title
            txtDescription.Text = objBook.Description
            txtGender.Text = objBook.Gender
        End If

        If Not VerifyAuthenticatedUserIsBookCreator() Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        End If

    End Sub

    Protected Function VerifyAuthenticatedUserIsBookCreator() As Boolean
        Dim currentUser As New User(Session("UserId"))

        If currentUser.Id = objBook.UserId Then
            Return True
        End If

        Return False
    End Function

#Region "Edit Function"

    Private Sub VerifyEmptyFields(ByVal title As String, ByVal description As String, ByVal gender As String)
        If title.Trim() = "" Then
            txtTitle.Text = objBook.Title
        End If

        If description.Trim() = "" Then
            txtDescription.Text = objBook.Description
        End If

        If gender.Trim() = "" Then
            txtGender.Text = objBook.Gender
        End If
    End Sub

    Private Function EditBook(ByVal bookId As Integer) As Boolean
        Try
            With objBook
                ' Adicionar verificação para não modificar campos que ficarem vazios
                VerifyEmptyFields(txtTitle.Text, txtDescription.Text, txtGender.Text)
                .Title = txtTitle.Text
                .Description = txtDescription.Text
                .Gender = txtGender.Text
                .Save()
            End With
            Session("Success") = "Livro editado com sucesso."

            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function
#End Region

#Region "Edit Events"
    Protected Sub btnEditBook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditBook.Click
        If EditBook(Book) Then
            Response.Redirect(GetRouteUrl("HomeRoute", Nothing))
        End If
    End Sub
#End Region

End Class
