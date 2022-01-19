using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace anonymyze
{
    public class MainPage : ContentPage
    {
        Button uploadButton;

        public MainPage()
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(uploadButton = new Button
            {
                Text = "Upload",
                IsEnabled = false,
            });

            uploadButton.Clicked += OnUpload;
            this.Content = panel;
        }

        private void OnUpload(object sender, EventArgs e)
        {
            uploadButton.Text = "Image Uploaded";
        }
    }
}
