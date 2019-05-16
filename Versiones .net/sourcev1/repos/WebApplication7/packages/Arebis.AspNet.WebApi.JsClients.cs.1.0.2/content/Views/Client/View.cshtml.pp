﻿@*********************************************************************************
** This file is part of the "Arebis.AspNet.WebApi.ClientsLib.cs" nuget package. **
** To install: Install-package "Arebis.AspNet.WebApi.JsClients.cs"              **
** To upgrade: Upgrade-package "Arebis.AspNet.WebApi.JsClients.cs"              **
** Copyright Rudi Breedenraedt (http://www.arebis.be)                           **
*********************************************************************************@
@{
    var id = (string)Html.ViewContext.RouteData.Values["id"];
    ViewBag.Title = "Client Code " + id;
    var code = Html.Action(id);
}

<h2>@ViewBag.Title</h2>

<p>[<a href="@Url.Action(id)">Download client here</a>]

<p>Or add following line in your client:</p>
<pre>@(String.Format("<script src=\"{0}{1}\"></script>", ViewBag.ApiRootUrl, Url.Action(id)))</pre>

<p>This will include the following code in your application: <small class="text-muted">(approx. @(code.ToHtmlString().Count(c => c == (char)10)) code lines)</small></p>

<pre>@code</pre>
