using Business.Models;

namespace Business.Contract
{
    public interface IBusinessContract<TEntity>
    {
        #region Methods

        Task<ResponseBase<int?>> TotalRecordsAsync();

        Task<ResponseBase<IEnumerable<TEntity>>> FindAllAsync();

        Task<ResponseBase<TEntity>> FindByIdAsync(int id);

        Task<ResponseBase<IEnumerable<TEntity>>> FindByNameAsync(string name);

        #endregion
    }
}
