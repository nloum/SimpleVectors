using System;
using System.Collections.Generic;
using System.Linq;

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
    public static class Vector3
    {
        public static IVector3<T> Create<T>(params T[] values)
        {
            if (values.Length != 3)
                throw new ArgumentException(string.Format("Incorrect number of elements for creating a Vector3: {0}", values.Length), "values");
            return new Vector3<T>(values[0], values[1], values[2]);
        }

        public static IVector3<T> Create<T>(IEnumerable<T> values)
        {
            return Create(values.ToArray());
        }

        public static IVector3<T> Create<T>(T x, IEnumerable<T> yz)
        {
            return Create(new[] { x }.Concat(yz));
        }

        public static IVector3<T> Create<T>(IEnumerable<T> xy, T z)
        {
            return Create(xy.Concat(new[] { z }));
        }

        public static IVector3<T> CreateAll<T>(T all)
        {
            return Create(all, all, all);
        }

        public static IVector3<T> CreateAllLazily<T>(Func<T> all)
        {
            return Create(all(), all(), all());
        }

        public static IVector3<T> Default<T>()
        {
            return CreateAll(default(T));
        }
    }
    
    public class Vector3<T> : Vector3<IVector3<T>, T>, IVector3<T>
    {
        public static IVector3<T> Zero { get; } = new Vector3<T>(0.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector3<T> UnitX { get; } = new Vector3<T>(1.Convert().To<T>(), 0.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector3<T> UnitY { get; } = new Vector3<T>(0.Convert().To<T>(), 1.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector3<T> UnitZ { get; } = new Vector3<T>(0.Convert().To<T>(), 0.Convert().To<T>(), 1.Convert().To<T>());

        public Vector3(params T[] elements)
            : base(elements)
        {
        }

        public T Z => Elements[2];
    }

    public class Vector3<TVector3, T> : Vector3<IVector2<T>, TVector3, T>, IVector3<TVector3, T>
        where TVector3 : IVector3<IVector2<T>, TVector3, T>
    {
        public Vector3(params T[] elements)
            : base(elements)
        {
        }
    }

    public class Vector3<TVector2, TVector3, T> : Vector2<TVector2, T>, IVector3<TVector2, TVector3, T>,
        // Arithmetic interfaces
        IAbs<TVector3>,
        ICeiling<TVector3>,
        IDividedBy<TVector3>,
        IFloor<TVector3>,
        IMinus<TVector3>,
        IPlus<TVector3>,
        IRaisedTo<TVector3>,
        IRemainder<TVector3>,
        IRound<TVector3>,
        ISqrt<TVector3>,
        ITimes<TVector3>
        where TVector3 : IVector3<TVector2, TVector3, T> where TVector2 : IVector2<TVector2, T>
    {
        public Vector3(params T[] elements)
            : base(elements)
        {
        }

        public T Z => Elements[2];

        #region 2D vector accessors

        public TVector2 Xz => VectorUtil<TVector2, T>.Create(X, Z);
        public TVector2 Yz => VectorUtil<TVector2, T>.Create(Y, Z);
        public TVector2 Zx => VectorUtil<TVector2, T>.Create(Z, X);
        public TVector2 Zy => VectorUtil<TVector2, T>.Create(Z, Y);
        public TVector2 Zz => VectorUtil<TVector2, T>.Create(Z, Z);

        #endregion

        #region 3D vector accessors

        public TVector3 Xxx => VectorUtil<TVector3, T>.Create(X, X, X);
        public TVector3 Xxy => VectorUtil<TVector3, T>.Create(X, X, Y);
        public TVector3 Xxz => VectorUtil<TVector3, T>.Create(X, X, Z);
        public TVector3 Xyx => VectorUtil<TVector3, T>.Create(X, Y, X);
        public TVector3 Xyy => VectorUtil<TVector3, T>.Create(X, Y, Y);
        public TVector3 Xyz => VectorUtil<TVector3, T>.Create(X, Y, Z);
        public TVector3 Xzx => VectorUtil<TVector3, T>.Create(X, Z, X);
        public TVector3 Xzy => VectorUtil<TVector3, T>.Create(X, Z, Y);
        public TVector3 Xzz => VectorUtil<TVector3, T>.Create(X, Z, Z);
        public TVector3 Yxx => VectorUtil<TVector3, T>.Create(Y, X, X);
        public TVector3 Yxy => VectorUtil<TVector3, T>.Create(Y, X, Y);
        public TVector3 Yxz => VectorUtil<TVector3, T>.Create(Y, X, Z);
        public TVector3 Yyx => VectorUtil<TVector3, T>.Create(Y, Y, X);
        public TVector3 Yyy => VectorUtil<TVector3, T>.Create(Y, Y, Y);
        public TVector3 Yyz => VectorUtil<TVector3, T>.Create(Y, Y, Z);
        public TVector3 Yzx => VectorUtil<TVector3, T>.Create(Y, Z, X);
        public TVector3 Yzy => VectorUtil<TVector3, T>.Create(Y, Z, Y);
        public TVector3 Yzz => VectorUtil<TVector3, T>.Create(Y, Z, Z);
        public TVector3 Zxx => VectorUtil<TVector3, T>.Create(Z, X, X);
        public TVector3 Zxy => VectorUtil<TVector3, T>.Create(Z, X, Y);
        public TVector3 Zxz => VectorUtil<TVector3, T>.Create(Z, X, Z);
        public TVector3 Zyx => VectorUtil<TVector3, T>.Create(Z, Y, X);
        public TVector3 Zyy => VectorUtil<TVector3, T>.Create(Z, Y, Y);
        public TVector3 Zyz => VectorUtil<TVector3, T>.Create(Z, Y, Z);
        public TVector3 Zzx => VectorUtil<TVector3, T>.Create(Z, Z, X);
        public TVector3 Zzy => VectorUtil<TVector3, T>.Create(Z, Z, Y);
        public TVector3 Zzz => VectorUtil<TVector3, T>.Create(Z, Z, Z);

        #endregion

        #region Arithmetic that produces a vector

        public virtual void Abs(out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select(t => t.Abs()));
        }

        public virtual void Ceiling(out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select(t => t.Ceiling()));
        }

        public virtual void Floor(out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select(t => t.Floor()));
        }

        public virtual void Round(out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select(t => t.Round()));
        }

        public virtual void Sqrt(out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select(t => t.Sqrt()));
        }

        #region Arithmetic that takes an input vector

        public virtual void DividedBy(TVector3 input, out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select((t, i) => t.DividedBy(input[i])));
        }

        public virtual void Minus(TVector3 input, out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select((t, i) => t.Minus(input[i])));
        }

        public virtual void Plus(TVector3 input, out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select((t, i) => t.Plus(input[i])));
        }

        public virtual void RaisedTo(TVector3 input, out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select((t, i) => t.RaisedTo(input[i])));
        }

        public virtual void Remainder(TVector3 input, out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select((t, i) => t.Remainder(input[i])));
        }

        public virtual void Times(TVector3 input, out TVector3 output)
        {
            output = VectorUtil<TVector3, T>.Create(Elements.Select((t, i) => t.Times(input[i])));
        }

        #endregion

        #endregion
    }
}
