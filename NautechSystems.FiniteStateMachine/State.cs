// -------------------------------------------------------------------------------------------------
// <copyright file="State.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteStateMachine
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
    /// The immutable <see cref="State"/> structure.
    /// </summary>
    [Immutable]
    public struct State
    {
        private readonly string state;

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> structure.
        /// </summary>
        /// <param name="state">The state.</param>
        public State(string state)
        {
            Validate.NotNull(state, nameof(state));

            this.state = state;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> structure.
        /// </summary>
        /// <param name="state">The state.</param>
        public State(Enum state)
        {
            Validate.NotNull(state, nameof(state));

            this.state = state.ToString();
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>A boolean.</returns>
        public static bool operator ==(State left, State right) => left.Equals(right);        

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>A boolean.</returns>
        public static bool operator !=(State left, State right) => !(left == right);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified <see cref="State"/>.
        /// </summary>
        /// <param name="other">The other state.</param>
        /// <returns>A boolean.</returns>
        public bool Equals(State other) => this.state == other.state;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>A boolean.</returns>
        public override bool Equals(object obj) => obj is State other && this.state == other.state;

        /// <summary>
        /// Returns the hash code of this <see cref="State"/>.
        /// </summary>
        /// <returns>An <see cref="int"/>.</returns>
        public override int GetHashCode() => this.state.GetHashCode();

        /// <summary>
        /// Returns a string representation of the <see cref="State"/>.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString() => this.state;
    }
}