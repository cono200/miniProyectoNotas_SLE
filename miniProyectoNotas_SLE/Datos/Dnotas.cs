using System;
using System.Collections.Generic;
using System.Text;
using miniProyectoNotas_SLE.Modelo;
using miniProyectoNotas_SLE.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;
using Xamarin.Essentials;
//using miniProyectoNotas_SLE.Vista

namespace miniProyectoNotas_SLE.Datos
{
    public class Dnotas
    {
        FirebaseClient firebaseClient = Cconexion.firebase;

        public async Task ActualizarNota(Mnotas notaEditada)
        {
            //CHECAR SI ES TITULO O MODELO
            string rutaNota = "Titulo/" + notaEditada.titulo;
            try
            {
                await Cconexion.firebase.Child(rutaNota).PutAsync(notaEditada);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el pokemon" + ex.Message);
            }
        }


        public async Task InsertarNota(Mnotas parametros)
        {
            await Cconexion.firebase
                .Child("Titulo")
                .Child(parametros.titulo)
                .PutAsync(parametros);
        }

        public async Task<ObservableCollection<Mnotas>> MostrarNotas()
        {
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Titulo")
                .AsObservable<Mnotas>()
                .AsObservableCollection());
            return data;
        }

        public async Task EliminarNota(string titulo)
        {
            string rutaNota = "Titulo/" + titulo;
            try
            {
                await Cconexion.firebase.Child(rutaNota).DeleteAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Editar(Mnotas nota)
        {
            var notas = (await Cconexion.firebase
                .Child("Titulo")
                .OnceAsync<Mnotas>())
                .Where(p=> p.Object.titulo == nota.titulo)
                .FirstOrDefault();

            if (notas !=null)
            {
                var notaEncontrado = notas;
                var nombreAnterior = notaEncontrado.Key;

                await Cconexion.firebase
                    .Child("Titulo")
                    .Child(nombreAnterior)
                    .DeleteAsync();

                await Cconexion.firebase
                    .Child("Titulo")
                    .Child(nota.titulo)
                    .PutAsync(nota);
            }
           
        }
      

   









    }
}
