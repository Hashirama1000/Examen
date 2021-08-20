using AppTutorialesFonsus.Data;
using AppTutorialesFonsus.Models;
using AppTutorialesFonsus.Sevices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTutorialesFonsus.BL
{
    public class Tutorials : ITutorials
    {
        public async Task<List<TutorialModel>> GetListTutorials()
        {
            using (var tutorialsContext = new TutorialsContext())
            {
                return  await tutorialsContext.TbTutorials.ToListAsync();
            }
        }

        public async Task<TutorialModel> GetTutorial(int TuturialId)
        {
            using (var tutorialsContext = new TutorialsContext())
            {
                return await tutorialsContext.TbTutorials
                    .Where(p => p.TutorialId == TuturialId).FirstOrDefaultAsync();
            }

        }


        public async Task<bool> InsertTutorial(TutorialModel tutorialModel)
        {
            using (var tutorialsContext = new TutorialsContext())
            {
                tutorialsContext.Add(tutorialModel);

                await tutorialsContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateTutorial(TutorialModel tutorialModel)
        {
            using (var tutorialsContext = new TutorialsContext())
            {
                var tracking = tutorialsContext.Update(tutorialModel);

                await tutorialsContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
        }

        public async Task<bool> DeleteTutorial(TutorialModel tutorialModel)
        {
            using (var tutorialsContext = new TutorialsContext())
            {
                var tracking = tutorialsContext.Remove(tutorialModel);

                await tutorialsContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }

        }


        public async Task<bool> DeleteAllTutorials()
        {
            using (var tutorialsContext = new TutorialsContext())
            {
                tutorialsContext.RemoveRange(tutorialsContext.TbTutorials);

                await tutorialsContext.SaveChangesAsync();
            }
            return true;
        }


    }
}
