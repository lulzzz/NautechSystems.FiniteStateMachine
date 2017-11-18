// -------------------------------------------------------------------------------------------------
// <copyright file="Trigger.cs" company="Nautech Systems Pty Ltd.">
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
    /// The immutable <see cref="Trigger"/> structure.
    /// </summary>
    [Immutable]
    public struct Trigger
    {
        private readonly string trigger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trigger"/> structure.
        /// </summary>
        /// <param name="trigger">The state.</param>
        public Trigger(string trigger)
        {
            Validate.NotNull(trigger, nameof(trigger));

            this.trigger = trigger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trigger"/> structure.
        /// </summary>
        /// <param name="trigger">The state.</param>
        public Trigger(Enum trigger)
        {
            Validate.NotNull(trigger, nameof(trigger));

            this.trigger = trigger.ToString();
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>A boolean.</returns>
        public static bool operator ==(Trigger left, Trigger right) => left.Equals(right);        

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>A boolean.</returns>
        public static bool operator !=(Trigger left, Trigger right) => !(left == right);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified <see cref="Trigger"/>.
        /// </summary>
        /// <param name="other">The other state.</param>
        /// <returns>A boolean.</returns>
        public bool Equals(Trigger other) => this.trigger == other.trigger;

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>A boolean.</returns>
        public override bool Equals(object obj) => obj is Trigger other && this.trigger == other.trigger;

        /// <summary>
        /// Returns the hash code of this <see cref="Trigger"/>.
        /// </summary>
        /// <returns>An <see cref="int"/>.</returns>
        public override int GetHashCode() => this.trigger.GetHashCode();

        /// <summary>
        /// Returns a string representation of the <see cref="Trigger"/>.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString() => this.trigger;
    }
}