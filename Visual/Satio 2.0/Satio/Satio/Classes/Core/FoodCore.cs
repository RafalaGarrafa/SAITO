using Microsoft.EntityFrameworkCore;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Satio.Classes.Core
{
    public class FoodCore
    {
        SatioDbContext dbContext;
        public FoodCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Food> GetAll()
        {
            try
            {
                // LinQ
                //Funciones

                //Lenguaje
                //List<Student> students = from s in dbContext.Student select s).ToList();

                List<Food> foods = (
                    from f in dbContext.Food
                    select f

                    ).ToList();

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

                return foods;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(Food food)
        {
            try
            {
                bool validFood = Validate(food);

                if (validFood)
                {
                    dbContext.Add(food);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(Food food)
        {
            try
            {
                if (string.IsNullOrEmpty(food.Name))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Food food, int id)
        {
            try
            {
                // Validar datos correctos
                bool validFood = Validate(food);

                if (validFood)
                {
                    // Que exista el id
                    bool existWord = dbContext.Food.Any(food => food.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        food.Id = id;

                        ///// Otra forma por si falla////

                        //BlockedWord blockedWordDB = dbContext.BlockedWord.First(blockedWord => blockedWord.Id == id);
                        //blockedWordDB.Word = blockedWord.Word;
                        //dbContext.Update(blockedWordDB);

                        dbContext.Update(food);
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
                Food food = dbContext.Food.FirstOrDefault(x => x.Id == id);

                if (food != null)
                {
                    //// Baja lógica
                    //blockedWord.Active = false;
                    //dbContext.Update(blockedWord);
                    //dbContext.SaveChanges();



                    //// Procedure
                    //dbContext.DeleteBadWord();



                    ////// Baja física
                    dbContext.Remove(food);
                    dbContext.SaveChanges();




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
