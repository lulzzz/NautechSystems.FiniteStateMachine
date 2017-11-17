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
            Assert.Equal(OrderStatus.Initialized, result);
        }

        [Fact]
        public void Process_WithValidTrigger_ReturnsExpectedState()
        {
            // Arrange
            var stateMachine = ExampleOrderStateMachine.Create();

            // Act
            var result = stateMachine.Process(OrderEvent.Accepted);

            // Assert
            //Assert.True(result.IsSuccess);
            Assert.Equal(OrderStatus.Accepted, stateMachine.CurrentState);
        }
    }
}