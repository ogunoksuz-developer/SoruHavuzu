<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LeftMenuOgretmen.ascx.cs" Inherits="SoruHavuzu.UC_LeftMenuOgretmen" %>
<div class="page-sidebar navbar-collapse collapse">
    <!-- add "navbar-no-scroll" class to disable the scrolling of the sidebar menu -->
    <!-- BEGIN SIDEBAR MENU -->
    <ul class="page-sidebar-menu" data-auto-scroll="true" data-slide-speed="200">
        <li class="sidebar-toggler-wrapper">
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
            <div class="sidebar-toggler hidden-phone" style="margin-left: 0px">
            </div>
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
        </li>
        <li class="sidebar-search-wrapper"></li>

        <li class="start active ">
            <a href="javascript:;">
                <i class="fa fa-shopping-cart"></i>
                <span class="title">Soru Havuzu
                </span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="OgretmenSoruListesi.aspx">
                        <i class="fa fa-tags"></i>
                        Soru Listesi
                    </a>
                </li>
                <li>
                    <a href="OgretmenSoruEkle.aspx">
                        <i class="fa fa-sitemap"></i>
                        Yeni Soru Oluştur
                    </a>
                </li>
                <li>
                    <a href="OgretmenSinavListesi.aspx">
                        <i class="fa fa-tags"></i>
                        Sınav Liste
                    </a>
                </li>
                <li>
                    <a href="OgretmenSinavEkle.aspx">
                        <i class="fa fa-sitemap"></i>
                        Sınav Bilgilerini Gir
                    </a>
                </li>
                 <li>
                    <a href="OgretmenSinavaSoruEkle.aspx">
                        <i class="fa fa-sitemap"></i>
                        Sınava Soru Ata
                    </a>
                </li>
                </ul>
        </li>
    </ul>
    <!-- END SIDEBAR MENU -->
</div>
