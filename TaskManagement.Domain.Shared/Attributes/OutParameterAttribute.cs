using System.Data;

namespace TaskManagement.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class OutParameterAttribute : Attribute
{
    public string ParameterName { get; }
    public DbType DbType { get; }
    public int Size { get; }

    public OutParameterAttribute(
        string parameterName = null,
        int size = 0,
        DbType dbType = default)
    {
        ParameterName = parameterName;
        Size = size;
        DbType = dbType;
    }
}
