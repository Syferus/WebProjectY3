<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="EyeMDB.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 310px">
        <div class="navbar navbar-default" style="clear: both">
            <div class="container">
                <div class="navbar-form navbar-left">
                    <div class="form-group">
                        <asp:TextBox ID="txtMovies" runat="server" class="form-control" placeholder="Search Movies"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-default"/>
                </div>  
                <div class="navbar-form navbar-right"> 
                    <asp:Button ID="btnAdd" runat="server" Text="Add a Movie" OnClick="btnAdd_OnClick" class="btn btn-default" style="margin-right: 45px"/>
                </div>
            </div>
            <div class="container">
                <asp:ListBox ID="lbxMovies" OnSelectedIndexChanged="lbxMovies_OnSelectedIndexChanged" AutoPostBack="True" runat="server"></asp:ListBox>
            </div>
        </div>

       <div class="navbar navbar-default" style="clear: both">
            <div class="container">
                <div class="navbar-form navbar-left">
                    <h4>Movie Details</h4>
                </div>
                <div class="navbar-form navbar-right">
                </div>
            </div>
            <div class="container">
                <div style="float: left; margin-left: 20px">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                    <div>
                        <label>Title: </label>
                        <asp:Label ID="lblTitle" runat="server" Text="-----"></asp:Label>
                    </div>
                    <div>
                        <label>Released: </label>
                        <asp:Label ID="lblReleased" runat="server" Text="--/--/--"></asp:Label>
                    </div>
                    <div>
                        <label>Studio:</label>
                        <asp:Label ID="lblStudio" runat="server" Text="-----"></asp:Label>
                    </div>
                     <div>
                        <label>Director:</label>
                        <asp:Label ID="lblDirector" runat="server" Text="-----"></asp:Label>
                    </div>
                     <div>
                        <label>Lead Actor:</label>
                        <asp:Label ID="lblActors" runat="server" Text="-----"></asp:Label>
                    </div>
                     <div>
                        <label>Added By:</label>
                        <asp:Label ID="lblAdded" runat="server" Text="-----"></asp:Label>
                    </div>
                </div>
                <div style="float: left; margin:0 0 20px 200px">
                    <asp:Image ID="imgMovie" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
