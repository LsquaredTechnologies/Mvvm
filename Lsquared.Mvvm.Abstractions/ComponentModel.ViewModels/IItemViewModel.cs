// <copyright file="IItemViewModel.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System.ComponentModel;

namespace Lsquared.ComponentModel.ViewModels
{
    public interface IItemViewModel : ISelectableViewModel, INotifyDataErrorInfo, IEditableObject
    {
        object Model
        {
            get; set;
        }

        bool IsChanged
        {
            get; set;
        }

        bool IsDeleting
        {
            get; set;
        }
    }
}
