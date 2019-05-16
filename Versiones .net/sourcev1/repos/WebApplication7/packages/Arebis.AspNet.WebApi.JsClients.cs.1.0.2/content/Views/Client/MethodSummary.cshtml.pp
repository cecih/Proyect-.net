@*********************************************************************************
    ** This file is part of the "Arebis.AspNet.WebApi.ClientsLib.cs" nuget package. **
    ** To install: Install-package "Arebis.AspNet.WebApi.JsClients.cs"              **
    ** To upgrade: Upgrade-package "Arebis.AspNet.WebApi.JsClients.cs"              **
    ** Copyright Rudi Breedenraedt (http://www.arebis.be)                           **
    *********************************************************************************@
@using $rootnamespace$.Areas.HelpPage
@{
    ViewBag.Title = "Web API Module Summary";
    var AppName = (String)ViewBag.AppName;
    var Configuration = (System.Web.Http.HttpConfiguration)ViewBag.Configuration;
    var ApiExplorer = (System.Web.Http.Description.IApiExplorer)ViewBag.ApiExplorer;
    var DocumentationProvider = (System.Web.Http.Description.IDocumentationProvider)ViewBag.DocumentationProvider;
    var RootUrl = (String)ViewBag.ApiRootUrl;

}
@section scripts {
    <link type="text/css" href="/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
    <style>
        .bullet {
            color: darkcyan;
        }
        .extension {
            color: darkgreen;
            padding-left: 2px;
        }
        .action-signature {
            font-size: 120%;
            text-decoration: underline;
        }
        .action-signature I {
            color: green;
            font-size: 85%;
            font-style: normal;
        }
        .action-url {
            color: gray;
            font-size: 85%;
        }
    </style>
}
<div class="help-page">

    <h1>@(ToCamelCase(AppName.Replace(" ", "")))<span class="extension">Services</span></h1>

    <h2>Introduction</h2>

    @Html.Action("MethodSummaryIntroduction", "Client", new { area = "" })

    <h2>Services &amp; Methods</h2>

    @foreach (var controllerGroup in ApiExplorer.ApiDescriptions.GroupBy(d => d.ActionDescriptor.ControllerDescriptor).OrderBy(g => g.Key.ControllerName))
    {
        var actions = controllerGroup.ToList();
        <h3><span class="glyphicon glyphicon-stop bullet"></span> @(ToCamelCase(controllerGroup.Key.ControllerName))<span class="extension">Service</span></h3>
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
            //foreach (var par in action.ParameterDescriptions)
            //{
            //    relativePathWithParams = relativePathWithParams.Replace("{" + par.Name + "}", "'+encodeURIComponent(" + par.Name + ")+'");
            //}
            <ul type="square">
                <li>
                    <span class="action-signature"><span title="@(action.ResponseDescription.ResponseType ?? action.ActionDescriptor.ReturnType ?? (object)"No return value")">@(uniqueActionName)</span>(<i>@Html.Raw(String.Join("</i>, <i title=\"hello\">", action.ParameterDescriptions.Select(p => "<span title=\"" + p.ParameterDescriptor.ParameterType + "\">" + p.Name + "</span>").ToArray()))</i>)</span> - <a href="@(RootUrl)/@(Url.Action("Api", "Help", new { id = action.GetFriendlyId() }))">Help</a><br />
                    <span class="action-url">@(method) /@Html.Raw(relativePathWithParams)</span>
                </li>
            </ul>
        }
    }

    @Html.Action("MethodSummaryFooter", "Client", new { area = "" })

</div>

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