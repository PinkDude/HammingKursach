using System;
using System.Collections.Generic;
using System.Text;

namespace Kursach
{
    static class WordHelper
    {
        /// <summary>
        /// Получение p для слова
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="indexes">Индексы для нахождения p</param>
        /// <returns></returns>
        public static string GetP(string word, int[] indexes)
        {
            if (indexes.Length != 3)
                Console.WriteLine("Не допустимое количество индексов");

            var d1 = Convert.ToInt32(word[indexes[0]]);
            var d2 = Convert.ToInt32(word[indexes[1]]);
            var d3 = Convert.ToInt32(word[indexes[2]]);

            var p = (d1 + d2 + d3) % 2;

            return p.ToString();
        }
    }
}
