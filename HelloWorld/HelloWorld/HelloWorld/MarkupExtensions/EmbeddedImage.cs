using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.MarkupExtensions
{
    [ContentProperty("ResourceID")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceID
        {
            get;
            set;
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(ResourceID))
                return null;
            else
                return ImageSource.FromResource(ResourceID);
        }
    }
}
