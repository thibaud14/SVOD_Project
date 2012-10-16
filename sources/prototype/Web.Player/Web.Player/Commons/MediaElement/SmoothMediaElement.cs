using System;
using System.Windows.Threading;
using Microsoft.Web.Media.SmoothStreaming;
using Web.Player.Commons.Events;

namespace Web.Player.Commons.MediaElement
{
  public class SmoothMediaElement : SmoothStreamingMediaElement
  {
    private readonly DispatcherTimer _videoTick;
    public event EventHandler<PositionEventArgs> PositionChanged;

    public new TimeSpan Position
    {
      get { return base.Position; }
      set { base.Position = value; }
    }

    public SmoothMediaElement()
    {
      _videoTick = new DispatcherTimer();
      _videoTick.Tick += VideoTickTick;
      _videoTick.Interval = TimeSpan.FromMilliseconds(250);

      MediaOpened += SmoothMediaElementMediaOpened;
      MediaEnded += SmoothMediaElementMediaEnded;
    }

    void SmoothMediaElementMediaEnded(object sender, System.Windows.RoutedEventArgs e)
    {
      _videoTick.Stop();
    }

    void SmoothMediaElementMediaOpened(object sender, System.Windows.RoutedEventArgs e)
    {
      _videoTick.Start();
    }

    void VideoTickTick(object sender, EventArgs e)
    {
      OnPositionChanged(new PositionEventArgs(Position.Ticks));
    }

    public void OnPositionChanged(PositionEventArgs positionEventArgs)
    {
      EventHandler<PositionEventArgs> handler = PositionChanged;
      if (handler != null) handler(this, positionEventArgs);
    }

  }
}
