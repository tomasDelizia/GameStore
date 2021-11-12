using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameStore.Utils
{
    public static class Utils
    {
        public static bool TieneSoloValoresAlfabeticos(String palabra)
        {
            // Defino expresión regular que contemple solo caracteres alfabéticos.
            //Regex regex = new Regex("^[a-zA-Z]+$");
            Regex regex = new Regex("^[-'a-zA-ZÀ-ÖØ-öø-ÿ]+$");
            return regex.IsMatch(palabra);
        }
    }
}
