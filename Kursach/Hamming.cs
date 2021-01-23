using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kursach
{
    public class Hamming
    {
        const string data = "1011";

        public void Main()
        {
            WriteBaseWord();
            var result = CodingWord(data);
            WriteWord(result);

            var newWord = Console.ReadLine();
            var codingNewWord = CodingWord(newWord);
            WriteWord(codingNewWord);

            EqualWords(result, codingNewWord);

            var codingWord = Console.ReadLine();
            var decodedWord = DecodeWord(codingWord);
            WriteWord(decodedWord);
        }

        /// <summary>
        /// Декодирование слова
        /// </summary>
        /// <param name="codingWord">Закоированое слово</param>
        /// <returns></returns>
        private string DecodeWord(string codingWord)
        {
            var decodingWord = codingWord[2].ToString() + 
                codingWord[4].ToString() + 
                codingWord[5].ToString() + 
                codingWord[6].ToString();

            return decodingWord.ToString();
        }

        /// <summary>
        /// Сравнение закодированных слов
        /// </summary>
        /// <param name="firstCodingWord">Первое закодированое слово</param>
        /// <param name="secondCodingWord">Второе закодированое слово</param>
        private void EqualWords(string firstCodingWord, string secondCodingWord)
        {
            var psFirst = GetPsFromCodingWord(firstCodingWord);
            var psSecond = GetPsFromCodingWord(secondCodingWord);

            string result = String.Empty;

            if (psFirst[0] != psSecond[0])
            {
                if (psFirst[1] != psSecond[1])
                {
                    if (psFirst[2] != psSecond[2])
                    {
                        result = "d4";
                    }
                    else
                    {
                        result = "d1";
                    }
                }
                else
                {
                    if (psFirst[2] != psSecond[2])
                    {
                        result = "d2";
                    }
                }
            }
            else
            {
                if (psFirst[1] != psSecond[1] && psFirst[2] != psSecond[2])
                {
                    result = "d3";
                }
            }

            if(result == String.Empty)
            {
                result = "Ошибок нет!";
            }

            Console.WriteLine("Ошибка: " + result);
        }

        private string[] GetPsFromCodingWord(string codingWord)
        {
            return new string[] {
                codingWord[0].ToString(),
                codingWord[1].ToString(),
                codingWord[3].ToString() };
        }

        /// <summary>
        /// Закодирование слова
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string CodingWord(string word)
        {
            var ps = GetPs(word);

            var result = ps[0] + ps[1] + word[0] + ps[2] + word[1] + word[2] + word[3];

            return result;
        }

        /// <summary>
        /// Получение ps для слова
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns> Упорядоченный массив p</returns>
        private string[] GetPs(string word)
        {
            var p1 = WordHelper.GetP(word, new int[] { 0, 1, 3 });
            var p2 = WordHelper.GetP(word, new int[] { 0, 2, 3 });
            var p3 = WordHelper.GetP(word, new int[] { 1, 2, 3 });

            return new string[] { p1, p2, p3 };
        }

        private void WriteWord(string word)
        {
            Console.WriteLine("Слово: " + word);
        }

        private void WriteBaseWord()
        {
            Console.Write("Исходное слово: ");
            Console.WriteLine(data);
        }
    }
}
