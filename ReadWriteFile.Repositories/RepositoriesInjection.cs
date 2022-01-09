using Microsoft.Extensions.DependencyInjection;

namespace ReadWriteFile.Repositories
{
    public static class RepositoriesInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<ITeacherRepository, TeacherRepository>();
            return service;
        }
    }
}
