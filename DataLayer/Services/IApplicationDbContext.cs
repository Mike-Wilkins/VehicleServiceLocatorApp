﻿using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public interface IApplicationDbContext
    {
        public DbSet<VehicleService> VehicleServices { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        EntityEntry Remove([NotNullAttribute] object entity);
        EntityEntry<TEntity> Remove<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
    }
}
