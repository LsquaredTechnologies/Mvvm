// <copyright file="ITreeItemViewModel`1.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System.Collections.Generic;

namespace Lsquared.ComponentModel.ViewModels
{
    public interface ITreeItemViewModel<T> : IItemViewModel<T>, ITreeItemViewModel
        where T : class
    {
        new ITreeItemViewModel<T> Parent
        {
            get;
        }

        new IReadOnlyCollection<ITreeItemViewModel<T>> Children
        {
            get;
        }
    }
}
