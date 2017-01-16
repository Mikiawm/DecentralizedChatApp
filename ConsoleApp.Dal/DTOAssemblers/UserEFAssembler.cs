using ChatApp.Dto.DTO;
using ConsoleApp.Dal.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Dal.DTOAssemblers
{
    public static partial class UserEFAssembler
    {
        static partial void OnEntity(this User dto, UserEF entity);
        static partial void OnDTO(this UserEF entity, User dto);
        public static UserEF ToEntity(this User dto)
        {
            if (dto == null) return null;

            var entity = new UserEF();

            entity.Id = dto.Id;
            entity.Email = dto.Email;
            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.Login = dto.Login;


            dto.OnEntity(entity);

            return entity;
        }
        public static User ToDTO(this UserEF entity)
        {
            if (entity == null) return null;

            var dto = new User();

            dto.Id = entity.Id;
            dto.Email = entity.Email;
            dto.Name = entity.Name;
            dto.LastName = entity.LastName;
            dto.Login = entity.Login;
            dto.Active = entity.Active;
            entity.OnDTO(dto);
            return dto;
        }
        public static List<UserEF> ToEntities(this IEnumerable<User> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="UzytkownikEF"/> to an instance of <see cref="Uzytkownik"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<User> ToDTOs(this IEnumerable<UserEF> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
