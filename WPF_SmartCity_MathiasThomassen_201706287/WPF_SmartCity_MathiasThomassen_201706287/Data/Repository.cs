using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPF_SmartCity_MathiasThomassen_201706287.Models;

//Class repository is made in lecture 11, to save agents to files.
//This uses the same functionality, that the smartcity can use, and is therefore reused.

namespace WPF_SmartCity_MathiasThomassen_201706287.Data
{
    class Repository
    {
        internal static void ReadFile(string filename, out ObservableCollection<Location> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextReader reader = new StreamReader(filename);
            data = (ObservableCollection<Location>) serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveFile(string filename, ObservableCollection<Location> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer,data);
            writer.Close();
        }
    }
}
