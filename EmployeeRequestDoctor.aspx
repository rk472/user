<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeRequestDoctor.aspx.cs" Inherits="EmployeeRequestDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" type="text/css" href="libs/prism/prism.css">
    <!-- original -->
    <link rel="stylesheet" type="text/css" href="assets/styles/libs/bootstrap-notify/bootstrap-notify.min.css">
    <!-- customization --></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">
    <div class="ks-page-header">
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            <section class="ks-title">
                <h3><span style="color: green;"><b><font color="red">Request Doctor</font></b></span></h3>
            </section>
    </div>
    <div class="ks-page-content">
        <div class="ks-page-content-body ks-content-nav">
            <div class="ks-nav-body">
                <div class="ks-nav-body-wrapper">
                    <div class="container-fluid">
                    	<div class="form-group row">
                            <label for="default-input" class="col-sm-2 form-control-label">Name</label>
                            <div class="col-sm-3">
                                 <asp:TextBox ID="DoctorName" runat="server"  class="form-control"></asp:TextBox>
                            </div>
							<label for="default-input" class="col-sm-2 form-control-label">Specialization</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="DoctorSpecialization" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
							<label for="default-input" class="col-sm-2 form-control-label">Qualification</label>
                            <div class="col-sm-3">
                                  <asp:TextBox ID="DocotrQualification" runat="server" class="form-control"></asp:TextBox>
                            </div>
						    <label for="default-input" class="col-sm-2 form-control-label">Catagory</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="DoctorCategory" runat="server" class="form-control ks-select ">
                                      <asp:ListItem>A</asp:ListItem>
                                      <asp:ListItem>B</asp:ListItem>
                                      <asp:ListItem>C</asp:ListItem>
                                      <asp:ListItem>D</asp:ListItem>
                                </asp:DropDownList>
                             </div>
                         </div> 
                        <div class="form-group row">
                            <label for="default-input" class="col-sm-2 form-control-label">
                                State</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="DoctorState" runat="server" class="form-control ks-select "
                                    OnSelectedIndexChanged="DoctorState_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                            <label for="default-input" class="col-sm-2 form-control-label">
                                City</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="DoctorCity" runat="server" class="form-control ks-select ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="default-input" class="col-sm-2 form-control-label">
                                Date of Birth</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="dojtxt" runat="server" class="form-control ks-daterange-single"
                                    Style="margin-bottom: 10px; text-align: center"></asp:TextBox>
                            </div>
                            <label for="default-input" class="col-sm-2 form-control-label">
                                Date of Anniversery</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="doatxt" runat="server" class="form-control ks-daterange-single"
                                    Style="margin-bottom: 10px; text-align: center"></asp:TextBox>
                            </div>
                        </div> 
							
						<center>
                             <asp:Button ID="RequestDoctor" runat="server" Text="Request Doctor" class="btn btn-primary ks-rounded" OnClientClick="return validate();" OnClick="add_doctor" />
						</center>
						
                    </div>
                 </div>
              </div>
           </div>
       </div>
      <script  type="text/javascript" src="libs/momentjs/moment-with-locales.min.js"></script>
    <script src="libs/bootstrap-daterange-picker/daterangepicker.js"></script>
   
    <script type="text/javascript">
    
        (function ($) {
            $(document).ready(function () {
                $('a[data-toggle="tab"]').click(function (e) {
                    e.preventDefault();
                    $(this).tab('show');
                });
            });
        })(jQuery);
        $('.ks-daterange-single').daterangepicker({
            singleDatePicker: true,
            showDropdowns: true
        });
           function validate() {
            var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
            if (document.getElementById('<%=DoctorName.ClientID%>').value == "") {
                 danger('Enter the Doctor name');
                document.getElementById('<%=DoctorName.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=DoctorSpecialization.ClientID%>').value == "") {
                danger('Enter the Doctor Specialization');
                document.getElementById('<%=DoctorSpecialization.ClientID%>').focus()
                return false;
            }

            if (document.getElementById('<%=DocotrQualification.ClientID%>').value == "") {
                danger('Enter the Doctor Qualification');
                document.getElementById('<%=DocotrQualification.ClientID%>').focus();
                return false;
            }
            return true;
        }
        </script>

</asp:Content>

