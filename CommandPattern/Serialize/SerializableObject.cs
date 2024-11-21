using CommandPattern.Commands.BaseEntities;
using Newtonsoft.Json;

namespace CommandPattern.Serialize;

public static class SerializableObject
{
    public static string SerializeCommand<TValue>(TValue json)
    {
        return JsonConvert.SerializeObject(json);
    }

    public static ICommandBase DeserializeCommand(string json, Type commandType)
    {
        return (ICommandBase)JsonConvert.DeserializeObject(json, commandType)!;
    }
}