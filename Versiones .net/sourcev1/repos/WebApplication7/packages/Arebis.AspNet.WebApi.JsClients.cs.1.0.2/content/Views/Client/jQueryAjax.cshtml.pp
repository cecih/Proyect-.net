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
        Response.ContentType = "application/javascript";
        Response.Headers.Add("Content-Disposition", "attachment; filename=\"jquery." + AppName.Replace(" ", "").ToLowerInvariant() + "-services.js\"");
    }
}/* jQuery.ajax() client for @(ViewBag.AppName) */
/* Generated from "@(Request.Url)" on @(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) */

// Declares the @AppName Services object:
$.@(ToCamelCase(AppName.Replace(" ", "")))Services = { };
$.@(ToCamelCase(AppName.Replace(" ", "")))Services._url = '@(RootUrl)';
$.@(ToCamelCase(AppName.Replace(" ", "")))Services._postContentType = 'application/json';
$.@(ToCamelCase(AppName.Replace(" ", "")))Services._postContentTransform = function(data) { return JSON.stringify(data); };

@foreach (var controllerGroup in ApiExplorer.ApiDescriptions.GroupBy(d => d.ActionDescriptor.ControllerDescriptor).OrderBy(g => g.Key.ControllerName))
{
    var actions = controllerGroup.ToList();
<text>// Declares the @(controllerGroup.Key.ControllerName) service:
$.@(ToCamelCase(AppName.Replace(" ", "")))Services.@(ToCamelCase(controllerGroup.Key.ControllerName)) = { };
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
        foreach (var par in action.ParameterDescriptions)
        {
            relativePathWithParams = relativePathWithParams.Replace("{" + par.Name + "}", "'+encodeURIComponent(" + par.Name + ")+'");
        }
<text>// Declares the @(ToCamelCase(action.ActionDescriptor.ActionName)) service method:
// <a href="@(RootUrl)/@(Url.Action("Api", "Help", new { id = action.GetFriendlyId() }))">Help for @(uniqueActionName)</a>
$.@(ToCamelCase(AppName.Replace(" ", "")))Services.@(ToCamelCase(controllerGroup.Key.ControllerName)).@(uniqueActionName) = function (@(String.Join(", ", action.ParameterDescriptions.Select(p => p.Name).ToArray()))) {
    return $.ajax({
        url: $.@(ToCamelCase(AppName.Replace(" ", "")))Services._url + '/@Html.Raw(relativePathWithParams)',
@if (action.ParameterDescriptions.Where(p => p.Source.ToString() == "FromBody").Any())
{<text>        contentType: $.@(ToCamelCase(AppName.Replace(" ", "")))Services._postContentType,
</text>}
@foreach (var par in action.ParameterDescriptions.Where(p => p.Source.ToString() == "FromBody"))
{
<text>        data: $.@(ToCamelCase(AppName.Replace(" ", "")))Services._postContentTransform(@(par.Name)),</text>
}
        type: '@(method)'
   });
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