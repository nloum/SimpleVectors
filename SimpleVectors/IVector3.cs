namespace SimpleVectors
{
    public interface IVector3<out T> : IVector3<IVector3<T>, T>
    {
    }

    public interface IVector3<out TVector3, out T> : IVector3<IVector2<T>, TVector3, T>, IVector2<T>
        where TVector3 : IVector3<IVector2<T>, TVector3, T>
    {
    }

    public interface IVector3<out TVector2, out TVector3, out T> : IVector2<TVector2, T>
        where TVector3 : IVector3<TVector2, TVector3, T> where TVector2 : IVector2<TVector2, T>
    {
        T Z { get; }
        TVector2 Xz { get; }
        TVector2 Yz { get; }
        TVector2 Zx { get; }
        TVector2 Zy { get; }
        TVector2 Zz { get; }

        TVector3 Xxx { get; }
        TVector3 Xxy { get; }
        TVector3 Xxz { get; }
        TVector3 Xyx { get; }
        TVector3 Xyy { get; }
        TVector3 Xyz { get; }
        TVector3 Xzx { get; }
        TVector3 Xzy { get; }
        TVector3 Xzz { get; }
        TVector3 Yxx { get; }
        TVector3 Yxy { get; }
        TVector3 Yxz { get; }
        TVector3 Yyx { get; }
        TVector3 Yyy { get; }
        TVector3 Yyz { get; }
        TVector3 Yzx { get; }
        TVector3 Yzy { get; }
        TVector3 Yzz { get; }
        TVector3 Zxx { get; }
        TVector3 Zxy { get; }
        TVector3 Zxz { get; }
        TVector3 Zyx { get; }
        TVector3 Zyy { get; }
        TVector3 Zyz { get; }
        TVector3 Zzx { get; }
        TVector3 Zzy { get; }
        TVector3 Zzz { get; }
    }
}
