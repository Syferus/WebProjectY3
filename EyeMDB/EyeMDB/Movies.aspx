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
                Movie Details
            </div>
        </div>
    </div>
</asp:Content>
