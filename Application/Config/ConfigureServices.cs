using Application.Interfaces;
using Application.Mapper;
using Application.Services;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}