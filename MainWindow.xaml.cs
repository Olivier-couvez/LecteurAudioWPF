﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfLecteurAudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool enTrainDeJouer = false;
        private bool modifSlider = false;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
		private void timer_Tick(object sender, EventArgs e)
		{
			if ((monLecteur.Source != null) && (monLecteur.NaturalDuration.HasTimeSpan) && (!modifSlider))
			{
				sliderAvance.Minimum = 0;
				sliderAvance.Maximum = monLecteur.NaturalDuration.TimeSpan.TotalSeconds;
				sliderAvance.Value = monLecteur.Position.TotalSeconds;
			}
		}

		private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			string chemin = "";
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				chemin = Convert.ToString(new Uri(openFileDialog.FileName));
				string[] decoupe = chemin.Split('/');

				lblChemin.Content = decoupe[decoupe.Length-1];

				monLecteur.Source = new Uri(openFileDialog.FileName);
			}
		}

		private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = (monLecteur != null) && (monLecteur.Source != null);
		}

		private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			monLecteur.Play();
			enTrainDeJouer = true;
		}

		private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = enTrainDeJouer;
		}

		private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			monLecteur.Pause();
		}

		private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = enTrainDeJouer;
		}

		private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			monLecteur.Stop();
			enTrainDeJouer = false;
		}

		private void sliderAvance_DragStarted(object sender, DragStartedEventArgs e)
		{
			modifSlider = true;
		}

		private void sliderAvance_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			modifSlider = false;
			monLecteur.Position = TimeSpan.FromSeconds(sliderAvance.Value);
		}

		private void sliderAvance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			lblProgression.Text = String.Format("{0} / {1}", monLecteur.Position.ToString(@"hh\:mm\:ss"), monLecteur.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
		}

		private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			monLecteur.Volume += (e.Delta > 0) ? 0.1 : -0.1;
		}
	}
}
