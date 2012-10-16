﻿using System;
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

namespace Web.Player.Core.View.Message
{
  public partial class CustomMessageBox : ChildWindow
  {
    public CustomMessageBox()
    {
      InitializeComponent();
    }

    private void YesButton_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }

    private void NoButton_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = false;
    }
  }
}

