$projectFile = [xml](Get-Content src\SpeechTime\SpeechTime.csproj)
$xmlTag = $projectFile.Project.PropertyGroup | Where-Object {$_.Label -eq "Custom"} | Select-Object -First 1 ProductVersion
$productVersion = "v$($xmlTag.ProductVersion)"

$outputPath = "artifacts\$($productVersion)"

if (Test-Path $outputPath)
{
    Remove-Item -Path $outputPath -Recurse
}

Invoke-Command {msbuild src\SpeechTime\SpeechTime.csproj /p:OutputPath=..\..\$($outputPath) /p:Configuration=Release /p:Optimize=true /p:DebugSymbols=false /p:DebugType=None}
New-Item -ItemType Directory -Path $outputPath -Name "Resources"
Remove-Item "$($outputPath)\*.pdb"