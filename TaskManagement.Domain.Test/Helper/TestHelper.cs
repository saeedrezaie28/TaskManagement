using Newtonsoft.Json;

namespace TaskManagement.Infrastructure.Test.Helper;

public static class TestHelper
{
    public static bool CehckEqualTo(this object left, object right)
    {
        var leftJson = JsonConvert.SerializeObject(left);
        var rightJson = JsonConvert.SerializeObject(right);

        return leftJson.Equals(rightJson);
    }
}