<%@ Page Title="Add Department" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AddDepartment.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Departments.AddDepartment" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Add Department</h2>

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

    <asp:Button ID="btnAdd"
        runat="server"
        Text="Add Department"
        CssClass="btn btn-primary"
        OnClick="btnAdd_Click" />

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="text-success" />

</asp:Content>