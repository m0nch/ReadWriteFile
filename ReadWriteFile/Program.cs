using ReadWriteFile.Data;
using ReadWriteFile.Services;
using ReadWriteFile.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ReadWriteFile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureService(services);

            using(ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var teachersForm = serviceProvider.GetRequiredService<TeachersForm>();
                Application.Run(teachersForm);
            }
        }
        private static void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<_IAppCache, _AppCache>();

            services.AddDbContext()
                    .AddRepositories()
                    .AddServices()
                    .AddScoped<TeachersForm>()
                    .AddScoped<StudentsForm>();
        }
    }
}
