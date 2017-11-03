<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Better.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr />
        
                <asp:Panel ID="Panel1" class="hall-of-hero-slot" style="width:32%" runat="server" >  

                    <dl class="dl-horizontal">
                        <dt>Password:</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                        </dd>                        
                        <dt>Reset ParentCode</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/Account/NewParentCode" Text="[New ParentCode]" Visible="true" ID="NewParentCode" runat="server" />
                        </dd>
                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                         <dt>Confirm Email</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/Account/Confirm" Text="[Send Email Confirmation]" ID="ConfirmEmail" runat="server" />
                        </dd>
                        </asp:Panel>
                        <dt>Display Full Name</dt>
                        <dd>
                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />
                        </dd>
                       
                    
                    </dl>
                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>
