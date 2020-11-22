using Tarea7MPaez;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea7MPaez.Models;

namespace Tarea7MPaez
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection conn;

        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int id)
        {
            InitializeComponent();
            this.conn = DependencyService.Get<Database>().GetConnection();
            idSeleccionado = id;

        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>
                ("Update Estudiante Set nombre=?, usuario=?, password=? where id = ?", nombre, usuario, contrasenia, id);
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete From Estudiante where id = ?", id);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {


            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, nombre.Text, usuario.Text, contra.Text, idSeleccionado);
                DisplayAlert("Alerta", "Se Actualizó correctamente", "ok");
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, idSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }
    }
}