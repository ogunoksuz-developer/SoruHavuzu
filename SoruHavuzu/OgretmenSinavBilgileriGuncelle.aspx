<%@ Page Title="" Language="C#" MasterPageFile="~/OgretmenPage.Master" AutoEventWireup="true" CodeBehind="OgretmenSinavBilgileriGuncelle.aspx.cs" Inherits="SoruHavuzu.OgretmenSinavBilgileriGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                        <h4 class="modal-title">Modal title</h4>
                    </div>
                    <div class="modal-body">
                        Widget settings form goes here
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn blue">Save changes</button>
                        <button type="button" class="btn default" data-dismiss="modal">Close</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <!-- BEGIN STYLE CUSTOMIZER -->
        <div class="theme-panel hidden-xs hidden-sm">
            <div class="toggler">
            </div>
            <div class="toggler-close">
            </div>
            <div class="theme-options">
                <div class="theme-option theme-colors clearfix">
                    <span>THEME COLOR
                    </span>
                    <ul>
                        <li class="color-black current color-default" data-style="default"></li>
                        <li class="color-blue" data-style="blue"></li>
                        <li class="color-brown" data-style="brown"></li>
                        <li class="color-purple" data-style="purple"></li>
                        <li class="color-grey" data-style="grey"></li>
                        <li class="color-white color-light" data-style="light"></li>
                    </ul>
                </div>
                <div class="theme-option">
                    <span>Layout
                    </span>
                    <select class="layout-option form-control input-small">
                        <option value="fluid" selected="selected">Fluid</option>
                        <option value="boxed">Boxed</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Header
                    </span>
                    <select class="header-option form-control input-small">
                        <option value="fixed" selected="selected">Fixed</option>
                        <option value="default">Default</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar
                    </span>
                    <select class="sidebar-option form-control input-small">
                        <option value="fixed">Fixed</option>
                        <option value="default" selected="selected">Default</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Sidebar Position
                    </span>
                    <select class="sidebar-pos-option form-control input-small">
                        <option value="left" selected="selected">Left</option>
                        <option value="right">Right</option>
                    </select>
                </div>
                <div class="theme-option">
                    <span>Footer
                    </span>
                    <select class="footer-option form-control input-small">
                        <option value="fixed">Fixed</option>
                        <option value="default" selected="selected">Default</option>
                    </select>
                </div>
            </div>
        </div>
        <!-- END STYLE CUSTOMIZER -->
        <!-- BEGIN PAGE HEADER-->
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">Konu Bilgileri Guncelle
                </h3>
                <ul class="page-breadcrumb breadcrumb">

                    <li>
                        <i class="fa fa-home"></i>
                        <a href="OgretmenFirstPage.aspx">Soru Havuzu
                        </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AdminSoruListesi.aspx">Soru
                        </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN PAGE CONTENT-->
        <div class="row">
            <div class="col-md-12">
                <div class="form-horizontal form-row-seperated">
                    <div class="portlet">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-shopping-cart"></i>Soru Güncelle
                            </div>
                            <div class="actions btn-set">

                                <asp:Button ID="bnt_Save" runat="server" Text="Kaydet" class="btn green" OnClick="bnt_Save_Click" />

                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="tabbable">
                                <ul class="nav nav-tabs">
                                    <li class="active">
                                        <a href="#tab_general" data-toggle="tab">Soru Bilgilerini Güncelle
                                        </a>
                                    </li>

                                </ul>
                                <div class="tab-content no-space">
                                    <div class="tab-pane active" id="tab_general">
                                        <div class="form-body">

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınavın Adı :													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSinavAdi" runat="server" placeholder="B Şıkkını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Soru Sayısı :													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSoruSayisi" runat="server" placeholder="C Şıkkını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Süresi :													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSinavSuresi" runat="server" placeholder="D Şıkkını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınavın Başlangıç Tarihi :													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtBaslangicTarihi" runat="server" TextMode="Date" placeholder="E Şıkkını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Bitiş Tarihi :													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtBitisTarihi" runat="server" TextMode="Date" placeholder="Doğru Cevabı Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sinav Durumu :
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:RadioButton ID="rbAktif" GroupName="RadioKonu" Text="Aktif" runat="server" />
                                                    <asp:RadioButton ID="rbPasif" GroupName="RadioKonu" Text="Pasif" runat="server" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab_meta">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Meta Title:</label>
                                                <div class="col-md-10">
                                                    <input type="text" class="form-control maxlength-handler" name="product[meta_title]" maxlength="100" placeholder="">
                                                    <span class="help-block">max 100 chars
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Meta Keywords:</label>
                                                <div class="col-md-10">
                                                    <textarea class="form-control maxlength-handler" rows="8" name="product[meta_keywords]" maxlength="1000"></textarea>
                                                    <span class="help-block">max 1000 chars
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Meta Description:</label>
                                                <div class="col-md-10">
                                                    <textarea class="form-control maxlength-handler" rows="8" name="product[meta_description]" maxlength="255"></textarea>
                                                    <span class="help-block">max 255 chars
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab_images">
                                        <div class="alert alert-success margin-bottom-10">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button>
                                            <i class="fa fa-warning fa-lg"></i>Image type and information need to be specified.
                                        </div>
                                        <div id="tab_images_uploader_container" class="text-align-reverse margin-bottom-10">
                                            <a id="tab_images_uploader_pickfiles" href="javascript:;" class="btn yellow">
                                                <i class="fa fa-plus"></i>Select Files
                                            </a>
                                            <a id="tab_images_uploader_uploadfiles" href="javascript:;" class="btn green">
                                                <i class="fa fa-share"></i>Upload Files
                                            </a>
                                        </div>
                                        <div class="row">
                                            <div id="tab_images_uploader_filelist" class="col-md-6 col-sm-12">
                                            </div>
                                        </div>
                                        <table class="table table-bordered table-hover">
                                            <thead>
                                                <tr role="row" class="heading">
                                                    <th width="8%">Image
                                                    </th>
                                                    <th width="25%">Label
                                                    </th>
                                                    <th width="8%">Sort Order
                                                    </th>
                                                    <th width="10%">Base Image
                                                    </th>
                                                    <th width="10%">Small Image
                                                    </th>
                                                    <th width="10%">Thumbnail
                                                    </th>
                                                    <th width="10%"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <a href="assets/img/works/img1.jpg" class="fancybox-button" data-rel="fancybox-button">
                                                            <img class="img-responsive" src="assets/img/works/img1.jpg" alt="">
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control" name="product[images][1][label]" value="Thumbnail image">
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control" name="product[images][1][sort_order]" value="1">
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][1][image_type]" value="1">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][1][image_type]" value="2">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][1][image_type]" value="3" checked>
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <a href="javascript:;" class="btn default btn-sm">
                                                            <i class="fa fa-times"></i>Remove
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="assets/img/works/img2.jpg" class="fancybox-button" data-rel="fancybox-button">
                                                            <img class="img-responsive" src="assets/img/works/img2.jpg" alt="">
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control" name="product[images][2][label]" value="Product image #1">
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control" name="product[images][2][sort_order]" value="1">
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][2][image_type]" value="1">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][2][image_type]" value="2" checked>
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][2][image_type]" value="3">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <a href="javascript:;" class="btn default btn-sm">
                                                            <i class="fa fa-times"></i>Remove
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="assets/img/works/img3.jpg" class="fancybox-button" data-rel="fancybox-button">
                                                            <img class="img-responsive" src="assets/img/works/img3.jpg" alt="">
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control" name="product[images][3][label]" value="Product image #2">
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control" name="product[images][3][sort_order]" value="1">
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][3][image_type]" value="1" checked>
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][3][image_type]" value="2">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            <input type="radio" name="product[images][3][image_type]" value="3">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <a href="javascript:;" class="btn default btn-sm">
                                                            <i class="fa fa-times"></i>Remove
                                                        </a>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="tab-pane" id="tab_reviews">
                                        <div class="table-container">
                                            <table class="table table-striped table-bordered table-hover" id="datatable_reviews">
                                                <thead>
                                                    <tr role="row" class="heading">
                                                        <th width="5%">Review&nbsp;#
                                                        </th>
                                                        <th width="10%">Review&nbsp;Date
                                                        </th>
                                                        <th width="10%">Customer
                                                        </th>
                                                        <th width="20%">Review&nbsp;Content
                                                        </th>
                                                        <th width="10%">Status
                                                        </th>
                                                        <th width="10%">Actions
                                                        </th>
                                                    </tr>
                                                    <tr role="row" class="filter">
                                                        <td>
                                                            <input type="text" class="form-control form-filter input-sm" name="product_review_no">
                                                        </td>
                                                        <td>
                                                            <div class="input-group date date-picker margin-bottom-5" data-date-format="dd/mm/yyyy">
                                                                <input type="text" class="form-control form-filter input-sm" readonly name="product_review_date_from" placeholder="From">
                                                                <span class="input-group-btn">
                                                                    <button class="btn btn-sm default" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                            <div class="input-group date date-picker" data-date-format="dd/mm/yyyy">
                                                                <input type="text" class="form-control form-filter input-sm" readonly name="product_review_date_to" placeholder="To">
                                                                <span class="input-group-btn">
                                                                    <button class="btn btn-sm default" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <input type="text" class="form-control form-filter input-sm" name="product_review_customer">
                                                        </td>
                                                        <td>
                                                            <input type="text" class="form-control form-filter input-sm" name="product_review_content">
                                                        </td>
                                                        <td>
                                                            <select name="product_review_status" class="form-control form-filter input-sm">
                                                                <option value="">Select...</option>
                                                                <option value="pending">Pending</option>
                                                                <option value="approved">Approved</option>
                                                                <option value="rejected">Rejected</option>
                                                            </select>
                                                        </td>
                                                        <td>
                                                            <div class="margin-bottom-5">
                                                                <button class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-search"></i>Search</button>
                                                            </div>
                                                            <button class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i>Reset</button>
                                                        </td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab_history">
                                        <div class="table-container">
                                            <table class="table table-striped table-bordered table-hover" id="datatable_history">
                                                <thead>
                                                    <tr role="row" class="heading">
                                                        <th width="25%">Datetime
                                                        </th>
                                                        <th width="55%">Description
                                                        </th>
                                                        <th width="10%">Notification
                                                        </th>
                                                        <th width="10%">Actions
                                                        </th>
                                                    </tr>
                                                    <tr role="row" class="filter">
                                                        <td>
                                                            <div class="input-group date datetime-picker margin-bottom-5" data-date-format="dd/mm/yyyy hh:ii">
                                                                <input type="text" class="form-control form-filter input-sm" readonly name="product_history_date_from" placeholder="From">
                                                                <span class="input-group-btn">
                                                                    <button class="btn btn-sm default date-set" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                            <div class="input-group date datetime-picker" data-date-format="dd/mm/yyyy hh:ii">
                                                                <input type="text" class="form-control form-filter input-sm" readonly name="product_history_date_to" placeholder="To">
                                                                <span class="input-group-btn">
                                                                    <button class="btn btn-sm default date-set" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <input type="text" class="form-control form-filter input-sm" name="product_history_desc" placeholder="To" />
                                                        </td>
                                                        <td>
                                                            <select name="product_history_notification" class="form-control form-filter input-sm">
                                                                <option value="">Select...</option>
                                                                <option value="pending">Pending</option>
                                                                <option value="notified">Notified</option>
                                                                <option value="failed">Failed</option>
                                                            </select>
                                                        </td>
                                                        <td>
                                                            <div class="margin-bottom-5">
                                                                <button class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-search"></i>Search</button>
                                                            </div>
                                                            <button class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i>Reset</button>
                                                        </td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END PAGE CONTENT-->
    </div>
</asp:Content>
