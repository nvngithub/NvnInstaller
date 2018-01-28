using System;
using System.Collections.Generic;
using System.Text;
using NvnInstaller.MsiDotNet;

namespace WindowsFormsApplication1 {
  class Globals {
    private static Globals instance = new Globals();
    private InstallType selectedInstallType = InstallType.Install;
    private List<MsiFeature> installFeatures = new List<MsiFeature>();
    private List<MsiFeature> uninstallFeatures = new List<MsiFeature>();
    private MsiInstaller msiInterface;

        public static Globals Instance {
      get { return instance; }
        }

    public InstallType SelectedInstallType {
      get { return selectedInstallType; }
      set { selectedInstallType = value; }
    }

    public List<MsiFeature> InstallFeatures {
      get { return installFeatures; }
      set { installFeatures = value; }
    }

    public List<MsiFeature> UninstallFeatures {
      get { return uninstallFeatures; }
      set { uninstallFeatures = value; }
    }

    public List<MsiFeature> Features {
      get {
        if (msiInterface != null) { return msiInterface.FeatureTree; }
        return null;
      }
    }

    public string InstallDir {
      get {
        return msiInterface.InstallDirectory;
      }
    }

    public MsiInstaller MsiInterface {
      get { return msiInterface; }
    }

    public bool IsAlreadyInstalled {
      get { return msiInterface.IsAlreadyInstalled; }
    }    

    private Globals() { }

    public void LoadMsi() {
      msiInterface = new MsiInstaller("test.msi");
    }
  }

  enum InstallType {
    Install,
    InstallAll,
    Change,
    Repair,
    Remove,
    RemoveAll
  }
}
