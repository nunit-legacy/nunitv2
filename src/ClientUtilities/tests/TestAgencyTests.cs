// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnit.Core;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace NUnit.Util.Tests
{
    [TestFixture]
    public class TestAgencyTests
    {
        private TestAgency agency;

        [SetUp]
        public void CreateAgency()
        {
            agency = new TestAgency("TempTestAgency", 0);
            agency.Start();
        }

        [TearDown]
        public void StopAgency()
        {
            agency.Stop();
        }

        [Test]
        public void CanConnectToAgency()
        {
            object obj = Activator.GetObject(typeof(TestAgency), agency.ServerUrl);
            Assert.IsNotNull(obj);
            Assert.That(obj is TestAgency);
        }

        [Test, Platform(Exclude="Mono")]
        public void CanLaunchAndConnectToAgent()
        {
            TestAgent agent = null;
            try
            {
                agent = agency.GetAgent(10000);
                Assert.IsNotNull(agent);
            }
            finally
            {
                if ( agent != null )
                    agency.ReleaseAgent(agent);
            }
        }

        [Test]
        public void Agent_X86_Is32Bit()
        {
            var agentPath = Path.Combine(NUnitConfiguration.NUnitBinDirectory, "nunit-agent-x86.exe");
            var agentAssembly = AssemblyName.GetAssemblyName(agentPath);

            Assert.That(agentAssembly.ProcessorArchitecture, Is.EqualTo(ProcessorArchitecture.X86));
        }

        // TODO: Decide if we really want to do this
        //[Test]
        public void CanReuseReleasedAgents()
        {
            TestAgent agent1 = agency.GetAgent(20000);
            Guid id1 = agent1.Id;
            agency.ReleaseAgent(agent1);
            TestAgent agent2 = agency.GetAgent(20000);
            Assert.AreEqual(id1, agent2.Id);
        }
    }
}
