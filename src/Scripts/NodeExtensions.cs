namespace Anubis;

public static class NodeExtensions
{
    public static T GetRequiredNode<T>(this Node node, NodePath path) where T : Node
    {
        return node.GetNode<T>(path) ??
               throw new InvalidOperationException(
                   $"Required node of type '{typeof(T).Name}' was not found at path '{path}'");
    }
}