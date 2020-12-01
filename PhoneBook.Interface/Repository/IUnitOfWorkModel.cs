using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Interface.Repository
{
    public interface IUnitOfWorkModel<TModel> where TModel : class
    {
        DbSet<TModel> Entity { get; }

        bool Add(IList<TModel> entities, bool saveChanges = true);
        bool Add(TModel entity, bool saveChanges = true);
        Task<bool> AddAsync(IList<TModel> entities, bool saveChanges = true);
        Task<bool> AddAsync(TModel entity, bool saveChanges = true);
        void Dispose();
        bool Remove(IList<TModel> entities, bool saveChanges = true);
        bool Remove(TModel entity, bool saveChanges = true);
        Task<bool> RemoveAsync(IList<TModel> entities, bool saveChanges = true);
        Task<bool> RemoveAsync(TModel entity, bool saveChanges = true);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        bool Update(TModel entity, bool saveChanges = true, byte[] concurrencyStamp = null);
        Task<bool> UpdateAsync(TModel entity, bool saveChanges = true, byte[] concurrencyStamp = null);
    }
}
