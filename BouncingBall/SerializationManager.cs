using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Engine
{
    class SerializationManager<T> where T : class 
    {
        public bool Serialize(T obj, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));

            try
            {

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(stream, obj);
                }

            }
            catch (IOException e)
            {

                using (StreamWriter stream = new StreamWriter(System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "SerializationLog.txt"))
                {
                    stream.WriteLine(DateTime.Now.ToString() + ": " + e.Message);
                }
                return false;
            }
            return true;
        }

        public T Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T obj;
            try
            {

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    obj = (T)(serializer.Deserialize(stream));
                }

            }
            catch (IOException e)
            {

                using (StreamWriter stream = new StreamWriter(System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "SerializationLog.txt"))
                {
                    stream.WriteLine(DateTime.Now.ToString() + ": " + e.Message);
                    obj = null;
                }
            }
            return obj;
        }
    }
}
