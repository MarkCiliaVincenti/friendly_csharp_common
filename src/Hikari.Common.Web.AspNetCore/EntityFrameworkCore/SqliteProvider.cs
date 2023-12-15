﻿using Microsoft.EntityFrameworkCore;

namespace Hikari.Common.Web.AspNetCore.EntityFrameworkCore;

internal class SqliteProvider
{
    public static DbContextOptionsBuilder Use(DbContextOptionsBuilder options, string connectionString, string assemblyName)
    {
        return options.UseSqlite(connectionString,
                    builder => { builder.MigrationsAssembly(assemblyName).UseRelationalNulls(); });
    }
}