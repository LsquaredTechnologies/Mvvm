// <copyright file="ViewModel.cs" company="LSQUARED">
// Copyright © 2008-2014
// </copyright>

using System;
using System.Globalization;

namespace Lsquared.ComponentModel.ViewModels
{
    public abstract class ViewModel : ObservableObject, IViewModel, IDisposable
    {
        /// <summary>
        /// Gets the user-friendly name of this object.
        /// </summary>
        /// <remarks>
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </remarks>
        public virtual string DisplayName { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        protected ViewModel()
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ViewModel"/> class.
        /// </summary>
        ~ViewModel()
        {
#if DEBUG
            var msg = string.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2} finalized!", this.GetType().Name, this.DisplayName, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
#endif
            Dispose(false);
        }

        /// <summary>
        /// Notifies inherited classes when DisplayName has changed.
        /// </summary>
        [ImplicitUse]
        protected virtual void OnDisplayNameChanged()
        {
        }

        /// <summary>
        /// Notifies inherited classes when DisplayName is about to change.
        /// </summary>
        [ImplicitUse]
        protected virtual void OnDisplayNameChanging()
        {
        }
    }
}
