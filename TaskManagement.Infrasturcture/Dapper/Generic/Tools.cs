using Dapper;
using System.Data;
using System.Reflection;
using TaskManagement.Domain.Shared.Attributes;
namespace TaskManagement.Infrasturcture.Dapper.Generic
{
    public static class Tools
    {
        public static DynamicParameters ToParams(this object param)
        {
            var parameters = new DynamicParameters();

            var type = param.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                var attribute = prop.GetCustomAttribute<OutParameterAttribute>();
                if (attribute != null)
                {
                    parameters.Add(
                        name: "@" + (attribute.ParameterName ?? prop.Name),
                        dbType: attribute.DbType,
                        size: attribute.Size,
                        direction: ParameterDirection.Output
                    );
                }
                else
                {
                    parameters.Add(
                        name: "@" + prop.Name,
                        value: prop.GetValue(param),
                        dbType: GetDbType(prop.PropertyType)
                    );
                }
            }

            return parameters;
        }


        private static readonly Dictionary<Type, DbType> typeMap = new()
        {
            { typeof(byte), DbType.Byte },
            { typeof(sbyte), DbType.SByte },
            { typeof(short), DbType.Int16 },
            { typeof(ushort), DbType.UInt16 },
            { typeof(int), DbType.Int32 },
            { typeof(uint), DbType.UInt32 },
            { typeof(long), DbType.Int64 },
            { typeof(ulong), DbType.UInt64 },
            { typeof(float), DbType.Single },
            { typeof(double), DbType.Double },
            { typeof(decimal), DbType.Decimal },
            { typeof(bool), DbType.Boolean },
            { typeof(string), DbType.String },
            { typeof(char), DbType.StringFixedLength },
            { typeof(Guid), DbType.Guid },
            { typeof(DateTime), DbType.DateTime },
            { typeof(DateTimeOffset), DbType.DateTimeOffset },
            { typeof(byte[]), DbType.Binary },
            { typeof(object), DbType.Object }
        };
        public static DbType GetDbType(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            if (typeMap.TryGetValue(underlyingType, out var dbType))
                return dbType;

            throw new ArgumentException($"Unsupported type: {type.FullName}");
        }
    }
}
