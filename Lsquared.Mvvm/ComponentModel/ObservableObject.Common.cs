// <copyright file="ObservableObject.Common.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System.Diagnostics;

namespace Lsquared.ComponentModel
{
    /// <content>
    /// Contains partial methods for full .Net framework.
    /// </content>
    partial class ObservableObject
    {
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        partial void VerifyPropertyName(string propertyName)
        {
            var type = GetType();
            if (propertyName != ObservableObject.All && !string.IsNullOrEmpty(propertyName) && type.GetProperty(propertyName) == null)
            {
                throw new UnknownPropertyException(type.Name, propertyName);
            }
        }
    }
}
