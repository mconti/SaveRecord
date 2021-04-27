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
            Console.WriteLine("Save record - maurizio.conti@ittsrimini.edu.it - 2021");
            Comuni comuni = new Comuni( "Comuni.csv" );

            try {   

                int numRecord = comuni.Save();
                Console.WriteLine($"Ho scritto {numRecord} comuni...");

                Comuni comuni2 = new Comuni();
                numRecord = comuni2.Load( "Comuni.bin" );
                Console.WriteLine($"Ho letto {numRecord} comuni...");
            } 
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}