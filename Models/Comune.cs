using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace conti.maurizio._4H.SaveRecord.Models
{
    public class Comune
    {
        public int ID {get;set;}
        public string NomeComune {get;set;}
        public string Ct {get;set;}

        public Comune(){}
        public Comune(string riga, int ID)
        {
            string[] colonne = riga.Split(',');
            if( colonne.Length == 2 ){
                this.ID = ID;
                Ct = colonne[0];
                NomeComune = colonne[1];
            }
            else
                throw new System.Exception("La riga non è conforme...");
        }
    }

    public class Comuni : List<Comune>
    {
        string FileName {get;}

        public Comuni(){}
        public Comuni( string fileName )
        {
            this.FileName = fileName;
            StreamReader readerComuni = new StreamReader(FileName);

            string riga;
            int i = 1;
            while ((riga = readerComuni.ReadLine()) != null)
                Add(new Comune(riga, i++));
        }

        public int Save()
        {
            int retVal=0;
            string fileName = FileName.Split(".")[0] + ".bin";

            FileStream stream = new FileStream( fileName, FileMode.Create);

            // Attenzione... codice non sicuro...
            // foreach (Comune comune in this) {
            //     var formatter = new BinaryFormatter();
            //     formatter.Serialize(stream, comune);
            // }

            BinaryWriter writer = new BinaryWriter(stream);
            foreach (Comune comune in this) {
                writer.Write(comune.ID);
                writer.Write(comune.NomeComune); 
                writer.Write(comune.Ct); 
                retVal++;
            }
            writer.Flush();
            writer.Close();

            return retVal;
        }

        public int Load( string fileName )
        {
            int retVal = 0;
            FileStream stream = new FileStream( fileName, FileMode.Open );
            BinaryReader reader = new BinaryReader(stream);
            
            while ( stream.Position != stream.Length ){  // il modo più sicuro di accorgersi della fine del file...
                Comune c = new Comune();
                c.ID = reader.ReadInt32();
                c.NomeComune = reader.ReadString();
                c.Ct = reader.ReadString();
                retVal++;
            }

            reader.Close();
            return retVal;
        }
    }
}