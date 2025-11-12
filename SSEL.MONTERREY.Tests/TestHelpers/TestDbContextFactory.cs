using Microsoft.EntityFrameworkCore;
using SSEL.MONTERREY.Infrastructure.Data;
using System;

namespace SSEL.MONTERREY.Tests.TestHelpers;

public static class TestDbContextFactory
{
    public static SSELContext Create()
    {
        var options = new DbContextOptionsBuilder<SSELContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new SSELContext(options);
    }
}
