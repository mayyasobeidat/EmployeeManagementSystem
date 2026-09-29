<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AddEmployee.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Employees.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Employee</h2>

   <div class="form-group">
    <label>First Name</label>

    <asp:TextBox ID="txtFirstName"
        runat="server"
        CssClass="form-control" />

    <asp:RequiredFieldValidator
        ID="rfvFirstName"
        runat="server"
        ControlToValidate="txtFirstName"
        ErrorMessage="First Name is required."
        CssClass="text-danger" />
</div>

<div class="form-group">
    <label>Last Name</label>

    <asp:TextBox ID="txtLastName"
        runat="server"
        CssClass="form-control" />

    <asp:RequiredFieldValidator
        ID="rfvLastName"
        runat="server"
        ControlToValidate="txtLastName"
        ErrorMessage="Last Name is required."
        CssClass="text-danger" />
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

    <asp:TextBox ID="txtPhone"
        runat="server"
        CssClass="form-control" />
</div>



<div class="form-group">
    <label>Job Title</label>

    <asp:TextBox ID="txtJobTitle"
        runat="server"
        CssClass="form-control" />

    <asp:RequiredFieldValidator
        ID="rfvJobTitle"
        runat="server"
        ControlToValidate="txtJobTitle"
        ErrorMessage="Job Title is required."
        CssClass="text-danger" />
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

    <asp:TextBox ID="txtSalary"
        runat="server"
        CssClass="form-control" />

    <asp:RequiredFieldValidator
        ID="rfvSalary"
        runat="server"
        ControlToValidate="txtSalary"
        ErrorMessage="Salary is required."
        CssClass="text-danger" />

    <asp:RangeValidator
        ID="rvSalary"
        runat="server"
        ControlToValidate="txtSalary"
        Type="Double"
        MinimumValue="0"
        MaximumValue="1000000"
        ErrorMessage="Salary must be between 0 and 1,000,000."
        CssClass="text-danger" />
</div>

    <asp:Button ID="btnAdd"
        runat="server"
        Text="Add Employee"
        CssClass="btn btn-primary"
        OnClick="btnAdd_Click" />

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="text-success" />

</asp:Content>