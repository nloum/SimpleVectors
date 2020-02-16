using System;
using System.Collections.Generic;
using System.Linq;

using GenericNumbers;

namespace SimpleVectors
{
    public static class Vector2
    {
        public static IVector2<T> Create<T>(params T[] values)
        {
            if (values.Length != 2)
                throw new ArgumentException(string.Format("Incorrect number of elements for creating a Vector2: {0}", values.Length), "values");
            return new Vector2<T>(values[0], values[1]);
        }

        public static IVector2<T> Create<T>(IEnumerable<T> values)
        {
            return Create(values.ToArray());
        }

        public static IVector2<T> CreateAll<T>(T all)
        {
            return Create(all, all);
        }

        public static IVector2<T> CreateAllLazily<T>(Func<T> all)
        {
            return Create(all(), all());
        }

        public static IVector2<T> Default<T>()
        {
            return CreateAll(default(T));
        }
    }

    public class Vector2<T> : Vector2<IVector2<T>, T>, IVector2<T>
    {
        public static IVector2<T> Zero { get; } = new Vector2<T>(0.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector2<T> UnitX { get; } = new Vector2<T>(1.Convert().To<T>(), 0.Convert().To<T>());
        public static IVector2<T> UnitY { get; } = new Vector2<T>(0.Convert().To<T>(), 1.Convert().To<T>());

        public Vector2(params T[] elements)
            : base(elements)
        {
        }
    }

    public class Vector2<TVector2, T> : Vector<TVector2, T>, IVector2<TVector2, T>
        where TVector2 : IVector2<TVector2, T>
    {
        public Vector2(params T[] elements) : base(elements)
        {
        }

        public T X => Elements[0];
        public T Y => Elements[1];

        #region 2D vector accessors

        public TVector2 Xy => VectorUtil<TVector2, T>.Create(X, Y);
        public TVector2 Yx => VectorUtil<TVector2, T>.Create(Y, X);
        public TVector2 Xx => VectorUtil<TVector2, T>.Create(X, X);
        public TVector2 Yy => VectorUtil<TVector2, T>.Create(Y, Y);

        #endregion
    }
}
