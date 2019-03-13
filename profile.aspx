<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="assets/styles/profile/settings.min.css">
    <title>Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
        
        <div class="ks-page-header">
            <section class="ks-title">
                <h2>Profile </h2>  
            </section>
        </div>

        <div class="ks-page-content">
            <div class="ks-page-content-body ks-profile">
                <div class="ks-profile-header">
                    <div class="ks-profile-header-user">
                        <%--<asp:Image ID="ProfileImage" runat="server" class="ks-avatar" width="100" height="100"/>--%>
                         <asp:Image ID="ProfileImage" runat="server" width="100" height="100" class="ks-avatar"></asp:Image>

                        <div class="ks-info">
                            <b><div class="ks-name">
                                <asp:Label ID="ProfileHeaderName" runat="server" Text="Label"></asp:Label></div>
                            <div class="ks-description">
                                <asp:Label ID="ProfileHeaderDesignation" runat="server" Text="Label"></asp:Label></div></b>
                        </div>
                    </div>
                    <div class="ks-profile-header-statistics">
                     <asp:FileUpload ID="fileUpload" runat ="server" />
                        <asp:LinkButton ID="ProfileUploadButton" runat="server" Text="Button" class="btn btn-primary" OnClick="upload">
							<span class="la la-upload ks-icon"></span>
                               
                            <span class="ks-text">Upload Image</span>
                        </asp:LinkButton>
                       <asp:Label ID="lbl" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="ks-profile-header">
                    <div class="ks-profile-header-user">
                        <%--<asp:Image ID="ProfileImage" runat="server" class="ks-avatar" width="100" height="100"/>--%>
                         <asp:Image ID="ParentImage" runat="server" width="100" height="100" class="ks-avatar"></asp:Image>

                        <div class="ks-info">
                            <b><div class="ks-name">
                                <asp:Label ID="ParentHeaderName" runat="server" Text="Parents"></asp:Label></div>
                            <div class="ks-description">
                                <asp:Label ID="ParentDesignathion" runat="server" Text=""></asp:Label></div></b>
                        </div>
                    </div>
                    <div class="ks-profile-header-statistics">
                     <asp:FileUpload ID="parentsupload" runat ="server" />
                        <asp:LinkButton ID="ParentsUploadButton" runat="server" Text="Button" class="btn btn-primary" OnClick="upload1">
							<span class="la la-upload ks-icon"></span>
                               
                            <span class="ks-text">Upload Image</span>
                        </asp:LinkButton>
                       <asp:Label ID="Label3" runat="server"></asp:Label>
                    </div>
                </div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Button" style="margin:10px" class="btn btn-primary" OnClick="goToSeniorUpdate">
							<span class="la la-upload ks-icon"></span>
                               
                            <span class="ks-text">Update senior</span>
                        </asp:LinkButton>
                <div class="ks-tabs-container ks-tabs-default ks-tabs-no-separator ks-full ks-light">
                    <ul class="nav ks-nav-tabs">
                        <li class="nav-item">
                            <a class="nav-link active " href="#" data-toggle="tab" data-target="#overview" aria-expanded="true">Details</a>
                        </li>
                    </ul>
                    <div class="tab-content"><div class="tab-pane active" id="settings" role="tabpanel" aria-expanded="false">
                            <div class="ks-settings-tab">
                               <div class="ks-settings-form-wrapper">
								   <div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Name</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileName" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Employee id</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileId" runat="server" Text="Label"></asp:Label></label>
									</div> 
									<div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Phone</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfilePhone" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Email id</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileEmail" runat="server" Text="Label"></asp:Label></label>
									</div> 
									<div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Date of Birth</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileDob" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Date if joining</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileDoj" runat="server" Text="Label"></asp:Label></label>
									</div> 
									<div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Address</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileAddress" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Blood group</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileBloodgroup" runat="server" Text="Label"></asp:Label></label>
									</div> 
									<div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Region</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileRegion" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Head quarter</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileHq" runat="server" Text="Label"></asp:Label></label>
									</div> 
									<div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Level</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileLevel" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Designation</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileDesignation" runat="server" Text="Label"></asp:Label></label>
									</div> 
									<div class="form-group row">
										<label for="default-input" class="col-sm-2 form-control-label"><b>Division</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileDivision" runat="server" Text="Label"></asp:Label></label>
										<label for="default-input" class="col-sm-2 form-control-label"><b>Adhar Card</b></label>
										<label for="default-input" class="col-sm-3 form-control-label"><asp:Label ID="ProfileAdharCard" runat="server" Text="Label"></asp:Label></label>
									</div> 
									
								</div>
								
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
   

</asp:Content>

