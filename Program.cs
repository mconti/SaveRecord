using System;
using System.Collections.Generic;
using System.IO;
using conti.maurizio._4H.SaveRecord.Models;

namespace conti.maurizio._4H.SaveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMERO_DEL_RECORD_DA_RILEGGERE_DAL_FILE_COME_VERIFICA = 5;

            Console.WriteLine("Save record - maurizio.conti@ittsrimini.edu.it - 2021\n");
            Comuni comuni = new Comuni( "Comuni.csv" );

            Console.WriteLine($"Ho letto {comuni.Count} righe dal file .csv.");
            Console.WriteLine( $"Ecco la riga {NUMERO_DEL_RECORD_DA_RILEGGERE_DAL_FILE_COME_VERIFICA}: {comuni[NUMERO_DEL_RECORD_DA_RILEGGERE_DAL_FILE_COME_VERIFICA].ToString()}" );

            try {   

                int numRecord = comuni.Save();
                Console.WriteLine($"Ho scritto {numRecord} comuni sul file .bin");

                Comuni comuni2 = new Comuni();
                numRecord = comuni2.Load( "Comuni.bin" );
                Console.WriteLine($"Ho letto {numRecord} comuni dal file .bin.");

                Console.WriteLine( $"Ecco la riga {NUMERO_DEL_RECORD_DA_RILEGGERE_DAL_FILE_COME_VERIFICA}: {comuni[NUMERO_DEL_RECORD_DA_RILEGGERE_DAL_FILE_COME_VERIFICA].ToString()}" );

            } 
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}