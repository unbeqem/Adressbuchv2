using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBuchv2
{
    internal class ReadAdressbuch
    {

        public static List<Personen> ReadCsv(string filepath)
        {
            List<Personen> data = new List<Personen>();
            using var reader = new StreamReader(filepath);
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length == 4)
                {
                    data.Add(new Personen(values[0], values[1], values[2], values[3]));
                }
            }

            return data;
        }
    }
}
