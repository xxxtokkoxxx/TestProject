namespace Sdk.CodeBase.SdkCore.SdkDataWriter
{
    public interface IDataReaderService
    {
        void WriteData(byte[] data, string location = null);
        byte[] ReadData(string location = null);
    }
}