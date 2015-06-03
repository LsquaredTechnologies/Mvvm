// <copyright file="ILifetimeViewModel.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.ComponentModel;

namespace Lsquared.ComponentModel.ViewModels
{
    public interface ILifetimeViewModel : IDisposable
    {
        event EventHandler Activated;

        event EventHandler Closed;

        event CancelEventHandler Closing;

        event EventHandler Disposed;
    }
}
