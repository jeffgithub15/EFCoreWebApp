using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DataLayer
{
    public class EfCoreContext2 : DbContext, IUserId
    {
        public Guid UserId { get; private set; }
        public EfCoreContext2(DbContextOptions<EfCoreContext> options,
                    IUserIdService userIdService = null)
            : base(options)
        {
            UserId = userIdService?.GetUserId()
                ?? new ReplacementUserIdService().GetUserId();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter(MyQueryFilterTypes.SoftDelete);
                }
                if (typeof(IUserId).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter(MyQueryFilterTypes.UserId, this);
                }
            }
        }
    }


    public enum MyQueryFilterTypes { SoftDelete, UserId }

    public static class SoftDeleteQueryExtensions
    {
        public static void AddSoftDeleteQueryFilter(
                    this IMutableEntityType entityData,
                    MyQueryFilterTypes queryFilterType,
                    IUserId userIdProvider = null)
        {
            var methodName = $"Get{queryFilterType}Filter";
            var methodToCall = typeof(SoftDeleteQueryExtensions)
                                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)
                                .MakeGenericMethod(entityData.ClrType);

            var filter = methodToCall.Invoke(null, new object[] { userIdProvider });

            entityData.SetQueryFilter((LambdaExpression)filter);

            if (queryFilterType == MyQueryFilterTypes.SoftDelete)
                entityData.AddIndex(entityData.FindProperty(nameof(ISoftDelete.SoftDeleted)));

            if (queryFilterType == MyQueryFilterTypes.UserId)
                entityData.AddIndex(entityData.FindProperty(nameof(IUserId.UserId)));

        }

        private static LambdaExpression GetUserIdFilter<TEntity>
            (IUserId userIdProvider)
                where TEntity : class, IUserId
        {
            Expression<Func<TEntity, bool>> filter = x => x.UserId == userIdProvider.UserId;
            return filter;
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>
            (IUserId userIdProvider)
            where TEntity : class, ISoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => !x.SoftDeleted;
            return filter;
        }
    }
}
