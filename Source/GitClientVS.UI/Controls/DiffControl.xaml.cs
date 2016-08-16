﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;
using ParseDiff;

namespace GitClientVS.UI.Controls
{
    /// <summary>
    /// Interaction logic for DiffControl.xaml
    /// </summary>
    public partial class DiffControl : UserControl
    {
       

        public FileDiff FileDiff
        {
            get { return (FileDiff)GetValue(FileDiffProperty); }
            set { SetValue(FileDiffProperty, value); }
        }

       
        // Using a DependencyProperty as the backing store for FileDiff.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileDiffProperty =
            DependencyProperty.Register("FileDiff", typeof(FileDiff), typeof(DiffControl), new PropertyMetadata(null));

        public DiffControl()
        {
            InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }


        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

      
    }
}
