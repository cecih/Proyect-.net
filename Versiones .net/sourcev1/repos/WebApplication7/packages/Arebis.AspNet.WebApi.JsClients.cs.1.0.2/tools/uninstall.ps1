    param($installPath, $toolsPath, $package, $project)

Write-Host $project.FullName
Write-Host $project.FileName

$path = [System.IO.Path]
$file = [System.IO.File]
$layoutfile = $path::Combine($path::GetDirectoryName($project.FullName), "Views\Shared\_Layout.cshtml")
if ($file::Exists($layoutfile)) {
    Write-Host 'Updating: ' + $layoutfile
    (Get-Content $layoutfile) | 
    Foreach-Object {
        if (!($_ -match '(\s*)<li>@Html\.ActionLink\("Clients", "Index", "Client", new \{ area = "" \}, null\)<\/li>'))
        {
            $_ # send the current line to output
        }
    } | Set-Content $layoutfile
    
}





