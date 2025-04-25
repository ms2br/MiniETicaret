using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Helpers.File
{
    public class NameOperation
    {
        public static string CharacterRegulatory(string name)
        {
            string normalized = name.Normalize(NormalizationForm.FormD);
            return Regex.Replace(normalized, @"[^a-zA-Z\s]", "")
                .Replace("-", "")
                .Replace('ı', 'i')
                .Replace('İ', 'I')
                .Replace('Ə', 'E')
                .Replace('ə', 'e');
        }
    }
}
