using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Contract.UnitOfWork
{
    public interface UnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Save();
        Task RoleBack();
    }
}
