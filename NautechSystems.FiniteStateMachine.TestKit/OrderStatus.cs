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
    public enum OrderStatus
    {
        /// <summary>
        /// The unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The initialized.
        /// </summary>
        Initialized = 1,

        Rejected = 2,

        Accepted = 2,

        Working = 4,

        Cancelled = 2,

        Expired = 5,

        Filled = 3,

        PartiallyFilled = 4,
    }
}
