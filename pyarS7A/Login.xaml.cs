using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using System.Net.Http.Headers;

namespace pyarS7A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<IDataBase>().GetConnection();
        }


        private void btnInicial_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SelectWhere(db, txtUsuario.Text, txtContrasenia.Text);
                if (resultado.Count() > 0) Navigation.PushAsync(new ConsultarRegistro());
                else DisplayAlert("Alerta", "Usuario o contraseña incorrecta", "Cerrar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        public static IEnumerable<Estudiante> SelectWhere(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("select * from estudiante where Usuario=? and Contrasenia=? ", usuario, contrasenia);
        }
    }
}