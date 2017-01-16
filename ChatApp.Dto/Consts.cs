using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Dto
{
    public static class Consts
    {
        /// <summary>
        /// Pole dla wartości T w bazie danych
        /// </summary>
        public const string Yes = "Y";
        /// <summary>
        /// Pole dla wartości N w bazie danych
        /// </summary>
        public const string No = "N";

        /// <summary>
        /// Przekształca podany tekst, na odpowiednią wartość true/false.
        /// </summary>
        /// <param name="constsText">Tekst odpowiadający stałym Consts.Tak/Consts.Nie</param>
        /// <returns>true dla Consts.Tak, w przeciwnym wypadku fale</returns>
        public static bool FromYesNoToBoolean(this string constsText)
        {
            return constsText.Equals(Yes);
        }
    }
}
