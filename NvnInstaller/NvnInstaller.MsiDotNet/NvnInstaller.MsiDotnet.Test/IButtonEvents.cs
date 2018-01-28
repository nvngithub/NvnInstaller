using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication1 {
  interface IButtonEvents {
    event EventHandler BackClicked;
    event EventHandler NextClicked;
    event EventHandler CloseClicked;
  }
}
