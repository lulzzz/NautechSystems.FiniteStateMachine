// -------------------------------------------------------------------------------------------------
// <copyright file="OrderEvent.cs" company="Nautech Systems Pty Ltd.">
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
    public enum OrderEvent
    {
        Rejected = 1,

        Accepted = 2,

        Working = 3,

        Cancelled = 4,

        Expired = 5,

        Filled = 6,

        PartiallyFilled = 7
    }
}