// <copyright file="ImplicitUseAttribute.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;

namespace Lsquared.ComponentModel.ViewModels
{
    /// <summary>
    /// Represents the implcit use attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
    internal class ImplicitUseAttribute : Attribute
    {
    }
}
