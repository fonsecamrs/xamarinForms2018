using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Carousel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoPagina3 : ContentPage
	{
		public TipoPagina3 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina(object sender, EventArgs args)
        {
            //Somente muda de página normal
            //App.Current.MainPage = new Navigation.Pagina1();

            //Muda de página para páginas NavigationPage
            App.Current.MainPage = new NavigationPage(new Navigation.Pagina1())
            {
                BarBackgroundColor = Color.Blue,
                BarTextColor = Color.White
            };
        }

    }
}