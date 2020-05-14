<%@ Page Title="" Language="C#" MasterPageFile="~/OgretmenPage.Master" AutoEventWireup="true" CodeFile="OgretmenSinavEkle.aspx.cs" Inherits="SoruHavuzu.OgretmenSinavEkle" %>

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
                <h3 class="page-title">Yeni Sınav
                </h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li class="btn-group"></li>
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.html">Home
                        </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="#">Soru Havuzu
                        </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="YeniDersEkle.aspx">Yeni Sınav Ekle
                        </a>
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
                                <i class="fa fa-shopping-cart"></i>Yeni Sınav Kaydı
                            </div>
                            <div class="actions btn-set">
                                <asp:Button ID="btnSinavOlustur" Text="Kaydet" runat="server" class="btn green" OnClick="btnSinavOlustur_Click"/>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="tabbable">
                                <ul class="nav nav-tabs">
                                    <li class="active">
                                        <a href="#tab_general" data-toggle="tab">Sınav Kaydını Yapınız
                                        </a>
                                    </li>

                                </ul>
                                <div class="tab-content no-space">
                                    <div class="tab-pane active" id="tab_general">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Ders Adı:
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:DropDownList ID="ddlDersAdi" runat="server" class="form-control" OnDataBound="ddlDersAdi_DataBound">
                                                        <asp:ListItem Text="Seçiniz" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Adı:
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSinavAdi" runat="server" placeholder="Sınavın Soru Sayısını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Soru Sayısı:
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSoruSayisi" runat="server" placeholder="Sınavın Soru Sayısını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Süresi(dk):
													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSinavSuresi" runat="server" placeholder="Sınav Süresini Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Başlangıç Tarihi:
													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSinavBaslangicTarihi" runat="server" placeholder="Sınav Süresini Giriniz" TextMode="Date" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Sınav Bitiş Tarihi:
													
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtSinavBitisTarihi" runat="server" placeholder="Sınav Süresini Giriniz" TextMode="Date" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <span class="help-block">
                                                <asp:Label ID="lbl_Error" runat="server" Text="" Visible="false"></asp:Label>
                                            </span>
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
</asp:Content>
