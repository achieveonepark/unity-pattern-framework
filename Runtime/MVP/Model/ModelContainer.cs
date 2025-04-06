public static class AttributeInstanceCache
{
    private static readonly Dictionary<Type, object> _instanceCache = new();
    private static readonly HashSet<Type> _targetTypes = new();
    private static bool _initialized = false;

    public static void Initialize()
    {
        if (_initialized) return;

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => t.GetCustomAttribute<ModelAttribute>() != null);

            foreach (var type in types)
            {
                if (!type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null)
                {
                    _targetTypes.Add(type);
                }
            }

            _initialized = true;   
    }

    public static T Get<T>() where T : class, new()
    {
        Initialize();

        var type = typeof(T);

        if (_targetTypes.Contains(type) is false)
        {
            throw new InvalidOperationException($"{type.Name} doesn't have [MyAttribute]");
        }

        if (_instanceCache.TryGetValue(type, out var cached))
        {
            return (T)cached;
        }

        lock (_lock)
        {
            // 더블 체크
            if (_instanceCache.TryGetValue(type, out cached))
                return (T)cached;

            var instance = new T();
            _instanceCache[type] = instance;
            return instance;
        }
    }
}