using System.Security.Claims;
using System.Security.Principal;
using TheAmazingRace.Utilities;

namespace Microsoft.AspNet.Identity
{
    public static class IdentityExtensions
    {
        public static string GetName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Name);

            return claim?.Value ?? string.Empty;
        }

        public static string GetUserEntityFullName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.UserEntityFullName);

            return claim != null ? claim.Value : string.Empty;
        }

        public static string GetMasterRoleName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.MasterRoleName);

            return claim != null ? claim.Value : string.Empty;
        }

        //public static int GetUserEntityId(this IIdentity identity)
        //{
        //    ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        //    Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.UserEntityId);

        //    return int.Parse(claim.Value);
        //}

        public static string GetUserEntityPhoto(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.UserEntityPhoto);

            return claim != null ? claim.Value : string.Empty;
        }
    }
}