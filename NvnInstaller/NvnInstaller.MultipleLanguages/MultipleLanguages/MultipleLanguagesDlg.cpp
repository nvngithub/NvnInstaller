
// MultipleLanguagesDlg.cpp : implementation file
//

#include "stdafx.h"
#include "MultipleLanguages.h"
#include "MultipleLanguagesDlg.h"

#include <iostream>
#include <windows.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

using namespace std;

// CMultipleLanguagesDlg dialog

CMultipleLanguagesDlg::CMultipleLanguagesDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMultipleLanguagesDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CMultipleLanguagesDlg::DoDataExchange(CDataExchange* pDX)
{
CDialog::DoDataExchange(pDX);
DDX_Control(pDX, IDC_COMBO, cmbNames);
	}

BEGIN_MESSAGE_MAP(CMultipleLanguagesDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDOK, &CMultipleLanguagesDlg::OnBnClickedOk)
	ON_BN_CLICKED(IDCANCEL, &CMultipleLanguagesDlg::OnBnClickedCancel)
END_MESSAGE_MAP()


void CMultipleLanguagesDlg::LoadNamesInCombo()
{
	// Find languages supported based on exe or msi files
	WIN32_FIND_DATA file;
	HANDLE handle=FindFirstFile("./nvn-*.*",&file);

	while(handle!=INVALID_HANDLE_VALUE)
	{
		string filename = file.cFileName;
		files.push_back(filename);
		// Get only the language
		size_t index = filename.find("-",4);
		string language = filename.substr(4,index-4);
		cmbNames.AddString(language.c_str());

		bool working = FindNextFile(handle, &file);
		if(working == FALSE) break;
	}
}

// CMultipleLanguagesDlg message handlers

BOOL CMultipleLanguagesDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	LoadNamesInCombo();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMultipleLanguagesDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMultipleLanguagesDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CMultipleLanguagesDlg::OnBnClickedOk()
{
	// Start repective MSI file
	int index = cmbNames.GetCurSel();
	if(index < 0)
	{
		MessageBox("Please select a language.", "Language...", MB_OK|MB_ICONEXCLAMATION);
	}
	else
	{
		string file = files[index];
		
		HINSTANCE hInst = ShellExecute(0,
                                   "open", // Operation to perform
								   file.c_str(), // Application name
                                   "", // Additional parameters
                                   0, // Default directory
                                   SW_HIDE);
		if(reinterpret_cast<int>(hInst) <= 32)
		{
			MessageBox("Error occured while executing installation package", "Error", MB_OK|MB_ICONERROR);
		}

		OnOK();
	}
}

void CMultipleLanguagesDlg::OnBnClickedCancel()
{
	// TODO: Add your control notification handler code here
	OnCancel();
}
