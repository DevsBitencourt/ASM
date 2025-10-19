namespace Repository.Contract
{
    public interface IBasicConsultation<TEntity>
    {
        #region Methods

        Task<int?> TotalRecordsAsync();

        Task<IEnumerable<TEntity>> FindAllAsync();

        Task<TEntity?> FindByIdAsync(int id);

        Task<IEnumerable<TEntity>> FindByNameAsync(string name);

        #endregion
    }
}
