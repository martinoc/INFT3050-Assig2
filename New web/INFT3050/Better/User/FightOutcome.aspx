<%@ Page Title="Fight Outcome" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FightOutcome.aspx.cs" Inherits="Better.User.FightOutcome" %>

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

                    <asp:Label ID="winName" Font-Size="50px" runat="server" Text="TitanName"></asp:Label>
                    <asp:Label ID="winner" Font-Size="50px" runat="server" Text=">>>>>>>"></asp:Label>

                    <strong>
                        <asp:Label ID="Wins" Font-Size="100px" runat="server" Text="Wins"></asp:Label></strong>


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
    <asp:Button runat="server" Style="padding: 20px;" ID="Button2" Text="TitanName1 Titan Page" OnCommand="leaveButton_Command" />



    <div class="row"></div>



</asp:Content>
