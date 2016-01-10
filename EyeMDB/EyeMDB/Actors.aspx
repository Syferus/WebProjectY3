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
                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-default"/>
                </div>  
                <div class="navbar-form navbar-right"> 
                    <asp:Button ID="btnAdd" runat="server" Text="Add an Actor" class="btn btn-default" style="margin-right: 45px"/>
                </div>
            </div>
            <div class="container">
                List Of Actors
            </div>
        </div>

       <div class="navbar navbar-default" style="clear: both">
            <div class="container">
                <div class="navbar-form navbar-left">
                    <h4>Actor Details</h4>
                </div>
                <div class="navbar-form navbar-right">
                     <asp:Button ID="btnEdit" runat="server" Text="Edit Actor Details" class="btn btn-default" style="margin-right: 45px"/>
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
                    <img src="http://placehold.it/200x200" alt="...">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
