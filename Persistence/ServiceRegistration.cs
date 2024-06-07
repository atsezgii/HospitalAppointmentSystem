
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;


namespace Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppointmentSystemDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IFeedBackRepository, FeedbackRepository>();
            return services;
        }
    }
}
