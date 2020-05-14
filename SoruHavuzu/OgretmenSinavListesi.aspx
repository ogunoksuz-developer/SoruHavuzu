<%@ Page Title="" Language="C#" MasterPageFile="~/OgretmenPage.Master" AutoEventWireup="true" CodeBehind="OgretmenSinavListesi.aspx.cs" Inherits="SoruHavuzu.OgretmenSinavListesi" %>

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
                <h3 class="page-title">Sinav Listesi
                </h3>
                <ul class="page-breadcrumb breadcrumb">

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
                        <a href="#">Sinav Listesi
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
                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-edit"></i>Sinav Listesi
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                            <asp:Repeater ID="rp_SinavListe" runat="server" OnItemCommand="rp_SinavListe_ItemCommand">
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td><%#Eval("DersAdi") %>
                                            </td>
                                            <td><%#Eval("SinavAdi") %>
                                            </td>
                                            <td><%#Eval("SoruSayisi") %>
                                            </td>
                                            <td><%#Eval("SinavSuresi") %>
                                            </td>
                                            <td><%#Eval("SinavBaslamaTarihi") %>
                                            </td>
                                            <td><%#Eval("SinavBitisTarihi") %>
                                            </td>
                                            <td><%#Eval("SinavDurumu") %>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button2" Text="Güncelle" CommandName="Edit" CommandArgument='<%#Eval("SinavId") %>' runat="server" />

                                            </td>
                                            <td>
                                                <asp:Button ID="Button3" Text="Sil" CommandName="Delete" CommandArgument='<%#Eval("SinavId") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                                <HeaderTemplate>
                                    <thead>
                                        <tr>
                                            <th>Ders Adı
                                            </th>
                                            <th>Sınav Adı
                                            </th>
                                            <th>Soru Sayısı
                                            </th>
                                            <th>Sınav Süresi
                                            </th>
                                            <th>Sınava Başlama Tarihi
                                            </th>
                                            <th>Sınav Bitiş Tarihi
                                            </th>
                                            <th>Sınav Durumu
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
                                <asp:Button ID="Button1" Text="Yeni Sinav Ekle" runat="server" class="btn green" OnClick="Button1_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
