<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AdminOgretmenListesi.aspx.cs" Inherits="SoruHavuzu.AdminOgretmenListesi" %>
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
            <h3 class="page-title">Öğretmen Listesi
            </h3>
            <ul class="page-breadcrumb breadcrumb">

                <li>
                    <i class="fa fa-home"></i>
                    <a href="index.html">Home
                    </a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Öğretmen
                    </a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="OgrenciListesi.aspx">Öğretmen Listesi
                    </a>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN EXAMPLE TABLE PORTLET-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Öğretmen Listesi
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">

                    <table class="table table-striped table-hover table-bordered" id="Table1">
                            <asp:Repeater ID="rp_OgretmenListesi" runat="server" OnItemCommand="rp_OgretmenListesi_ItemCommand">
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td><%#Eval("Adi") %>
                                            </td>
                                            <td><%#Eval("Soyadi") %>
                                            </td>
                                            <td><%#Eval("KulAdi") %>
                                            </td>
                                            <td><%#Eval("Email") %>
                                            </td>
                                            <td><%#Eval("KullaniciDurumu") %>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" Text="Güncelle" CommandName="Edit" CommandArgument='<%#Eval("KullaniciId") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button2" Text="Sil" CommandName="Delete" CommandArgument='<%#Eval("KullaniciId") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                                <HeaderTemplate>
                                    <thead>
                                        <tr>
                                            <th>Öğretmen Adı
                                            </th>
                                            <th>Öğretmen Soyadı
                                            </th>
                                            <th>Kullanıcı Adı
                                            </th>
                                            <th>Öğretmen Email
                                            </th>
                                            <th>Öğretmen Durumu
                                            </th>
                                            <th>Düzenle
                                            </th>
                                            <th>Sil
                                            </th>
                                        </tr>
                                    </thead>
                                </HeaderTemplate>
                            </asp:Repeater>
                            </table>

                    <div class="table-toolbar">
                        <div class="btn-group">
                            <asp:Button ID="btnEkle" Text="Öğretmen Kayıt Ekle" runat="server" class="btn green" OnClick="btnEkle_Click" />
                            
                        </div>

                    </div>
                </div>
            </div>
            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>
    <!-- END PAGE CONTENT -->
</div>
</asp:Content>
