using Microsoft.EntityFrameworkCore;
using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class ContactInfoCore
    {
        SatioDbContext dbContext;
        public ContactInfoCore(SatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ContactInfo> GetAll()
        {
            try
            {

                List<ContactInfo> contactInfos = (
                    from ci in dbContext.ContactInfo
                    select ci

                    ).ToList();


                return contactInfos;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Create(ContactInfo contactInfo)
        {
            try
            {

                dbContext.Add(contactInfo);
                dbContext.
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(ContactInfo contactInfo)
        {
            try
            {
                //if (string.IsNullOrEmpty(contactInfo.Word))
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

        public void Update(ContactInfo contactInfo, int id)
        {
            try
            {
                // Validar datos correctos
                bool validContactInfo = Validate(contactInfo);

                if (validContactInfo)
                {
                    // Que exista el id
                    bool existWord = dbContext.ContactInfo.Any(contactInfo => contactInfo.Id == id);

                    if (existWord)
                    {
                        // actualizar
                        contactInfo.Id = id;

                        ///// Otra forma por si falla////

                        //BlockedWord blockedWordDB = dbContext.BlockedWord.First(blockedWord => blockedWord.Id == id);
                        //blockedWordDB.Word = blockedWord.Word;
                        //dbContext.Update(blockedWordDB);

                        dbContext.Update(contactInfo);
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
                ContactInfo contactInfo = dbContext.ContactInfo.FirstOrDefault(x => x.Id == id);

                if (contactInfo != null)
                {
                    //// Baja lógica
                    //blockedWord.Active = false;
                    //dbContext.Update(blockedWord);
                    //dbContext.SaveChanges();



                    //// Procedure
                    //dbContext.DeleteBadWord();



                    ////// Baja física
                    dbContext.Remove(contactInfo);
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
