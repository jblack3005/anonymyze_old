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
            Application.Current.MainPage = new Pages.UploadPage();
        }

        private void OnUpload(object sender, EventArgs e)
        {
            uploadButton.Text = "Image Uploaded";
        }
    }
}
