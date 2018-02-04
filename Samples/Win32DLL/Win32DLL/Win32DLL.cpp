#include "stdafx.h"
#include <direct.h>
#include <windows.h>
#include <msi.h> 

UINT __stdcall SamplesAction(MSIHANDLE hInstall)
{
	mkdir("d:\\test");
	return 0;
}