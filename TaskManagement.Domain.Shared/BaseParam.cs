using System.Data;
using TaskManagement.Domain.Shared.Attributes;

namespace TaskManagement.Infrasturcture.Dapper.Generic;

public class BaseParam
{
}

public class BaseParam_Output : BaseParam
{
    [OutParameter(dbType: DbType.Int32)]
    public int OutCount { get; set; }
}
