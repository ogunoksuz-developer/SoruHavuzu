<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LeftMenu_2.ascx.cs" Inherits="SoruHavuzu.UC_LeftMenu_2" %>
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
                <span class="title">Sınav
                </span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="OgrenciGirilenSinavlar.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Girilen Sınavlar
                    </a>
                </li>
                <li>
                    <a href="OgrenciSinavOturumu.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Sınav Oturumu
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
                    <a href="OgrenciTaleplerim.aspx">
                        <i class="fa fa-bullhorn"></i>
                        Taleplerim
                    </a>
                </li>
            </ul>
</div>
