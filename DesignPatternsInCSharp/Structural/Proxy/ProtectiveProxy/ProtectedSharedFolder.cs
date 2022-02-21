namespace DesignPatternsInCSharp.Structural.Proxy.ProtectiveProxy;

public class ProtectedSharedFolder : SharedFolder
{
    public ProtectedSharedFolder(string sharedFolder) : base(sharedFolder)
    {
    }

    public override void Write(Employee employee)
    {
        if (employee.Role == "admin")
        {
            Console.WriteLine($"Access granted - Folder: {FolderName}, User/Role: {employee.Username}/{employee.Role}");
            base.Write(employee);
            return;
        }

        throw new UnauthorizedAccessException($"You don't have permission to write to this folder - Folder: {FolderName}, User/Role: {employee.Username}/{employee.Role}");      
    }
}
