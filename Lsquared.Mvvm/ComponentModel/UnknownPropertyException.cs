// <copyright file="UnknownPropertyException.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Lsquared.ComponentModel
{
#if DEBUG

    [Serializable]
    public sealed class UnknownPropertyException : Exception
    {
        public string TypeName { get; private set; }

        public string PropertyName { get; private set; }

        public UnknownPropertyException()
        {
        }

        public UnknownPropertyException(string message)
            : base(message)
        {
        }

        public UnknownPropertyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UnknownPropertyException(string typeName, string propertyName)
        {
            TypeName = typeName;
            PropertyName = propertyName;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }

#endif
}
