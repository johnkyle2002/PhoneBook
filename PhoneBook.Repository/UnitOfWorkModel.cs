using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBook.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Repository
{
    public class UnitOfWorkModel<TModel>: IUnitOfWorkModel<TModel> where TModel : class
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UnitOfWorkModel(PhoneBookDBContext context, ILogger<UnitOfWorkModel<TModel>> logger)
        {
            _context = context;
            _logger = logger;
        }

        #endregion

        #region Private Members

        private readonly PhoneBookDBContext _context;
        private readonly ILogger<UnitOfWorkModel<TModel>> _logger;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the entity.
        /// </summary>
        public DbSet<TModel> Entity
        {
            get { return _context.Set<TModel>(); }
        }

        #endregion

        #region Persistence

        /// <summary>
        /// This will add new entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Add(TModel entity, bool saveChanges = true)
        {
            try
            {
                Entity.Add(entity);
                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Add TModel", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously add new entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(TModel entity, bool saveChanges = true)
        {
            try
            {
                await Entity.AddAsync(entity);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("AddAsync TModel", ex);
                return false;
            }
        }

        /// <summary>
        /// This will add new list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Add(IList<TModel> entities, bool saveChanges = true)
        {
            try
            {
                Entity.AddRange(entities);

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Add List<TModel>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously add new list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(IList<TModel> entities, bool saveChanges = true)
        {
            try
            {
                await Entity.AddRangeAsync(entities);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("AddAsync IList<TModel>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will update an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Update(TModel entity, bool saveChanges = true, byte[] concurrencyStamp = null)
        {
            try
            {
                Entity.Update(entity).State = EntityState.Modified;

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Update TModel", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Update TModel", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously update an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TModel entity, bool saveChanges = true, byte[] concurrencyStamp = null)
        {
            try
            {
                Entity.Update(entity).State = EntityState.Modified;

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("UpdateAsync TModel", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateAsync TModel", ex);
            }
            return false;
        }

        /// <summary>
        /// This will remove an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Remove(TModel entity, bool saveChanges = true)
        {
            try
            {
                Entity.Remove(entity);

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Remove TModel", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously remove an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(TModel entity, bool saveChanges = true)
        {
            try
            {
                Entity.Remove(entity);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("RemoveAsync TModel", ex);
                return false;
            }
        }

        /// <summary>
        /// This will remove a list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Remove(IList<TModel> entities, bool saveChanges = true)
        {
            try
            {
                Entity.RemoveRange(entities);

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Remove IList<TModel>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously remove a list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(IList<TModel> entities, bool saveChanges = true)
        {
            try
            {
                Entity.RemoveRange(entities);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("RemoveAsync IList<TModel>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will save the changes made to the database context.
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("SaveChange", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("SaveChange", ex);
            }
            return false;
        }

        /// <summary>
        /// This will asynchronously saves the changes made to the database context.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("SaveChangeAsync", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("SaveChangeAsync", ex);
                return false;
            }
        }

        #endregion
         
        #region Public Methods

        /// <summary>
        /// Implementation for database context dispose.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
