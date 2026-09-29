<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Login" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Login</h2>

  <div class="form-group">
    <label>Username</label>

    <asp:TextBox ID="txtUsername"
        runat="server"
        CssClass="form-control" />

    <asp:RequiredFieldValidator
        ID="rfvUsername"
        runat="server"
        ControlToValidate="txtUsername"
        ErrorMessage="Username is required."
        CssClass="text-danger" />
</div>

<div class="form-group">
    <label>Password</label>

    <asp:TextBox ID="txtPassword"
        runat="server"
        TextMode="Password"
        CssClass="form-control" />

    <asp:RequiredFieldValidator
        ID="rfvPassword"
        runat="server"
        ControlToValidate="txtPassword"
        ErrorMessage="Password is required."
        CssClass="text-danger" />
</div>

    <asp:Button ID="btnLogin"
        runat="server"
        Text="Login"
        CssClass="btn btn-primary"
        OnClick="btnLogin_Click" />

    <br />
    <br />

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="text-danger" />

</asp:Content>