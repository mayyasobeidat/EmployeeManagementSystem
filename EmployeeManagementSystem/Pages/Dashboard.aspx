<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="EmployeeManagementSystem.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Dashboard</h2>

    <div class="row">

        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Employees
                </div>

                <div class="panel-body">
                    <h2>
                        <asp:Label ID="lblEmployeeCount"
                            runat="server"
                            Text="0">
                        </asp:Label>
                    </h2>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="panel panel-success">
                <div class="panel-heading">
                    Departments
                </div>

                <div class="panel-body">
                    <h2>
                        <asp:Label ID="lblDepartmentCount"
                            runat="server"
                            Text="0">
                        </asp:Label>
                    </h2>
                </div>
            </div>
        </div>

    </div>

</asp:Content>