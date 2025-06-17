; Script gerado para instalação do seu projeto em C#
[Setup]
AppName=Controle de Pedidos
AppVersion=25.4.2.3
DefaultDirName=C:\CP
DisableDirPage=yes
DefaultGroupName=ControlePedido
DisableProgramGroupPage=no
OutputDir="C:\EDM\ControlePedido\"
OutputBaseFilename=Install_ControlePedido_25423
SetupIconFile=C:\EDM\ControlePedido\install.ico
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin

; Ícone no Painel de Controle > Programas
UninstallDisplayIcon={app}\ControlePedido.exe

[Languages]
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"

[Files]
Source: "C:\EDM\ControlePedido\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
; Atalho no menu iniciar
Name: "{group}\ControlePedido"; Filename: "{app}\ControlePedido.exe"

; Atalho na área de trabalho - só se o usuário quiser
Name: "{commondesktop}\ControlePedido"; Filename: "{app}\ControlePedido.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Criar atalho na área de trabalho"; GroupDescription: "Opções adicionais:"; Flags: unchecked

[Run]
; Executar o programa após a instalação (opcional)
Filename: "{app}\ControlePedido.exe"; Description: "Executar ControlePedido"; Flags: nowait postinstall skipifsilent
