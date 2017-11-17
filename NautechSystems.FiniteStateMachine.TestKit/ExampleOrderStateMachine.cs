// -------------------------------------------------------------------------------------------------
// <copyright file="ExampleOrderStateMachine.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteStateMachine
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine.TestKit
{
    using System;
    using System.Collections.Generic;
    using NautechSystems.CSharp.Annotations;

    /// <summary>
    /// The immutable static <see cref="ExampleOrderStateMachine"/> class.
    /// </summary>
    [Immutable]
    public static class ExampleOrderStateMachine
    {
        /// <summary>
        /// Returns a <see cref="FiniteStateMachine"/> which represents a generic order.
        /// </summary>
        /// <returns>A <see cref="FiniteStateMachine"/>.</returns>
        public static FiniteStateMachine Create()
        {
            var stateTransitionTable = new Dictionary<StateTransition, Enum>
            {
                { new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted), OrderStatus.Accepted },
                { new StateTransition(OrderStatus.Initialized, OrderEvent.Rejected), OrderStatus.Rejected },
                { new StateTransition(OrderStatus.Accepted, OrderEvent.Working), OrderStatus.Working },
                { new StateTransition(OrderStatus.Working, OrderEvent.Cancelled), OrderStatus.Cancelled },
                { new StateTransition(OrderStatus.Working, OrderEvent.Expired), OrderStatus.Expired },
                { new StateTransition(OrderStatus.Working, OrderEvent.Filled), OrderStatus.Filled },
                { new StateTransition(OrderStatus.Working, OrderEvent.PartiallyFilled), OrderStatus.PartiallyFilled },
                { new StateTransition(OrderStatus.PartiallyFilled, OrderEvent.PartiallyFilled), OrderStatus.PartiallyFilled },
                { new StateTransition(OrderStatus.PartiallyFilled, OrderEvent.Filled), OrderStatus.Filled }
            };

            return new FiniteStateMachine(stateTransitionTable, OrderStatus.Initialized);
        }
    }
}