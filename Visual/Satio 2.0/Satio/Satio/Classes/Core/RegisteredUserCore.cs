using Microsoft.EntityFrameworkCore;
using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class RegisteredUserCore
    {
        SatioDbContext dbContext;
        public RegisteredUserCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RegisteredUser> GetAll()
        {
            try
            {
                // LinQ
                //Funciones

                //Lenguaje
                //List<Student> students = from s in dbContext.Student select s).ToList();

                List<RegisteredUser> registeredUsers = (
                    from ru in dbContext.RegisteredUser
                    select ru

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

                return registeredUsers;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(RegisteredUser registeredUser)
        {
            try
            {
                bool validregisteredUser = Validate(registeredUser);

                if (validregisteredUser)
                {
                    dbContext.Add(registeredUser);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(RegisteredUser registeredUser)
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

        public void Update(RegisteredUser registeredUser, int id)
        {
            try
            {
                // Validar datos correctos
                bool validregisteredUser = Validate(registeredUser);

                if (validregisteredUser)
                {
                    // Que exista el id
                    bool existRu = dbContext.BlockedWord.Any(registeredUser => registeredUser.Id == id);

                    if (existRu)
                    {
                        // actualizar
                        registeredUser.Id = id;

                        ///// Otra forma por si falla////

                        //BlockedWord blockedWordDB = dbContext.BlockedWord.First(blockedWord => blockedWord.Id == id);
                        //blockedWordDB.Word = blockedWord.Word;
                        //dbContext.Update(blockedWordDB);

                        dbContext.Update(registeredUser);
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
                RegisteredUser registeredUser = dbContext.RegisteredUser.FirstOrDefault(x => x.Id == id);

                if (registeredUser != null)
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
