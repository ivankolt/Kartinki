using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Kartinki
{
    public partial class MainWindow : Window
    {
        public static BlurEffect blurEffect = new BlurEffect { Radius = 10 };

        public MainWindow()
        {
            InitializeComponent();
            image1.Source = new BitmapImage(new Uri("Images/1.png", UriKind.Relative));
            image2.Source = new BitmapImage(new Uri("Images/2.png", UriKind.Relative));
            image3.Source = new BitmapImage(new Uri("Images/3.png", UriKind.Relative));
            image4.Source = new BitmapImage(new Uri("Images/4.png", UriKind.Relative));
            image5.Source = new BitmapImage(new Uri("Images/5.png", UriKind.Relative));
            image6.Source = new BitmapImage(new Uri("Images/6.png", UriKind.Relative));
            image7.Source = new BitmapImage(new Uri("Images/7.png", UriKind.Relative));
            image8.Source = new BitmapImage(new Uri("Images/8.png", UriKind.Relative));
            image9.Source = new BitmapImage(new Uri("Images/9.png", UriKind.Relative));
            image10.Source = new BitmapImage(new Uri("Images/10.png", UriKind.Relative));
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Image image)
            {
                DropShadowEffect shadowEffect = new DropShadowEffect
                {
                    BlurRadius = 10,
                    Color = Colors.Black,
                    Opacity = 1
                };
                image.Effect = shadowEffect;
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Image image)
            {
                BlurEffect blurEffect = new BlurEffect
                {
                    Radius = 10
                };
                image.Effect = blurEffect;
            }
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button &&

            button.Tag is Image image)
            {

                RotateAnimation(image, 90);
            }
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button &&

               button.Tag is Image image)
            {

                RotateAnimation(image, -90);
            }
        }

        private void RotateAnimation(UIElement element, double angle)
        {
            RotateTransform rotateTransform = (RotateTransform)element.RenderTransform;
            DoubleAnimation rotateAnimation = new DoubleAnimation
            {
                To = rotateTransform.Angle + angle,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
            };
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }



        private void stackpanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is StackPanel stackpanel)
            {
                
                if (stackpanel.RenderTransform is ScaleTransform currentScaleTransform)
                {
                   
                    DoubleAnimation scaleDownX = new DoubleAnimation
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    DoubleAnimation scaleDownY = new DoubleAnimation
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    currentScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleDownX);
                    currentScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleDownY);
                }
                else
                {
                   
                    ScaleTransform newScaleTransform = new ScaleTransform(1, 1);
                    stackpanel.RenderTransform = newScaleTransform;

                    DoubleAnimation scaleDownX = new DoubleAnimation
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    DoubleAnimation scaleDownY = new DoubleAnimation
                    {
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    newScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleDownX);
                    newScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleDownY);
                }
            }
        }

        private void stackpanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel stackpanel)
            {
             
                if (stackpanel.RenderTransform is ScaleTransform currentScaleTransform)//это который у нас сейчас на стак апнели
                {
                   
                    DoubleAnimation scaleUpX = new DoubleAnimation //меняме x
                    {
                        To = currentScaleTransform.ScaleX * 1.5,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    DoubleAnimation scaleUpY = new DoubleAnimation //y
                    {
                        To = currentScaleTransform.ScaleY * 1.5,
                        Duration = TimeSpan.FromSeconds(0.3),///анимация времени
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    currentScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUpX);
                    currentScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUpY);
                }
                else
                {
                    
                    ScaleTransform newScaleTransform = new ScaleTransform(1.5, 1.5);
                    stackpanel.RenderTransform = newScaleTransform;

                    DoubleAnimation scaleUpX = new DoubleAnimation
                    {
                        To = newScaleTransform.ScaleX,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    DoubleAnimation scaleUpY = new DoubleAnimation
                    {
                        To = newScaleTransform.ScaleY,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    newScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUpX);
                    newScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUpY);
                }
            }
        }
    }
}
