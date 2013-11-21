!include "MUI2.nsh"

!define APP_VERSION "1_04_04"
!define APP_NAME "GrabNDrop"

!define GND_BASEPATH "C:\Users\y\Dropbox\Projects\VisualStudio\GrabNDrop\"

Name "${APP_NAME}"
OutFile ".\install\${APP_NAME}_${APP_VERSION}_Setup.exe"

ShowInstDetails show
#LicenseData "License.txt"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\GrabNDrop"

    ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\GrabNDrop" ""

  
  Var StartMenuFolder
 
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_STARTMENU "Application"  $StartMenuFolder
  
  !insertmacro MUI_PAGE_INSTFILES

  !insertmacro MUI_UNPAGE_INSTFILES

  Section
 
	SetOutPath "$INSTDIR"

		FindProcDLL::FindProc "GrabNDrop.exe"
		StrCmp $R0 1 killProc resume
		
		killProc:
		DetailPrint "Stopping Running Process..." 
		KillProcDLL::KillProc "GrabNDrop.exe"
		StrCmp $R0 1 resume resume
		
		resume:
	
		File "${GND_BASEPATH}GrabNSend\bin\Release\GrabNDrop.exe"
		   
		!insertmacro MUI_STARTMENU_WRITE_BEGIN Application
			;Create shortcuts
			CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
			CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
			CreateShortCut "$SMPROGRAMS\$StartMenuFolder\GrabNDrop.lnk" "$INSTDIR\GrabNDrop.exe"
		!insertmacro MUI_STARTMENU_WRITE_END		    

		# create the uninstaller
		WriteUninstaller "$INSTDIR\Uninstall.exe"
		
		Exec "$INSTDIR\GrabNDrop.exe"
  SectionEnd


  Section "Uninstall"
  
	Delete "$INSTDIR\GrabNDrop.exe"
	Delete "$INSTDIR\Uninstall.exe"

	RMDir "$INSTDIR"
	!insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuFolder
	Delete "$SMPROGRAMS\$StartMenuFolder\Uninstall.lnk"
	Delete "$SMPROGRAMS\$StartMenuFolder\GrabNDrop.lnk"
	RMDir "$SMPROGRAMS\$StartMenuFolder"
	
	Delete "$DESKTOP\GrabNDrop.lnk"
	
	DeleteRegKey HKLM "Software\GrabNDrop"

SectionEnd