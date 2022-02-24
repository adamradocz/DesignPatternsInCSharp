namespace DesignPatternsInCSharp.Structural.Proxy.ProtectiveProxy;

public class SharedFolder
{
    public string FolderName { get; }

    protected SharedFolder(string folderName)
    {
        if (string.IsNullOrEmpty(folderName))
        {
            throw new ArgumentException($"'{nameof(folderName)}' cannot be null or empty.", nameof(folderName));
        }

        FolderName = folderName;
    }

    public virtual void Read(Employee employee) => Console.WriteLine($"Performing Read operation on shared folder - {FolderName}");

    public virtual void Write(Employee employee) => Console.WriteLine($"Performing Write operation on shared folder - {FolderName}");

    public static SharedFolder Create(string name) => new ProtectedSharedFolder(name);
}
