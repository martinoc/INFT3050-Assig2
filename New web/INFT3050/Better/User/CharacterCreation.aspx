<%@ Page Title="Character Creation" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CharacterCreation.aspx.cs" Inherits="Better.User.CharacterCreation" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2><%: Title %>. </h2>

   
    <div class="row"></div>

    <asp:Panel id="PanelTitanInfo" runat="server">
        <div>
        <asp:Image CssClass="profile-image2" id="image1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="200px"/>
        <asp:Button runat="server" Text="Create" style="display:inline;" OnClientClick="return confirm('Are you sure?');" OnClick="Enter_Click" CssClass="btn btn-default" />
        <asp:TextBox runat="server" ID="TitanName" Text="TitanName" CssClass="form-control"/>
        </div>
    </asp:Panel>

    <div class="row" style="height:5px"></div>
     <div style="height:20%;">
        <asp:Panel ID="Panel1" height="300px" Visible="true" runat="server" > 
            <asp:Panel id="char1" class="select-character" runat="server">
                <div class="text">
                    Air
                </div>
                <asp:Panel ID="ImageOverlay1" runat="server" >
                    <asp:Panel id="overLay1" class="current-overlay" Visible="false" runat="server">
                    <asp:Label runat="server" ID="Label1" />
                    </asp:Panel>
                    <asp:ImageButton ID="btnSubmit1" class="image-hover" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front_half.png" Width="100%"  OnCommand="ImageButton_Command" />
                </asp:Panel>
            </asp:Panel>

            <asp:Panel id="char2" class="select-character" runat="server">
                 <div class="text">
                    Earth
                </div>
                <asp:Panel ID="ImageOverlay2" runat="server">
                    <asp:Panel id="overLay2" class="current-overlay" Visible="false" runat="server">
                    <asp:Label runat="server" ID="Label2" />
                    </asp:Panel>
                    <asp:ImageButton ID="btnSubmit2" class="image-hover" runat="server" ImageUrl="~/Images/Earth_Elemental_titans_front_half.png" Width="100%" OnCommand="ImageButton_Command" />
                </asp:Panel>
            </asp:Panel>

            <asp:Panel id="char3" class="select-character" runat="server">
                 <div class="text">
                    Fire
                </div>
                <asp:Panel ID="ImageOverlay3" runat="server">
                    <asp:Panel id="overLay3" class="current-overlay" Visible="false" runat="server">
                    <asp:Label runat="server" ID="Label3" />
                    </asp:Panel>
                    <asp:ImageButton ID="btnSubmit3" class="image-hover" runat="server" ImageUrl="~/Images/Fire_Elemental_titans_front_half.png" Width="100%"  OnCommand="ImageButton_Command" />
                </asp:Panel>
             </asp:Panel>

            <asp:Panel id="char4" class="select-character" runat="server">
                 <div class="text">
                    Water
                </div>
                <asp:Panel ID="ImageOverlay4" runat="server" >
                    <asp:Panel id="overLay4" class="current-overlay" Visible="false" runat="server">
                    <asp:Label runat="server" ID="Label4" />
                    </asp:Panel>
                    <asp:ImageButton ID="btnSubmit4" class="image-hover" runat="server" ImageUrl="~/Images/Water_Elemental_titans_front_half.png" Width="100%" OnCommand="ImageButton_Command" />


                </asp:Panel>
             </asp:Panel>

            

        </asp:Panel>
    </div>
    
    
    <div class="row"></div>
</asp:Content>
