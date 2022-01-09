using Microsoft.Extensions.DependencyInjection;
using ReadWriteFile.Data.DB;

namespace ReadWriteFile.Data
{
    public static class DataInjection
    {
        public static IServiceCollection AddDbContext(this IServiceCollection service)
        {
            service.AddSingleton<IDbContext, DbContext>();
            return service;
        }  
    }
}
