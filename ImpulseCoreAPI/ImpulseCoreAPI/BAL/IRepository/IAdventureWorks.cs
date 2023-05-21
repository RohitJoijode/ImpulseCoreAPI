using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.Bridge;

namespace ImpulseCoreAPI.BAL.IRepository
{
    public interface IAdventureWorks
    {
        List<DimAccountModal> GetDimAccount();
    }
}
