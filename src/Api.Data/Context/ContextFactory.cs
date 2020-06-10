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
            var connectionString = "Host=200.147.61.79 ;Port=5432; Database=manager;Username=efdados;Password=Toor2019@";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql (connectionString);
            optionsBuilder.UseNpgsql(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
