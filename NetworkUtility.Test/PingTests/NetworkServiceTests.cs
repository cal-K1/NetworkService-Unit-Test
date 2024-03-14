using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NetworkUtility;
using Network_Utility_Unit_Test_Example.Ping;
using FluentAssertions;
using FakeItEasy;
using Xunit.Sdk;
using System.Net.WebSockets;
using System.Globalization;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;
using Network_Utility_Unit_Test_Example.DNS;

namespace NetworkUtility.Test.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS;
        public NetworkServiceTests()
        {
            // Dependencies
            // Using FakeItEasy to fake the interface to allow us to do our tests
            // Means we dont have to manually pass through the dns and fix everything
            _dNS = A.Fake<IDNS>();

            // SUT (System Under Test)
            _pingService = new NetworkService(_dNS);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            A.CallTo(() => _dNS.SendDNS()).Returns(true);

            // Act
            var result = _pingService.SendPing();

            // Assert 
            // Examples of nuget package FluentAssertions and what types of assertions it is capable of.
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]

        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            var pingService = new NetworkService(_dNS);

            // Act
            var result = pingService.PingTimeout(a, b);

            // Assert 
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsDateTime()
        {
            // Arrange
            // We dont need anything here as we made _pingService a global var in the constructor

            // Act
            var result = _pingService.LastPingDate();


            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsDateTime()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.GetPingOptions();

            // Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.MostRecentPings();

            // Assert
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }

    }
}
