using System.IO;
using UnityEngine;

namespace Sdk.CodeBase.SdkCore.SdkDataWriter
{
    public class DataReadWriteService : IDataReadWriteService
    {
        public void WriteData(byte[] data, string dataElementName)
        {
            var path = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
            
            File.WriteAllBytes(path + dataElementName, data);
        }

        public byte[] ReadData(string location)
        {
            var path = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
            var data = File.ReadAllBytes(path);

            return data;
        }
    }
}