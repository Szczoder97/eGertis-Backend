using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Constants
{
    public static class UserRole
    {
        public const string Administrator = "Administrator";
        public const string NewUser = "NewUser";
        public const string Purchaser = "Purchaser";
        public const string SupplyWorker = "SupplyWorker";
        public const string VerifiedUser = "Administrator,Purchaser,SupplyWorker";
    }
}
