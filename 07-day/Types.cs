using System.Text;

namespace Types;

public enum Comparison
{
    LessThan,
    GreaterThan,
    EqualTo
}

public class SystemDirectory
{
    public string Name { get; set; }
    public List<SystemDirectory> Directories { get; set; }
    public List<SystemFile> Files { get; set; }
    public SystemDirectory Parent { get; set; }
    public int Size { get; set; }

    public SystemDirectory(string name, SystemDirectory parent)
    {
        Name = name;
        Parent = parent;
        Directories = new List<SystemDirectory>();
        Files = new List<SystemFile>();
    }

    public int GetSize(List<SystemDirectory> list, int maxSize, Comparison comparison)
    {
        var size = 0;
        size += this.Files.Sum(file => file.Size);
        size += this.Directories.Sum(dir => dir.GetSize(list, maxSize, comparison));
        if (comparison == Comparison.LessThan && size < maxSize) list.Add(this);
        if (comparison == Comparison.GreaterThan && size >= maxSize) list.Add(this);
        this.Size = size;
        return size;
    }

    public string ToString(string indent)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{indent}- {Name} ({Size})");
        foreach (var dir in Directories) sb.Append(dir.ToString(indent + "  "));
        foreach (var file in Files) sb.AppendLine($"{indent}  - {file.Name} ({file.Size}) (owned by {Name})");
        return sb.ToString();
    }
}

public class SystemFile
{
    public string Name { get; set; }
    public int Size { get; set; }
}