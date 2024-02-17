using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Contract.CommonServices
{
    public static class CommonServices
    {
        public static string RemoveWhithSapases(this string phrase)
        {
            phrase = phrase.Trim();
            return phrase;
        }
        public static int CalAge(DateTime birthDate)
        {
            var age =(DateTime.Now-birthDate).Days;
            return (age/365);
        }
    }
}
