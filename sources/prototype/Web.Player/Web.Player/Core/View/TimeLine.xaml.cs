using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Web.Player.Core.View
{
  public partial class TimeLine : UserControl
  {
    public event EventHandler<RoutedEventArgs> FullScreenToggled;
    public event EventHandler<RoutedEventArgs> PlayButtonPressed;

    public TimeLine()
    {
      InitializeComponent();
    }

    #region Events

    private void FullScreenButtonClick(object sender, RoutedEventArgs e)
    {
      OnFullScreenToggled(e);
    }

    private void PlayButtonClick(object sender, RoutedEventArgs e)
    {
      OnPlayButtonPressed(e);
    }

    #endregion

    #region Rais events

    private void OnFullScreenToggled(RoutedEventArgs e)
    {
      EventHandler<RoutedEventArgs> handler = FullScreenToggled;
      if (handler != null) handler(this, e);
    }

    private void OnPlayButtonPressed(RoutedEventArgs e)
    {
      EventHandler<RoutedEventArgs> handler = PlayButtonPressed;
      if (handler != null) handler(this, e);
    }


    #endregion

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void Volume_MouseEnter(object sender, MouseEventArgs e)
    {
      VolumeSlider.Visibility = Visibility.Visible;
    }

    private void Volume_MouseLeave(object sender, MouseEventArgs e)
    {
      VolumeSlider.Visibility = Visibility.Collapsed;
    }



  }
}
