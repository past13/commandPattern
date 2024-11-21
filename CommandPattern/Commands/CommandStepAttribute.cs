namespace CommandPattern.Commands;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CommandStepAttribute : Attribute
{
    public Type EnumType { get; }
    public int StepValue { get; }

    public CommandStepAttribute(Type enumType, int stepValue)
    {
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("EnumType must be an enum type.");
        }

        EnumType = enumType;
        StepValue = stepValue;
    }
}