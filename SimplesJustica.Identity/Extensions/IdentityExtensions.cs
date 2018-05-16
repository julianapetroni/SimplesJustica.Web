using System;
using System.Security.Principal;

namespace Microsoft.AspNet.Identity
{
    public static class IdentityExtensions
    {
        public static Guid GetUserGuidId(this IIdentity identity)
        {
            return Guid.Parse(identity.GetUserId());
        }
    }
}
