@*********************************************************************************
** This file is part of the "Arebis.AspNet.WebApi.ClientsLib.cs" nuget package. **
** To install: Install-package "Arebis.AspNet.WebApi.JsClients.cs"              **
** To upgrade: Upgrade-package "Arebis.AspNet.WebApi.JsClients.cs"              **
** Copyright Rudi Breedenraedt (http://www.arebis.be)                           **
*********************************************************************************@
@{
    ViewBag.Title = "Web API Clients";
    var RootUrl = (String)ViewBag.ApiRootUrl;
}
<h2>@(ViewBag.Title)</h2>

<ul class="list-group">
    @foreach (var file in new DirectoryInfo(Server.MapPath("/Views/Client")).GetFiles("*.cshtml"))
    {
        var viewName = file.Name.Replace(file.Extension, "");
        if (viewName.Equals("Index", StringComparison.OrdinalIgnoreCase)) { continue; }
        if (viewName.Equals("View", StringComparison.OrdinalIgnoreCase)) { continue; }
        if (viewName.Equals("MethodSummary", StringComparison.OrdinalIgnoreCase)) { continue; }
        if (viewName.Equals("MethodSummaryIntroduction", StringComparison.OrdinalIgnoreCase)) { continue; }
        if (viewName.Equals("MethodSummaryFooter", StringComparison.OrdinalIgnoreCase)) { continue; }
        var url = RootUrl + Url.Action("View", new { Id = viewName });
        <li class="list-group-item"><a href="@(url)">@(url.Replace("/View/", "/"))</a></li>
    }
</ul>

<p>
  Method and argument information can be found in the @Html.ActionLink("Method Summary", "MethodSummary", "Client", new { area = "" }, null).
</p>