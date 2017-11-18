// -------------------------------------------------------------------------------------------------
// <copyright file="TriggerTests.cs" company="Nautech Systems Pty Ltd.">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/nautechsystems/NautechSystems.FiniteTriggerMachine
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace NautechSystems.FiniteStateMachine.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using NautechSystems.FiniteStateMachine;
    using NautechSystems.FiniteStateMachine.TestKit;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]

    public class TriggerTests
    {

        [Fact]
        public void Equals_VariousTriggerTransitionsAndOperators_TestsCorrectly()
        {
            // Arrange
            var trigger1 = new Trigger(OrderEvent.Accepted);
            var trigger2 = new Trigger("Accepted");
            var trigger3 = new Trigger(OrderEvent.Working);

            // Act
            var result1 = trigger1.Equals(trigger2);
            var result2 = trigger1.Equals((object)trigger2);
            var result3 = !trigger1.Equals(trigger3);
            var result4 = trigger1 == trigger2;
            var result5 = trigger1 != trigger3;
            var result6 = trigger1.GetHashCode() == trigger2.GetHashCode();

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
            var trigger = new Trigger(OrderEvent.Cancelled);

            // Act
            var result = trigger.GetHashCode();

            // Assert
            Assert.Equal(typeof(int), result.GetType());
        }

        [Fact]
        public void ToString_ReturnsExpectedString()
        {
            // Arrange
            var trigger = new Trigger(OrderEvent.Working);

            // Act
            var result = trigger.ToString();

            // Assert
            Assert.Equal("Working", result);
        }
    }
}
