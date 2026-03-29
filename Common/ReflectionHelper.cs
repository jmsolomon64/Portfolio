namespace Common;

public static class ReflectionHelper
{
    public static List<T?> GetInstancesImplementingInterface<T>()
    {
        return GetTypesImplementingInterface<T>()
            .Select(x => (T?)Activator.CreateInstance(x))
            .ToList();
    }
    public static List<T?> GetInstancesImplementingInterface<T>(params object[] args)
    {
        return GetTypesImplementingInterface<T>()
            .Select(x => (T?)Activator.CreateInstance(x, args))
            .ToList();
    }

    private static IEnumerable<Type> GetTypesImplementingInterface<T>()
    {
        // return AppDomain.CurrentDomain.GetAssemblies()
        // .SelectMany(x => x.GetTypes())
        // .Where(x => typeof(T).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

        IEnumerable<Type> results = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(T).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

        foreach(Type result in results)
        {
            Console.WriteLine($"Type Discovered: {result.Name}");
        }

        return results;
    }

    
}
