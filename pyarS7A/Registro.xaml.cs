using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pyarS7A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<IDataBase>().GetConnection();

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante
            {
                Nombre = txtNombre.Text,
                Usuario = txtUsuario.Text,
                Contrasenia = txtContrasenia.Text
            };
            _conn.InsertAsync(datos);
            txtNombre.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtContrasenia.Text = string.Empty;

            Navigation.PushAsync(new Login());

        }

        public static IEnumerable<Estudiante> SaveUser(SQLiteConnection db, Estudiante usuario)
        {
            return db.Query<Estudiante>("select * from estudiante where Usuario=? and Contrasenia=? ", usuario);
        }
    }
}