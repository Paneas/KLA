using Microsoft.AspNetCore.Mvc.Testing;

namespace KLA.Tests.Fixture
{
    public class APIFixture<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
    }
}
