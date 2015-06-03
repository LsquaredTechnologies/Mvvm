// <copyright file="SelectableViewModel.cs" company="LSQUARED">
// Copyright © 2008-2014
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Lsquared.ComponentModel.ViewModels
{
    public abstract partial class SelectableViewModel : ViewModel, ISelectableViewModel
    {
        /// <summary>
        /// Gets or sets whether view-model is in the selected state.
        /// </summary>
        /// <remarks>
        /// When this property is set to a new value, this object's
        /// PropertyChanged event is raised.
        /// </remarks>
        public bool IsSelected
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectableViewModel"/> class.
        /// </summary>
        protected SelectableViewModel()
        {
        }

        /// <summary>
        /// Selects or un-selects all items in the specified collection.
        /// </summary>
        /// <param name="source">The source collection where items will be selected or unselected.</param>
        /// <param name="isSelected">Whether view-model is in the selected state.</param>
        public static void SelectAll(IEnumerable<SelectableViewModel> source, bool isSelected)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            foreach (var option in source)
            {
                option.IsSelected = isSelected;
            }
        }

        /// <summary>
        /// Notifies inherited classes when IsSelected has changed.
        /// </summary>
        [ImplicitUse]
        protected virtual void OnIsSelectedChanged()
        {
        }

        /// <summary>
        /// Notifies inherited classes when IsSelected is about to change.
        /// </summary>
        [ImplicitUse]
        protected virtual void OnIsSelectedChanging()
        {
        }
    }
}
