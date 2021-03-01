using CS.Api.Facade.CustomAuthentication;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CS.Api.Facade.Security
{
    public static class SecurityContext
    {
        public static CustomPrincipal UserPrincipal
        {
            get
            {
                HttpContextBase httpContextBase = new HttpContextWrapper(HttpContext.Current);

                return (CustomPrincipal)httpContextBase.User;
            }
        }

        public static ClaimsIdentity UserIdentity => (ClaimsIdentity)UserPrincipal.Identity;
    }

    public static class ClaimsExtensions
    {
        public static string GetToken(this ClaimsIdentity identity)
        {
            var token = identity.FindFirst(c => c.Type == "token");
            return token != null ? token.Value : string.Empty;
        }

        public static string GetUserId(this ClaimsIdentity identity)
        {
            var userIdClaim = identity.Claims.SingleOrDefault(c => c.Type == "appserid");
            return userIdClaim != null ? userIdClaim.Value : string.Empty;
        }

        public static int GetRoleId(this ClaimsIdentity identity)
        {
            //type should be single so replace firstordefault with singleordefault
            //var roleIdClaim = identity.Claims.FirstOrDefault(c => c.Type == "roleid");
            //return roleIdClaim != null ? roleIdClaim.Value : string.Empty;

            return SecurityContext.UserPrincipal.RoleId;
        }
    }
}