// <copyright file="UnknownPropertyException.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Lsquared.ComponentModel
{
    /// <summary>
    /// Represents the unknown property exception.
    /// </summary>
    [Serializable]
    public sealed class UnknownPropertyException : Exception
    {
        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownPropertyException"/> class.
        /// </summary>
        public UnknownPropertyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownPropertyException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnknownPropertyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownPropertyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public UnknownPropertyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownPropertyException"/> class.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="propertyName">Name of the property.</param>
        public UnknownPropertyException(string typeName, string propertyName)
        {
            TypeName = typeName;
            PropertyName = propertyName;
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
