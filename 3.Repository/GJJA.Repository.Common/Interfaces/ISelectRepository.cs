using System.Collections.Generic;

namespace GJJA.Repository.Common.Interfaces
{
    public interface ISelectRepository<TDomain, TKey>
        where TDomain : class
    {
        List<TDomain> Select();
        TDomain SelectById(TKey id);
    }
    
}