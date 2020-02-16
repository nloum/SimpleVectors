using System;
using System.Collections.Generic;

namespace SimpleVectors
{
    public interface IVector<out T> : IVector<IVector<T>, T>
    {
    }

    public interface IVector<out TVector, out T> : IReadOnlyList<T>
        where TVector : IVector<TVector, T>
    {
    }
}
