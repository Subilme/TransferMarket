namespace TransferMarket.App.Services
{
    public interface IRepository<T>
    {
        public IList<T> GetAll();
        public T? GetById(int id);
        public int Create(T data);
        public bool Update(T data);
        public bool Delete(int id);
    }
}
