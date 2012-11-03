using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Web.Player.Commons.Events
{
  public class HDEventArgs : EventArgs
  {
    public bool IsHD { get; set; }

    public HDEventArgs(bool isHD)
    {
      IsHD = isHD;
    }
  }
}
