// <copyright file="ImplicitUseAttribute.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;

namespace Lsquared.ComponentModel.ViewModels
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
    public class ImplicitUseAttribute : Attribute
    {
    }
}
