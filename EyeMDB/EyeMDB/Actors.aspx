<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Actors.aspx.cs" Inherits="EyeMDB.Actors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 310px">
        <div class="navbar navbar-default" style="clear: both">
            <div class="container">
                <div class="navbar-form navbar-left">
                    <div class="form-group">
                        <asp:TextBox ID="txtActors" runat="server" class="form-control" placeholder="Search Actors"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" class="btn btn-default"/>
                </div>  
                <div class="navbar-form navbar-right"> 
                    <asp:Button ID="btnAdd" runat="server" Text="Add an Actor" class="btn btn-default" OnClick="btnAdd_OnClick" style="margin-right: 45px"/>
                </div>
            </div>
            <div class="container">
                <asp:ListBox ID="lbxActors" OnSelectedIndexChanged="lbxActors_OnSelectedIndexChanged" AutoPostBack="True" runat="server"></asp:ListBox>
            </div>
        </div>

       <div class="navbar navbar-default" style="clear: both">
            <div class="container">
                <div class="navbar-form navbar-left">
                    <h4>Actor Details</h4>
                </div>
                <div class="navbar-form navbar-right">
                    <asp:Label ID="lblErrors" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="container">
                <div style="float: left; margin-left: 20px">
                    <div>
                        <label>Actor Name: </label>
                        <asp:Label ID="lblActorName" runat="server" Text="-----"></asp:Label>
                    </div>
                    <div>
                        <label>DOB: </label>
                        <asp:Label ID="lblDob" runat="server" Text="--/--/--"></asp:Label>
                    </div>
                    <div>
                        <label>Nationality:</label>
                        <asp:Label ID="lblNationality" runat="server" Text="-----"></asp:Label>
                    </div>
                </div>
                <div style="float: left; margin:0 0 20px 200px">
                    <asp:Image ID="imgActor" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
