﻿<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Farmers_Market.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="jumbotron" style="margin-top: 25px; margin-bottom: 25px;">
            <div class="container">
                <h1 class="display-6">Welcome,
                <asp:Label ID="loggedInStaff" runat="server" Text=""></asp:Label></h1>
                <p class="lead">Secure your account by changing the login credentials</p>
            </div>
        </div>
        <div class="row">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a runat="server" href="~/">Home</a></li>
                    <li class="breadcrumb-item active">Profile</li>
                </ol>
            </nav>
        </div>
        <div class="row" style="padding-top:0!important;">
            <div class="col-md-5 p-4">
                <div class="row">
                    <div class="card bg-light mb-3" style="max-width: 98%">
                        <div class="card-header">Staff details</div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="lblName">Name</label><br />
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblDesignation">Designation</label><br />
                                <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblEmail">Email</label><br />
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblMobile">Mobile</label><br />
                                <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblCity">City</label><br />
                                <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblState">State</label><br />
                                <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblZip">Zip</label><br />
                                <asp:Label ID="lblZip" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-7 p-4">
                <div class="profileForm">
                    <div class="form-group">
                        <label for="txtCurrentPass">Current Password</label>
                        <asp:TextBox ID="txtCurrentPass" runat="server" type="password" class="form-control" placeholder="Current Password" ValidationGroup="profileForm"></asp:TextBox>
                        <small id="passHelp" class="form-text text-muted">If this is the first time your are changing your password, use the generated password</small>
                        <asp:RequiredFieldValidator ID="validateCurrentPass" runat="server" ErrorMessage="Required" ControlToValidate="txtCurrentPass" ForeColor="Red" ValidationGroup="profileForm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtNewPass">New Password</label>
                        <asp:TextBox ID="txtNewPass" runat="server" type="password" class="form-control" placeholder="New Password" ValidationGroup="profileForm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validateNewPass" runat="server" ErrorMessage="Required" ControlToValidate="txtNewPass" ForeColor="Red" ValidationGroup="profileForm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtConPass">Confirm Password</label>
                        <asp:TextBox ID="txtConPass" runat="server" type="password" class="form-control" placeholder="Confirm Password" ValidationGroup="profileForm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validateConPass" runat="server" ErrorMessage="Required" ControlToValidate="txtConPass" ForeColor="Red" ValidationGroup="profileForm"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="compareProfilePasswords" runat="server" Style="margin-bottom: 10px;" ErrorMessage="Make sure the passwords match" ForeColor="Red" ValidationGroup="profileForm" ControlToCompare="txtConPass" ControlToValidate="txtNewPass"></asp:CompareValidator>
                    </div>
                    <asp:Button ID="btnProfilePassword" runat="server" Text="Change Password" class="btn btn-primary" ValidationGroup="profileForm" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
