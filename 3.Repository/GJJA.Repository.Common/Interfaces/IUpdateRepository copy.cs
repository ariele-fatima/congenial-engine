namespace GJJA.Repository.Common.Interfaces
{
    public interface IUpdateRepository<TDomain>
        where TDomain : class
    {
       void Update(TDomain domain);
    }
    
}