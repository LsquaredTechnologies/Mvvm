// <copyright file="DisposableObject.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Runtime.InteropServices;

namespace Lsquared.ComponentModel
{
    public class DisposableObject : IDisposable
    {
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

        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        #region Initializers

        public DisposableObject()
        {
            // NO-OP
        }

        #endregion

        #region Finalizer

        ~DisposableObject()
        {
            Dispose(false);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        protected virtual void DisposeManagedResources()
        {
        }

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
