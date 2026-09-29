<%@ Page Title="Edit Employee" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EditEmployee.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Employees.EditEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Employee</h2>

    <asp:HiddenField ID="hfEmployeeId" runat="server" />

    <div class="form-group">
        <label>First Name</label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Last Name</label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
    </div>

  <div class="form-group">
    <label>Email</label>

    <asp:TextBox ID="txtEmail"
        runat="server"
        CssClass="form-control" />

    <asp:RegularExpressionValidator
        ID="revEmail"
        runat="server"
        ControlToValidate="txtEmail"
        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
        ErrorMessage="Please enter a valid email address."
        CssClass="text-danger" />
</div>

    <div class="form-group">
        <label>Phone</label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Job Title</label>
        <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Department</label>
        <asp:DropDownList ID="ddlDepartment"
            runat="server"
            CssClass="form-control">
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <label>Salary</label>
        <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" />
    </div>

    <asp:Button ID="btnUpdate"
        runat="server"
        Text="Update Employee"
        CssClass="btn btn-primary"
        OnClick="btnUpdate_Click" />

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="text-success" />

</asp:Content>