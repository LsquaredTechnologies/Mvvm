// <copyright file="IItemViewModel`1.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;

namespace Lsquared.ComponentModel.ViewModels
{
    public interface IItemViewModel<T> : IItemViewModel, IEquatable<T>
         where T : class
    {
        new T Model
        {
            get; set;
        }
    }
}
