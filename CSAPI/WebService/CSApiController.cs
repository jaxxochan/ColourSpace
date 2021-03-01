using CS.Api.Facade.Filters.ActionFilters;
using CS.Api.Facade.WebService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CS.Api.Facade.WebService
{
    [AuthorizationRequired]
    public class CSApiController : ApiController
    {
        protected ApiRequestContext ApiRequestContext => new ApiRequestContext(Request);

        //protected PagedApiRequestContext PageRequestConext => new PagedApiRequestContext(Request);

        protected int UserId => ApiRequestContext.UserId;
    }
}