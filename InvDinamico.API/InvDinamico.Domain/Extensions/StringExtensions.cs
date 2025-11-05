namespace InvDinamico.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrWhiteSpace(value);

        public static string SemCaracteresEspeciais(this string s)
        {
            /* Troca os caracteres acentuados por não acentuados */
            string[] acentos = { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Ý", "É", "Ý", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ý", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };
            for (var i = 0; i < acentos.Length; i++)
            {
                s = s.Replace(acentos[i], semAcento[i]);
            }
            /* Troca os caracteres especiais da string por "" */
            string[] caracteresEspeciais = { ".", "\\.", ",", "-", "–", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };
            for (var i = 0; i < caracteresEspeciais.Length; i++)
            {
                s = s.Replace(caracteresEspeciais[i], "");
            }
            /* Troca os espaços no início por "" */
            s = s.Replace("^\\s+", "");
            /* Troca os espaços no início por "" */
            s = s.Replace("\\s+$", "");
            /* Troca os espaços duplicados, tabulações e etc por  " " */
            s = s.Replace("\\s+", " ");
            return s;
        }

        public static string Normalizar(this string s) => s.SemCaracteresEspeciais().ToLower();
    }
}
