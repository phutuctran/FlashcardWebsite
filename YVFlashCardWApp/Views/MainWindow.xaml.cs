﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YVFlashCardWApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
		}

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

		private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			WindowInteropHelper helper = new WindowInteropHelper(this);
			SendMessage(helper.Handle, 161, 2, 0);
		}

		private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
		{
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void btnMaximize_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = this.WindowState == WindowState.Normal? WindowState.Maximized : WindowState.Normal;
		}

		private void btnMinimize_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}
	}
}