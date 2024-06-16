using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Anubis;

public class RequiredPropertyNotAssignedException : Exception
{
    private RequiredPropertyNotAssignedException(string name, Type type)
        : base($"Required property '{name}' of type '{type.Name}' was not assigned!")
    {
    }

    public static void ThrowIfNull<T>(
        [NotNull] T? value,
        [CallerArgumentExpression(nameof(value))] string name = ""
    )
    {
        if (value is null)
            throw new RequiredPropertyNotAssignedException(name, typeof(T));
    }
}