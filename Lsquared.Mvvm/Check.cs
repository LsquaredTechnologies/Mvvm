// <copyright file="Check.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Lsquared
{
    internal static class Check
    {
        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void IsInRange(object[] array, int index, string arrayName, string indexName)
        {
            IsNotNull(array, arrayName);

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(indexName, "The index cannot be negative.");
            }
            if (index >= array.Length)
            {
                throw new ArgumentOutOfRangeException(indexName, "The index is outside the bounds of the array.");
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void IsNotEmpty(string parameter, string parameterName)
        {
            IsNotNull(parameter, parameterName);

            if (parameter.Length == 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "The string cannot be empty");
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void IsNotEmpty<T>(IEnumerable<T> parameter, string parameterName)
        {
            IsNotNull(parameter, parameterName);

            if (!parameter.Any())
            {
                throw new ArgumentOutOfRangeException(parameterName, "The index cannot be negative.");
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void IsNotNull<T>(T parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            Contract.EndContractBlock();
        }
    }
}
