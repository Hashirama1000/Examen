using AppTutorialesFonsus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace AppTutorialesFonsus.Data
{
    public class TutorialsContext: DbContext
    {
        public DbSet<TutorialModel> TbTutorials { get; set; }

        public TutorialsContext()
        {
            /*Necesario para iniciar sqlite en iOS*/
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TutorialesDbFonsus.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
