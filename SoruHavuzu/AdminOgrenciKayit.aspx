<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminOgrenciKayit.aspx.cs" Inherits="SoruHavuzu.AdminOgrenciKayit" %>

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
                <h3 class="page-title">Yeni Öğrenci
                </h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li class="btn-group"></li>
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="AdminFirstPage.aspx">Soru Havuzu
                        </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="AdminOgrenciListesi">Öğrenci
                        </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="YeniDersEkle.aspx">Yeni Öğrenci Ekle
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
                                <i class="fa fa-shopping-cart"></i>Yeni Öğrenci Kaydı
                            </div>
                            <div class="actions btn-set">

                                <asp:Button ID="bnt_Save" runat="server" Text="Kaydet" class="btn green" OnClick="bnt_Save_Click" />


                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="tabbable">
                                <ul class="nav nav-tabs">
                                    <li class="active">
                                        <a href="#tab_general" data-toggle="tab">Öğrenci Kaydını Yapınız
                                        </a>
                                    </li>

                                </ul>
                                <div class="tab-content no-space">
                                    <div class="tab-pane active" id="tab_general">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Öğrenci Adı:
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Öğrenci Adini Giriniz" ControlToValidate="txtOgrenciAdi" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtOgrenciAdi" runat="server" placeholder="Öğrenci Adı Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Öğrenci Soyadı:
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Öğrenci Soyadını Giriniz" ControlToValidate="txtOgrenciSoyadi" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtOgrenciSoyadi" runat="server" placeholder="Öğrenci Soyadını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Öğrenci No:
													<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Öğrenci Noyu Girniz" ControlToValidate="txtOgrenciNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtOgrenciNo" runat="server" placeholder="Öğrenci Numarasını Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Öğrenci Email:
													<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Öğrenci Mail Adresini Giriniz" ControlToValidate="txtOgrenciEmail" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email Adresini yalnış Formatta Giriniz" ControlToValidate="txtOgrenciEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtOgrenciEmail" runat="server" placeholder="Öğrenci Emailini Giriniz" class="form-control">

                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Öğrenci Şifre:
													<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Şifreyi Giriniz" ControlToValidate="txtOgrenciSifre" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtOgrenciSifre" runat="server" placeholder="Öğrenci Şifresini Giriniz" class="form-control" TextMode="Password">

                                                    </asp:TextBox>
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
    </div>
</asp:Content>
