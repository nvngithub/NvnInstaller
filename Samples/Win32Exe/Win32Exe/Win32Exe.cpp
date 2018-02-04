// Win32Exe.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <direct.h>
#include <string>
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	if(argc == 2)
	{
		string folderName(argv[1]);
		mkdir(folderName.c_str());
	}
	else
	{
		mkdir("d:\\WinExe_DeleteMe");
	}
	return 0;
}

