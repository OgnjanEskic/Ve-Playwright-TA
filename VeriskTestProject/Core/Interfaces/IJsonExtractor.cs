namespace VeriskTestProject.Core.Interfaces
{
    /// <summary>
    /// A Class responsible for reading and extracting values from Appsettings config based on the given key.
    /// </summary>
    public interface IJsonExtractor
    {
        string GetSingleJsonValue(string key);
    }
}
