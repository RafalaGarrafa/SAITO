using Satio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satio.Classes.Core
{
    public class BlockedWordCore
    {
        SatioDbContext dbContext;
        public BlockedWordCore(SatioDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public List<BlockedWord> GetAll()
        {
            try
            {
                // LinQ
                //Funciones

                //Lenguaje
                //List<Student> students = from s in dbContext.Student select s).ToList();

                List<BlockedWord> blockedWords = (
                    from bw in dbContext.BlockedWord
                    select bw

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

                return blockedWords;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public void Create (BlockedWord blockedWord)
        {
            try
            {
                bool validBlockedWord = Validate(blockedWord);

                if (validBlockedWord)
                {
                    dbContext.Add(blockedWord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Validate(BlockedWord blockedWord)
        {
            try
            {
                if(string.IsNullOrEmpty(blockedWord.Word))
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
    }
}
