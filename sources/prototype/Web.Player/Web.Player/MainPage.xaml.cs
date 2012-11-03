using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Web.Media.SmoothStreaming;
using Web.Player.Commons.Events;
using Web.Player.Core.View.Message;

namespace Web.Player
{
  public partial class MainPage : UserControl
  {
    private readonly IsolatedStorageSettings _userSettings = IsolatedStorageSettings.ApplicationSettings;

    private readonly DispatcherTimer _nomousemoveTimer = new DispatcherTimer();
    private readonly double _layoutWidth;
    private readonly double _layoytHeight;

    private bool _isSeek;

    public MainPage()
    {
      InitializeComponent();
      Player.MediaElement.SmoothStreamingSource = new Uri("http://vps.vincex86.be/videos/bbt/3/bbts03E01/bbts03E01.ism/manifest");
      //Player.MediaElement.SmoothStreamingSource = new Uri("http://localhost/videos/bbt/3/bbts03E02/bbts03E02.ism/manifest");
      //Player.MediaElement.SmoothStreamingSource = new Uri("http://vps.vincex86.be/videos/bbt/3/bbts03E02/bbts03E02.ism/manifest");
      //Player.MediaElement.SmoothStreamingSource = new Uri("http://localhost/videos/Gladiator/gladiator.ism/manifest");
      Player.MediaElement.AutoPlay = true;
      Player.MediaElement.MediaOpened += MediaElementMediaOpened;
      Player.MediaElement.MediaEnded += MediaElementMediaEnded;
      Player.MediaElement.PositionChanged += MediaElementPositionChanged;
      Player.MediaElement.MouseLeftButtonDown += MediaElementMouseLeftButtonDown;
      Player.MediaElement.MouseLeftButtonUp += MediaElementMouseLeftButtonUp;
      Player.MediaElement.CurrentStateChanged += MediaElementCurrentStateChanged;
      Player.MediaElement.ConfigPath = "config.xml";

      MouseMove += MainPageMouseMove;
      _nomousemoveTimer.Tick += NomousemoveTimerTick;
      _nomousemoveTimer.Interval = TimeSpan.FromSeconds(2);
      _nomousemoveTimer.Start();

      TimeLine.Slider.Seek += SliderSeek;
      TimeLine.Slider.SeekStarted += SliderSeekStarted;
      TimeLine.Slider.SeekCompleted += SliderSeekCompleted;
      TimeLine.Slider.BarClick += SliderBarClick;
    
      TimeLine.FullScreenToggled += TimeLineFullScreenToggled;
      TimeLine.PlayButtonPressed += TimeLinePlayButtonPressed;

      MouseWheel += MainPageMouseWheel;

      Application.Current.Exit += CurrentExit;
      Application.Current.Host.Content.FullScreenChanged += ContentFullScreenChanged;

      _layoutWidth = LayoutRoot.Width;
      _layoytHeight = LayoutRoot.Height;
    }

    private void MainPageMouseWheel(object sender, MouseWheelEventArgs e)
    {
      if (e.Delta > 0)
        Player.MediaElement.Volume += 0.1;
      else
        Player.MediaElement.Volume -= 0.1;
      e.Handled = true;
    }

    #region Player events

    private void MediaElementMediaOpened(object sender, RoutedEventArgs e)
    {
      Player.MediaElement.Pause();
      TimeLine.Slider.Minimum = 0;
      TimeLine.Slider.Maximum = Player.MediaElement.EndPosition.Ticks;
      TimeLine.EndPositionText.Text = TimespanToString(Player.MediaElement.EndPosition);
      var storedPosition = StorePosition();
      if (storedPosition != null && storedPosition != Player.MediaElement.EndPosition &&
          storedPosition != TimeSpan.FromSeconds(0))
      {
        CustomMessageBox box = new CustomMessageBox();
        box.Title = "Reprise lecture...";
        box.Message.Text = "Voulez-vous reprendre à la dernière lecture ?";
        box.Show();
        box.Closed += (s, a) =>
                        {
                          if ((bool) (s as CustomMessageBox).DialogResult)
                          {
                            Player.MediaElement.Position = ((TimeSpan) storedPosition) - TimeSpan.FromSeconds(5);
                            Player.MediaElement.Play();
                          }
                          else
                          {
                            Player.MediaElement.Play();
                          }
                        };
      }
    }

    private void MediaElementMediaEnded(object sender, RoutedEventArgs e)
    {
      TimeLine.Slider.Value = 0;
    }

    private void MediaElementPositionChanged(object sender, PositionEventArgs e)
    {
      if (!_isSeek)
      {
        TimeLine.Slider.Position = e.Position;
      }
      TimeLine.CurrentPositionText.Text = TimespanToString(TimeSpan.FromTicks((long) e.Position));
    }

    private void MediaElementCurrentStateChanged(object sender, RoutedEventArgs e)
    {
      switch (Player.MediaElement.CurrentState)
      {
        case SmoothStreamingMediaElementState.Playing:
          //Player.Opacity = 1;
          TimeLine.PlayButton2.IsChecked = true;
          break;
        case SmoothStreamingMediaElementState.Paused:
          //Player.Opacity = 0.6;
          TimeLine.PlayButton2.IsChecked = false;
          break;
      }
    }

    #endregion

    #region Timeline events

    private void SliderSeekCompleted(object sender, PositionEventArgs e)
    {
      _isSeek = false;
    }

    private void SliderSeekStarted(object sender, PositionEventArgs e)
    {
      Player.MediaElement.Pause();
      _isSeek = true;
    }

    private void SliderSeek(object sender, PositionEventArgs e)
    {
      Player.MediaElement.Position = TimeSpan.FromTicks((long) e.Position);
    }

    private void SliderBarClick(object sender, PositionEventArgs e)
    {
      Player.MediaElement.Position = TimeSpan.FromTicks((long) e.Position);
    }

    private void TimeLineFullScreenToggled(object sender, RoutedEventArgs e)
    {
      ToggleFullScreen();
    }

    private void TimeLinePlayButtonPressed(object sender, RoutedEventArgs e)
    {
      if (Player.MediaElement.CurrentState == SmoothStreamingMediaElementState.Playing)
        Player.MediaElement.Pause();
      else
      {
        Player.MediaElement.Play();
      }
    }

    #endregion

    private void NomousemoveTimerTick(object sender, EventArgs e)
    {
      TimeLineAnimationHide.Begin();
      TimeLineAnimationHide.Completed += (s, a) => { Cursor = Cursors.None; };
      _nomousemoveTimer.Stop();
    }

    private void MainPageMouseMove(object sender, MouseEventArgs e)
    {
      _nomousemoveTimer.Stop();
      _nomousemoveTimer.Start();

      if (!Equals(Cursor, Cursors.Arrow))
        Cursor = Cursors.Arrow;

      if (!Equals(TimeLine.Opacity, 1))
      {
        TimeLine.Opacity = 1;
      }
    }

    #region Fullscreen

    private void ToggleFullScreen()
    {
      Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
    }

    private void ContentFullScreenChanged(object sender, EventArgs e)
    {
      if (Application.Current.Host.Content.IsFullScreen)
      {
        LayoutRoot.Width = Application.Current.Host.Content.ActualWidth;
        LayoutRoot.Height = Application.Current.Host.Content.ActualHeight;
        TimeLine.FullScreenButton.IsChecked = true;
      }
      else
      {
        LayoutRoot.Width = _layoutWidth;
        LayoutRoot.Height = _layoytHeight;
        TimeLine.FullScreenButton.IsChecked = false;
      }
    }

    private void MediaElementMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount == 2)
      {
        ToggleFullScreen();
        return;
      }
    }

    private void MediaElementMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      TimeLinePlayButtonPressed(this, new RoutedEventArgs());
    }

    #endregion

    #region Storage

    private void StoreActualPosition()
    {
      RemoveActualStoredPosition();
      _userSettings.Add(Player.MediaElement.SmoothStreamingSource.ToString(), Player.MediaElement.Position);
    }

    private void RemoveActualStoredPosition()
    {
      if (StorePosition() != null)
        _userSettings.Remove(Player.MediaElement.SmoothStreamingSource.ToString());
    }

    private TimeSpan? StorePosition()
    {
      if (_userSettings.Contains(Player.MediaElement.SmoothStreamingSource.ToString()))
        return (TimeSpan) _userSettings[Player.MediaElement.SmoothStreamingSource.ToString()];
      return null;
    }

    private void CurrentExit(object sender, EventArgs e)
    {
      StoreActualPosition();
    }

    #endregion

    #region Utils

    private string TimespanToString(TimeSpan time)
    {
      if(time.Hours != 0)
        return string.Format("{0}:{1}:{2}", time.Hours.ToString("00"), time.Minutes.ToString("00"),
                           time.Seconds.ToString("00"));

      return string.Format("{0}:{1}", time.Minutes.ToString("00"), time.Seconds.ToString("00"));

    }

    #endregion
  }
}