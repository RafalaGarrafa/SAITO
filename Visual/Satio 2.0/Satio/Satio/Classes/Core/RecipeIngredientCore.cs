using Microsoft.EntityFrameworkCore;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class RecipeIngredientCore
    {
        SatioDbContext dbContext;
        public RecipeIngredientCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RecipeIngredient> GetAll()
        {
            try
            {

                List<RecipeIngredient> recipeIngredients = (
                    from ri in dbContext.RecipeIngredient
                    select ri

                    ).ToList();

                return recipeIngredients;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(RecipeIngredient recipeIngredient)
        {
            try
            {
                bool validWarning = Validate(recipeIngredient);

                if (validWarning)
                {
                    dbContext.Add(recipeIngredient);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(RecipeIngredient recipeIngredient)
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

        public void Update(RecipeIngredient recipeIngredient, int id)
        {
            try
            {
                // Validar datos correctos
                bool validWarning = Validate(recipeIngredient);

                if (validWarning)
                {
                    // Que exista el id
                    bool existWord = dbContext.RecipeIngredient.Any(recipeIngredient => recipeIngredient.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        recipeIngredient.Id = id;


                        dbContext.Update(recipeIngredient);
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
                RecipeIngredient recipeIngredient = dbContext.RecipeIngredient.FirstOrDefault(x => x.Id == id);

                if (recipeIngredient != null)
                {
                  
                    dbContext.Remove(recipeIngredient);
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
