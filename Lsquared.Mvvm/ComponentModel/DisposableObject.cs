// <copyright file="DisposableObject.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Runtime.InteropServices;

namespace Lsquared.ComponentModel
{
    /// <summary>
    /// Represents a base class for disposable objects.
    /// </summary>
    public class DisposableObject : IDisposable
    {
        /// <summary>
        /// Occurs when the instance is disposing.
        /// </summary>
        public event EventHandler Disposing
        {
            add
            {
                ThrowIfDisposed();
                _disposing += value;
            }
            remove
            {
                ThrowIfDisposed();
                _disposing -= value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        #region Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableObject"/> class.
        /// </summary>
        public DisposableObject()
        {
            // NO-OP
        }

        #endregion

        #region Finalizer

        /// <summary>
        /// Finalizes an instance of the <see cref="DisposableObject"/> class.
        /// </summary>
        ~DisposableObject()
        {
            Dispose(false);
        }

        #endregion

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposeManagedResources"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (!_isDisposed)
            {
                try
                {
                    _disposing.RaiseEvent(this);
                    _disposing = null;
                    if (disposeManagedResources)
                    {
                        DisposeManagedResources();
                    }

                    DisposeNativeResources();
                }
                finally
                {
                    _isDisposed = true;
                }
            }
        }

        /// <summary>
        /// Releases the managed resources.
        /// </summary>
        protected virtual void DisposeManagedResources()
        {
        }

        /// <summary>
        /// Releases the native resources.
        /// </summary>
        protected virtual void DisposeNativeResources()
        {
        }

        private void ThrowIfDisposed()
        {
            if (_isDisposed) { throw new ObjectDisposedException(GetType().Name); }
        }

        private bool _isDisposed = false;
        private EventHandler _disposing;
    }
}
