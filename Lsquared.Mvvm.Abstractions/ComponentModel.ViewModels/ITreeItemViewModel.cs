// <copyright file="ITreeItemViewModel.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System.Collections.Generic;

namespace Lsquared.ComponentModel.ViewModels
{
    public interface ITreeItemViewModel : IItemViewModel
    {
        int Level
        {
            get;
        }

        bool IsExpanded
        {
            get; set;
        }

        ITreeItemViewModel Parent
        {
            get;
        }

        IReadOnlyCollection<ITreeItemViewModel> Children
        {
            get;
        }
    }
}
