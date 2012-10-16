using System.Windows.Controls;

namespace Web.Player.Core.View
{
  public partial class Player : UserControl
  {
    public Player()
    {
      InitializeComponent();
      MediaElement.EnableGPUAcceleration = true;
      MediaElement.AutoPlay = false;
    }
  }
}
