namespace DesignPatternsInCSharp.Structural.Proxy.SmartProxy;

public class FileSmartProxy
{
    readonly Dictionary<string, FileStream> _openStreams = new();

    public FileStream OpenWrite(string path)
    {
        try
        {
            var stream = File.OpenWrite(path);
            _openStreams.Add(path, stream);
            return stream;
        }
        catch (IOException)
        {
            if (_openStreams.ContainsKey(path))
            {
                var stream = _openStreams[path];

                if (stream != null && stream.CanWrite)
                {
                    return stream;
                }
            }

            throw;
        }
    }
}
