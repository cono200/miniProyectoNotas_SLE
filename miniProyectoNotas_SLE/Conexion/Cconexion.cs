using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace miniProyectoNotas_SLE.Conexion
{
    public  class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://notascono-default-rtdb.firebaseio.com/");
    }
}
