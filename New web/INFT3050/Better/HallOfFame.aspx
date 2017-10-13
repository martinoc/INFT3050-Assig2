<%@ Page Title="Hall Of Fame" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HallOfFame.aspx.cs" Inherits="HallOfFame" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div></div>

    <div>
        <asp:Panel ID="Panel1" class="hall-of-hero-slot" Visible="false" runat="server" > 
            <div class="hall-of-hero-titan">
                <asp:Image id="image1" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div  class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table1">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel2" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image2" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table2">
                        
                </asp:Table>
            </div>
        </asp:Panel>

         <asp:Panel ID="Panel3" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image3" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table3">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel4" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image4" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table4">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel5" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image5" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table5">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel6" class="hall-of-hero-slot" Visible="false" runat="server" > 
            <div class="hall-of-hero-titan">
                <asp:Image id="image6" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div  class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table6">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel7" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image7" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table7">
                        
                </asp:Table>
            </div>
        </asp:Panel>

         <asp:Panel ID="Panel8" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image8" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table8">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel9" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image9" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table9">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel10" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image10" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table10">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel11" class="hall-of-hero-slot" Visible="false" runat="server" > 
            <div class="hall-of-hero-titan">
                <asp:Image id="image11" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div  class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table11">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel12" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image12" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table12">
                        
                </asp:Table>
            </div>
        </asp:Panel>

         <asp:Panel ID="Panel13" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image13" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table13">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel14" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image14" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table14">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel15" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image15" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table15">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel16" class="hall-of-hero-slot" Visible="false" runat="server" > 
            <div class="hall-of-hero-titan">
                <asp:Image id="image16" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div  class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table16">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel17" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image17" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table17">
                        
                </asp:Table>
            </div>
        </asp:Panel>

         <asp:Panel ID="Panel18" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image18" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table18">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel19" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image19" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table19">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel20" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image20" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table20">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel21" class="hall-of-hero-slot" Visible="false" runat="server" > 
            <div class="hall-of-hero-titan">
                <asp:Image id="image21" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div  class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table21">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel22" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image22" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table22">
                        
                </asp:Table>
            </div>
        </asp:Panel>

         <asp:Panel ID="Panel23" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image23" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table23">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel24" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image24" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table24">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel25" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image25" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table25">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel26" class="hall-of-hero-slot" Visible="false" runat="server" > 
            <div class="hall-of-hero-titan">
                <asp:Image id="image26" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div  class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table26">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel27" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image27" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table27">
                        
                </asp:Table>
            </div>
        </asp:Panel>

         <asp:Panel ID="Panel28" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image28" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table28">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel29" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image29" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table29">
                        
                </asp:Table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel30" class="hall-of-hero-slot" Visible="false" runat="server" >  
            <div class="hall-of-hero-titan">
                <asp:Image id="image30" runat="server" ImageUrl="~/Images/Air_Elemental_titans_front.png" Height="105px"/>
            </div>
            <div class="hall-of-hero-detail">
                <asp:Table Orientation="Horizontal" runat="server" ID="Table30">
                        
                </asp:Table>
            </div>
        </asp:Panel>

    </div>

    <div></div>
</asp:Content>
