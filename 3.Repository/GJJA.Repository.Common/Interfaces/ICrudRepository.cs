namespace GJJA.Repository.Common.Interfaces
{
    public interface ICrudRepository<TDomain, TKey> :
        ISelectRepository<TDomain, TKey>,
        IInsertRepository<TDomain>,
        IUpdateRepository<TDomain>,
        IDeleteRepository<TDomain, TKey>
        where TDomain : class
    {
        
    }
}