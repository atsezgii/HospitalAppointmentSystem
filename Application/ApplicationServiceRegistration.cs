using Application.Services.AdminService;
using Application.Services.AppointmentService;
using Application.Services.DepartmentService;
using Application.Services.DoctorService;
using Application.Services.PatientService;
using Application.Services.UserService;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.CrossCuttingConcerns.Logging.Serilog;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Serilog;
using Core.Application.Pipelines.Authorization;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            });
            services.AddScoped<IPatientService, PatientManager>();
            services.AddScoped<IDoctorSevice, DoctorManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSingleton<FileLogger>();
            services.AddSingleton<MsSqlLogger>();

            services.AddSingleton<LoggerServiceBase>(provider =>
            {
                var fileLogger = provider.GetRequiredService<FileLogger>();
                var msSqlLogger = provider.GetRequiredService<MsSqlLogger>();

                return new LoggerServiceBase
                {
                    Logger = new LoggerConfiguration()
                        .WriteTo.Logger(fileLogger.Logger) // parallel logging
                        .WriteTo.Logger(msSqlLogger.Logger) // parallel logging
                        .CreateLogger()
                };
            });


            return services;
        }
    }
}
