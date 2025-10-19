namespace Repository.Models.Clients
{
    public sealed class ClientModel
    {
        #region Properties

        public int IdClients { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        #endregion
    }
}
