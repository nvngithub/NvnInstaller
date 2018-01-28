using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller {
    public interface INvnControl {
        void Open(Dictionary<string, object> objects);
        void Saving();        
        void Close();
        void InitializeLoad();
        void Load();
        ControlType Type { get; }
        void LoadSaveObjects(Dictionary<string, object> objects);        
        List<Summary> GetSummary();
        void Validate();
        void InitializeBuild();
        void Build();
    }
}
