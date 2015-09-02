<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UR_Talking._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Willkommen zu Elise</h1>
                <h2> - dem Chatbot der Informationswissenschaft an der Uni Regensburg.</h2>
            </hgroup>
            <p>
                Elise ist immer bereit mit dir zu sprechen. Beginne einfach eine Unterhaltung.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="chat_box" style="width:50%;">
        <ul id="chatHistory" style="list-style: none">
            <li><b>Elise: </b>Na süßer, wie gehts dir?</li>
        </ul>
    </div>
    <input type="search"/>
    <button type="submit">ok</button>
    <iframe src="../Images/bild.html" 
width="450" height="350" style="margin-left:540px; margin-top:-200px;" name="Super duper Video"></iframe>
<script src="Scripts/questionHandler.js"></script>
</asp:Content>
