<%@ Control Language="c#" AutoEventWireup="false" Inherits="Engage.Dnn.Publish.ArticleControls.AuthorToken" Codebehind="AuthorToken.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" %>

<div id="Publish_AuthorInfo">
    <asp:HyperLink ID="lblAuthorLink" runat="server" CssClass="Publish_AuthorInfo_Link"></asp:HyperLink>
    <asp:Label ID="lblAuthorInfo" runat="server"></asp:Label>
</div>
