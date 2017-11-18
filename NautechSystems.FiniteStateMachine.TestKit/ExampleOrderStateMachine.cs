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
            var stateTransitionTable = new Dictionary<StateTransition, State>
            {
                { new StateTransition(new State(OrderStatus.Initialized), new Trigger(OrderEvent.Accepted)), new State(OrderStatus.Accepted) },
                { new StateTransition(new State(OrderStatus.Initialized), new Trigger(OrderEvent.Rejected)), new State(OrderStatus.Rejected) },
                { new StateTransition(new State(OrderStatus.Accepted), new Trigger(OrderEvent.Working)), new State(OrderStatus.Working) },
                { new StateTransition(new State(OrderStatus.Working), new Trigger(OrderEvent.Cancelled)), new State(OrderStatus.Cancelled) },
                { new StateTransition(new State(OrderStatus.Working), new Trigger(OrderEvent.Expired)), new State(OrderStatus.Expired) },
                { new StateTransition(new State(OrderStatus.Working), new Trigger(OrderEvent.Filled)), new State(OrderStatus.Filled) },
                { new StateTransition(new State(OrderStatus.Working), new Trigger(OrderEvent.PartiallyFilled)), new State(OrderStatus.PartiallyFilled) },
                { new StateTransition(new State(OrderStatus.PartiallyFilled), new Trigger(OrderEvent.PartiallyFilled)), new State(OrderStatus.PartiallyFilled) },
                { new StateTransition(new State(OrderStatus.PartiallyFilled), new Trigger(OrderEvent.Filled)), new State(OrderStatus.Filled) }
            };

            return new FiniteStateMachine(stateTransitionTable, new State(OrderStatus.Initialized));
        }
    }
}