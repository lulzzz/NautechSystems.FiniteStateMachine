﻿// -------------------------------------------------------------------------------------------------
// <copyright file="StateTests.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteStateMachine
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NautechSystems.FiniteStateMachine.TestKit;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class StateTests
    {
        [Fact]
        public void Equals_VariousStateTransitionsAndOperators_TestsCorrectly()
        {
            // Arrange
            var state1 = new State(OrderStatus.Initialized);
            var state2 = new State("Initialized");
            var state3 = new State(OrderStatus.Accepted);

            // Act
            var result1 = state1.Equals(state2);
            var result2 = !state1.Equals(state3);
            var result3 = !state1.Equals((object)state3);
            var result4 = state1 == state2;
            var result5 = state1 != state3;
            var result6 = state1.GetHashCode() == state2.GetHashCode();

            // Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
            Assert.True(result5);
            Assert.True(result6);
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedInt()
        {
            // Arrange
            var state = new State(OrderStatus.Initialized);

            // Act
            var result = state.GetHashCode();

            // Assert
            Assert.Equal(typeof(int), result.GetType());
        }

        [Fact]
        public void ToString_ReturnsExpectedString()
        {
            // Arrange
            var state = new State(OrderStatus.Initialized);

            // Act
            var result = state.ToString();

            // Assert
            Assert.Equal("Initialized", result);
        }
    }
}
