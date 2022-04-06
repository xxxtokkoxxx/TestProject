using System;
using System.IO;
using UnityEngine;

namespace Sdk.CodeBase.SdkCore.SdkDataWriter
{
    public class DataReaderService : IDataReaderService
    {
        public void WriteData(byte[] data, string location = null)
        {
            var defaultPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
            var saveLocation = location ?? defaultPath;
            
            File.WriteAllBytes(saveLocation, data);
        }

        public byte[] ReadData(string location = null)
        {
            var defaultPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
            var saveLocation = location ?? defaultPath;
            
            var data = File.ReadAllBytes(saveLocation);

            return data;
        }
    }
}