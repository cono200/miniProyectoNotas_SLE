using miniProyectoNotas_SLE.Datos;
using miniProyectoNotas_SLE.Modelo;
using miniProyectoNotas_SLE.Vista.Notas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace miniProyectoNotas_SLE.VistaModelo.VMNotas
{
    public class VMdetalleNotas : BaseViewModel
    {
        #region VARIABLES
        string _Mensaje;
        public Mnotas parametrosRecibe {  get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMdetalleNotas(INavigation navigation, Mnotas parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
            
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Mensaje; }
            set { SetValue(ref _Mensaje, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        private async Task IrAEditar(Mnotas nota)
        {
            var viewModel = new VMEditarNotas(Navigation, parametrosRecibe);
            viewModel.TituloOriginal = nota.titulo;

            var editarNotaPage = new EditarNotas(nota);

            await Navigation.PushAsync(editarNotaPage);
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public async Task EliminarNota(string tituloNota)
        {
            try
            {
                var funcion = new Dnotas();
                await funcion.EliminarNota(tituloNota);
                await Navigation.PushAsync(new ListaNotas());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand IrAEditarCommand => new Command<Mnotas>(async (nota) => await IrAEditar(nota));
        public ICommand EliminarCommand => new Command(async () => await EliminarNota(parametrosRecibe.titulo));

        #endregion


    }
}
