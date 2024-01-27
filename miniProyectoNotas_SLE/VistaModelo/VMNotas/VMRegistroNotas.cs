using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using miniProyectoNotas_SLE.Modelo;
using miniProyectoNotas_SLE.Datos;
namespace miniProyectoNotas_SLE.VistaModelo.VMNotas
{
    public class VMRegistroNotas : BaseViewModel
    {
        #region VARIABLES
         private string _texto;
         private string _titulo;
        #endregion
        #region CONSTRUCTOR
        public VMRegistroNotas(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _texto; }
            set { SetValue(ref _texto, value); }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Insertar()
        {
            var funcion = new Dnotas();
            var parametros = new Mnotas();
            parametros.titulo = Titulo;
            parametros.texto = Texto;

            await funcion.InsertarNota(parametros);
            await Volver();
        }

        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand InsertarCommand => new Command(async() => await Insertar());
        public ICommand VolverCommand => new Command(async() => await Volver());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion


    }
}
