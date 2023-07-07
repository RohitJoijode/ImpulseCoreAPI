using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.BAL.Repository;

namespace ImpulseCoreAPI.BAL.IRepository
{
    public interface IRsaHelperRepo
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
    }
}
