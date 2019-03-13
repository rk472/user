<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="updatesenior.aspx.cs" Inherits="updatesenior" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="ks-page-header">
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            <section class="ks-title">
                <h3><span style="color: green;"><b>Add your senior</b></span></h3>
            </section>
    </div>
    <div class="ks-page-content">
        <div class="ks-page-content-body ks-content-nav">
            <div class="ks-nav-body">
                <div class="ks-nav-body-wrapper">
                    <div class="container-fluid">
                        <div class="form-group row">
							
						    <label for="default-input" class="col-sm-2 form-control-label">Add your senior</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="seniorDropDown" runat="server" class="form-control ks-select ">
                                      
                                </asp:DropDownList>
                             </div>
                             <asp:Button ID="RequestDoctor" runat="server" Text="Update" class="btn btn-primary ks-rounded" OnClientClick="return validate();" OnClick="update" />
                         </div> 
                         <asp:Label ID="lbl1" runat="server"/>
                     </div>
                 </div>
             </div>
         </div>
     </div>
</asp:Content>

