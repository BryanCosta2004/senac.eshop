﻿using Senac.eShop.Domain.Entities;
using Senac.eShop.Domain.Interfaces;
using Senac.eShop.Infra.Data.Context;
using System.Linq.Expressions;

namespace Senac.eShop.Infra.Data.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(EShopDbContext context) : base(context)
        { }

        public Basket Add(Basket entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Basket GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var basket = context.FirstOrDefault(c => c.Id == id);
            return basket;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Basket Update(Basket entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
