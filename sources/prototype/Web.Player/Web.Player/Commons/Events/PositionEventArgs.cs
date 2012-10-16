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
  public class PositionEventArgs : EventArgs
  {
    public double Position { get; set; }

    public PositionEventArgs(double position)
    {
      Position = position;
    }
  }
}
