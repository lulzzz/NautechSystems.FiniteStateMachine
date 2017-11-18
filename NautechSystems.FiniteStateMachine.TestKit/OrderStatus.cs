// -------------------------------------------------------------------------------------------------
// <copyright file="OrderStatus.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteStateMachine
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine.TestKit
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum OrderStatus
    {
        Unknown = 0,

        Initialized = 1,

        Rejected = 2,

        Accepted = 3,

        Working = 4,

        Cancelled = 5,

        Expired = 6,

        Filled = 7,

        PartiallyFilled = 8
    }
}