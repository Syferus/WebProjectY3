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
                    <asp:Button ID="btnAdd" runat="server" Text="Add a Movie" class="btn btn-default" style="margin-right: 45px"/>
                </div>
            </div>
            <div class="container">
                List Of Movies
            </div>
        </div>

       <div class="navbar navbar-default" style="clear: both">
            <div class="container">
                <div class="navbar-form navbar-left">
                    <h4>Movie Details</h4>
                </div>
                <div class="navbar-form navbar-right">
                     <asp:Button ID="btnEdit" runat="server" Text="Edit Movie Details" class="btn btn-default" style="margin-right: 45px"/>
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
                        <label>Actors:</label>
                        <asp:Label ID="lblActors" runat="server" Text="-----"></asp:Label>
                    </div>
                     <div>
                        <label>Added By:</label>
                        <asp:Label ID="lblAdded" runat="server" Text="-----"></asp:Label>
                    </div>
                     <div>
                         <asp:DropDownList ID="ddlActors" runat="server"></asp:DropDownList>
                         <asp:Button ID="btnAddActor" runat="server" Text="Add Actor" />
                    </div>
                </div>
                <div style="float: left; margin:0 0 20px 200px">
                    <img src="http://placehold.it/200x200" alt="...">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
