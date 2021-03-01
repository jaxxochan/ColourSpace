using CS.Api.ResourceModels;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;

namespace CS.Api.Facade.WebService.Infrastructure
{
    public class ApiRequestContext
    {
        public int UserId { get; set; }

        public ApiRequestContext(HttpRequestMessage request)
        {
            UserId = ClaimsExtensions.GetUserId(((ClaimsIdentity)((request.GetRequestContext()).Principal?.Identity)));
        }
    }

    public static class ClaimsExtensions
    {
        public static int GetUserId(this ClaimsIdentity identity)
        {
            var userClaim = identity.Claims.SingleOrDefault(c => c.Type == "csuserid");
            return Convert.ToInt32(userClaim.Value);
        }
    }

    public class PagedApiRequestContext : ApiRequestContext
    {
        private readonly HttpRequestMessage currentRequest;

        private const int DefaultLimit = 100;
        private const int DefaultOffset = 0;
        private const Order DefaultOrder = Order.ASC;
        private const string LimitQueryParam = "limit";
        private const string OffsetQueryParam = "offset";
        private const string OrderQueryParam = "order";
        private const string OrderByQueryParam = "order_by";
        private const string SearchQueryParam = "search";
        private const string LocaleQueryParam = "locale";


        public PagedApiRequestContext(HttpRequestMessage request) : base(request) {
            currentRequest = request;
            Init();

        }

        public int Limit { get; private set; }
        public int Offset { get; private set; }

        
        public string OrderBy { get; private set; }
        public Order Order { get; private set; }
        public bool HasOrdering { get { return !string.IsNullOrEmpty(OrderBy); } }



        public string Search { get; private set; }
        public string Locale { get; private set; }

        private void Init()
        {
            var queryParams = GetQueryStringParams();
            Limit = ExtractLimit(queryParams);
            Offset = ExtractOffset(queryParams);
            Order = ExtractOrder(queryParams);
            OrderBy = ExtractOrderBy(queryParams);
            Search = ExtractSearch(queryParams);
            Locale = ExtractLocale(queryParams);
        }

        private static int ExtractLimit(NameValueCollection queryParams)
        {
            var p = queryParams[LimitQueryParam];
            if (!string.IsNullOrEmpty(p))
            {
                int limit;
                if (int.TryParse(p, out limit) && limit >= 0)
                {
                    return limit;
                }
            }
            return DefaultLimit;
        }

        private static int ExtractOffset(NameValueCollection queryParams)
        {
            var p = queryParams[OffsetQueryParam];
            if (!string.IsNullOrEmpty(p))
            {
                int offset;
                if (int.TryParse(p, out offset))
                {
                    return offset;
                }
            }
            return DefaultOffset;
        }

        private static Order ExtractOrder(NameValueCollection queryParams)
        {
            var p = queryParams[OrderQueryParam];
            if (!string.IsNullOrEmpty(p))
            {
                Order order;
                if (Enum.TryParse(p, true, out order))
                {
                    return order;
                }
            }
            return DefaultOrder;
        }

        private static string ExtractOrderBy(NameValueCollection queryParams)
        {
            return queryParams[OrderByQueryParam];
        }

        private static string ExtractSearch(NameValueCollection queryParams)
        {
            return queryParams[SearchQueryParam];
        }

        private static string ExtractLocale(NameValueCollection queryParams)
        {
            return queryParams[LocaleQueryParam];
        }

        private NameValueCollection GetQueryStringParams()
        {
            var queryParams = new NameValueCollection();
            foreach (var nvp in currentRequest.GetQueryNameValuePairs())
            {
                queryParams.Add(nvp.Key, nvp.Value);
            }
            return queryParams;
        }
    }
}