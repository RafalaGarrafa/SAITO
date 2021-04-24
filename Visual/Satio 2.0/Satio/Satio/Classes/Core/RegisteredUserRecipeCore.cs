using Microsoft.EntityFrameworkCore;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class RegisteredUserRecipeCore
    {
        SatioDbContext dbContext;
        public RegisteredUserRecipeCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RegisteredUserRecipe> GetAll()
        {
            try
            {

                List<RegisteredUserRecipe> registeredUserRecipes = (
                    from rur in dbContext.RegisteredUserRecipe
                    select rur

                    ).ToList();

                return registeredUserRecipes;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(RegisteredUserRecipe registeredUserRecipe)
        {
            try
            {
                bool validWarning = Validate(registeredUserRecipe);

                if (validWarning)
                {
                    dbContext.Add(registeredUserRecipe);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(RegisteredUserRecipe registeredUserRecipe)
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

        public void Update(RegisteredUserRecipe registeredUserRecipe, int id)
        {
            try
            {
                // Validar datos correctos
                bool validWarning = Validate(registeredUserRecipe);

                if (validWarning)
                {
                    // Que exista el id
                    bool existWord = dbContext.RegisteredUserRecipe.Any(registeredUserRecipe => registeredUserRecipe.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        registeredUserRecipe.Id = id;


                        dbContext.Update(registeredUserRecipe);
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
                RegisteredUserRecipe registeredUserRecipe = dbContext.RegisteredUserRecipe.FirstOrDefault(x => x.Id == id);

                if (registeredUserRecipe != null)
                {
                   
                    dbContext.Remove(registeredUserRecipe);
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
