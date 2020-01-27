using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreetPage : ContentPage
    {
        Random r = new Random();
        public GreetPage()
        {
            InitializeComponent();
            sldvalue.Value = 0.5;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
                default:
                    Padding = new Thickness(0, 50, 0, 0);
                    break;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Anirban here", "Hello!", "OK");
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
        }
    }
}