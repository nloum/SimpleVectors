using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenericNumbers;
using GenericNumbers.Arithmetic.Abs;
using GenericNumbers.Arithmetic.Ceiling;
using GenericNumbers.Arithmetic.DividedBy;
using GenericNumbers.Arithmetic.Floor;
using GenericNumbers.Arithmetic.Minus;
using GenericNumbers.Arithmetic.Plus;
using GenericNumbers.Arithmetic.RaisedTo;
using GenericNumbers.Arithmetic.Remainder;
using GenericNumbers.Arithmetic.Round;
using GenericNumbers.Arithmetic.Sqrt;
using GenericNumbers.Arithmetic.Times;

namespace SimpleVectors
{
    public static class Vector4
    {
        public static IVector4<T> Create<T>(params T[] values)
        {
            if (values.Length != 4)
                throw new ArgumentException(string.Format("Incorrect number of elements for creating a Vector4: {0}", values.Length), "values");
            return new Vector4<T>(values[0], values[1], values[2], values[3]);
        }

        public static IVector4<T> Create<T>(IEnumerable<T> values)
        {
            return Create(values.ToArray());
        }

        public static IVector4<T> Create<T>(T x, IEnumerable<T> yzw)
        {
            return Create(new[] { x }.Concat(yzw));
        }

        public static IVector4<T> Create<T>(IEnumerable<T> xyz, T w)
        {
            return Create(xyz.Concat(new[] { w }));
        }

        public static IVector4<T> Create<T>(T x, T y, IEnumerable<T> zw)
        {
            return Create(new[] { x, y }.Concat(zw));
        }

        public static IVector4<T> Create<T>(IEnumerable<T> xy, T z, T w)
        {
            return Create(xy.Concat(new[] { z, w }));
        }

        public static IVector4<T> Create<T>(T x, IEnumerable<T> yz, T w)
        {
            return Create(new[] { x }.Concat(yz).Concat(new[] { w }));
        }

        public static IVector4<T> Create<T>(IEnumerable<T> xy, IEnumerable<T> zw)
        {
            return Create(xy.Concat(zw));
        }

        public static IVector4<T> CreateAll<T>(T all)
        {
            return Create(all, all, all, all);
        }

        public static IVector4<T> CreateAllLazily<T>(Func<T> all)
        {
            return Create(all(), all(), all(), all());
        }

        public static IVector4<T> Default<T>()
        {
            return CreateAll(default(T));
        }
    }

    public class Vector4<T> : Vector4<IVector4<T>, T>, IVector4<T>
    {
        public static IVector4<T> Zero { get; } = new Vector4<T>(0.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector4<T> UnitX { get; } = new Vector4<T>(1.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector4<T> UnitY { get; } = new Vector4<T>(0.Convert().To<T>(), 1.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector4<T> UnitZ { get; } = new Vector4<T>(0.Convert().To<T>(), 0.Convert().To<T>(), 1.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector4<T> UnitW { get; } = new Vector4<T>(0.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>(), 1.Convert().To<T>());

        public Vector4(params T[] elements)
            : base(elements)
        {
        }
    }

    public class Vector4<TVector4, T> : Vector4<IVector3<T>, TVector4, T>, IVector4<TVector4, T>
        where TVector4 : IVector4<IVector2<T>, IVector3<T>, TVector4, T>
    {
        public Vector4(params T[] elements)
            : base(elements)
        {
        }
    }

    public class Vector4<TVector3, TVector4, T> : Vector4<IVector2<T>, TVector3, TVector4, T>, IVector4<TVector3, TVector4, T>
        where TVector3 : IVector3<IVector2<T>, TVector3, T>
        where TVector4 : IVector4<IVector2<T>, TVector3, TVector4, T>
    {
        public Vector4(params T[] elements)
            : base(elements)
        {
        }
    }

    public class Vector4<TVector2, TVector3, TVector4, T> : Vector3<TVector2, TVector3, T>, IVector4<TVector2, TVector3, TVector4, T>,
        // Arithmetic interfaces
        IAbs<TVector4>,
        ICeiling<TVector4>,
        IDividedBy<TVector4>,
        IFloor<TVector4>,
        IMinus<TVector4>,
        IPlus<TVector4>,
        IRaisedTo<TVector4>,
        IRemainder<TVector4>,
        IRound<TVector4>,
        ISqrt<TVector4>,
        ITimes<TVector4>
        where TVector2 : IVector2<TVector2, T>
        where TVector3 : IVector3<TVector2, TVector3, T>
        where TVector4 : IVector4<TVector2, TVector3, TVector4, T>
    {
        public Vector4(params T[] elements)
            : base(elements)
        {
        }

        public T W => Elements[3];

        #region 2D vector accessors

        public TVector2 Xw => VectorUtil<TVector2, T>.Create(X, W);
        public TVector2 Yw => VectorUtil<TVector2, T>.Create(Y, W);
        public TVector2 Zw => VectorUtil<TVector2, T>.Create(Z, W);
        public TVector2 Wx => VectorUtil<TVector2, T>.Create(W, X);
        public TVector2 Wy => VectorUtil<TVector2, T>.Create(W, Y);
        public TVector2 Wz => VectorUtil<TVector2, T>.Create(W, Z);
        public TVector2 Ww => VectorUtil<TVector2, T>.Create(W, W);

        #endregion

        #region 3D vector accessors

        public TVector3 Xxw => VectorUtil<TVector3, T>.Create(X, X, W);
        public TVector3 Xyw => VectorUtil<TVector3, T>.Create(X, Y, W);
        public TVector3 Xzw => VectorUtil<TVector3, T>.Create(X, Z, W);
        public TVector3 Xwx => VectorUtil<TVector3, T>.Create(X, W, X);
        public TVector3 Xwy => VectorUtil<TVector3, T>.Create(X, W, Y);
        public TVector3 Xwz => VectorUtil<TVector3, T>.Create(X, W, Z);
        public TVector3 Xww => VectorUtil<TVector3, T>.Create(X, W, W);
        public TVector3 Yxw => VectorUtil<TVector3, T>.Create(Y, X, W);
        public TVector3 Yyw => VectorUtil<TVector3, T>.Create(Y, Y, W);
        public TVector3 Yzw => VectorUtil<TVector3, T>.Create(Y, Z, W);
        public TVector3 Ywx => VectorUtil<TVector3, T>.Create(Y, W, X);
        public TVector3 Ywy => VectorUtil<TVector3, T>.Create(Y, W, Y);
        public TVector3 Ywz => VectorUtil<TVector3, T>.Create(Y, W, Z);
        public TVector3 Yww => VectorUtil<TVector3, T>.Create(Y, W, W);
        public TVector3 Zxw => VectorUtil<TVector3, T>.Create(Z, X, W);
        public TVector3 Zyw => VectorUtil<TVector3, T>.Create(Z, Y, W);
        public TVector3 Zzw => VectorUtil<TVector3, T>.Create(Z, Z, W);
        public TVector3 Zwx => VectorUtil<TVector3, T>.Create(Z, W, X);
        public TVector3 Zwy => VectorUtil<TVector3, T>.Create(Z, W, Y);
        public TVector3 Zwz => VectorUtil<TVector3, T>.Create(Z, W, Z);
        public TVector3 Zww => VectorUtil<TVector3, T>.Create(Z, W, W);
        public TVector3 Wxx => VectorUtil<TVector3, T>.Create(W, X, X);
        public TVector3 Wxy => VectorUtil<TVector3, T>.Create(W, X, Y);
        public TVector3 Wxz => VectorUtil<TVector3, T>.Create(W, X, Z);
        public TVector3 Wxw => VectorUtil<TVector3, T>.Create(W, X, W);
        public TVector3 Wyx => VectorUtil<TVector3, T>.Create(W, Y, X);
        public TVector3 Wyy => VectorUtil<TVector3, T>.Create(W, Y, Y);
        public TVector3 Wyz => VectorUtil<TVector3, T>.Create(W, Y, Z);
        public TVector3 Wyw => VectorUtil<TVector3, T>.Create(W, Y, W);
        public TVector3 Wzx => VectorUtil<TVector3, T>.Create(W, Z, X);
        public TVector3 Wzy => VectorUtil<TVector3, T>.Create(W, Z, Y);
        public TVector3 Wzz => VectorUtil<TVector3, T>.Create(W, Z, Z);
        public TVector3 Wzw => VectorUtil<TVector3, T>.Create(W, Z, W);
        public TVector3 Wwx => VectorUtil<TVector3, T>.Create(W, W, X);
        public TVector3 Wwy => VectorUtil<TVector3, T>.Create(W, W, Y);
        public TVector3 Wwz => VectorUtil<TVector3, T>.Create(W, W, Z);
        public TVector3 Www => VectorUtil<TVector3, T>.Create(W, W, W);

        #endregion

        #region 4D vector accessors

        public TVector4 Xxxx => VectorUtil<TVector4, T>.Create(X, X, X, X);
        public TVector4 Xxxy => VectorUtil<TVector4, T>.Create(X, X, X, Y);
        public TVector4 Xxxz => VectorUtil<TVector4, T>.Create(X, X, X, Z);
        public TVector4 Xxxw => VectorUtil<TVector4, T>.Create(X, X, X, W);
        public TVector4 Xxyx => VectorUtil<TVector4, T>.Create(X, X, Y, X);
        public TVector4 Xxyy => VectorUtil<TVector4, T>.Create(X, X, Y, Y);
        public TVector4 Xxyz => VectorUtil<TVector4, T>.Create(X, X, Y, Z);
        public TVector4 Xxyw => VectorUtil<TVector4, T>.Create(X, X, Y, W);
        public TVector4 Xxzx => VectorUtil<TVector4, T>.Create(X, X, Z, X);
        public TVector4 Xxzy => VectorUtil<TVector4, T>.Create(X, X, Z, Y);
        public TVector4 Xxzz => VectorUtil<TVector4, T>.Create(X, X, Z, Z);
        public TVector4 Xxzw => VectorUtil<TVector4, T>.Create(X, X, Z, W);
        public TVector4 Xxwx => VectorUtil<TVector4, T>.Create(X, X, W, X);
        public TVector4 Xxwy => VectorUtil<TVector4, T>.Create(X, X, W, Y);
        public TVector4 Xxwz => VectorUtil<TVector4, T>.Create(X, X, W, Z);
        public TVector4 Xxww => VectorUtil<TVector4, T>.Create(X, X, W, W);
        public TVector4 Xyxx => VectorUtil<TVector4, T>.Create(X, Y, X, X);
        public TVector4 Xyxy => VectorUtil<TVector4, T>.Create(X, Y, X, Y);
        public TVector4 Xyxz => VectorUtil<TVector4, T>.Create(X, Y, X, Z);
        public TVector4 Xyxw => VectorUtil<TVector4, T>.Create(X, Y, X, W);
        public TVector4 Xyyx => VectorUtil<TVector4, T>.Create(X, Y, Y, X);
        public TVector4 Xyyy => VectorUtil<TVector4, T>.Create(X, Y, Y, Y);
        public TVector4 Xyyz => VectorUtil<TVector4, T>.Create(X, Y, Y, Z);
        public TVector4 Xyyw => VectorUtil<TVector4, T>.Create(X, Y, Y, W);
        public TVector4 Xyzx => VectorUtil<TVector4, T>.Create(X, Y, Z, X);
        public TVector4 Xyzy => VectorUtil<TVector4, T>.Create(X, Y, Z, Y);
        public TVector4 Xyzz => VectorUtil<TVector4, T>.Create(X, Y, Z, Z);
        public TVector4 Xyzw => VectorUtil<TVector4, T>.Create(X, Y, Z, W);
        public TVector4 Xywx => VectorUtil<TVector4, T>.Create(X, Y, W, X);
        public TVector4 Xywy => VectorUtil<TVector4, T>.Create(X, Y, W, Y);
        public TVector4 Xywz => VectorUtil<TVector4, T>.Create(X, Y, W, Z);
        public TVector4 Xyww => VectorUtil<TVector4, T>.Create(X, Y, W, W);
        public TVector4 Xzxx => VectorUtil<TVector4, T>.Create(X, Z, X, X);
        public TVector4 Xzxy => VectorUtil<TVector4, T>.Create(X, Z, X, Y);
        public TVector4 Xzxz => VectorUtil<TVector4, T>.Create(X, Z, X, Z);
        public TVector4 Xzxw => VectorUtil<TVector4, T>.Create(X, Z, X, W);
        public TVector4 Xzyx => VectorUtil<TVector4, T>.Create(X, Z, Y, X);
        public TVector4 Xzyy => VectorUtil<TVector4, T>.Create(X, Z, Y, Y);
        public TVector4 Xzyz => VectorUtil<TVector4, T>.Create(X, Z, Y, Z);
        public TVector4 Xzyw => VectorUtil<TVector4, T>.Create(X, Z, Y, W);
        public TVector4 Xzzx => VectorUtil<TVector4, T>.Create(X, Z, Z, X);
        public TVector4 Xzzy => VectorUtil<TVector4, T>.Create(X, Z, Z, Y);
        public TVector4 Xzzz => VectorUtil<TVector4, T>.Create(X, Z, Z, Z);
        public TVector4 Xzzw => VectorUtil<TVector4, T>.Create(X, Z, Z, W);
        public TVector4 Xzwx => VectorUtil<TVector4, T>.Create(X, Z, W, X);
        public TVector4 Xzwy => VectorUtil<TVector4, T>.Create(X, Z, W, Y);
        public TVector4 Xzwz => VectorUtil<TVector4, T>.Create(X, Z, W, Z);
        public TVector4 Xzww => VectorUtil<TVector4, T>.Create(X, Z, W, W);
        public TVector4 Xwxx => VectorUtil<TVector4, T>.Create(X, W, X, X);
        public TVector4 Xwxy => VectorUtil<TVector4, T>.Create(X, W, X, Y);
        public TVector4 Xwxz => VectorUtil<TVector4, T>.Create(X, W, X, Z);
        public TVector4 Xwxw => VectorUtil<TVector4, T>.Create(X, W, X, W);
        public TVector4 Xwyx => VectorUtil<TVector4, T>.Create(X, W, Y, X);
        public TVector4 Xwyy => VectorUtil<TVector4, T>.Create(X, W, Y, Y);
        public TVector4 Xwyz => VectorUtil<TVector4, T>.Create(X, W, Y, Z);
        public TVector4 Xwyw => VectorUtil<TVector4, T>.Create(X, W, Y, W);
        public TVector4 Xwzx => VectorUtil<TVector4, T>.Create(X, W, Z, X);
        public TVector4 Xwzy => VectorUtil<TVector4, T>.Create(X, W, Z, Y);
        public TVector4 Xwzz => VectorUtil<TVector4, T>.Create(X, W, Z, Z);
        public TVector4 Xwzw => VectorUtil<TVector4, T>.Create(X, W, Z, W);
        public TVector4 Xwwx => VectorUtil<TVector4, T>.Create(X, W, W, X);
        public TVector4 Xwwy => VectorUtil<TVector4, T>.Create(X, W, W, Y);
        public TVector4 Xwwz => VectorUtil<TVector4, T>.Create(X, W, W, Z);
        public TVector4 Xwww => VectorUtil<TVector4, T>.Create(X, W, W, W);
        public TVector4 Yxxx => VectorUtil<TVector4, T>.Create(Y, X, X, X);
        public TVector4 Yxxy => VectorUtil<TVector4, T>.Create(Y, X, X, Y);
        public TVector4 Yxxz => VectorUtil<TVector4, T>.Create(Y, X, X, Z);
        public TVector4 Yxxw => VectorUtil<TVector4, T>.Create(Y, X, X, W);
        public TVector4 Yxyx => VectorUtil<TVector4, T>.Create(Y, X, Y, X);
        public TVector4 Yxyy => VectorUtil<TVector4, T>.Create(Y, X, Y, Y);
        public TVector4 Yxyz => VectorUtil<TVector4, T>.Create(Y, X, Y, Z);
        public TVector4 Yxyw => VectorUtil<TVector4, T>.Create(Y, X, Y, W);
        public TVector4 Yxzx => VectorUtil<TVector4, T>.Create(Y, X, Z, X);
        public TVector4 Yxzy => VectorUtil<TVector4, T>.Create(Y, X, Z, Y);
        public TVector4 Yxzz => VectorUtil<TVector4, T>.Create(Y, X, Z, Z);
        public TVector4 Yxzw => VectorUtil<TVector4, T>.Create(Y, X, Z, W);
        public TVector4 Yxwx => VectorUtil<TVector4, T>.Create(Y, X, W, X);
        public TVector4 Yxwy => VectorUtil<TVector4, T>.Create(Y, X, W, Y);
        public TVector4 Yxwz => VectorUtil<TVector4, T>.Create(Y, X, W, Z);
        public TVector4 Yxww => VectorUtil<TVector4, T>.Create(Y, X, W, W);
        public TVector4 Yyxx => VectorUtil<TVector4, T>.Create(Y, Y, X, X);
        public TVector4 Yyxy => VectorUtil<TVector4, T>.Create(Y, Y, X, Y);
        public TVector4 Yyxz => VectorUtil<TVector4, T>.Create(Y, Y, X, Z);
        public TVector4 Yyxw => VectorUtil<TVector4, T>.Create(Y, Y, X, W);
        public TVector4 Yyyx => VectorUtil<TVector4, T>.Create(Y, Y, Y, X);
        public TVector4 Yyyy => VectorUtil<TVector4, T>.Create(Y, Y, Y, Y);
        public TVector4 Yyyz => VectorUtil<TVector4, T>.Create(Y, Y, Y, Z);
        public TVector4 Yyyw => VectorUtil<TVector4, T>.Create(Y, Y, Y, W);
        public TVector4 Yyzx => VectorUtil<TVector4, T>.Create(Y, Y, Z, X);
        public TVector4 Yyzy => VectorUtil<TVector4, T>.Create(Y, Y, Z, Y);
        public TVector4 Yyzz => VectorUtil<TVector4, T>.Create(Y, Y, Z, Z);
        public TVector4 Yyzw => VectorUtil<TVector4, T>.Create(Y, Y, Z, W);
        public TVector4 Yywx => VectorUtil<TVector4, T>.Create(Y, Y, W, X);
        public TVector4 Yywy => VectorUtil<TVector4, T>.Create(Y, Y, W, Y);
        public TVector4 Yywz => VectorUtil<TVector4, T>.Create(Y, Y, W, Z);
        public TVector4 Yyww => VectorUtil<TVector4, T>.Create(Y, Y, W, W);
        public TVector4 Yzxx => VectorUtil<TVector4, T>.Create(Y, Z, X, X);
        public TVector4 Yzxy => VectorUtil<TVector4, T>.Create(Y, Z, X, Y);
        public TVector4 Yzxz => VectorUtil<TVector4, T>.Create(Y, Z, X, Z);
        public TVector4 Yzxw => VectorUtil<TVector4, T>.Create(Y, Z, X, W);
        public TVector4 Yzyx => VectorUtil<TVector4, T>.Create(Y, Z, Y, X);
        public TVector4 Yzyy => VectorUtil<TVector4, T>.Create(Y, Z, Y, Y);
        public TVector4 Yzyz => VectorUtil<TVector4, T>.Create(Y, Z, Y, Z);
        public TVector4 Yzyw => VectorUtil<TVector4, T>.Create(Y, Z, Y, W);
        public TVector4 Yzzx => VectorUtil<TVector4, T>.Create(Y, Z, Z, X);
        public TVector4 Yzzy => VectorUtil<TVector4, T>.Create(Y, Z, Z, Y);
        public TVector4 Yzzz => VectorUtil<TVector4, T>.Create(Y, Z, Z, Z);
        public TVector4 Yzzw => VectorUtil<TVector4, T>.Create(Y, Z, Z, W);
        public TVector4 Yzwx => VectorUtil<TVector4, T>.Create(Y, Z, W, X);
        public TVector4 Yzwy => VectorUtil<TVector4, T>.Create(Y, Z, W, Y);
        public TVector4 Yzwz => VectorUtil<TVector4, T>.Create(Y, Z, W, Z);
        public TVector4 Yzww => VectorUtil<TVector4, T>.Create(Y, Z, W, W);
        public TVector4 Ywxx => VectorUtil<TVector4, T>.Create(Y, W, X, X);
        public TVector4 Ywxy => VectorUtil<TVector4, T>.Create(Y, W, X, Y);
        public TVector4 Ywxz => VectorUtil<TVector4, T>.Create(Y, W, X, Z);
        public TVector4 Ywxw => VectorUtil<TVector4, T>.Create(Y, W, X, W);
        public TVector4 Ywyx => VectorUtil<TVector4, T>.Create(Y, W, Y, X);
        public TVector4 Ywyy => VectorUtil<TVector4, T>.Create(Y, W, Y, Y);
        public TVector4 Ywyz => VectorUtil<TVector4, T>.Create(Y, W, Y, Z);
        public TVector4 Ywyw => VectorUtil<TVector4, T>.Create(Y, W, Y, W);
        public TVector4 Ywzx => VectorUtil<TVector4, T>.Create(Y, W, Z, X);
        public TVector4 Ywzy => VectorUtil<TVector4, T>.Create(Y, W, Z, Y);
        public TVector4 Ywzz => VectorUtil<TVector4, T>.Create(Y, W, Z, Z);
        public TVector4 Ywzw => VectorUtil<TVector4, T>.Create(Y, W, Z, W);
        public TVector4 Ywwx => VectorUtil<TVector4, T>.Create(Y, W, W, X);
        public TVector4 Ywwy => VectorUtil<TVector4, T>.Create(Y, W, W, Y);
        public TVector4 Ywwz => VectorUtil<TVector4, T>.Create(Y, W, W, Z);
        public TVector4 Ywww => VectorUtil<TVector4, T>.Create(Y, W, W, W);
        public TVector4 Zxxx => VectorUtil<TVector4, T>.Create(Z, X, X, X);
        public TVector4 Zxxy => VectorUtil<TVector4, T>.Create(Z, X, X, Y);
        public TVector4 Zxxz => VectorUtil<TVector4, T>.Create(Z, X, X, Z);
        public TVector4 Zxxw => VectorUtil<TVector4, T>.Create(Z, X, X, W);
        public TVector4 Zxyx => VectorUtil<TVector4, T>.Create(Z, X, Y, X);
        public TVector4 Zxyy => VectorUtil<TVector4, T>.Create(Z, X, Y, Y);
        public TVector4 Zxyz => VectorUtil<TVector4, T>.Create(Z, X, Y, Z);
        public TVector4 Zxyw => VectorUtil<TVector4, T>.Create(Z, X, Y, W);
        public TVector4 Zxzx => VectorUtil<TVector4, T>.Create(Z, X, Z, X);
        public TVector4 Zxzy => VectorUtil<TVector4, T>.Create(Z, X, Z, Y);
        public TVector4 Zxzz => VectorUtil<TVector4, T>.Create(Z, X, Z, Z);
        public TVector4 Zxzw => VectorUtil<TVector4, T>.Create(Z, X, Z, W);
        public TVector4 Zxwx => VectorUtil<TVector4, T>.Create(Z, X, W, X);
        public TVector4 Zxwy => VectorUtil<TVector4, T>.Create(Z, X, W, Y);
        public TVector4 Zxwz => VectorUtil<TVector4, T>.Create(Z, X, W, Z);
        public TVector4 Zxww => VectorUtil<TVector4, T>.Create(Z, X, W, W);
        public TVector4 Zyxx => VectorUtil<TVector4, T>.Create(Z, Y, X, X);
        public TVector4 Zyxy => VectorUtil<TVector4, T>.Create(Z, Y, X, Y);
        public TVector4 Zyxz => VectorUtil<TVector4, T>.Create(Z, Y, X, Z);
        public TVector4 Zyxw => VectorUtil<TVector4, T>.Create(Z, Y, X, W);
        public TVector4 Zyyx => VectorUtil<TVector4, T>.Create(Z, Y, Y, X);
        public TVector4 Zyyy => VectorUtil<TVector4, T>.Create(Z, Y, Y, Y);
        public TVector4 Zyyz => VectorUtil<TVector4, T>.Create(Z, Y, Y, Z);
        public TVector4 Zyyw => VectorUtil<TVector4, T>.Create(Z, Y, Y, W);
        public TVector4 Zyzx => VectorUtil<TVector4, T>.Create(Z, Y, Z, X);
        public TVector4 Zyzy => VectorUtil<TVector4, T>.Create(Z, Y, Z, Y);
        public TVector4 Zyzz => VectorUtil<TVector4, T>.Create(Z, Y, Z, Z);
        public TVector4 Zyzw => VectorUtil<TVector4, T>.Create(Z, Y, Z, W);
        public TVector4 Zywx => VectorUtil<TVector4, T>.Create(Z, Y, W, X);
        public TVector4 Zywy => VectorUtil<TVector4, T>.Create(Z, Y, W, Y);
        public TVector4 Zywz => VectorUtil<TVector4, T>.Create(Z, Y, W, Z);
        public TVector4 Zyww => VectorUtil<TVector4, T>.Create(Z, Y, W, W);
        public TVector4 Zzxx => VectorUtil<TVector4, T>.Create(Z, Z, X, X);
        public TVector4 Zzxy => VectorUtil<TVector4, T>.Create(Z, Z, X, Y);
        public TVector4 Zzxz => VectorUtil<TVector4, T>.Create(Z, Z, X, Z);
        public TVector4 Zzxw => VectorUtil<TVector4, T>.Create(Z, Z, X, W);
        public TVector4 Zzyx => VectorUtil<TVector4, T>.Create(Z, Z, Y, X);
        public TVector4 Zzyy => VectorUtil<TVector4, T>.Create(Z, Z, Y, Y);
        public TVector4 Zzyz => VectorUtil<TVector4, T>.Create(Z, Z, Y, Z);
        public TVector4 Zzyw => VectorUtil<TVector4, T>.Create(Z, Z, Y, W);
        public TVector4 Zzzx => VectorUtil<TVector4, T>.Create(Z, Z, Z, X);
        public TVector4 Zzzy => VectorUtil<TVector4, T>.Create(Z, Z, Z, Y);
        public TVector4 Zzzz => VectorUtil<TVector4, T>.Create(Z, Z, Z, Z);
        public TVector4 Zzzw => VectorUtil<TVector4, T>.Create(Z, Z, Z, W);
        public TVector4 Zzwx => VectorUtil<TVector4, T>.Create(Z, Z, W, X);
        public TVector4 Zzwy => VectorUtil<TVector4, T>.Create(Z, Z, W, Y);
        public TVector4 Zzwz => VectorUtil<TVector4, T>.Create(Z, Z, W, Z);
        public TVector4 Zzww => VectorUtil<TVector4, T>.Create(Z, Z, W, W);
        public TVector4 Zwxx => VectorUtil<TVector4, T>.Create(Z, W, X, X);
        public TVector4 Zwxy => VectorUtil<TVector4, T>.Create(Z, W, X, Y);
        public TVector4 Zwxz => VectorUtil<TVector4, T>.Create(Z, W, X, Z);
        public TVector4 Zwxw => VectorUtil<TVector4, T>.Create(Z, W, X, W);
        public TVector4 Zwyx => VectorUtil<TVector4, T>.Create(Z, W, Y, X);
        public TVector4 Zwyy => VectorUtil<TVector4, T>.Create(Z, W, Y, Y);
        public TVector4 Zwyz => VectorUtil<TVector4, T>.Create(Z, W, Y, Z);
        public TVector4 Zwyw => VectorUtil<TVector4, T>.Create(Z, W, Y, W);
        public TVector4 Zwzx => VectorUtil<TVector4, T>.Create(Z, W, Z, X);
        public TVector4 Zwzy => VectorUtil<TVector4, T>.Create(Z, W, Z, Y);
        public TVector4 Zwzz => VectorUtil<TVector4, T>.Create(Z, W, Z, Z);
        public TVector4 Zwzw => VectorUtil<TVector4, T>.Create(Z, W, Z, W);
        public TVector4 Zwwx => VectorUtil<TVector4, T>.Create(Z, W, W, X);
        public TVector4 Zwwy => VectorUtil<TVector4, T>.Create(Z, W, W, Y);
        public TVector4 Zwwz => VectorUtil<TVector4, T>.Create(Z, W, W, Z);
        public TVector4 Zwww => VectorUtil<TVector4, T>.Create(Z, W, W, W);
        public TVector4 Wxxx => VectorUtil<TVector4, T>.Create(W, X, X, X);
        public TVector4 Wxxy => VectorUtil<TVector4, T>.Create(W, X, X, Y);
        public TVector4 Wxxz => VectorUtil<TVector4, T>.Create(W, X, X, Z);
        public TVector4 Wxxw => VectorUtil<TVector4, T>.Create(W, X, X, W);
        public TVector4 Wxyx => VectorUtil<TVector4, T>.Create(W, X, Y, X);
        public TVector4 Wxyy => VectorUtil<TVector4, T>.Create(W, X, Y, Y);
        public TVector4 Wxyz => VectorUtil<TVector4, T>.Create(W, X, Y, Z);
        public TVector4 Wxyw => VectorUtil<TVector4, T>.Create(W, X, Y, W);
        public TVector4 Wxzx => VectorUtil<TVector4, T>.Create(W, X, Z, X);
        public TVector4 Wxzy => VectorUtil<TVector4, T>.Create(W, X, Z, Y);
        public TVector4 Wxzz => VectorUtil<TVector4, T>.Create(W, X, Z, Z);
        public TVector4 Wxzw => VectorUtil<TVector4, T>.Create(W, X, Z, W);
        public TVector4 Wxwx => VectorUtil<TVector4, T>.Create(W, X, W, X);
        public TVector4 Wxwy => VectorUtil<TVector4, T>.Create(W, X, W, Y);
        public TVector4 Wxwz => VectorUtil<TVector4, T>.Create(W, X, W, Z);
        public TVector4 Wxww => VectorUtil<TVector4, T>.Create(W, X, W, W);
        public TVector4 Wyxx => VectorUtil<TVector4, T>.Create(W, Y, X, X);
        public TVector4 Wyxy => VectorUtil<TVector4, T>.Create(W, Y, X, Y);
        public TVector4 Wyxz => VectorUtil<TVector4, T>.Create(W, Y, X, Z);
        public TVector4 Wyxw => VectorUtil<TVector4, T>.Create(W, Y, X, W);
        public TVector4 Wyyx => VectorUtil<TVector4, T>.Create(W, Y, Y, X);
        public TVector4 Wyyy => VectorUtil<TVector4, T>.Create(W, Y, Y, Y);
        public TVector4 Wyyz => VectorUtil<TVector4, T>.Create(W, Y, Y, Z);
        public TVector4 Wyyw => VectorUtil<TVector4, T>.Create(W, Y, Y, W);
        public TVector4 Wyzx => VectorUtil<TVector4, T>.Create(W, Y, Z, X);
        public TVector4 Wyzy => VectorUtil<TVector4, T>.Create(W, Y, Z, Y);
        public TVector4 Wyzz => VectorUtil<TVector4, T>.Create(W, Y, Z, Z);
        public TVector4 Wyzw => VectorUtil<TVector4, T>.Create(W, Y, Z, W);
        public TVector4 Wywx => VectorUtil<TVector4, T>.Create(W, Y, W, X);
        public TVector4 Wywy => VectorUtil<TVector4, T>.Create(W, Y, W, Y);
        public TVector4 Wywz => VectorUtil<TVector4, T>.Create(W, Y, W, Z);
        public TVector4 Wyww => VectorUtil<TVector4, T>.Create(W, Y, W, W);
        public TVector4 Wzxx => VectorUtil<TVector4, T>.Create(W, Z, X, X);
        public TVector4 Wzxy => VectorUtil<TVector4, T>.Create(W, Z, X, Y);
        public TVector4 Wzxz => VectorUtil<TVector4, T>.Create(W, Z, X, Z);
        public TVector4 Wzxw => VectorUtil<TVector4, T>.Create(W, Z, X, W);
        public TVector4 Wzyx => VectorUtil<TVector4, T>.Create(W, Z, Y, X);
        public TVector4 Wzyy => VectorUtil<TVector4, T>.Create(W, Z, Y, Y);
        public TVector4 Wzyz => VectorUtil<TVector4, T>.Create(W, Z, Y, Z);
        public TVector4 Wzyw => VectorUtil<TVector4, T>.Create(W, Z, Y, W);
        public TVector4 Wzzx => VectorUtil<TVector4, T>.Create(W, Z, Z, X);
        public TVector4 Wzzy => VectorUtil<TVector4, T>.Create(W, Z, Z, Y);
        public TVector4 Wzzz => VectorUtil<TVector4, T>.Create(W, Z, Z, Z);
        public TVector4 Wzzw => VectorUtil<TVector4, T>.Create(W, Z, Z, W);
        public TVector4 Wzwx => VectorUtil<TVector4, T>.Create(W, Z, W, X);
        public TVector4 Wzwy => VectorUtil<TVector4, T>.Create(W, Z, W, Y);
        public TVector4 Wzwz => VectorUtil<TVector4, T>.Create(W, Z, W, Z);
        public TVector4 Wzww => VectorUtil<TVector4, T>.Create(W, Z, W, W);
        public TVector4 Wwxx => VectorUtil<TVector4, T>.Create(W, W, X, X);
        public TVector4 Wwxy => VectorUtil<TVector4, T>.Create(W, W, X, Y);
        public TVector4 Wwxz => VectorUtil<TVector4, T>.Create(W, W, X, Z);
        public TVector4 Wwxw => VectorUtil<TVector4, T>.Create(W, W, X, W);
        public TVector4 Wwyx => VectorUtil<TVector4, T>.Create(W, W, Y, X);
        public TVector4 Wwyy => VectorUtil<TVector4, T>.Create(W, W, Y, Y);
        public TVector4 Wwyz => VectorUtil<TVector4, T>.Create(W, W, Y, Z);
        public TVector4 Wwyw => VectorUtil<TVector4, T>.Create(W, W, Y, W);
        public TVector4 Wwzx => VectorUtil<TVector4, T>.Create(W, W, Z, X);
        public TVector4 Wwzy => VectorUtil<TVector4, T>.Create(W, W, Z, Y);
        public TVector4 Wwzz => VectorUtil<TVector4, T>.Create(W, W, Z, Z);
        public TVector4 Wwzw => VectorUtil<TVector4, T>.Create(W, W, Z, W);
        public TVector4 Wwwx => VectorUtil<TVector4, T>.Create(W, W, W, X);
        public TVector4 Wwwy => VectorUtil<TVector4, T>.Create(W, W, W, Y);
        public TVector4 Wwwz => VectorUtil<TVector4, T>.Create(W, W, W, Z);
        public TVector4 Wwww => VectorUtil<TVector4, T>.Create(W, W, W, W);

        #endregion

        #region Arithmetic that produces a vector

        public virtual void Abs(out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select(t => t.Abs()));
        }

        public virtual void Ceiling(out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select(t => t.Ceiling()));
        }

        public virtual void Floor(out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select(t => t.Floor()));
        }

        public virtual void Round(out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select(t => t.Round()));
        }

        public virtual void Sqrt(out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select(t => t.Sqrt()));
        }

        #region Arithmetic that takes an input vector

        public virtual void DividedBy(TVector4 input, out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select((t, i) => t.DividedBy(input[i])));
        }

        public virtual void Minus(TVector4 input, out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select((t, i) => t.Minus(input[i])));
        }

        public virtual void Plus(TVector4 input, out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select((t, i) => t.Plus(input[i])));
        }

        public virtual void RaisedTo(TVector4 input, out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select((t, i) => t.RaisedTo(input[i])));
        }

        public virtual void Remainder(TVector4 input, out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select((t, i) => t.Remainder(input[i])));
        }

        public virtual void Times(TVector4 input, out TVector4 output)
        {
            output = VectorUtil<TVector4, T>.Create(Elements.Select((t, i) => t.Times(input[i])));
        }

        #endregion

        #endregion
    }
}
