param($build_number, $project_path)

Write-Host "Versioning started"
"Build number " + ${build_number}
$csprojfilename = ${project_path}
"Project file to update " + $csprojfilename
[xml]$csprojcontents = Get-Content -Path $csprojfilename;
"Current version number is " + $csprojcontents.Project.PropertyGroup[1].Version
$oldversionNumber = $csprojcontents.Project.PropertyGroup.Version
$csprojcontents.Project.PropertyGroup[1].Version = ${build_number}
$csprojcontents.Save($csprojfilename)
"Version number has been udated from " + $oldversionNumber + " to " + ${build_number}
Write-Host "Finished"