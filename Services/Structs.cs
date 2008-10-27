﻿using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using CookComputing.XmlRpc;

namespace Engage.Dnn.Publish.Services
{
    #region Structs

    public struct BlogInfo
    {
        public string blogid;
        public string url;
        public string blogName;
    }

    public struct Category
    {
        public string categoryId;
        public string categoryName;
    }

    [Serializable]
    public struct CategoryInfo
    {
        public string description;
        public string htmlUrl;
        public string rssUrl;
        public string title;
        public string categoryid;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Enclosure
    {
        public int length;
        public string type;
        public string url;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        public DateTime dateCreated;
        public string description;
        public string title;
        public string[] categories;
        public string permalink;
        public object postid;
        public string userid;
        public string wp_slug;
        public string mt_keywords;
        public string mt_excerpt;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct BloggerPost
    {
        public string content;
        public DateTime dateCreated;
        public object postid;
        public string userid;
    }


    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Source
    {
        public string name;
        public string url;
    }

    public struct UserInfo
    {
        public string userid;
        public string firstname;
        public string lastname;
        public string nickname;
        public string email;
        public string url;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaObject
    {
        public string name;
        public string type;
        public byte[] bits;
    }

    [Serializable]
    public struct MediaObjectInfo
    {
        public string url;
    }

    public struct MTCategory
    {
        public string categoryId;
        public string categoryName;
        public bool isPrimary;
    }
    
    #endregion


}

