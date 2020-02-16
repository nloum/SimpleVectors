using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

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
using GenericNumbers.Arithmetic.SpecialNumbers;
using GenericNumbers.Arithmetic.Sqrt;
using GenericNumbers.Arithmetic.Times;
using GenericNumbers.ConvertTo;
using GenericNumbers.Relational;

namespace SimpleVectors
{
    public static class Vector
    {
        public static Vector<T> Create<T>(IEnumerable<T> values)
        {
            return new Vector<T>(values.ToArray());
        }

        public static Vector<T> Create<T>(params T[] values)
        {
            return new Vector<T>(values);
        }

        public static Vector<T> CreateAll<T>(T value, int howMany)
        {
            T[] values = new T[howMany];
            for (var i = 0; i < howMany; i++)
            {
                values[i] = value;
            }
            return Create(values);
        }

        public static Vector<T> CreateLazily<T>(IEnumerable<Func<T>> values)
        {
            return new Vector<T>(values.Select(t => t()).ToArray());
        }

        public static Vector<T> CreateLazily<T>(params Func<T>[] values)
        {
            return new Vector<T>(values.Select(t => t()).ToArray());
        }

        public static Vector<T> CreateLazily<T>(Func<T> value, int howMany)
        {
            T[] values = new T[howMany];
            for (var i = 0; i < howMany; i++)
            {
                values[i] = value();
            }
            return Create(values);
        }
    }

    public class Vector<T> : Vector<Vector<T>, T>, IVector<T>
    {
        public Vector(params T[] elements)
            : base(elements)
        {
        }
    }

    /// <summary>
    /// A base class that helps implement IVector.
    /// </summary>
    /// <typeparam name="TVector"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class Vector<TVector, T> : IVector<TVector, T>,
        // Arithmetic interfaces
        IAbs<TVector>,
        ICeiling<TVector>,
        IDividedBy<TVector>,
        IFloor<TVector>,
        IMinus<TVector>,
        IPlus<TVector>,
        IRaisedTo<TVector>,
        IRemainder<TVector>,
        IRound<TVector>,
        ISpecialNumbers,
        ISqrt<TVector>,
        ITimes<TVector>,
        // Relational interfaces
        IComparable<TVector>
        where TVector : IVector<TVector, T>
    {
        protected readonly ImmutableList<T> Elements;

        public Vector(params T[] elements)
        {
            Elements = elements.ToImmutableList();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <returns>
        /// The number of elements in the collection. 
        /// </returns>
        public int Count => Elements.Count;

        /// <summary>
        /// Gets the element at the specified index in the read-only list.
        /// </summary>
        /// <returns>
        /// The element at the specified index in the read-only list.
        /// </returns>
        /// <param name="index">The zero-based index of the element to get. </param>
        public T this[int index] => Elements[index];

        #region Arithmetic

        #region Arithmetic that produces a vector

        public virtual void Abs(out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select(t => t.Abs()));
        }

        public virtual void Ceiling(out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select(t => t.Ceiling()));
        }

        public virtual void Floor(out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select(t => t.Floor()));
        }

        public virtual void Round(out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select(t => t.Round()));
        }

        public virtual void Sqrt(out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select(t => t.Sqrt()));
        }

        #region Arithmetic that takes an input vector

        public virtual void DividedBy(TVector input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t, i) => t.DividedBy(input[i])));
        }

        public virtual void Minus(TVector input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t, i) => t.Minus(input[i])));
        }

        public virtual void Plus(TVector input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t, i) => t.Plus(input[i])));
        }

        public virtual void RaisedTo(TVector input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t, i) => t.RaisedTo(input[i])));
        }

        public virtual void Remainder(TVector input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t, i) => t.Remainder(input[i])));
        }

        public virtual void Times(TVector input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t, i) => t.Times(input[i])));
        }

        #endregion

        #region Arithmetic that takes an input number

        public virtual void DividedBy(T input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t) => t.DividedBy(input)));
        }

        public virtual void Minus(T input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t) => t.Minus(input)));
        }

        public virtual void Plus(T input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t) => t.Plus(input)));
        }

        public virtual void RaisedTo(T input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t) => t.RaisedTo(input)));
        }

        public virtual void Remainder(T input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t) => t.Remainder(input)));
        }

        public virtual void Times(T input, out TVector output)
        {
            output = VectorUtil<TVector, T>.Create(Elements.Select((t) => t.Times(input)));
        }

        #endregion

        #endregion

        public virtual void IsNegativeInfinite(out bool output)
        {
            output = Elements.Any(t => t.IsNegativeInfinite());
        }

        public virtual void IsPositiveInfinite(out bool output)
        {
            output = Elements.Any(t => t.IsPositiveInfinite());
        }

        public virtual void IsNumber(out bool output)
        {
            output = Elements.All(t => t.IsNumber());
        }

        #endregion

        #region Relational

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual int CompareTo(TVector other)
        {
            var countComparison = Count.CompareTo(other.Count);
            if (countComparison != 0) return countComparison;

            for (var i = 0; i < Count; i++)
            {
                var elementComparison = this[i].CompareTo(other[i]);
                if (elementComparison != 0) return elementComparison;
            }
            return 0;
        }

        protected bool Equals(Vector<TVector, T> other)
        {
            if (Count != other.Count) return false;
            for (var i = 0; i < Count; i++)
            {
                if (!this[i].Equals(other[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Vector<TVector, T>)obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach (var element in Elements)
                {
                    hash = hash * 31 + element.GetHashCode();
                }
                return hash;
            }
        }

        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"<{string.Join(", ", Elements)}>";
        }
    }
}
