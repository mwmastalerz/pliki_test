using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace pliki_projekt
{
    internal class Program
    {


        static string ZapiszPlik(string NazwaPliku)
        {

            string tekstDoZapisu = "ZAPISANO";
            FileStream cel = new FileStream(NazwaPliku, FileMode.Create, FileAccess.Write);
            if (cel.CanWrite)
            {

                byte[] bufor = Encoding.ASCII.GetBytes(tekstDoZapisu);
                cel.Write(bufor, 0, bufor.Length);

            }
            cel.Flush();
            cel.Close();
            return tekstDoZapisu;
        }

        static void OdczytajPlik(string NazwaPliku)
        {
            FileStream zrodlo = new FileStream(NazwaPliku, FileMode.Open, FileAccess.Read, FileShare.Read);
            //int odczytanyTekst = zrodlo.ReadByte();
            //Console.WriteLine("x={0}, y={1}", x, y);

            byte[] bufor = new byte[1024];
            int odczytanyTekst = zrodlo.Read(bufor, 0, bufor.Length);

            Console.WriteLine("Odczytany tekst bez konwersji: {0}", odczytanyTekst);
            Console.WriteLine("Odczytany tekst po konwersji: {0}", Encoding.ASCII.GetString(bufor, 0, bufor.Length));
            Console.ReadKey();

        }


        static void Main(string[] args)
        {

            string NazwaPliku = @"D:\test_plik.txt";

            try
            {


                string x = ZapiszPlik(NazwaPliku);
                Console.WriteLine("Zapisono tekst: {0}", x);
                Console.ReadKey();
                OdczytajPlik(NazwaPliku);

            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Wykonano zadanie.");
            }



        }
    }
}