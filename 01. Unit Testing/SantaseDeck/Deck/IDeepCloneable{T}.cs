namespace Santase.Logic.Cards
{
    public interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
}
