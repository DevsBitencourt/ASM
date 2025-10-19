namespace Repository.Contract.Clients
{
    public interface IDeleteClientRepository
    {
        Task<bool> DeleteAsync(int id);
    }
}
