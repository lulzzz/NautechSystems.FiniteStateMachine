// -------------------------------------------------------------------------------------------------
// <copyright file="FiniteStateMachineTests.cs" company="Nautech Systems Pty Ltd.">
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
    public class FiniteStateMachineTests
    {
        [Fact]
        public void CurrentState_WithNewStateMachine_EqualsStartingState()
        {
            // Arrange
            var stateMachine = ExampleOrderStateMachine.Create();

            // Act
            var result = stateMachine.CurrentState;

            // Assert
            Assert.Equal(new State(OrderStatus.Initialized), result);
        }

        [Fact]
        public void Process_WithValidTrigger_ReturnsExpectedState()
        {
            // Arrange
            var stateMachine = ExampleOrderStateMachine.Create();

            // Act
            var result = stateMachine.Process(new Trigger(OrderEvent.Accepted));

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(new State(OrderStatus.Accepted), stateMachine.CurrentState);
        }

        [Fact]
        public void Process_WithInvalidTrigger_ReturnsFailure()
        {
            // Arrange
            var stateMachine = ExampleOrderStateMachine.Create();

            // Act
            var result = stateMachine.Process(new Trigger(OrderEvent.Working));

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Process_ThroughFullCycle_ReturnsExpectedState()
        {
            // Arrange
            var stateMachine = ExampleOrderStateMachine.Create();

            // Act
            stateMachine.Process(new Trigger(OrderEvent.Accepted));
            stateMachine.Process(new Trigger(OrderEvent.Working));
            stateMachine.Process(new Trigger(OrderEvent.PartiallyFilled));
            var result = stateMachine.Process(new Trigger(OrderEvent.Filled));

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(new State(OrderStatus.Filled), stateMachine.CurrentState);
        }

        [Fact]
        public void Process_MultipleValidTriggersThenInvalidTrigger_ReturnsFailure()
        {
            // Arrange
            var stateMachine = ExampleOrderStateMachine.Create();

            // Act
            stateMachine.Process(new Trigger(OrderEvent.Accepted));
            stateMachine.Process(new Trigger(OrderEvent.Working));
            stateMachine.Process(new Trigger(OrderEvent.PartiallyFilled));
            var result = stateMachine.Process(new Trigger(OrderEvent.Expired));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(new State(OrderStatus.PartiallyFilled), stateMachine.CurrentState);
        }
    }
}