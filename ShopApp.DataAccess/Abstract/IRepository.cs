using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
	public interface IRepository<TEntity>
	{
		TEntity GetById(int id);
		TEntity GetOne(Expression<Func<TEntity, bool>> filter);
		IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

		void Create(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}
