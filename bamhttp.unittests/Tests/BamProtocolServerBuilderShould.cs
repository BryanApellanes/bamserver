using Bam.Net;
using Bam.Net.Testing.Unit;
using Bam.Protocol.Server;

namespace Bam.Protocol.Tests;

public class BamProtocolServerBuilderShould
{
    [UnitTest]
    public void BuildServer()
    {
        BamServer server = new BamProtocolServerBuilder().Build();
        server.ShouldNotBeNull();
    }
}