using Microsoft.EntityFrameworkCore;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class RecipeWarningCore
    {
        SatioDbContext dbContext;
        public RecipeWarningCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RecipeWarning> GetAll()
        {
            try
            {

                List<RecipeWarning> recipeWarnings = (
                    from rw in dbContext.RecipeWarning
                    select rw

                    ).ToList();

                return recipeWarnings;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(RecipeWarning recipeWarnings)
        {
            try
            {
                bool validWarning = Validate(recipeWarnings);

                if (validWarning)
                {
                    dbContext.Add(recipeWarnings);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(RecipeWarning recipeWarnings)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(RecipeWarning recipeWarnings, int id)
        {
            try
            {
                // Validar datos correctos
                bool validWarning = Validate(recipeWarnings);

                if (validWarning)
                {
                    // Que exista el id
                    bool existWord = dbContext.RecipeWarning.Any(recipeWarnings => recipeWarnings.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        recipeWarnings.Id = id;

                      
                        dbContext.Update(recipeWarnings);
                        dbContext.SaveChanges();
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                RecipeWarning recipeWarnings = dbContext.RecipeWarning.FirstOrDefault(x => x.Id == id);

                if (recipeWarnings != null)
                {
                  
                    dbContext.Remove(recipeWarnings);
                    dbContext.SaveChanges();


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
