using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pyarS7A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSelecccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;


        public Elemento(int id, string nombre, string usuario, string contrasenia)
        {
            InitializeComponent();
            txtName.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasenia.Text = contrasenia;
            idSelecccionado = id;
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("delete from estudiante where Id=?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("update estudiante set Nombre=?, Usuario=?, Contrasenia=? where Id=?", nombre, usuario, contrasenia, id);
        }

        private void btnActualiar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rActualizar = Update(db, idSelecccionado, txtName.Text, txtUsuario.Text, txtContrasenia.Text);
                Navigation.PushAsync(new ConsultarRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btneEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, idSelecccionado);
                Navigation.PushAsync(new ConsultarRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}