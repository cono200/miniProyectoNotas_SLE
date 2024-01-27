using miniProyectoNotas_SLE.Modelo;
using miniProyectoNotas_SLE.VistaModelo.VMNotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace miniProyectoNotas_SLE.Vista.Notas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarNotas : ContentPage
    {
        public EditarNotas(Mnotas parametros)
        {
            InitializeComponent();
            BindingContext = new VMEditarNotas(Navigation, parametros);

        }
    }
}