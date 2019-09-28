namespace GJJA.Repository.Common.Interfaces
{
    public interface IDeleteRepository<TDomain, TKey>
        where TDomain : class
    {
        void Delele(TDomain domain);
        void DeletetById(TKey id);
    }
}