using Microsoft.EntityFrameworkCore;
using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Satio.Classes.Core
{
    public class RecipeCore
    {
        SatioDbContext dbContext;
        public RecipeCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Recipe> GetAll()
        {
            try
            {
               

                List<Recipe> recipes = (
                    from re in dbContext.Recipe
                    select re

                    ).ToList();


                return recipes;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Recipe> GetAllFromUser(int id)
        {
            try
            {


                var recipes = (
                    from re in dbContext.Recipe
                    join usre in dbContext.RegisteredUserRecipe on re.Id equals usre.IdRecipe
                    join us in dbContext.RegisteredUser on usre.IdRegisteredUser equals us.Id
                    where us.Id == id
                    select new
                    {
                        Id = us.Id,
                        Username = us.Name,
                        RecipeName = re.Name,
                        PrepTime = re.PrepTime,
                        Rating = re.Rating,
                        Steps = re.Steps
                    }).ToList();

                /*
                 * 
                 * Ejemplo Joins
                 
                var students = (
                    from s in dbContext.Student
                    join sSchoolSubject in dbContext.StudentSchoolSubject on s.Id equals sSchoolSubject.StudentId
                    join ss in dbContext.SchoolSubject on sSchoolSubjectId equals ss.Id
                    where s.Active == true
                    select new
                    {
                        nombre = s.Name,
                        apellido = s.LasName
                        subject = ss.Name
                    }
                ).ToList();
                 
                 */

                return recipes;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(Recipe recipe)
        {
            try
            {
                bool validrecipe = Validate(recipe);

                if (validrecipe)
                {
                    dbContext.Add(recipe);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(Recipe recipe)
        {
            try
            {
                //if (string.IsNullOrEmpty(blockedWord.Word))
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

        public void Update(Recipe recipe, int id)
        {
            try
            {
                // Validar datos correctos
                bool validrecipe = Validate(recipe);

                if (validrecipe)
                {
                    // Que exista el id
                    bool existRe = dbContext.BlockedWord.Any(registeredUser => registeredUser.Id == id);

                    if (existRe)
                    {
                        // actualizar
                        recipe.Id = id;

                        ///// Otra forma por si falla////

                        //BlockedWord blockedWordDB = dbContext.BlockedWord.First(blockedWord => blockedWord.Id == id);
                        //blockedWordDB.Word = blockedWord.Word;
                        //dbContext.Update(blockedWordDB);

                        dbContext.Update(recipe);
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
                Recipe recipe = dbContext.Recipe.FirstOrDefault(x => x.Id == id);

                if (recipe != null)
                {
                    //// Baja lógica
                    //blockedWord.Active = false;
                    //dbContext.Update(blockedWord);
                    //dbContext.SaveChanges();



                    //// Procedure
                    //dbContext.DeleteBadWord();



                    ////// Baja física
                    // dbContext.Remove(registeredUser);
                    // dbContext.SaveChanges();




                    ////Si se tiene FK, borrar tambien de las tablas que influye

                    //BlockedWord blockedWord2 = dbContext.BlockedWord
                    //    .Include(x => x.TablaDependiente)
                    //    .FirstOrDefault(x => x.Id == id);

                    //dbContext.Remove(blockedWord2);
                    //dbContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
