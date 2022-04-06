namespace Sdk.CodeBase.SdkCore.SdkDataWriter
{
    public interface IDataReadWriteService
    {
        void WriteData(byte[] data, string dataElementName);
        byte[] ReadData(string location);
    }
}