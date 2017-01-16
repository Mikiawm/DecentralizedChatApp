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
        public static UserEF ToEntity(this User dto)
        {
            if (dto == null) return null;

            var entity = new UserEF();

            entity.Id = dto.Id;
            entity.Email = dto.Email;
            entity.Name = dto.Imie;
            entity.LastName = dto.Nazwisko;
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
            dto.Imie = entity.Imie;
            dto.Nazwisko = entity.Nazwisko;
            dto.Login = entity.Login;
            dto.Aktywny = entity.Aktywny;
        }
        public static List<UzytkownikEF> ToEntities(this IEnumerable<Uzytkownik> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="UzytkownikEF"/> to an instance of <see cref="Uzytkownik"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<Uzytkownik> ToDTOs(this IEnumerable<UzytkownikEF> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
