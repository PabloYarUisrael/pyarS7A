using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pyarS7A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> tEstudiante;
        public ConsultarRegistro()
        {
            InitializeComponent();
            _conn=DependencyService.Get<IDataBase>().GetConnection();
            Listar();
        }

        public async void Listar()
        {
            var resultado = await _conn.Table<Estudiante>().ToListAsync();
            tEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaEstudiantes.ItemsSource = tEstudiante;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var id = Convert.ToInt32(item);
            var nombre = obj.Nombre.ToString();
            var usuario = obj.Usuario.ToString();
            var contrasenia = obj.Contrasenia.ToString();
            Navigation.PushAsync(new Elemento(id, nombre, usuario, contrasenia));

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());

        }
    }
}