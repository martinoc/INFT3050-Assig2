﻿<%@ Page Title="Fight" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Fight.aspx.cs" Inherits="Account_Manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div class="row"></div>

    <div>
        <div id="container">

            <div class="leftContent" style="background-color: lightgray;">

                <div style="float: left; height: 230px;">
                    <div>
                        <asp:Image ID="image1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="200px" />
                    </div>
                    <div>
                        <asp:Label runat="server" ID="TitanName1" Text="TitanName1" Style="font-size: 20px;" />
                    </div>

                </div>
                <asp:Panel runat="server" ID="Panel1" Style="height: 230px; padding-left: 120px;">

                    <asp:Table Orientation="Horizontal" runat="server" ID="Table1">
                    </asp:Table>


                </asp:Panel>
                <div>
                    <asp:Label ID="heroLevel1" runat="server" Text="LVL: 3" Style="font-size: 15px;" />
                </div>
                <div class="myProgress">

                    <asp:Panel runat="server" ID="HeroExp1" CssClass="myBar">
                        <p>
                            <asp:Label ID="heroExpText1" runat="server" Text="10%"></asp:Label>
                        </p>
                    </asp:Panel>
                </div>
            </div>
            <div class="leftContent" style="text-align: center;">

                <asp:Panel ID="vs" runat="server">
                    <strong>
                        <asp:Label ID="VStext" Font-Size="200px" runat="server" Text="VS"></asp:Label></strong>

                </asp:Panel>
            </div>



            <div class="leftContent" style="background-color: lightgray;">

                <div style="float: left; height: 230px;">
                    <div>
                        <asp:Image ID="image2" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="200px" />
                    </div>
                    <div>
                        <asp:Label runat="server" ID="TitanName2" Text="TitanName2" Style="font-size: 20px;" />
                    </div>

                </div>
                <asp:Panel runat="server" ID="Panel2" Style="height: 230px; padding-left: 120px;">

                    <asp:Table Orientation="Horizontal" runat="server" ID="Table2">
                    </asp:Table>


                </asp:Panel>
                <div>
                    <asp:Label ID="heroLevel2" runat="server" Text="LVL: 3" Style="font-size: 15px;" />
                </div>
                <div class="myProgress">

                    <asp:Panel runat="server" ID="HeroExp2" CssClass="myBar">
                        <p>
                            <asp:Label ID="heroExpText2" runat="server" Text="10%"></asp:Label>
                        </p>
                    </asp:Panel>
                </div>
            </div>


        </div>
    </div>




    <div style="clear: both"></div>
    <div class="row" style="height: 20px;"></div>
    <div style="padding-left:35%;">
        <asp:Button runat="server" Style="padding: 20px;" ID="Button1" Text="Begin Fight" OnClientClick="return confirm('Are you sure?');" OnCommand="fightButton_Command" />
        <asp:Button runat="server" Style="padding: 20px;" ID="Button2" Text="Cancel Fight" OnCommand="fightButton_Command" />
    </div>


    <div class="row"></div>



</asp:Content>
