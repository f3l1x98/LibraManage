﻿using Domain;
using Domain.Books;
using Domain.Loans;
using Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Options;
using Persistence.Repositories;

namespace Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<ApplicationDbContext>(
            (serviceProvider, dbContextOptionsBuilder) =>
            {
                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder.UseNpgsql(databaseOptions.ConnectionString, sqlServerAction =>
                {
                    sqlServerAction.MigrationsAssembly("LibraManage");

                    sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                    sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
                });

                dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnabledDetailedErrors);

                dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // TODO repositories
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();

        return services;
    }
}
