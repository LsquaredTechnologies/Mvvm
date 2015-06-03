// <copyright file="ObservableObject.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Lsquared.ComponentModel
{
    /// <summary>
    /// Represents a base class for observable objects.
    /// </summary>
    public abstract partial class ObservableObject : DisposableObject, INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>
        /// All properties.
        /// </summary>
        public const string All = "*";

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangingEventHandler PropertyChanging;

        #region Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableObject"/> class.
        /// </summary>
        protected ObservableObject()
        {
        }

        #endregion

        /// <summary>
        /// Executes the property changed action.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = PropertyChanged;
            if (h == null) { return; }

            if (propertyName == ObservableObject.All)
            {
                // TODO Use PropertyHelper
                var type = GetType();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var names = from p in properties select p.Name;
                foreach (var name in names)
                {
                    h(this, new PropertyChangedEventArgs(name));
                }
            }
            else
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Executes the property changing action.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanging([CallerMemberName]string propertyName = null)
        {
            var h = PropertyChanging;
            if (h == null) { return; }

            if (propertyName == ObservableObject.All)
            {
                // TODO Use PropertyHelper
                var type = GetType();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var names = from p in properties select p.Name;
                foreach (var name in names)
                {
                    h(this, new PropertyChangingEventArgs(name));
                }
            }
            else
            {
                h(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        partial void VerifyPropertyName(string propertyName);
    }
}
