using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

using miniProyectoNotas_SLE.Vista.Notas;
using miniProyectoNotas_SLE.Datos;
using miniProyectoNotas_SLE.Modelo;
using Xamarin.Forms;

namespace miniProyectoNotas_SLE.VistaModelo.VMNotas
{
    public class VMListarNotas : BaseViewModel
    {
        #region VARIABLES
         private string _texto;
        ObservableCollection<Mnotas> _ListarNotas;
        #endregion
        #region CONSTRUCTOR
        public VMListarNotas(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
       public ObservableCollection<Mnotas> ListarNotas
        {
            get {  return _ListarNotas;}
            set
            {
                SetValue(ref _ListarNotas, value);
                OnpropertyChanged();
            }
        }
        #endregion
        #region PROCESOS
        public async Task MostrarNota()
        {
            var funcion = new Dnotas();
            ListarNotas = await funcion.MostrarNotas();
        }
        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new RegistarNotas());
        }
        public async Task Iradetalle(Mnotas parametros)
        {
            await Navigation.PushAsync(new DetalleNotas(parametros));
        }
        public async Task EditarNotas(Mnotas parametros)
        {
            await Navigation.PushAsync(new EditarNotas(parametros));
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand IraregistroCommand => new Command(async () => await Iraregistro());
        public ICommand IradetalleCommand => new Command<Mnotas>(async (p) => await Iradetalle(p));
        public ICommand EditarCommand => new Command<Mnotas>(async (p) => await EditarNotas(p));

        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
