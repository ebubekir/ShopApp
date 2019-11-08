using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System.Linq;
using System.Linq.Expressions;
namespace ShopApp.DataAccess.Concrete.EfCore
{
	public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
		where TEntity : class
		where TContext : DbContext, new()
	{
		public void Create(TEntity entity)
		{
			using (var context = new TContext())
			{
				context.Set<TEntity>().Add(entity);
				context.SaveChanges();
			}
		}

		public void Delete(TEntity entity)
		{
			using (var context = new TContext())
			{
				context.Set<TEntity>().Remove(entity);
				context.SaveChanges();
			}
		}

		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
		{
			using (var context = new TContext())
			{
				return filter == null
					? context.Set<TEntity>().ToList()
					: context.Set<TEntity>().Where(filter).ToList();
			}
		}

		public TEntity GetById(int id)
		{
			using (var context = new TContext())
			{
				return context.Set<TEntity>().Find(id);
			}
		}

		public TEntity GetOne(Expression<Func<TEntity, bool>> filter)
		{
			using (var context = new TContext())
			{
				return context.Set<TEntity>().Where(filter).SingleOrDefault();
			}
		}

		public void Update(TEntity entity)
		{
			using (var context = new TContext())
			{
				context.Entry(entity).State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
