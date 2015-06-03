// <copyright file="ViewModel`1.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Diagnostics.Contracts;

namespace Lsquared.ComponentModel.ViewModels
{
    /// <summary>
    /// Represents a view-model with a specific model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    [Obsolete("Use ItemViewModel instead")]
    public abstract partial class ViewModel<TModel> : SelectableViewModel, IEquatable<ViewModel<TModel>>
        where TModel : class
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is modified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is changed; otherwise, <c>false</c>.
        /// </value>
        [PropertyChanged.DoNotSetChanged]
        public bool IsChanged { get; protected set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        [PropertyChanged.DoNotNotify, PropertyChanged.DoNotSetChanged]
        public TModel Model { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemViewModel{TModel}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        protected ViewModel(TModel model)
        {
            this.Model = model;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as ViewModel<TModel>;
            if (other == null) { return false; }
            return this.Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(ViewModel<TModel> other)
        {
            if (other == null) { return false; }
            return this.Model.Equals(other.Model);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Lsquared.ComponentModel.ViewModels.ViewModel{TModel}"/> to TModel.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TModel(ViewModel<TModel> value)
        {
            Contract.Requires(value != null);

            return value.Model;
        }

        protected virtual void OnModelChanged()
        {
        }

        protected virtual void OnModelChanging()
        {
        }
    }
}
