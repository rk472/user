<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="report.aspx.cs" Inherits="report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <head>
    <meta charset="UTF-8">
    <title>Makeway Report</title>

	<link rel="stylesheet" type="text/css" href="libs/bootstrap-daterange-picker/daterangepicker.css">
    <link rel="stylesheet" type="text/css" href="assets/styles/libs/bootstrap-daterange-picker/daterangepicker.min.css">
    <link rel="stylesheet" type="text/css" href="libs/select-multi/multi.min.css">
    <link rel="stylesheet" type="text/css" href="libs/select2/css/select2.min.css"> <!-- Original -->
    <link rel="stylesheet" type="text/css" href="assets/styles/libs/select2/select2.min.css"> 	
     <link rel="stylesheet" type="text/css" href="libs/prism/prism.css">
    <!-- original -->
    <link rel="stylesheet" type="text/css" href="assets/styles/libs/bootstrap-notify/bootstrap-notify.min.css">
    <!-- customization -->

</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="Server">
    
        <div class="ks-page-header">
            <section class="ks-title">
                <h3>Reporting</h3>
            </section>
        </div>
        <div class="ks-page-content">
            <div class="ks-page-content-body ks-tabs-page-container">
                <div class="tab-content">
                 <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">  </asp:ScriptManager>
                    <div class="tab-pane active ks-column-section" id="in-patient" role="tabpanel">
                        <div class="row" style="justify-content: center">
                                
                            <%--<input type="text" name="datontent: center; text-align: center">erange" value="10/24/1984" class="form-control ks-daterange-single col-xl-3"
                                style="margin-bottom: 10px; justify-c--%>
                                <asp:TextBox ID="ReportDatetxt" runat="server" class="form-control ks-daterange-single col-xl-3"  style="margin-bottom: 10px; text-align:center"></asp:TextBox>
                        </div>
                        <div class="row" style="justify-content: center">
                            <div>
                                <div class="ks-tabs-container ks-tabs-default ks-tabs-no-separator">
                                    <ul class="nav ks-nav-tabs">
                                        <li class="nav-item"><a class="nav-link " href="#" data-toggle="tab" data-target="#normal">
                                            Field Work</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#conference">
                                            Conference</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#leave">
                                            Leave</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#meeting">
                                            Meeting</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#closing">
                                            Closing day</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#travel">
                                            Travel</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#training">
                                            Training</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#camp">
                                            Medical Camp</a> </li>
                                        <li class="nav-item"><a class="nav-link" href="#" data-toggle="tab" data-target="#other">
                                            Other</a> </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div class="tab-pane" id="normal" role="tabpanel">

                                            <div class="form-group row">
                                                <%--<label for="default-input" class="col-sm-2 form-control-label">
                                                    State</label>--%>
                                                
                                               
                                                    <asp:Label ID="Statelbl" runat="server" Text="State" class="col-sm-2 form-control-label"></asp:Label>
                                                <div class="col-sm-3">
                                                   <%-- <select id="select2-id-label-single" class="form-control ks-select ">
                                                        <option value="A">A</option>
                                                        <option value="B">B</option>
                                                        <option value="C">C</option>
                                                        <option value="D">D</option>
                                                    </select>--%>
                                                    <asp:DropDownList ID="StateDropdown" runat="server" class="form-control ks-select " OnSelectedIndexChanged="StateDropdown_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<label for="default-input" class="col-sm-2 form-control-label">
                                                    City</label>--%>
                                                    <asp:Label ID="Citylbl" runat="server" Text="City" class="col-sm-2 form-control-label"></asp:Label>
                                                <div class="col-sm-3">
                                                    <%--<select id="select2-id-label-single" class="form-control ks-select ">
                                                        <option value="A">A</option>
                                                        <option value="B">B</option>
                                                        <option value="C">C</option>
                                                        <option value="D">D</option>
                                                    </select>--%>
                                                    <asp:DropDownList ID="CityDropdown" runat="server"  class="form-control ks-select " OnSelectedIndexChanged="CityDropdown_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </div>
                                                </div>
                                                 <div class="form-group row">
                                                <div class="col-sm-5">
                                                   
                                                   <%-- <asp:DropDownList ID="DoctorDropdown"  multiple="multiple" class="form-control ks-select " runat="server" select="multiple" >
                                                  
                                                    </asp:DropDownList>--%>
                                                     <asp:ListBox ID="DoctorDropdown" runat="server" class="form-control ks-select " SelectionMode="Multiple" AutoPostBack="true">
                                                       
                                                    </asp:ListBox>
                                                </div>
                                                                                              
                                                <div class="col-sm-5">
                                                    <%--<select multiple="multiple" name="favorite_fruits" id="select-multi-2">
                                                        <option>Apple</option>
                                                        <option>Banana</option>
                                                        <option>Blueberry</option>
                                                        <option>Cherry</option>
                                                        <option>Coconut</option>
                                                        <option>Grapefruit</option>
                                                        <option>Kiwi</option>
                                                        <option>Lemon</option>
                                                        <option>Lime</option>
                                                        <option>Mango</option>
                                                        <option>Orange</option>
                                                        <option>Papaya</option>
                                                    </select>--%>
                                                     <%-- <asp:DropDownList ID="MedicineDropdown"  class="form-control ks-select " runat="server" select="multiple" >
                                                       
                                                    </asp:DropDownList>--%>
                                                     <asp:ListBox ID="MedicineDropdown" runat="server" class="form-control ks-select " SelectionMode="Multiple" AutoPostBack="true">
                                                       
                                                    </asp:ListBox>
                                                </div>
                                            </div>
                                            <div class="ks-items-block" style="margin-top: 10px">
                                                <%--<button class="btn btn-primary">
                                                    Report</button>--%>
                                                    <asp:Button ID="Normalreportbtn" runat="server" Text="Report" class="btn btn-primary" OnClick="Normalreport" >
                                                    </asp:Button>
                                            </div>
                                        </div>

                                        <div class="tab-pane" id="conference" role="tabpanel">
                                            <div class="col-sm-10">
                                                <%--<input type="text" class="form-control active" id="active-input" placeholder="Where is the conference ? " />--%>
                                                <asp:TextBox ID="Conferencetxt" runat="server" class="form-control active" placeholder="Where is the conference ?" >
                                                </asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                    <%--<button class="btn btn-primary">
                                                        Report</button>--%>
                                                        <asp:Button ID="Conferencereportbtn" runat="server" Text="Report"  class="btn btn-primary" OnClientClick="return validatecon();" OnClick="Conferencereport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="leave" role="tabpanel">
                                            <div class="col-sm-10">
                                                <%--<input type="text" class="form-control active" id="active-input" placeholder="Tell us the reason" />--%>
                                                  <asp:TextBox ID="Leavetxt" runat="server" class="form-control active" placeholder="Tell us the reason"></asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                    <asp:Button ID="Leavereportbtn" runat="server" Text="Report" class="btn btn-primary" OnClientClick="return validateleave();" OnClick="Leavereport" ></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="meeting" role="tabpanel">
                                            <div class="col-sm-10">
                                               <%-- <input type="text" class="form-control active" id="active-input" placeholder="Where is the meeting ? " />--%>
                                               <asp:TextBox ID="Meetingtxt" runat="server" class="form-control active" placeholder="Where is the meeting ? "></asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                    <%--<button class="btn btn-primary">
                                                        Report</button>--%>
                                                        <asp:Button ID="Meetingreportbtn" runat="server" Text="Report"  class="btn btn-primary" OnClientClick="return validatemeeting();" OnClick="Meetingreport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="closing" role="tabpanel">
                                            <div class="col-sm-10">
                                             <div class="form-group row">
                                                <div class="col-sm-5">
                                                  <%-- <asp:DropDownList ID="StockistDropdown" multiple="true" class="form-control ks-select " runat="server"  autopostback="true">
                                                     
                                                   </asp:DropDownList>--%>
                                                    <asp:ListBox ID="StockistDropdown" runat="server" class="form-control ks-select " SelectionMode="Multiple" AutoPostBack="true">
                                                       
                                                    </asp:ListBox>
 
                                                </div>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                  <%--<button class="btn btn-primary">
                                                        Report</button>--%>
                                                        <asp:Button ID="Closingreportbtn" runat="server" Text="Report" class="btn btn-primary" OnClick="Closingreport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                        <div class="tab-pane" id="travel" role="tabpanel">
                                            <div class="col-sm-10">
                                                <%--<input type="text" class="form-control active" id="active-input" placeholder="From where ?" />
                                                <input type="text" class="form-control active" id="active-input" placeholder="To where ? "
                                                    style="margin-top: 10px" />--%>
                                                    <asp:TextBox ID="Travelfromtxt" runat="server" class="form-control active"  placeholder="From where ?" ></asp:TextBox>
                                                    <asp:TextBox ID="Traveltotxt" runat="server" class="form-control active" placeholder="To where ?" style="margin-top: 10px"></asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                   <asp:Button ID="Travelreportbtn" runat="server" Text="Report" class="btn btn-primary" OnClientClick="return validatetravel();" OnClick="Travelreport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="training" role="tabpanel">
                                            <div class="col-sm-10">
                                                <%--<input type="text" class="form-control active" id="active-input" placeholder="Where is the training going on  ? " />--%>
                                                <asp:TextBox ID="Trainingtxt" runat="server" class="form-control active" placeholder="Where is the training going on  ? "></asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                    <%--<button class="btn btn-primary">
                                                        Report</button>--%>
                                                        <asp:Button ID="Trainingreportbtn" runat="server" Text="Report" class="btn btn-primary" OnClientClick="return validatetraining();" OnClick="Trainingreport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="camp" role="tabpanel">
                                            <div class="col-sm-10">
                                                <%--<input type="text" class="form-control active" id="active-input" placeholder="Where have you put the camp ? " />--%>
                                                <asp:TextBox ID="Camptxt" runat="server" class="form-control active" placeholder="Where have you put the camp ? "></asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                   <%-- <button class="btn btn-primary">
                                                        Report</button>--%>
                                                        <asp:Button ID="Campreportbtn" runat="server" Text="Report" class="btn btn-primary" OnClientClick="return validatecamp();" OnClick="Campreport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="other" role="tabpanel">
                                            <div class="col-sm-10">
                                                <%--<input type="text" class="form-control active" id="active-input" placeholder="What's the other thing ? " />--%>
                                                <asp:TextBox ID="Othertxt" runat="server" class="form-control active"  placeholder="What's the other thing ? " ></asp:TextBox>
                                                <div class="ks-items-block" style="margin-top: 10px">
                                                    <%--<button class="btn btn-primary">
                                                        Report</button>--%>
                                                        <asp:Button ID="Otherreportbtn" runat="server" Text="Report" class="btn btn-primary" OnClientClick="return validateother();" OnClick="Otherreport"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <%--<script src="libs/jquery/jquery.min.js"></script>
    <script src="libs/popper/popper.min.js"></script>
    <script src="assets/scripts/common.min.js"></script>
--%>

    <script src="libs/momentjs/moment-with-locales.min.js"></script>
    <script src="libs/bootstrap-daterange-picker/daterangepicker.js"></script>
    
    <script type="application/javascript">
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
</script>
<script src="libs/select-multi/multi.min.js"></script>
<script src="libs/select2/js/select2.min.js"></script>
<script type="application/javascript">
(function ($) {
    $(document).ready(function () {
        multi($('#bodyContent_DoctorDropdown').get(0), {
            'enable_search': true,
            'search_placeholder': 'Search Doctor',
        });
         multi($('#bodyContent_MedicineDropdown').get(0), {
            'enable_search': true,
            'search_placeholder': 'Search Medicine',
        });
         multi($('#bodyContent_StockistDropdown').get(0), {
            'enable_search': true,
            'search_placeholder': 'Search Stockist',
            'includeSelectAllOption': true
        });

    });
})(jQuery);
</script>
  
<script type="text/javascript">
    function validatecon() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Conferencetxt.ClientID%>').value == "") {
           danger('Enter the place of conference');
            document.getElementById('<%=Conferencetxt.ClientID%>').focus();
            return false;
        }
    }
    function validateleave() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Leavetxt.ClientID%>').value == "") {
            danger('ENTER YOUR REASON FOR LEAVE');
            document.getElementById('<%=Leavetxt.ClientID%>').focus();
            return false;
        }
    }
    function validatemeeting() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Meetingtxt.ClientID%>').value == "") {
           danger('Enter the place of meeting');
            document.getElementById('<%=Meetingtxt.ClientID%>').focus();
            return false;
        }
    }
    function validatetravel() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Travelfromtxt.ClientID%>').value == "") {
           danger('Enter the travel from');
            document.getElementById('<%=Travelfromtxt.ClientID%>').focus();
            return false;
        }
        if (document.getElementById('<%=Traveltotxt.ClientID%>').value == "") {
            danger('Enter the travel to');
            document.getElementById('<%=Traveltotxt.ClientID%>').focus();
            return false;
        }
    }
    function validatetraining() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Trainingtxt.ClientID%>').value == "") {
            danger('Enter the place of training');
            document.getElementById('<%=Trainingtxt.ClientID%>').focus();
            return false;
        }
    }
    function validatecamp() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Camptxt.ClientID%>').value == "") {
            danger('Enter the place of medical camp');
            document.getElementById('<%=Camptxt.ClientID%>').focus();
            return false;
        }
    }
    function validateother() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=Othertxt.ClientID%>').value == "") {
            danger('Enter the other thing');
            document.getElementById('<%=Othertxt.ClientID%>').focus();
            return false;
        }
    }

 </script>
       
</asp:Content>
