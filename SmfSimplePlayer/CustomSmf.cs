/*
 * This custom code is thanks to Kevin @ Vertigo for understanding my needs
 * and pointing out I could just subclass the existing Player from the
 * Silverlight Media Framework http://smf.codeplex.com
 * 
 * Thanks Kevin! http://twitter.com/sundriedcoder
 * 
 * */
using System;
using Microsoft.SilverlightMediaFramework.Player;

namespace SmfSimplePlayer
{
    public class CustomSmf : Player
    {
        public Uri DeferredSource { get; set; }
        public Uri DeferredSmoothStreamingSource { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (base.playElement != null)
            {
                base.playElement.IsEnabledChanged += PlayElement_IsEnabledChanged;
                base.playElement.PlayControlClicked += PlayElement_PlayControlClicked;
            }
        }

        void PlayElement_IsEnabledChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            base.playElement.IsEnabled = true;
        }

        private void PlayElement_PlayControlClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (base.MediaElement != null)
            {
                if (DeferredSource != null)
                {
                    base.MediaElement.Source = DeferredSource;
                }
                else if (DeferredSmoothStreamingSource != null)
                {
                    base.MediaElement.SmoothStreamingSource = DeferredSmoothStreamingSource;
                }
            }
        }

    }
}