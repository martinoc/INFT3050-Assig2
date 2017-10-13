<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Account_Manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div class="row"></div>

    <div style="width: 100%;">

        <div style="float: left; ">
            <asp:Panel ID="UserDetails" class="select-character" runat="server">
                <h3><asp:Label runat="server" ID="Name" /></h3>
                <h4><asp:Label runat="server" ID="UserEmail" /></h4>
                <h5>Exercise Points Balance:  <strong><asp:Label runat="server" ID="EPBalance" Text="1400EP"  /></strong></h5>
                <asp:Button runat="server" ID="Button1" Text="Enter Exercises" OnCommand="Button_Command" />
            </asp:Panel>
        </div>
    </div>
    <div style="clear: both"></div>




    <div class="row" style="height: 20px;"></div>

    <div style="width: 100%;">

        <div>
            <h3>Your Current Titans </h3>

        </div>
        <div>

            <asp:Panel ID="hero1" class="select-character" runat="server">

                <asp:ImageButton CssClass="profile-image" ID="ImageButton1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />

                <div>
                    <div>
                        <asp:Label ID="heroName1" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel1" runat="server" Text="LVL: 3"></asp:Label>
                    </div>
                    <div class="myProgress">
                        <asp:Panel runat="server" ID="HeroExp1" CssClass="myBar">
                            <p>
                                <asp:Label ID="heroExpText1" runat="server" Text="10%"></asp:Label>
                            </p>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="hero2" class="select-character" runat="server">

                <asp:ImageButton CssClass="profile-image" ID="ImageButton2" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                <div>
                        <asp:Label ID="heroName2" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel2" runat="server" Text="LVL: 3"></asp:Label>
                    </div>
                    <div class="myProgress">
                        <asp:Panel runat="server" ID="HeroExp2" CssClass="myBar">
                            <p>
                                <asp:Label ID="heroExpText2" runat="server" Text="10%"></asp:Label>
                            </p>
                        </asp:Panel>
                    </div>

            </asp:Panel>
            <asp:Panel ID="hero3" class="select-character" runat="server">

                <asp:ImageButton CssClass="profile-image" ID="ImageButton3" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                <div>
                        <asp:Label ID="heroName3" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel3" runat="server" Text="LVL: 3"></asp:Label>
                    </div>
                    <div class="myProgress">
                        <asp:Panel runat="server" ID="HeroExp3" CssClass="myBar">
                            <p>
                                <asp:Label ID="heroExpText3" runat="server" Text="10%"></asp:Label>
                            </p>
                        </asp:Panel>
                    </div>

            </asp:Panel>

            <asp:Panel ID="hero4" class="select-character" runat="server">

                <asp:ImageButton CssClass="profile-image" ID="ImageButton4" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                <div>
                        <asp:Label ID="heroName4" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel4" runat="server" Text="LVL: 3"></asp:Label>
                    </div>
                    <div class="myProgress">
                        <asp:Panel runat="server" ID="HeroExp4" CssClass="myBar">
                            <p>
                                <asp:Label ID="heroExpText4" runat="server" Text="10%"></asp:Label>
                            </p>
                        </asp:Panel>
                    </div>

            </asp:Panel>
            
            <asp:Panel ID="addHero1" class="select-character" runat="server">

                <asp:ImageButton CssClass="profile-image" ID="AddButton10" runat="server" ImageUrl="~/Images/Add_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                <asp:Panel runat="server" Style="text-align: center;">
                    <div>Create </div>
                    <div>New </div>
                    <div>Hero</div>

                </asp:Panel>


            </asp:Panel>
        </div>
        <div class="row"></div>

    </div>

    <div class="row"></div>

    <div style="width: 100%;">

        <div>
            <h3>Your Titans in your Hall Of Heros </h3>

        </div>
        <div>
            <asp:Panel ID="hoh" runat="server">

                <asp:Panel ID="Panel1" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table1">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel2" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image2" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table2">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel3" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image3" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table3">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel4" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image4" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table4">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel5" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image5" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table5">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel6" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image6" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table6">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel7" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image7" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table7">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel8" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image8" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table8">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel9" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image9" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table9">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel10" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image10" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table10">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel11" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image11" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table11">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel12" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image12" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table12">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel13" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image13" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table13">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel14" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image14" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table14">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel15" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image15" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table15">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel16" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image16" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table16">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel17" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image17" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table17">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel18" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image18" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table18">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel19" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image19" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table19">
                        </asp:Table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel20" class="hall-of-hero-slot" Visible="false" runat="server">
                    <div class="hall-of-hero-titan">
                        <asp:Image ID="image20" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px" />
                    </div>
                    <div class="hall-of-hero-detail">
                        <asp:Table Orientation="Horizontal" runat="server" ID="Table20">
                        </asp:Table>
                    </div>
                </asp:Panel>


            </asp:Panel>

        </div>
        <div class="row"></div>

    </div>


</asp:Content>
