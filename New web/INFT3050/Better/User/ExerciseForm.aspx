<%@ Page Title="Exercise Form" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ExerciseForm.aspx.cs" Inherits="Better.User.ExerciseForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>


    <div class="row"></div>

    <div style="width: 100%;">

        <div style="float: left;">

            <asp:Panel ID="UserDetails" runat="server">
                <h3><asp:Label runat="server" ID="Name" /></h3>
                <h5>Exercise Points Balance:  <strong><asp:Label runat="server" ID="EPBalance" /></strong></h5>
            </asp:Panel>
        </div>
        <asp:Panel runat="server" ID="epAdded" Style="padding-left: 20%; padding-top: 1px">

            <h1><strong>
                <asp:Label runat="server" ID="newEP" Text="1400" /></strong>EP Added</h1>
            <h3>Well Done! Keep it up.</h3>

        </asp:Panel>

    </div>
    <div style="clear: both"></div>




    <div class="row" style="height: 20px;"></div>

    <div class="row">
        <asp:Panel runat="server" ID="Panel1" class="col-md-12">
            <section id="ExerciseForm">


                <asp:PlaceHolder runat="server" ID="changePasswordHolder">
                    <div class="form-horizontal">
                        <h4>Daily Exercise Form</h4>
                       <p> <asp:Label runat="server" Id="Error" Visible="false" CssClass="text-danger" Text="Some of your inputs are incorrect." /></p>
                        <div class="form-group">
                            <asp:Label runat="server" ID="distanceWalkedLabel" CssClass="col-md-2 control-label">Distance walked in Meters</asp:Label>
                            <div class="col-md-10" style="width: 140px;">
                                <asp:TextBox runat="server" ID="distanceWalked" CssClass="form-control" />
                            </div>
                            <p>
                                <asp:Literal runat="server" ID="Literal1" />
                            </p>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="distanceWalked"
                                CssClass="text-danger" ErrorMessage="The distance walked field is Empty." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="distanceRanLabel" CssClass="col-md-2 control-label">Distance ran in Meters</asp:Label>
                            <div class="col-md-10" style="width: 140px;">
                                <asp:TextBox runat="server" ID="distanceRan" CssClass="form-control" />
                            </div>
                            <p>
                                <asp:Literal runat="server" ID="Literal2" />
                            </p>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="distanceRan"
                                CssClass="text-danger" ErrorMessage="The distance ran field is Empty." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label2" CssClass="col-md-2 control-label">Number of push-ups</asp:Label>
                            <div class="col-md-10" style="width: 140px;">
                                <asp:TextBox runat="server" ID="pushUps" CssClass="form-control" />
                            </div>
                            <p>
                                <asp:Literal runat="server" ID="Literal3" />
                            </p>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="pushUps"
                                CssClass="text-danger" ErrorMessage="The number of push ups field is Empty." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label3" CssClass="col-md-2 control-label">Number of sit-ups</asp:Label>
                            <div class="col-md-10" style="width: 140px;">
                                <asp:TextBox runat="server" ID="sitUps" CssClass="form-control" />
                            </div>
                            <p>
                                <asp:Literal runat="server" ID="Literal4" />
                            </p>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="sitUps"
                                CssClass="text-danger" ErrorMessage="The number of sit ups field is Empty." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" CssClass="col-md-2 control-label">Parent Pin</asp:Label>
                            <div class="col-md-10" style="width: 140px;">
                                <asp:TextBox runat="server" ID="ParentPin" CssClass="form-control" />
                            </div>
                            <p>
                                <asp:Literal runat="server" ID="Literal5" />
                            </p>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ParentPin"
                                CssClass="text-danger" ErrorMessage="The ParentPin is field is Empty." />
                        </div>

                        <div class="col-md-10" style="padding-left: 200px;">
                            <asp:Button runat="server" Text="Enter exercises" Style="display: inline;" OnClick="Enter_Click" CssClass="btn btn-default" />

                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>


        </asp:Panel>
    </div>

</asp:Content>
