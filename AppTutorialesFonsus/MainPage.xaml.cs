using AppTutorialesFonsus.Models;
using AppTutorialesFonsus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTutorialesFonsus
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        MainViewModel Vm { get { return BindingContext as MainViewModel; } }

        public async void UpdateRow_Tapped(object sender, EventArgs e)
        {
            var contenedor = ((Frame)sender).GestureRecognizers[0];

            TutorialModel tutorialModel = ((TapGestureRecognizer)contenedor).CommandParameter as TutorialModel;

            string Titulo = await DisplayPromptAsync("Idpago", tutorialModel.TutorialIdpago);
            string Titulo = await DisplayPromptAsync("Titulo", tutorialModel.TutorialFecha);
            string Descripcion = await DisplayPromptAsync("Descripción", tutorialModel.TutorialDescripcion);
            string Titulo = await DisplayPromptAsync("Fecha", tutorialModel.TutorialFecha);


            tutorialModel.TutorialFecha = Titulo;
            tutorialModel.TutorialDescripcion = Descripcion;

            Vm.UpdateRowCommand.Execute(tutorialModel);

        }

        private async void DeleteRow_Swiped(object sender, SwipedEventArgs e)
        {

            bool resultado = await DisplayAlert("Eliminar", "¿Seguro que desea eliminar el registro?", "Si", "No");

            if (resultado)
            {
                var contenedor = ((Frame)sender).GestureRecognizers[0];

                TutorialModel tutorialModel = ((TapGestureRecognizer)contenedor).CommandParameter as TutorialModel;

                Vm.DeleteRowCommand.Execute(tutorialModel);
            }

        }


    }
}
