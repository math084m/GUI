using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Class repository is made in lecture 11, to save agents to files.
//This uses the same functionality, that the smartcity can use, and is therefore reused.

namespace WPF_SmartCity_MathiasThomassen_201706287.Data
{
    class Repository
    {
        internal static bool ReadFile(string filename, out ObservableCollection<int> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<int>));
            TextReader reader = new StreamReader(filename);
            data = (ObservableCollection<int>) serializer.Deserialize(reader);
            reader.Close();
            return true;
        }

        internal static void SaveFile(string filename, ObservableCollection<int> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<int>));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer,data);
            writer.Close();
        }
    }
}
