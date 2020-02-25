using System;
using System.Diagnostics;


namespace GraProceduralnie
{
    class Program
    {
        const string zaduzo = "Za Dużo";
        const string zamalo = "Za Mało";
        const string trafiono = "Trafiono";


        static void Main(string[] args)
        {
            Console.WriteLine("Gra za dużo za mało");
            int a = WczytajLiczbe("Podaj dolny zakres losowania");
            int b = WczytajLiczbe("Podaj górny zakres losowania");
            int wylosowana = Losuj(a,b);

#if DEBUG
            Console.WriteLine(wylosowana);

#endif
            int licznik = 0;
            var stoper = new Stopwatch();
            stoper.Start(); 
            while(true)
            {
                // 2. Człowiek proponuje

                licznik++; // licznik = licznik + 1;
                int propozycja = WczytajLiczbe("Podaj swoją propozycję lub x aby zakończyć:");
                string wynik = (Ocena(wylosowana, propozycja));
                Console.WriteLine(wynik);
                if (wynik == trafiono)
                    break;

               
            }
            stoper.Stop();
            Console.WriteLine($"liczba ruchów = {licznik}");
            Console.WriteLine($"Czas gry = {stoper.Elapsed}");
            Console.WriteLine("Koniec gry");

        }

        /// <summary>
        /// Losuje liczbę z podanego zakresu włącznie
        /// </summary>
        /// <param name="min">dolne ograniczenie</param>
        /// <param name="max">górne ograniczenie</param>
        /// <returns></returns>
        static int Losuj(int min = 1, int max = 100)
        {
            var min1 = Math.Min(min, max);
            var max1 = Math.Max(min, max); 

            var rnd = new Random();
            var los = rnd.Next(min1, max1 + 1);

            return los; 
        }

        static int WczytajLiczbe(string prompt = "")
        {
            bool poprawnie = false;
            int wynik = 0;
            do
            {
                Console.Write(prompt);
                string wczytano = Console.ReadLine();
                if (wczytano == "X" || wczytano == "x")
                    Environment.Exit(0);



                try
                {
                    wynik = int.Parse(wczytano);
                    poprawnie = true;
                }
                catch (FormatException)
                {

                    Console.WriteLine("niepoprawny zapis liczby. Spróbuj jeszcze raz");
                }
                catch (OverflowException)
                {

                    Console.WriteLine("Przekroczony zakres");
                }
                catch (Exception)
                {
                    Console.WriteLine("nieznany błąd");
                }

            }
            while(!poprawnie);

       
            return wynik; 

        }

        static string Ocena(int wylosowana, int propozycja)
        {
            if (wylosowana < propozycja)
            {
                return zaduzo;
            }
            else if (wylosowana > propozycja)
            {
                return zamalo;
            }
            else
            {
                return trafiono;
            }
        }
    }
}
