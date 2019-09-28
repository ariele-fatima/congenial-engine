namespace GJJA.Repository.Common.Interfaces
{
    public interface IInsertRepository<TDomain>
        where TDomain : class
    {
       void Insert(TDomain domain);
    }
    
}