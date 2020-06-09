using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=mudar@123";
            var connectionString = "Server=localhost ;Port=5432; Database=postgres;Uid=postgres;Pwd=Senhaaa";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql (connectionString);
            optionsBuilder.UseNpgsql(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
