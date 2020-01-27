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
    public partial class ImageExercise : TabbedPage
    {
        public ImageExercise()
        {
            InitializeComponent();

            var imageSource = new UriImageSource { Uri = new Uri("https://images.unsplash.com/photo-1490100886609-e401a775fb3a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"), CachingEnabled = true, CacheValidity = TimeSpan.FromHours(12) };
            imgBottom.Source = imageSource;
            imgBottom.Aspect = Aspect.AspectFill;

            imgGrid00.Source = ImageSource.FromResource("HelloWorld.Images.Witcher1.jpg");
        }
    }
}