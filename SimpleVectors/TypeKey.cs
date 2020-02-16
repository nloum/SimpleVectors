using System;
using System.Reflection;

namespace SimpleVectors
{
    internal class TypeKey
    {
        public Type Type { get; }

        public TypeKey(Type type)
        {
            this.Type = type;
            this.GetFriendlyName();
        }

        public string GetFriendlyName()
        {
            var type = Type.GetTypeInfo();

            string friendlyName = type.Name;
            if (type.IsGenericType)
            {
                int iBacktick = friendlyName.IndexOf('`');
                if (iBacktick > 0)
                {
                    friendlyName = friendlyName.Remove(iBacktick);
                }
                friendlyName += "<";
                var a = type.IsGenericType;
                var b = type.IsGenericTypeDefinition;
                Type[] typeParameters = type.GenericTypeArguments;
                if (type.GenericTypeParameters.Length > typeParameters.Length) typeParameters = type.GenericTypeParameters;
                for (int i = 0; i < typeParameters.Length; ++i)
                {
                    string typeParamName = typeParameters[i].Name;
                    friendlyName += (i == 0 ? typeParamName : "," + typeParamName);
                }
                friendlyName += ">";
            }

            return friendlyName;
        }

        public string Identifier => $"{Type.Namespace}.{GetFriendlyName()}";

        protected bool Equals(TypeKey other)
        {
            return string.Equals(this.Identifier, other.Identifier);
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
            return Equals((TypeKey)obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.Identifier != null ? this.Identifier.GetHashCode() : 0);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Identifier;
        }
    }
}