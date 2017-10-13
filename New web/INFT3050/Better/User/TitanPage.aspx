<%@ Page Title="Titan Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TitanPage.aspx.cs" Inherits="Better.User.TitanPage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>. </h2>


    <div class="row"></div>
    <div>
        <div style="float: left; height: 230px;">
            <div>
                <asp:Image CssClass="profile-image2" ID="image1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="200px" />
            </div>
            <div>
                <asp:Label runat="server" ID="TitanName" Text="TitanName" Style="font-size: 20px;" />
            </div>

        </div>
        <asp:Panel runat="server" ID="Panel1" Style="height: 230px; padding-left: 120px;">

            <asp:Table Orientation="Horizontal" runat="server" ID="Table1">
            </asp:Table>
            
            <h5>Exercise Points Balance:  <strong><asp:Label runat="server" ID="EPBalance" Text="1400"  /></strong>EP</h5>
            <asp:TextBox runat="server" ID="EP" Text="100"/>
            <asp:Button runat="server" ID="EPButton" Text="Spend Ep" OnClientClick="return confirm('Are you sure?');" OnCommand="EPButton_Command" />
            <div></div>
            <asp:Button runat="server" ID="Button1" Text="Fight History" OnCommand="fsButton_Command" />

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
    <div class="row"></div>

    <div>

        <div style="width: 100%; ">

            <div>
                <h3>Challenger Titans </h3>

            </div>
            <div>

                <asp:Panel ID="hero1" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />

                    <div>
                        <div>
                            <asp:Label ID="heroName1" runat="server" Text="Titan Name"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="LVL: 3"></asp:Label>
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


                </asp:Panel>
                <asp:Panel ID="hero3" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton3" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                    <div>
                        <asp:Label ID="heroName3" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel3" runat="server" Text="LVL: 3"></asp:Label>
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


                </asp:Panel>
                <asp:Panel ID="hero5" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton5" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />

                    <div>
                        <asp:Label ID="heroName5" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel5" runat="server" Text="LVL: 3"></asp:Label>
                    </div>


                </asp:Panel>

                <asp:Panel ID="hero6" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton6" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                    <div>
                        <asp:Label ID="heroName6" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel6" runat="server" Text="LVL: 3"></asp:Label>
                    </div>


                </asp:Panel>

                <asp:Panel ID="hero7" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton7" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                    <div>
                        <asp:Label ID="heroName7" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel7" runat="server" Text="LVL: 3"></asp:Label>
                    </div>

                </asp:Panel>
                <asp:Panel ID="hero8" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton8" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />

                    <div>
                        <asp:Label ID="heroName8" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel8" runat="server" Text="LVL: 3"></asp:Label>
                    </div>


                </asp:Panel>
                <asp:Panel ID="hero9" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton9" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />


                    <div>
                        <asp:Label ID="heroName9" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel9" runat="server" Text="LVL: 3"></asp:Label>
                    </div>


                </asp:Panel>
                <asp:Panel ID="hero10" class="select-character" runat="server">

                    <asp:ImageButton CssClass="profile-image" ID="ImageButton10" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" OnCommand="ImageButton_Command" Height="200px" />

                    <div>
                        <asp:Label ID="heroName10" runat="server" Text="Titan Name"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="heroLevel10" runat="server" Text="LVL: 3"></asp:Label>
                    </div>


                </asp:Panel>
            </div>
            <div class="row"></div>

        </div>

    </div>


    <div class="row"></div>

</asp:Content>
