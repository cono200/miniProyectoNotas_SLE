using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using miniProyectoNotas_SLE.Datos;
using miniProyectoNotas_SLE.Modelo;
using miniProyectoNotas_SLE.Vista.Notas;
using Xamarin.Forms;

namespace miniProyectoNotas_SLE.VistaModelo.VMNotas
{
    public class VMEditarNotas : BaseViewModel
    {
        string _nuevoTexto;
        string _nuevoTitulo;
        string _tituloOriginal;
        Command _editarCommand;

        public string TituloOriginal
        {
            get => _tituloOriginal;
            set => SetProperty(ref _tituloOriginal, value);
        }
         public string NuevoTexto
        {
            get => _nuevoTexto;
            set => SetProperty(ref _nuevoTexto, value);
        }
          public string NuevoTitulo
        {
            get => _nuevoTitulo;
            set => SetProperty(ref _nuevoTitulo, value);
        }


        public Mnotas parametrosRecibe {  get; set; }
        public VMEditarNotas(INavigation navigation, Mnotas parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;

            TituloOriginal = parametrosRecibe.titulo;
            NuevoTitulo = parametrosRecibe.titulo;
            NuevoTexto = parametrosRecibe.texto;
            
        }


        public async Task EditarNota()
        {
            var funcion = new Dnotas();

            var notaEditada = new Mnotas()
            {
                titulo = TituloOriginal,
                texto = NuevoTexto,
            };
            await funcion.ActualizarNota(notaEditada);

        }

        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand EditarCommand => _editarCommand ?? (_editarCommand = new Command(async () => await EditarNota()));



    }
}
