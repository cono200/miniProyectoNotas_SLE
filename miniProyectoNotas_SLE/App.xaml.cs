using miniProyectoNotas_SLE.Vista.Notas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace miniProyectoNotas_SLE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaNotas());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
