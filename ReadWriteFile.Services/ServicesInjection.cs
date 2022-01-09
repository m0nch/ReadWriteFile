using Microsoft.Extensions.DependencyInjection;

namespace ReadWriteFile.Services
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<ITeacherService, TeacherService>();
            return service;
        }
    }
}
