<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Master/MasterPage.master" AutoEventWireup="false" CodeFile="RecoverPassword.aspx.vb" Inherits="Views_Authentication_RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="container">
        <div class="login-page">
            <div class="form">
                <p>Recover Password</p>
                <hr />
                <asp:TextBox runat="server" required="required" type="text" ID="txtEmail" name="email" placeholder="e-mail" MaxLength="50" />

                <asp:Label runat="server" ID="lblErrorMessage" CssClass="mb-3" Font-Bold="True" ForeColor="Red" />

                <asp:Button ID="btnRecoverPassword" runat="server" class="btnRegister" Text="send mail" BackColor="#76b852" />
            </div>
        </div>
    </section>
</asp:Content>
