using ChatApp.Dto.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp.Dal.DataManagers
{
    class UserDataManager
    {
        public bool Add(User user)
        {
            bool result = true;

            if (user == null)
            {
                result = false;
            }

            try
            {
                using (var ctx = new SimikEntities())
                {
                    var encja = user.ToEntity();
                    ctx.UzytkownikSet.Add(encja);
                    ctx.SaveChanges();
                    user.Id = encja.Id;
                }
            }
            catch (Exception exception)
            {
                logger.LogException(LoggingLevel.Error, exception);
                result = false;

                throw exception;

            }

            return result;
        }
    }
}
