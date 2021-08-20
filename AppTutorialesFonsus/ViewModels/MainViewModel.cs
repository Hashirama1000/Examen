using AppTutorialesFonsus.BL;
using AppTutorialesFonsus.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTutorialesFonsus.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        Tutorials tutorials = new Tutorials();


        private ObservableCollection<TutorialModel> listTutoriales;
        public ObservableCollection<TutorialModel> ListTutoriales
        {
            get { return listTutoriales; }
            set { listTutoriales = value; RaisePropetyChanged(); }
        }



        private string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; RaisePropetyChanged(); }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; RaisePropetyChanged(); }
        }


        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel() {

            DeleteRowCommand= new Command<TutorialModel>(execute: async (tutorialModel)=>{
                await tutorials.DeleteTutorial(tutorialModel);

                LoadListTutorials();
            });

            DeleteAllRowCommand= new Command(execute: async ()=>{
                await tutorials.DeleteAllTutorials();
                LoadListTutorials();
            });

            UpdateRowCommand = new Command<TutorialModel>(execute: async (tutorialModel) => {
                await tutorials.UpdateTutorial(tutorialModel);

                LoadListTutorials();
            });

            InsertRowCommand = new Command(execute: async () => {
                
                await tutorials.InsertTutorial(new TutorialModel() { TutorialFecha= Titulo , TutorialDescripcion= Descripcion });
                Titulo = "";
                Descripcion = "";

                LoadListTutorials();
            });


            LoadListTutorials();


        }
        async void LoadListTutorials() {

            ListTutoriales = new ObservableCollection<TutorialModel>(await tutorials.GetListTutorials());
        }

    }
}
