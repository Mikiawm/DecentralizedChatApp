using ChatApp.Dal.DBModel;
using ChatApp.Dto.DTO;
using ConsoleApp.Dal.DTOAssemblers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
                using (var ctx = new ChatDataModel())
                {
                    var encja = user.ToEntity();
                    ctx.UserSet.Add(encja);
                    ctx.SaveChanges();
                    user.Id = encja.Id;
                }
            }
            catch (Exception exception)
            {
                throw exception;

            }

            return result;
        }
        public bool CheckLoginExists(string login)
        {
            using (var ctx = new ChatDataModel())
            {
                return ctx.UserSet.Any(r => r.Login == login);
            }
        }
    }
}
