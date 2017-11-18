// -------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachine.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteStateMachine
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine
{
    using System;
    using System.Collections.Generic;
    using NautechSystems.CSharp;
    using NautechSystems.CSharp.Validation;

    /// <summary>
    /// The <see cref="FiniteStateMachine"/> class.
    /// </summary>
    public class FiniteStateMachine
    {
        private readonly Dictionary<StateTransition, State> stateTransitionTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="FiniteStateMachine"/> class.
        /// </summary>
        /// <param name="stateTransitionTable">The state transition table.</param>
        /// <param name="startingState">The starting state.</param>
        /// <exception cref="ArgumentNullException">Throws if either argument is null.</exception>
        /// <exception cref="ArgumentException">Throws if the collection is empty.</exception>
        public FiniteStateMachine(
            Dictionary<StateTransition, State> stateTransitionTable, 
            State startingState)
        {
            Validate.CollectionNotNullOrEmpty(stateTransitionTable, nameof(stateTransitionTable));
            Validate.NotNull(startingState, nameof(startingState));

            this.stateTransitionTable = stateTransitionTable;
            this.CurrentState = startingState;
        }

        /// <summary>
        /// Gets the current <see cref="State"/>.
        /// </summary>
        public State CurrentState { get; private set; }

        /// <summary>
        /// Processes the state machine with the given trigger
        /// </summary>
        /// <param name="trigger">The trigger.</param>
        /// <returns>A command result.</returns>
        /// <exception cref="ArgumentNullException">Throws if the trigger is null.</exception>
        public Command Process(Trigger trigger)
        {
            Validate.NotNull(trigger, nameof(trigger));

            var stateTransition = new StateTransition(this.CurrentState, trigger);

            if (this.IsValidStateTransition(stateTransition))
            {
                this.ChangeStateTo(this.stateTransitionTable[stateTransition]);

                return Command.Ok();
            }

            return Command.Fail($"Invalid State Transition ({this.CurrentState} -> {trigger})");
        }

        private bool IsValidStateTransition(StateTransition transition) => this.stateTransitionTable.ContainsKey(transition);

        private void ChangeStateTo(State state)
        {
            Debug.NotNull(state, nameof(state));

            this.CurrentState = state;
        }
    }
}