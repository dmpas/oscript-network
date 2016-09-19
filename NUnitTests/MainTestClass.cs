using System;
using System.IO;
using NUnit.Framework;
using ScriptEngine.HostedScript;
using ScriptEngine.Machine;
using ScriptEngine.Environment;
using OneScriptNetwork;
using System.Net.NetworkInformation;

// Используется NUnit 3.6

namespace NUnitTests
{
    [TestFixture]
    public class MainTestClass
    {

        private EngineHelpWrapper host;

        [OneTimeSetUp]
        public void Initialize()
        {
            host = new EngineHelpWrapper();
            host.StartEngine();
        }

        [Test]
        public void TestAsInternalObjects()
        {

			var statusEnum = GlobalsManager.GetEnum<PingStatusEnumImpl>();

			var ping = PingImpl.Constructor() as PingImpl;
			{
				var reply = ping.Send("localhost", ValueFactory.Create(5));
				Assert.AreEqual(reply.Status, statusEnum.FromNativeValue(IPStatus.Success));
			}
			{
				var reply = ping.Send("localhost");
				Assert.AreEqual(reply.Status, statusEnum.FromNativeValue(IPStatus.Success));
			}
		}

        [Test]
        public void TestAsExternalObjects()
        {
            host.RunTestScript("NUnitTests.Tests.external.os");
        }
    }
}
