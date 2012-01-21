using System;
using System.Windows;
using System.Windows.Controls;

namespace SmfSimplePlayer
{
    public partial class MainPage : UserControl
    {
        private Uri _media;
        private bool _cue = false;
        private bool _isSmooth = false;
        private double _buffer = 3.0;

        public MainPage(Uri media, bool cue, bool smoothStreaming, double bufferTime)
        {
            InitializeComponent();

            App.Current.Host.Content.FullScreenOptions = System.Windows.Interop.FullScreenOptions.StaysFullScreenWhenUnfocused;

            _media = media;
            _cue = cue;
            _isSmooth = smoothStreaming;
            _buffer = bufferTime;

            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // if it is smooth streaming then just use normal operations
            if (_isSmooth)
            {
                MediaBits.SmoothStreamingSource = _media;
            }
            else
            {
                if (_cue) // auto load the video as normal
                {
                    MediaBits.BufferingTime = TimeSpan.FromSeconds(_buffer);
                    MediaBits.Source = _media;
                }
                else // progressive download with no auto load
                {
                    PlayerRoot.MediaElement.BufferingTime = TimeSpan.FromSeconds(_buffer);
                    PlayerRoot.DeferredSource = _media;
                }
            }
        }
    }
}