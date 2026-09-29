<%@ Page Title="Employee Details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EmployeeDetails.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Employees.EmployeeDetails" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Employee Details</h2>

    <div class="form-group">
        <label>First Name</label>
        <asp:Label
            ID="lblFirstName"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Last Name</label>
        <asp:Label
            ID="lblLastName"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Email</label>
        <asp:Label
            ID="lblEmail"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Phone</label>
        <asp:Label
            ID="lblPhone"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Job Title</label>
        <asp:Label
            ID="lblJobTitle"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Department</label>
        <asp:Label
            ID="lblDepartmentId"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Salary</label>
        <asp:Label
            ID="lblSalary"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Hire Date</label>
        <asp:Label
            ID="lblHireDate"
            runat="server"
            CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Status</label>
        <asp:Label
            ID="lblStatus"
            runat="server"
            CssClass="form-control" />
    </div>

    <br />

    <asp:HyperLink
        ID="lnkBack"
        runat="server"
        NavigateUrl="~/Pages/Employees/Employees.aspx"
        Text="Back to Employees"
        CssClass="btn btn-secondary" />

</asp:Content>