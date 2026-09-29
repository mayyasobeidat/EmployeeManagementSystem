<%@ Page Title="Edit Department" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EditDepartment.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Departments.EditDepartment" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Edit Department</h2>

    <asp:HiddenField ID="hfDepartmentId"
        runat="server" />

    <div class="form-group">
        <label>Department Name</label>

        <asp:TextBox ID="txtDepartmentName"
            runat="server"
            CssClass="form-control" />

        <asp:RequiredFieldValidator
            ID="rfvDepartmentName"
            runat="server"
            ControlToValidate="txtDepartmentName"
            ErrorMessage="Department name is required."
            CssClass="text-danger" />
    </div>

    <div class="form-group">
        <label>Description</label>

        <asp:TextBox ID="txtDescription"
            runat="server"
            TextMode="MultiLine"
            Rows="4"
            CssClass="form-control" />
    </div>

    <br />

    <asp:Button ID="btnUpdate"
        runat="server"
        Text="Update Department"
        CssClass="btn btn-primary"
        OnClick="btnUpdate_Click" />

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="text-success" />

</asp:Content>