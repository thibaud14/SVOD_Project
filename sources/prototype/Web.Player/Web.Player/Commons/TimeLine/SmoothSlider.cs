using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Web.Player.Commons.Events;

namespace Web.Player.Commons.TimeLine
{
  public class SmoothSlider : Slider
  {
    private Point _mousePoint;
    private DateTime _lastEventReceived;
    private DateTime _lastEventSend;

    public event EventHandler<PositionEventArgs> BarClick;
    public event EventHandler<PositionEventArgs> SeekStarted;
    public event EventHandler<PositionEventArgs> Seek;
    public event EventHandler<PositionEventArgs> SeekCompleted;

    public double Position
    {
      get { return Value; }
      set { Value = value; }
    }

    public SmoothSlider()
    {
      DefaultStyleKey = typeof (Slider);
    }

    #region Template

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      var horizontalThumb = GetTemplateChild("HorizontalThumb") as Thumb;
      if (horizontalThumb != null)
      {
        horizontalThumb.DragStarted += HorizontalThumbDragStarted;
        horizontalThumb.DragCompleted += HorizontalThumbDragCompleted;
        horizontalThumb.DragDelta += HorizontalThumbDragDelta;
      }

      RepeatButton rb;
      rb = base.GetTemplateChild("HorizontalTrackLargeChangeIncreaseRepeatButton") as RepeatButton;
      rb.MouseMove += TrackBarMouseMove;
      rb.Click += TrackBarClick;
      rb = base.GetTemplateChild("HorizontalTrackLargeChangeDecreaseRepeatButton") as RepeatButton;
      rb.MouseMove += TrackBarMouseMove;
      rb.Click += TrackBarClick;
    }

    #endregion

    #region Horizontal thumb events

    private void HorizontalThumbDragDelta(object sender, DragDeltaEventArgs e)
    {
      _lastEventReceived = DateTime.Now;
      if(_lastEventReceived - _lastEventSend > TimeSpan.FromMilliseconds(100))
      {
        if (Seek != null)
          Seek(this, new PositionEventArgs(Value));
        _lastEventSend = DateTime.Now;
      }
    }

    private void HorizontalThumbDragStarted(object sender, DragStartedEventArgs e)
    {
      if (SeekStarted != null)
        SeekStarted(this, new PositionEventArgs(Value));
    }

    private void HorizontalThumbDragCompleted(object sender, DragCompletedEventArgs e)
    {
      if (SeekCompleted != null)
        SeekCompleted(this, new PositionEventArgs(Value));
    }

    #endregion

    #region Track bar event

    private void TrackBarMouseMove(object sender, MouseEventArgs e)
    {
      _mousePoint = e.GetPosition(this);
    }

    private void TrackBarClick(object sender, RoutedEventArgs e)
    {
      if (BarClick != null)
        BarClick(this, new PositionEventArgs(ComputePosition(_mousePoint)));
    }

    private double ComputePosition(Point ps)
    {
      return (Maximum - Minimum) * ps.X / ActualWidth;
    }

    #endregion


  }
}
