//////////////////////////////////////////////////////////////////////////////////
// This file is part of the "Arebis.AspNet.WebApi.ClientsLib.cs" nuget package. //
// To install: Install-package "Arebis.AspNet.WebApi.JsClients.cs"              //
// To upgrade: Upgrade-package "Arebis.AspNet.WebApi.JsClients.cs"              //
// Copyright Rudi Breedenraedt (http://www.arebis.be)                           //
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;

namespace $rootnamespace$.Controllers
{
    public class ClientController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            ViewBag.AppName = ConfigurationManager.AppSettings["Api.AppName"];
            if (String.IsNullOrWhiteSpace((string)ViewBag.AppName))
                ViewBag.AppName = Request.Url.Authority.ToString().Replace(".", "").Replace(":", "");
            ViewBag.ApiRootUrl = ConfigurationManager.AppSettings["Api.RootUrl"];
            if (String.IsNullOrWhiteSpace((string)ViewBag.ApiRootUrl))
                ViewBag.ApiRootUrl = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "");

            ViewBag.Configuration = GlobalConfiguration.Configuration;
            ViewBag.DocumentationProvider = GlobalConfiguration.Configuration.Services.GetDocumentationProvider();
            ViewBag.ApiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            
            ViewBag.IsChildAction = ControllerContext.IsChildAction;

            this.View(actionName).ExecuteResult(this.ControllerContext);
        }
    }
}
