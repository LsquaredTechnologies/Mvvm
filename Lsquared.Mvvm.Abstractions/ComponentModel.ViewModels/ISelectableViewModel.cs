// <copyright file="ISelectableViewModel.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

namespace Lsquared.ComponentModel.ViewModels
{
    public interface ISelectableViewModel: IViewModel
    {
        bool IsSelected
        {
            get; set;
        }
    }
}
