namespace UploadUI.Services
{
    public interface ICsvMemoryStream<T>
    {
        byte[] GetCsv(T value);
    }
}
