using Microsoft.EntityFrameworkCore;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class IngredientCore
    {
        SatioDbContext dbContext;
        public IngredientCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Ingredient> GetAll()
        {
            try
            {

                List<Ingredient> ingredients = (
                    from i in dbContext.Ingredient
                    select i

                    ).ToList();

                return ingredients;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Ingredient GetLastRegistered()
        {
            try
            {

                List<Ingredient> ingredients = (
                    from i in dbContext.Ingredient
                    select i

                    ).ToList();

                return ingredients.OrderByDescending(x => x.Id).ToList().First();


                //return contactInfos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Create(Ingredient ingredient)
        {
            try
            {
                bool validWarning = Validate(ingredient);

                if (validWarning)
                {
                    dbContext.Add(ingredient);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(Ingredient ingredient)
        {
            try
            {
                //if (string.IsNullOrEmpty(ingredient.Food))
                //{
                //    return false;
                //}

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Ingredient ingredient, int id)
        {
            try
            {
                // Validar datos correctos
                bool validIngredient = Validate(ingredient);

                if (validIngredient)
                {
                    // Que exista el id
                    bool existWord = dbContext.Ingredient.Any(ingredient => ingredient.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        ingredient.Id = id;

                        dbContext.Update(ingredient);
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
                Ingredient ingredient = dbContext.Ingredient.FirstOrDefault(x => x.Id == id);

                if (ingredient != null)
                {
                    dbContext.Remove(ingredient);
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
