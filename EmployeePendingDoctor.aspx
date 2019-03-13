<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeePendingDoctor.aspx.cs" Inherits="EmployeePendingDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
<asp:Label id="lblmsg" runat=server></asp:Label>
<div class="ks-page-content">
            <div class="ks-page-content-body ks-content-nav">
                <div class="ks-nav-body">
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
 </asp:Content>

