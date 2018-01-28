@Echo OFF
Echo Do you really want to Delete Bin and Obj folders
pause
Echo Deleting 'Bin' and 'Obj' folder in NvnInstaller
rd /s /q .\NvnInstaller\bin
rd /s /q .\NvnInstaller\obj

Echo Deleting 'Bin' and 'Obj' folder in NvnInstaller.Common
rd /s /q .\NvnInstaller.Common\bin
rd /s /q .\NvnInstaller.Common\obj

Echo Deleting 'Bin' and 'Obj' folder in NvnInstaller.Console
rd /s /q .\NvnInstaller.Console\bin
rd /s /q .\NvnInstaller.Console\obj

Echo Deleting 'Bin' and 'Obj' folder in NvnInstaller.PatchMaker
::rd /s /q .\NvnInstaller.PatchMaker\bin
::rd /s /q .\NvnInstaller.PatchMaker\obj

Echo Deleting 'Bin' and 'Obj' folder in NvnInstaller.Scheduler
rd /s /q .\NvnInstaller.Scheduler\bin
rd /s /q .\NvnInstaller.Scheduler\obj