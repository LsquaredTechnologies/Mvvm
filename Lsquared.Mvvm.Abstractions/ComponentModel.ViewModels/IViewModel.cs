// <copyright file="IViewModel.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;

namespace Lsquared.ComponentModel.ViewModels
{
    public interface IViewModel: IDisposable
    {
        string DisplayName
        {
            get;
        }
    }
}
