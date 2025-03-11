[Setup]
AppName=ControlePedido
AppVersion=25.3.0.1
DefaultDirName={pf}\ControlePedido
OutputDir=.
OutputBaseFilename=SetupControlePedidos
SetupIconFile=iconAzul.ico

[Files]
Source: "C:\EDM\ControlePedido\bin\Debug\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
Name: "{group}\C:\EDM\ControlePedido\img\ico"; Filename: "{app}\ControlePedio.exe"

[Run]

