namespace DesignPatternsInCSharp.Structural.Proxy.SmartProxy;

public interface IFile
{
    FileStream OpenWrite(string path);
}
