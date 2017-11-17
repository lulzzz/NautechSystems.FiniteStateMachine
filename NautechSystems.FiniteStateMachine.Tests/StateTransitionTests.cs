// -------------------------------------------------------------------------------------------------
// <copyright file="StateTransitionTests.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteStateMachine
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using NautechSystems.FiniteStateMachine.TestKit;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class StateTransitionTests
    {
        [Fact]
        public void IndexDictionary_WithExampleStateTransition_ReturnsExpectedValue()
        {
            // Arrange
            var stateTransitionTable = new Dictionary<StateTransition, Enum>
                                           {
                                               { new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted), OrderStatus.Accepted }
                                           };

            // Act
            var result = stateTransitionTable[new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted)];

            // Assert
            Assert.Equal(OrderStatus.Accepted, result);
        }

        [Fact]
        public void ContainsKey_WithExampleTransitionTable_ReturnsTrue()
        {
            // Arrange
            var stateTransitionTable = new Dictionary<StateTransition, Enum>
            {
                { new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted), OrderStatus.Accepted }
            };

            // Act
            var result = stateTransitionTable.ContainsKey(new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_WhenStateTransitionsShouldBeEqual_ReturnsTrue()
        {
            // Arrange
            var stateTransition1 = new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted);
            var stateTransition2 = new StateTransition(OrderStatus.Initialized, OrderEvent.Accepted);
            var stateTransition3 = new StateTransition(OrderStatus.Accepted, OrderEvent.Working);

            // Act
            var result1 = stateTransition1.Equals(stateTransition2);
            var result2 = stateTransition1 == stateTransition2;
            var result3 = stateTransition1.GetHashCode() == stateTransition2.GetHashCode();
            var result4 = stateTransition1 != stateTransition3;

            // Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
        }
    }
}