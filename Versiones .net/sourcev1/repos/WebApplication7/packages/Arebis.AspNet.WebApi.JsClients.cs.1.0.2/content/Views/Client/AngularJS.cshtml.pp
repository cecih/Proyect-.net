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
        Response.Headers.Add("Content-Disposition", "attachment; filename=\"" + AppName.Replace(" ", "").ToLowerInvariant() + ".services.js\"");
    }
}/* AngularJS service module for @(AppName) */
/* Generated from "@(Request.Url)" on @(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) */

_@(ToCamelCase(AppName.Replace(" ", "")))_services_url = '@(RootUrl)';
_@(ToCamelCase(AppName.Replace(" ", "")))_services_postContentTransform = function(data) { return angular.toJson(data); };

angular

    .module('@(ToCamelCase(AppName.Replace(" ", ""))).services', [])
@foreach (var controllerGroup in ApiExplorer.ApiDescriptions.GroupBy(d => d.ActionDescriptor.ControllerDescriptor).OrderBy(g => g.Key.ControllerName))
{ 
    var actions = controllerGroup.ToList();
<text>
    .factory('@(ToCamelCase(controllerGroup.Key.ControllerName))Service', ['$http', function($http) {
        
        function @(controllerGroup.Key.ControllerName)Service() {
@for (int i=0; i<actions.Count; i++)
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
<text>
            // <a href="@(RootUrl)/@(Url.Action("Api", "Help", new { id = action.GetFriendlyId() }))">Help for @(uniqueActionName)</a>
            this.@(uniqueActionName) = function (@(String.Join(", ", action.ParameterDescriptions.Select(p => p.Name).ToArray()))) {
                return $http({
                    method: '@(method)',
                    url: _@(ToCamelCase(AppName.Replace(" ", "")))_services_url + '/@Html.Raw(relativePathWithParams)',
@foreach(var par in action.ParameterDescriptions.Where(p => p.Source.ToString() == "FromBody"))
{
<text>                    data: _@(ToCamelCase(AppName.Replace(" ", "")))_services_postContentTransform(@(par.Name)),</text>
}
                    cache: false
                });
            };</text>
}
        }

        return new @(controllerGroup.Key.ControllerName)Service();
    }])</text>
}
;
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