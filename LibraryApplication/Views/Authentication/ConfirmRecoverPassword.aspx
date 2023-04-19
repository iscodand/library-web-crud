<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Master/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmRecoverPassword.aspx.vb" Inherits="Views_Authentication_ConfirmRecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="container">
        <div class="login-page">
            <div class="form">
                <p class="fw-bold">Change Password</p>
                <asp:Label ID="lblSuccess" runat="server" CssClass="mb-3" Font-Bold="True" ForeColor="Green" />
                <hr />

                <asp:TextBox runat="server" required="required" type="password" ID="txtPassword" name="password" placeholder="password" MaxLength="50" />
                <asp:TextBox runat="server" required="required" type="password" ID="txtPasswordConfirm" name="passwordConfirm" placeholder="password confirm" MaxLength="50" />

                <asp:Label ID="lblInvalid" runat="server" Font-Bold="True" ForeColor="Red" />
                <br />

                <asp:Button ID="btnConfirm" runat="server" class="btnRegister" Text="confirm" BackColor="#76b852" />
            </div>
        </div>
    </section>

</asp:Content>
