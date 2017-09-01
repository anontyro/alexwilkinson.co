using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alexwilkinson.Auth
{
    interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName);
    }
}
