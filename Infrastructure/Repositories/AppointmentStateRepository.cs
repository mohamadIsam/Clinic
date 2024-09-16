using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AppointmentStatusRepository : BaseRepository<AppointmentStatus>, IAppointmentStatusRepository
    {
        public AppointmentStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    internal interface IAppointmentState
    {
    }
}