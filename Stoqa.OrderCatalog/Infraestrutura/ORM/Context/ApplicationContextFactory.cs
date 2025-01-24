using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Stoqa.Infra.ORM.Context;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.Context;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var connectionString =
            "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Stoqa;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=True;Pooling=True;Min Pool Size=10;Max Pool Size=100;";

        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationContext(optionsBuilder.Options);
    }
}