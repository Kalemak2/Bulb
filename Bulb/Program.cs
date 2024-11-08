using System;

namespace lampka
{
    public class Zarowka
    {
        public bool Swieci { get; set; }
        public bool Spalona { get; set; }

        public Zarowka(bool swieci, bool spalona)
        {
            Swieci = swieci;
            Spalona = spalona;
        }

        public void Zapal()
        {
            if (!Spalona)
            {
                Swieci = true;
            }
        }

        public void Zgas()
        {
            Swieci = false;
        }

        public bool CzySwieci()
        {
            return Swieci;
        }

        public bool CzySpalona()
        {
            return Spalona;
        }
    }

    public class Lampka
    {
        public bool Wlaczona { get; private set; }
        public int Intensywnosc { get; private set; }
        public Zarowka Zarowka { get; private set; }

        public Lampka(bool wlaczona, int intensywnosc, Zarowka zarowka)
        {
            Wlaczona = wlaczona;
            Intensywnosc = intensywnosc;
            Zarowka = zarowka;
        }

        public void Wlacz()
        {
            if (!Zarowka.Spalona)
            {
                Wlaczona = true;
                Zarowka.Zapal();
                Intensywnosc = 1;
            }
        }

        public void Wylacz()
        {
            Wlaczona = false;
            Zarowka.Zgas();
        }

        public void Rozjasnij()
        {
            if (Wlaczona && !Zarowka.Spalona)
            {
                if (Intensywnosc < 10)
                {
                    Intensywnosc++;
                }
                else
                {
                    Zarowka.Spalona = true;
                    Zarowka.Zgas();
                }
            }
        }

        public void Sciemnij()
        {
            if (Wlaczona && !Zarowka.Spalona)
            {
                if (Intensywnosc > 0)
                {
                    Intensywnosc--;
                }
                if (Intensywnosc == 0)
                {
                    Wylacz();
                }
            }
        }

        public bool WymienZarowke()
        {
            if (!Wlaczona)
            {
                Zarowka = new Zarowka(false, false);
                return true;
            }
            return false;
        }

        public bool CzyWlaczona()
        {
            return Wlaczona;
        }

        public bool CzySwieci()
        {
            return Zarowka.CzySwieci();
        }

        public bool CzyZarowkaSpalona()
        {
            return Zarowka.CzySpalona();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Zarowka zarowka = new Zarowka(false, false);
            Lampka lampka = new Lampka(true, 5, zarowka);

            do
            {
                Console.WriteLine("Wybierz opcje: ");
                Console.WriteLine("1. Wylacz lampke \n2. Wlacz lampke \n3. Rozjasnij zarowke \n4. Sciemnij zarowke \n5. Wymien zarowke");

                Console.Write("\n\nWybierz opcje:");
                string wybor = Console.ReadLine();

                switch (wybor)
                {
                    case "1":
                        lampka.Wylacz();
                        break;
                    case "2":
                        lampka.Wlacz();
                        break;
                    case "3":
                        lampka.Rozjasnij();
                        break;
                    case "4":
                        lampka.Sciemnij();
                        break;
                    case "5":
                        if (lampka.WymienZarowke())
                        {
                            Console.WriteLine("Żarówka wymieniona.");
                        }
                        else
                        {
                            Console.WriteLine("Nie można wymienić żarówki, lampka jest włączona.");
                        }
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }

                Console.WriteLine($"Lampka włączona: {lampka.CzyWlaczona()}");
                Console.WriteLine($"Lampka świeci: {lampka.CzySwieci()}");
                Console.WriteLine($"Żarówka spalona: {lampka.CzyZarowkaSpalona()}");
                Console.WriteLine($"Intensywność: {lampka.Intensywnosc}");

                Console.WriteLine("\n\n");

            } while (true);
        }
    }
}