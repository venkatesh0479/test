using App.Logger;
using Moq;
using System;
using Xunit;

namespace AppLoggerUnitTestCore
{
    public class AppLoggerUnitTest
    {
        [Fact]
        public void TestLogDetailsWhat()
        {
            //Parameters
            var eventID = new Microsoft.Extensions.Logging.EventId(100, "Test Event ID");
            var appLayer = "Test Layer";
            var productInfo = "Test App";
            var location = "Test Layer";
            var hostName = "Test Host Name";

            var logDetails = new Mock<ILogDetails>();
            logDetails.SetupGet(eventdetails => eventdetails.EventID).
                Returns(eventID);

            logDetails.SetupGet(layer => layer.Layer).Returns(appLayer);
            logDetails.SetupGet(product => product.Product).Returns(productInfo);
            logDetails.SetupGet(location => location.Location).Returns(location);
            logDetails.SetupGet(hostName => hostName.HostName).Returns(hostName);

            Assert.Equal(eventID.Id, logDetails.Object.EventID.Id);
            Assert.Equal(eventID.Name, logDetails.Object.EventID.Name);
            Assert.Equal(appLayer, logDetails.Object.Layer);
            Assert.Equal(productInfo, logDetails.Object.Product);
            Assert.Equal(hostName, logDetails.Object.HostName);
        }
    }
}
