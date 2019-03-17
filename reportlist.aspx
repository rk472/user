<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="reportlist.aspx.cs" Inherits="reportlist" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<head>
 <meta charset="UTF-8">
    <title>Report List</title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link rel="stylesheet" type="text/css" href="libs/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="assets/fonts/line-awesome/css/line-awesome.min.css">
    <!--<link rel="stylesheet" type="text/css" href="assets/fonts/open-sans/styles.css">-->

    <link rel="stylesheet" type="text/css" href="assets/fonts/montserrat/styles.css">

    <link rel="stylesheet" type="text/css" href="libs/tether/css/tether.min.css">
    <link rel="stylesheet" type="text/css" href="libs/jscrollpane/jquery.jscrollpane.css">
    <link rel="stylesheet" type="text/css" href="libs/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" type="text/css" href="assets/styles/common.min.css">
    <!-- END GLOBAL MANDATORY STYLES -->

    <!-- BEGIN THEME STYLES -->
    <link rel="stylesheet" type="text/css" href="assets/styles/themes/primary.min.css">
    <link class="ks-sidebar-dark-style" rel="stylesheet" type="text/css" href="assets/styles/themes/sidebar-black.min.css">
    <!-- END THEME STYLES -->
	<link rel="stylesheet" type="text/css" href="libs/bootstrap-daterange-picker/daterangepicker.css">
<link rel="stylesheet" type="text/css" href="assets/styles/libs/bootstrap-daterange-picker/daterangepicker.min.css">
<link rel="stylesheet" type="text/css" href="libs/select-multi/multi.min.css">
<link rel="stylesheet" type="text/css" href="libs/select2/css/select2.min.css"> <!-- Original -->
<link rel="stylesheet" type="text/css" href="assets/styles/libs/select2/select2.min.css"> 	
</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">

        <div class="ks-page-header">
            <section class="ks-title">
                <h3>Reporting</h3>
            </section>
        </div>
        
        <div class="ks-page-content">
            <div class="ks-page-content-body ks-tabs-page-container">
             <div class="tab-content">
                <div class="tab-pane active ks-column-section" id="in-patient" role="tabpanel">
             <center>
                 <div style="margin-bottom: 50px">
                     <asp:Button ID="DownloadButton" runat="server" Text="Download File" OnClick="DownloadButton_Click"/>

                 </div>
             </center> 
				<div class="row" style="justify-content:center">
                        <%--<input type="text" name="daterange" value="10/24/1984" class="form-control ks-daterange-single col-xl-3" style="margin:10px;justify-content:center;text-align:center">
						<input type="text" name="daterange" value="10/24/1984" class="form-control ks-daterange-single col-xl-3" style="margin:10px;justify-content:center;text-align:center">
						<button class="btn btn-primary" style="margin:10px">Report</button>--%>
                         <asp:TextBox ID="ReportFromDatetxt" runat="server" class="form-control ks-daterange-single col-xl-3"  style="margin: 10px; text-align:center"></asp:TextBox>
                          <asp:TextBox ID="ReportToDatetxt" runat="server" class="form-control ks-daterange-single col-xl-3"  style="margin: 10px; text-align:center"></asp:TextBox>
                          <asp:Button ID="ReportBtn" runat="server" Text="Report" class="btn btn-primary" style="margin:10px"  OnClick="showreport"></asp:Button>
                </div> 
                <div>
                     <asp:Label ID="lblerrormsg" runat="server" Text=""  style="margin: 10px; text-align:center"></asp:Label>
                </div>
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
    

<!-- DATE PICKER -->
<script src="libs/momentjs/moment-with-locales.min.js"></script>
<script src="libs/bootstrap-daterange-picker/daterangepicker.js"></script>
<!-- DATE PICKER -->

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
			multi($('#select-multi').get(0), {
				'enable_search': true,
				'search_placeholder': 'Search...',
			});
		});
	})(jQuery);
</asp:Content>

