// -------------------------------------------------------------------------------------------------
// <copyright file="StateTransition.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.CSharp
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine
{
    using System;
    using NautechSystems.CSharp.Annotations;
    using NautechSystems.CSharp.Validation;

    /// <summary>
    /// The immutable <see cref="StateTransition"/> structure.
    /// </summary>
    [Immutable]
    public class StateTransition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateTransition"/> class.
        /// </summary>
        /// <param name="currentState">The current state.</param>
        /// /// <param name="trigger">The trigger.</param>
        public StateTransition(Enum currentState, Enum trigger)
        {
            Validate.NotNull(currentState, nameof(currentState));
            Validate.NotNull(trigger, nameof(trigger));

            this.CurrentState = currentState;
            this.Trigger = trigger;
        }

        /// <summary>
        /// Gets the current state.
        /// </summary>
        public Enum CurrentState { get; }

        /// <summary>
        /// Gets the trigger.
        /// </summary>
        public Enum Trigger { get; }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            return obj is StateTransition other 
                && this.CurrentState == other.CurrentState 
                && this.Trigger == other.Trigger;
        }

        /// <summary>
        /// Returns the hash code of this <see cref="StateTransition"/>.
        /// </summary>
        /// <returns>An <see cref="int"/>.</returns>
        public override int GetHashCode()
        {
            return 17 + (31 * this.CurrentState.GetHashCode()) + (31 * this.Trigger.GetHashCode());
        }

        /// <summary>
        /// Returns a string representation of the <see cref="StateTransition"/>.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString() => $"{nameof(StateTransition)}: {this.CurrentState} -> {this.Trigger}";
    }
}