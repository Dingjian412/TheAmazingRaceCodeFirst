using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace TheAmazingRace.DAL
{
    public partial class BaseRepo<T> where T : class, new()
    {
        private TheAmazingRaceDbContext dbContext = DbContextFactory.Create();

        public T Create()
        {
            try
            {
                return dbContext.Set<T>().Create();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(T t)
        {
            try
            {
                dbContext.Set<T>().Add(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(T t)
        {
            try
            {
                dbContext.Set<T>().Remove(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T t)
        {
            try
            {
                dbContext.Set<T>().AddOrUpdate(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return dbContext.Set<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                return dbContext.Set<T>().Where(whereLambda);
            } catch (Exception)
            {
                throw;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges() > 0;
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
