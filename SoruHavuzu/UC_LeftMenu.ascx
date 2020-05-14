<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LeftMenu.ascx.cs" Inherits="SoruHavuzu.UC_LeftMenu" %>
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
                    <a href="AdminDersListesi.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Ders Listesi
                    </a>
                </li>

                <li>
                    <a href="AdminDersEkle.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Yeni Ders Oluştur
                    </a>
                </li>

                <li>
                    <a href="AdminKonuListesi.aspx">
                        <i class="fa fa-shopping-cart"></i>
                        Konu Liste
                    </a>
                </li>

                <li>
                    <a href="AdminKonuEkle.aspx">
                        <i class="fa fa-shopping-cart"></i>
                        Yeni Konu Oluştur
                    </a>
                </li>
            </ul>

            <a href="javascript:;">
                <i class="fa fa-shopping-cart"></i>
                <span class="title">Öğretmen
                </span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="AdminOgretmenListesi.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Öğretmen Listesi
                    </a>
                </li>

                <li>
                    <a href="AdminOgretmenEkle.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Öğretmen Kayıt
                    </a>
                </li>

                <li>
                    <a href="AdminOgretmenDersEsle.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Öğretmen Ders Eşlemesi
                    </a>
                </li>
            </ul>

            <a href="javascript:;">
                <i class="fa fa-shopping-cart"></i>
                <span class="title">Öğrenci
                </span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="AdminOgrenciListesi.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Öğrenci Listesi
                    </a>
                </li>

                <li>
                    <a href="AdminOgrenciKayit.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Öğrenci Kayıt
                    </a>
                </li>

                <li>
                    <a href="AdminOgrenciDersEsle.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Öğrenci Ders Eşlemesi
                    </a>
                </li>
            </ul>
            <a href="javascript:;">
                <i class="fa fa-shopping-cart"></i>
                <span class="title">Destek
                </span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="AdminTaleplerListesi.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Talepler Listesi
                    </a>
                </li>
            </ul>
        </li>
    </ul>
</div>
