using Microsoft.EntityFrameworkCore;
using Satio.Models;
using Satio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class WarnignCore
    {
        SatioDbContext dbContext;
        public WarnignCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Warning> GetAll()
        {
            try
            {
              
                List<Warning> warnings = (
                    from w in dbContext.Warning
                    select w

                    ).ToList();

                return warnings;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(Warning warning)
        {
            try
            {
                bool validWarning = Validate(warning);

                if (validWarning)
                {
                    dbContext.Add(warning);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(Warning warning)
        {
            try
            {
                if (string.IsNullOrEmpty(warning.Description))
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

        public void Update(Warning warning, int id)
        {
            try
            {
                // Validar datos correctos
                bool validWarning = Validate(warning);

                if (validWarning)
                {
                    // Que exista el id
                    bool existWord = dbContext.Warning.Any(warning => warning.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        warning.Id = id;

                        ///// Otra forma por si falla////

                        //BlockedWord blockedWordDB = dbContext.BlockedWord.First(blockedWord => blockedWord.Id == id);
                        //blockedWordDB.Word = blockedWord.Word;
                        //dbContext.Update(blockedWordDB);

                        dbContext.Update(warning);
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
                Warning warning = dbContext.Warning.FirstOrDefault(x => x.Id == id);

                if (warning != null)
                {
                    //// Baja lógica
                    //blockedWord.Active = false;
                    //dbContext.Update(blockedWord);
                    //dbContext.SaveChanges();



                    //// Procedure
                    //dbContext.DeleteBadWord();



                    ////// Baja física
                    dbContext.Remove(warning);
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
