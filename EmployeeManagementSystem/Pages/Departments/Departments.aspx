<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Departments.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Departments.Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Departments</h2>

    <asp:Label
    ID="lblMessage"
    runat="server"
    CssClass="text-danger" />
    <br />

<asp:HyperLink
    ID="lnkAddDepartment"
    runat="server"
    Text="Add Department"
    NavigateUrl="~/Pages/Departments/AddDepartment.aspx"
    CssClass="btn btn-primary" />

<br /><br />
<asp:GridView ID="gvDepartments"
    runat="server"
    AutoGenerateColumns="False"
    CssClass="table table-striped"
    OnRowCommand="gvDepartments_RowCommand">
        <Columns>

            <asp:BoundField
                DataField="DepartmentId"
                HeaderText="ID" />

            <asp:BoundField
                DataField="DepartmentName"
                HeaderText="Department Name" />

            <asp:BoundField
                DataField="Description"
                HeaderText="Description" />

        <asp:BoundField
    DataField="IsActive"
    HeaderText="Active" />

<asp:TemplateField HeaderText="Action">
    <ItemTemplate>

        <asp:HyperLink
            ID="lnkEdit"
            runat="server"
            Text="Edit"
            NavigateUrl='<%# "EditDepartment.aspx?id=" + Eval("DepartmentId") %>'
            CssClass="btn btn-sm btn-primary" />

        <asp:LinkButton
            ID="btnDelete"
            runat="server"
            Text="Delete"
            CommandName="DeleteDepartment"
            CommandArgument='<%# Eval("DepartmentId") %>'
            CssClass="btn btn-sm btn-danger"
            OnClientClick="return confirm('Are you sure you want to delete this department?');" />

    </ItemTemplate>
</asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>