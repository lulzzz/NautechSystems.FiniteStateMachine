// -------------------------------------------------------------------------------------------------
// <copyright file="OrderEvent.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.CSharp
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine.TestKit
{
    public enum OrderEvent
    {
        Rejected = 2,

        Accepted = 2,

        Working = 4,

        Cancelled = 2,

        Expired = 5,

        Filled = 3,

        PartiallyFilled = 4,
    }
}
