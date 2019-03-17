<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JuniorsReport.aspx.cs" Inherits="JuniorsReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="libs/bootstrap-table/bootstrap-table.min.css"> <!-- Original -->
<link rel="stylesheet" type="text/css" href="assets/styles/libs/bootstrap-table/bootstrap-table.min.css"> <!-- Customization -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
<div class="ks-page-content">
        <div class="ks-page-content-body ks-content-nav">
            <div class="ks-nav-body">
                 <center>
                 <div style="margin-bottom: 50px">
                     <asp:Button ID="DownloadButton" runat="server" Text="Download File" OnClick="DownloadButton_Click"/>

                 </div>
             </center> 
             <asp:Label ID="lblId" runat="server"></asp:Label>
                <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                <asp:Label ID="lblReport" runat="server"></asp:Label>
                <div class="ks-nav-body-wrapper">
                    <div class="container-fluid"  style="overflow:auto;height:350px">
                        <asp:Table id="ksdatatable" class="table table-striped table-bordered" 
                             data-search="true" data-sort-name="name"
                            data-sort-order="desc" runat="server" GridLines="Horizontal">
                        </asp:Table>
                      </div>
                </div>
            </div>
        </div>
    </div>
    
    <script src="libs/bootstrap-table/bootstrap-table.min.js"></script>
   
</asp:Content>

