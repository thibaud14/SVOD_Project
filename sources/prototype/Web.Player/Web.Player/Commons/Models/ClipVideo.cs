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

namespace Web.Player.Commons.Models
{
  public class ClipVideo
  {
    public string Title { get; set; }
    public string Author { get; set; }
    public TimeSpan Duration { get; set; }
    public string[] Audios { get; set; }
    public string[] Subtitles { get; set; }

    public string Source { get; set; }
  }
}
