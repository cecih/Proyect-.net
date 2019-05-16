@*********************************************************************************
** This file is part of the "Arebis.AspNet.WebApi.ClientsLib.cs" nuget package. **
** To install: Install-package "Arebis.AspNet.WebApi.JsClients.cs"              **
** To upgrade: Upgrade-package "Arebis.AspNet.WebApi.JsClients.cs"              **
** Copyright Rudi Breedenraedt (http://www.arebis.be)                           **
*********************************************************************************@
@using $rootnamespace$.Areas.HelpPage
@{
    var AppName = (String)ViewBag.AppName;    
    var Configuration = (System.Web.Http.HttpConfiguration)ViewBag.Configuration;
    var ApiExplorer = (System.Web.Http.Description.IApiExplorer)ViewBag.ApiExplorer;
    var DocumentationProvider = (System.Web.Http.Description.IDocumentationProvider)ViewBag.DocumentationProvider;
    var RootUrl = (String)ViewBag.ApiRootUrl;

    Layout = null;

    if (!ViewBag.IsChildAction)
    {
        Response.ContentType = "application/xml";
        Response.Headers.Add("Content-Disposition", "attachment; filename=\"" + AppName.Replace(" ", "").ToLowerInvariant() + "-client.js\"");
    }
}/* XMLHTTPRequest JavaScript client for @(AppName) */
/* Generated from "@(Request.Url)" on @(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) */

// Declares the @AppName Services object:
@(ToCamelCase(AppName.Replace(" ", "")))Services = { };
@(ToCamelCase(AppName.Replace(" ", "")))Services._url = '@(RootUrl)';
@(ToCamelCase(AppName.Replace(" ", "")))Services._provideRequestor = function(method) {
    return (window.XMLHttpRequest) ? new XMLHttpRequest() : /* for IE5 and IE6: */ new ActiveXObject("Microsoft.XMLHTTP");
};
@(ToCamelCase(AppName.Replace(" ", "")))Services._async = true;
@(ToCamelCase(AppName.Replace(" ", "")))Services._username = '';
@(ToCamelCase(AppName.Replace(" ", "")))Services._password = '';

// Provide 'setAuthentication' method:
@(ToCamelCase(AppName.Replace(" ", "")))Services.setAuthentication = function(username, password) {
    @(ToCamelCase(AppName.Replace(" ", "")))Services._username = username;
    @(ToCamelCase(AppName.Replace(" ", "")))Services._password = password;
}

@foreach (var controllerGroup in ApiExplorer.ApiDescriptions.GroupBy(d => d.ActionDescriptor.ControllerDescriptor).OrderBy(g => g.Key.ControllerName))
{
    var actions = controllerGroup.ToList();
<text>// Declares the @(controllerGroup.Key.ControllerName) service:
@(ToCamelCase(AppName.Replace(" ", "")))Services.@(ToCamelCase(controllerGroup.Key.ControllerName)) = { };
</text>
    for (int i = 0; i < actions.Count; i++)
    {
        var action = actions.Skip(i).First();
        var uniqueActionName = ToCamelCase(action.ActionDescriptor.ActionName);
        var method = Convert.ToString(action.GetType().GetProperty("HttpMethod").GetValue(action));
        if (actions.Take(i).Any(a => a.ActionDescriptor.ActionName == action.ActionDescriptor.ActionName))
        {
            uniqueActionName += (2 + actions.Take(0).Count(a => a.ActionDescriptor.ActionName == action.ActionDescriptor.ActionName));
        }
        var relativePathWithParams = action.RelativePath;
        foreach (var par in action.ParameterDescriptions.Where(p => p.Source.ToString() != "FromBody"))
        {
            relativePathWithParams = relativePathWithParams.Replace("{" + par.Name + "}", "'+encodeURIComponent(" + par.Name + ")+'");
        }
<text>// Declares the @(ToCamelCase(action.ActionDescriptor.ActionName)) method:
// <a href="@(RootUrl)/@(Url.Action("Api", "Help", new { id = action.GetFriendlyId() }))">Help for @(uniqueActionName)</a>
@(ToCamelCase(AppName.Replace(" ", "")))Services.@(ToCamelCase(controllerGroup.Key.ControllerName)).@(uniqueActionName) = function (@(String.Join(", ", action.ParameterDescriptions.Where(p => p.Source.ToString() != "FromBody").Select(p => p.Name).ToArray()))) {
    var svc = @(ToCamelCase(AppName.Replace(" ", "")))Services;
    var req = svc._provideRequestor('@method');
    req.open('@(method)', svc._url + '/@Html.Raw(relativePathWithParams)', svc._async, svc._username, svc._password);
    return req;
};
</text>
    }
}

@functions{

    string ToCamelCase(string str)
    {
        if (String.IsNullOrEmpty(str))
            return str;
        else if (str.Length == 1)
            return str.ToLowerInvariant();
        else
            return str.Substring(0, 1).ToLowerInvariant() + str.Substring(1);
    }

}