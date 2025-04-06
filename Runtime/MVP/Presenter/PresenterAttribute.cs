[AttributeUsage(AttributeTargets.Class)]
public class PresenterAttribute : Attribute
{
    public PresenterType Type { get; }

    public PresenterAttribute(PresenterType type)
    {
        Type = type;
    }
}
