namespace SimpleVectors
{
    public interface IVector2<out T> : IVector2<IVector2<T>, T>, IVector<T>
    {
    }

    public interface IVector2<out TVector2, out T> : IVector<TVector2, T>
        where TVector2 : IVector2<TVector2, T>
    {
        T X { get; }
        T Y { get; }
        TVector2 Xx { get; }
        TVector2 Xy { get; }
        TVector2 Yx { get; }
        TVector2 Yy { get; }
    }
}
