using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenericNumbers;

namespace SimpleVectors
{
    public static class VectorExtensions
    {
        #region Arithmetic that takes an input number

        #region IVector

        public static IVector<T> DividedBy<T>(this IVector<T> source, T input)
        {
            return source.DividedBy<IVector<T>, T, IVector<T>>(input);
        }

        public static IVector<T> Minus<T>(this IVector<T> source, T input)
        {
            return source.Minus<IVector<T>, T, IVector<T>>(input);
        }

        public static IVector<T> Plus<T>(this IVector<T> source, T input)
        {
            return source.Plus<IVector<T>, T, IVector<T>>(input);
        }

        public static IVector<T> RaisedTo<T>(this IVector<T> source, T input)
        {
            return source.RaisedTo<IVector<T>, T, IVector<T>>(input);
        }

        public static IVector<T> Remainder<T>(this IVector<T> source, T input)
        {
            return source.Remainder<IVector<T>, T, IVector<T>>(input);
        }

        public static IVector<T> Times<T>(this IVector<T> source, T input)
        {
            return source.Times<IVector<T>, T, IVector<T>>(input);
        }

        #endregion

        #region IVector

        public static IVector2<T> DividedBy<T>(this IVector2<T> source, T input)
        {
            return source.DividedBy<IVector2<T>, T, IVector2<T>>(input);
        }

        public static IVector2<T> Minus<T>(this IVector2<T> source, T input)
        {
            return source.Minus<IVector2<T>, T, IVector2<T>>(input);
        }

        public static IVector2<T> Plus<T>(this IVector2<T> source, T input)
        {
            return source.Plus<IVector2<T>, T, IVector2<T>>(input);
        }

        public static IVector2<T> RaisedTo<T>(this IVector2<T> source, T input)
        {
            return source.RaisedTo<IVector2<T>, T, IVector2<T>>(input);
        }

        public static IVector2<T> Remainder<T>(this IVector2<T> source, T input)
        {
            return source.Remainder<IVector2<T>, T, IVector2<T>>(input);
        }

        public static IVector2<T> Times<T>(this IVector2<T> source, T input)
        {
            return source.Times<IVector2<T>, T, IVector2<T>>(input);
        }

        #endregion

        #region IVector3

        public static IVector3<T> DividedBy<T>(this IVector3<T> source, T input)
        {
            return source.DividedBy<IVector3<T>, T, IVector3<T>>(input);
        }

        public static IVector3<T> Minus<T>(this IVector3<T> source, T input)
        {
            return source.Minus<IVector3<T>, T, IVector3<T>>(input);
        }

        public static IVector3<T> Plus<T>(this IVector3<T> source, T input)
        {
            return source.Plus<IVector3<T>, T, IVector3<T>>(input);
        }

        public static IVector3<T> RaisedTo<T>(this IVector3<T> source, T input)
        {
            return source.RaisedTo<IVector3<T>, T, IVector3<T>>(input);
        }

        public static IVector3<T> Remainder<T>(this IVector3<T> source, T input)
        {
            return source.Remainder<IVector3<T>, T, IVector3<T>>(input);
        }

        public static IVector3<T> Times<T>(this IVector3<T> source, T input)
        {
            return source.Times<IVector3<T>, T, IVector3<T>>(input);
        }

        #endregion

        #region IVector4

        public static IVector4<T> DividedBy<T>(this IVector4<T> source, T input)
        {
            return source.DividedBy<IVector4<T>, T, IVector4<T>>(input);
        }

        public static IVector4<T> Minus<T>(this IVector4<T> source, T input)
        {
            return source.Minus<IVector4<T>, T, IVector4<T>>(input);
        }

        public static IVector4<T> Plus<T>(this IVector4<T> source, T input)
        {
            return source.Plus<IVector4<T>, T, IVector4<T>>(input);
        }

        public static IVector4<T> RaisedTo<T>(this IVector4<T> source, T input)
        {
            return source.RaisedTo<IVector4<T>, T, IVector4<T>>(input);
        }

        public static IVector4<T> Remainder<T>(this IVector4<T> source, T input)
        {
            return source.Remainder<IVector4<T>, T, IVector4<T>>(input);
        }

        public static IVector4<T> Times<T>(this IVector4<T> source, T input)
        {
            return source.Times<IVector4<T>, T, IVector4<T>>(input);
        }

        #endregion

        #endregion

        #region Select

        public static IVector<T2> Select<T1, T2>(this IVector<T1> source, Func<T1, T2> selector)
        {
            return source.AsEnumerable().Select(selector).ToVector();
        }

        public static IVector2<T2> Select<T1, T2>(this IVector2<T1> source, Func<T1, T2> selector)
        {
            return source.AsEnumerable().Select(selector).ToVector2();
        }

        public static IVector3<T2> Select<T1, T2>(this IVector3<T1> source, Func<T1, T2> selector)
        {
            return source.AsEnumerable().Select(selector).ToVector3();
        }

        public static IVector4<T2> Select<T1, T2>(this IVector4<T1> source, Func<T1, T2> selector)
        {
            return source.AsEnumerable().Select(selector).ToVector4();
        }

        #endregion

        #region TNumber conversion functions

        public static IVector2<double> AsDoubles(this IVector2<float> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector3<double> AsDoubles(this IVector3<float> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector4<double> AsDoubles(this IVector4<float> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector<double> AsDoubles(this IVector<int> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector2<double> AsDoubles(this IVector2<int> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector3<double> AsDoubles(this IVector3<int> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector4<double> AsDoubles(this IVector4<int> f)
        {
            return f.Select(f2 => (double)f2);
        }

        public static IVector<float> AsFloats(this IVector<double> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector2<float> AsFloats(this IVector2<double> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector3<float> AsFloats(this IVector3<double> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector4<float> AsFloats(this IVector4<double> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector<float> AsFloats(this IVector<int> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector2<float> AsFloats(this IVector2<int> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector3<float> AsFloats(this IVector3<int> f)
        {
            return f.Select(f2 => (float)f2);
        }

        public static IVector4<float> AsFloats(this IVector4<int> f)
        {
            return f.Select(f2 => (float)f2);
        }

        #endregion TNumber conversion functions

        #region Vector creation functions

        public static IVector<T> ToVector<T>(this IEnumerable<T> values)
        {
            return new Vector<T>(values.ToArray());
        }

        public static IVector<T> ToVector<T>(this T[] values)
        {
            return new Vector<T>(values);
        }

        public static IVector2<T> ToVector2<T>(this IEnumerable<T> values)
        {
            return Vector2.Create(values);
        }

        public static IVector2<T> ToVector2<T>(this T[] values)
        {
            return Vector2.Create(values);
        }

        public static IVector3<T> ToVector3<T>(this IEnumerable<T> values)
        {
            return Vector3.Create(values);
        }

        public static IVector3<T> ToVector3<T>(this T[] values)
        {
            return Vector3.Create(values);
        }

        public static IVector3<T> ToVector3<T>(this IEnumerable<T> values, T z)
        {
            return Vector3.Create(values, z);
        }

        public static IVector3<T> ToVector3<T>(this T[] values, T z)
        {
            return Vector3.Create(values, z);
        }

        public static IVector4<T> ToVector4<T>(this IEnumerable<T> values)
        {
            return Vector4.Create(values);
        }

        public static IVector4<T> ToVector4<T>(this T[] values)
        {
            return Vector4.Create(values);
        }

        public static IVector4<T> ToVector4<T>(this IEnumerable<T> values, params T[] rest)
        {
            return Vector4.Create(values, rest);
        }

        public static IVector4<T> ToVector4<T>(this T[] values, params T[] rest)
        {
            return Vector4.Create(values, rest.AsEnumerable());
        }

        #endregion

        #region Vector extension methods

        public static IVector3<TNumber> CrossProduct<TNumber>(this IVector3<TNumber> u, IVector3<TNumber> v)
        {
            return Vector3.Create(u[1].Times(v[2]).Minus(u[2].Times(v[1])),
                                 u[2].Times(v[0]).Minus(u[0].Times(v[2])),
                                 u[0].Times(v[1]).Minus(u[1].Times(v[0])));
        }

        public static IVector<TNumber> CrossProduct<TNumber>(this IVector<TNumber> u, IVector<TNumber> v)
        {
            return Vector.Create(u[1].Times(v[2]).Minus(u[2].Times(v[1])),
                                 u[2].Times(v[0]).Minus(u[0].Times(v[2])),
                                 u[0].Times(v[1]).Minus(u[1].Times(v[0])));
        }

        #endregion

        #region Normalize

        public static IEnumerable<TNumber> Normalize<TNumber>(this IEnumerable<TNumber> v)
        {
            TNumber length = v.LengthSquared().Sqrt();
            return v.Select(el => el.DividedBy(length));
        }

        public static IVector<TNumber> Normalize<TNumber>(this IVector<TNumber> v)
        {
            TNumber length = v.LengthSquared().Sqrt();
            return v.DividedBy<IVector<TNumber>, TNumber, IVector<TNumber>>(length);
        }

        public static IVector2<TNumber> Normalize<TNumber>(this IVector2<TNumber> v)
        {
            TNumber length = v.LengthSquared().Sqrt();
            return v.DividedBy<IVector2<TNumber>, TNumber, IVector2<TNumber>>(length);
        }

        public static IVector3<TNumber> Normalize<TNumber>(this IVector3<TNumber> v)
        {
            TNumber length = v.LengthSquared().Sqrt();
            return v.DividedBy<IVector3<TNumber>, TNumber, IVector3<TNumber>>(length);
        }

        #endregion

        #region Vector-related IEnumerable extension methods

        public static TNumber LengthSquared<TNumber>(this IEnumerable<TNumber> v)
        {
            return v.Select(t => t.Times(t)).Aggregate((t1, t2) => t1.Plus(t2));
        }

        public static TNumber DotProduct<TNumber>(this IEnumerable<TNumber> u, IEnumerable<TNumber> v)
        {
            var sum = 0.ConvertTo<int, TNumber>();
            foreach (var elements in u.Zip(v, (Element1, Element2) => new { Element1, Element2 }))
            {
                sum = sum.Plus(elements.Element1.Times(elements.Element2));
            }
            return sum;
        }

        public static TNumber ScalarProjection<TNumber>(this IEnumerable<TNumber> a, IEnumerable<TNumber> b)
        {
            return a.DotProduct(b).DividedBy(b.LengthSquared().Sqrt());
        }

        #endregion
    }
}
