<%@ Control Language="c#" AutoEventWireup="false" Inherits="Engage.Dnn.Publish.ArticleControls.ArticleList" CodeBehind="ArticleList.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/labelControl.ascx" %>



<table border="0" class="">
    <tr valign="top">
        <td>
            <dnn:Label ID="lblItemType" ResourceKey="lblItemType" Runat="server" CssClass="" ControlName="cboCategories"></dnn:Label></td>
        <td>
            <asp:DropDownList ID="cboCategories" runat="server" AutoPostBack="True" CssClass=""></asp:DropDownList></td>
        <td>
            <dnn:Label ID="lblWorkflow" ResourceKey="lblWorkFlow" Runat="server" CssClass="" ControlName="cboWorkFlow"></dnn:Label></td>
        <td>
            <asp:DropDownList ID="cboWorkflow" runat="server" AutoPostBack="True" CssClass=""></asp:DropDownList></td>
        <td>
            <dnn:Label ID="lblArticleSearch" ResourceKey="lblArticleSearch" Runat="server" cssClass="" ControlName="txtArticleSearch"></dnn:Label></td>
        <td>
            <asp:TextBox ID="txtArticleSearch" runat="server" CssClass=""></asp:TextBox></td>
        <td>
            <asp:LinkButton ID="btnFilter" runat="server" resourcekey="btnFilter"
                OnClick="btnFilter_Click" CssClass="" /></td>

    </tr>
</table>
<div id="divArticleRepeater">
    <asp:GridView ID="dgItems"
        Visible="false"
        runat="server"
        EnableViewState="true"
        AlternatingRowStyle-CssClass="DataGrid_AlternatingItem"
        HeaderStyle-CssClass="DataGrid_Header"
        RowStyle-CssClass="DataGrid_Item"
        PagerStyle-CssClass="Normal"
        CssClass=""
        AutoGenerateColumns="false"
        Width="100%"
        AllowPaging="true"
        PagerSettings-Visible="true"
        PageSize='<%# DefaultAdminPagingSize %>'
        OnPageIndexChanging="dgItems_PageIndexChanging"
        AllowSorting="true"
        OnSorting="dgItems_Sorting">
        <Columns>

            <asp:TemplateField ShowHeader="true" HeaderText="SelectText" ItemStyle-CssClass="Publish_CheckBoxColumn">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="true" HeaderText="ID" SortExpression="ItemId">
                <ItemTemplate>
                    <asp:HyperLink ID="hlId" runat="server" CssClass="" NavigateUrl='<%# GetItemVersionLinkUrl(DataBinder.Eval(Container.DataItem,"ItemVersionId")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"ItemId") %>' />
                    <asp:Label ID="lblItemVersionId" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"ItemVersionId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="true" HeaderText="Name" SortExpression="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="hlPreview" runat="server" CssClass="" NavigateUrl='<%# GetItemVersionLinkUrl(DataBinder.Eval(Container.DataItem,"ItemVersionId")) %>'
                        Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="true" HeaderText="Description" SortExpression="Name">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" CssClass="" Text='<%# GetDescription(DataBinder.Eval(Container.DataItem,"Description")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Author" HeaderText="DisplayName" SortExpression="Author" ItemStyle-CssClass="" />
            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" ItemStyle-CssClass="" />
            <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" ItemStyle-CssClass="" />
            <asp:TemplateField ShowHeader="true" HeaderText="">
                <ItemTemplate>
                    <asp:HyperLink ID="hlVersions" runat="server" CssClass="" NavigateUrl='<%# GetVersionsUrl(DataBinder.Eval(Container.DataItem,"ItemId")) %>'
                        Text='<%# GetLocalizedVersionText() %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="true" HeaderText="">
                <ItemTemplate>
                    <asp:HyperLink ID="hlEdit" runat="server" CssClass="" NavigateUrl='<%# GetArticleEditUrl(DataBinder.Eval(Container.DataItem,"ItemVersionId")) %>'
                        Text='<%# GetLocalizedEditText() %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<asp:Label ID="lblMessage" runat="server" CssClass="Subhead"></asp:Label>
<br />
<asp:HyperLink ID="lnkAddNewArticle" runat="server" ResourceKey="lnkAddNewArticle" CssClass="CommandButton"></asp:HyperLink>
<div style="text-align: center;">
    <asp:LinkButton CssClass="CommandButton" ID="cmdApprove" resourcekey="cmdApprove" runat="server" Text="Approve Articles" CausesValidation="False" OnClick="cmdApprove_Click"></asp:LinkButton>
    <asp:LinkButton CssClass="CommandButton" ID="cmdArchive" resourcekey="cmdArchive" runat="server" Text="Archive Articles" CausesValidation="False" OnClick="cmdArchive_Click"></asp:LinkButton>
    <asp:LinkButton CssClass="CommandButton" ID="cmdDelete" resourcekey="cmdDelete" runat="server" Text="Delete Articles" CausesValidation="False" OnClick="cmdDelete_Click"></asp:LinkButton>
    <asp:LinkButton CssClass="CommandButton" ID="cmdBack" resourcekey="cmdBack" runat="server" Text="Back" CausesValidation="False" OnClick="cmdBack_Click"></asp:LinkButton>
</div>
