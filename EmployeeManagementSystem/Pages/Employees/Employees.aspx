<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Employees.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Employees.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employees</h2>
 <br />
    <div class="form-group">
    <label>Search Employees</label>

    <asp:TextBox
        ID="txtSearch"
        runat="server"
        CssClass="form-control"
        placeholder="Search by name, email or job title">
    </asp:TextBox>

    <br />

    <asp:DropDownList
        ID="ddlDepartment"
        runat="server"
        CssClass="form-control">
    </asp:DropDownList>

    <br />

    <asp:Button
        ID="btnSearch"
        runat="server"
        Text="Search"
        CssClass="btn btn-primary"
        OnClick="btnSearch_Click" />

    <asp:Button
        ID="btnClear"
        runat="server"
        Text="Clear"
        CssClass="btn btn-secondary"
        OnClick="btnClear_Click" />
</div>


    <br /><br />
    <a href="AddEmployee.aspx" class="btn btn-primary">
    Add Employee
</a>
    <br /><br />
   <asp:GridView ID="gvEmployees"
    runat="server"
    OnRowCommand="gvEmployees_RowCommand"
        AutoGenerateColumns="False"
        CssClass="table table-striped">

        <Columns>

            <asp:BoundField DataField="EmployeeId"
                HeaderText="ID" />

            <asp:BoundField DataField="FirstName"
                HeaderText="First Name" />

            <asp:BoundField DataField="LastName"
                HeaderText="Last Name" />

            <asp:BoundField DataField="JobTitle"
                HeaderText="Job Title" />
            <asp:BoundField DataField="DepartmentName"
    HeaderText="Department" />
            <asp:BoundField DataField="Email"
                HeaderText="Email" />

            <asp:BoundField DataField="Salary"
                HeaderText="Salary" />

            <asp:BoundField DataField="HireDate"
                HeaderText="Hire Date"
                DataFormatString="{0:yyyy-MM-dd}" />
          <asp:TemplateField HeaderText="Action">
    <ItemTemplate>

        <asp:HyperLink
            ID="lnkDetails"
            runat="server"
            Text="Details"
            NavigateUrl='<%# "EmployeeDetails.aspx?id=" + Eval("EmployeeId") %>'
            CssClass="btn btn-sm btn-info" />

        <asp:HyperLink
            ID="lnkEdit"
            runat="server"
            Text="Edit"
            NavigateUrl='<%# "EditEmployee.aspx?id=" + Eval("EmployeeId") %>'
            CssClass="btn btn-sm btn-primary" />

        <asp:LinkButton
            ID="btnDelete"
            runat="server"
            Text="Delete"
            CommandName="DeleteEmployee"
            CommandArgument='<%# Eval("EmployeeId") %>'
            CssClass="btn btn-sm btn-danger"
            OnClientClick="return confirm('Are you sure you want to delete this employee?');" />

    </ItemTemplate>
</asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>