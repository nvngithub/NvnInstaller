
// MultipleLanguagesDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include <vector>
#include <string>

using namespace std;

// CMultipleLanguagesDlg dialog
class CMultipleLanguagesDlg : public CDialog
{
// Construction
public:
	CMultipleLanguagesDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_MULTIPLELANGUAGES_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedCancel();
private:
	CComboBox cmbNames;
	vector<string> files;
	void LoadNamesInCombo();
	};
