using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleVectors
{
    public static class VectorUtility
    {
        public static void Initialize()
        {
            RegisterImplementation(typeof(Vector<>));
            RegisterImplementation(typeof(Vector2<>));
            RegisterImplementation(typeof(Vector2<,>));
            RegisterImplementation(typeof(Vector3<>));
            RegisterImplementation(typeof(Vector3<,>));
            RegisterImplementation(typeof(Vector3<,,>));
        }

        internal static Dictionary<TypeKey, TypeValue> Implementations { get; } = new Dictionary<TypeKey, TypeValue>();

        private static readonly TypeInfo _vector = typeof(IVector<,>).GetTypeInfo();

        public static void RegisterImplementation(Type type)
        {
            var typeInfo = type.GetGenericTypeDefinition().GetTypeInfo();
            foreach (var iface in typeInfo.ImplementedInterfaces)
            {
                RegisterImplementation(type, iface, 1);
            }
        }

        private static void RegisterImplementation(Type type, Type iface, int indirection)
        {
            var ifaceTypeInfo = iface.GetTypeInfo();
            if (!ifaceTypeInfo.IsGenericType && !ifaceTypeInfo.IsGenericTypeDefinition)
                return;
            var key = new TypeKey(iface.GetGenericTypeDefinition());
            //if (!_vector.IsAssignableFrom(iface.GetTypeInfo())) continue;
            if (Implementations.ContainsKey(key))
            {
                if (Implementations[key].Indirection > indirection)
                    Implementations[key] = new TypeValue(type, indirection);
            }
            else
            {
                Implementations.Add(key, new TypeValue(type, indirection));
            }

            foreach (var subInterface in ifaceTypeInfo.ImplementedInterfaces)
            {
                RegisterImplementation(type, subInterface, indirection + 1);
            }
        }
    }

    public static class VectorUtil<TVector, TNumber>
    {
        private static Func<TNumber[], TVector> _creator;

        static VectorUtil()
        {
            var vector = typeof(TVector);
            var vectorTypeInfo = vector.GetTypeInfo();
            var number = typeof(TNumber);
            var numberTypeInfo = number.GetTypeInfo();
            var numberArray = number.MakeArrayType();
            var numberArrayTypeInfo = numberArray.GetTypeInfo();

            var key = new TypeKey(vector.GetGenericTypeDefinition());

            if (VectorUtility.Implementations.ContainsKey(key))
                vectorTypeInfo = VectorUtility.Implementations[key].Type.MakeGenericType(number).GetTypeInfo();

            var theConstructor = vectorTypeInfo.DeclaredConstructors.First();

            var parameter = Expression.Parameter(numberArray);
            
            var @new = Expression.New(theConstructor, parameter);
            var result = Expression.Lambda(@new, parameter);
            _creator = (Func<TNumber[], TVector>)result.Compile();
        }

        public static TVector Create(IEnumerable<TNumber> numbers)
        {
            return Create(numbers.ToArray());
        }

        public static TVector Create(params TNumber[] numbers)
        {
            return _creator(numbers);
        }
    }
}
