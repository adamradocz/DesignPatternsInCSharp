namespace DesignPatternsInCSharp.Structural.Proxy.SmartProxy;

public class DefaultFile : IFile
{
    public FileStream OpenWrite(string path) => File.OpenWrite(path);
}
