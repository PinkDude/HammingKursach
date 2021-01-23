using System;
using System.Collections;

namespace Kursach
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHamming();
        }

        static void GetHamming()
        {
            var ham = new Hamming();
            ham.Main();
        }
    }
}
