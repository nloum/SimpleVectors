using System;

namespace SimpleVectors
{
    internal class TypeValue
    {
        public Type Type { get; }
        public int Indirection { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public TypeValue(Type type, int indirection)
        {
            this.Type = type;
            this.Indirection = indirection;
        }
    }
}