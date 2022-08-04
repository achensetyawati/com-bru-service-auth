using Com.Bateeq.Service.Auth.Lib.Services.IdentityService;
using Com.Bateeq.Service.Auth.Lib.ViewModels;
using Com.Bateeq.Service.Auth.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Bateeq.Service.Auth.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/me")]
    [Authorize]
    public class MeController : Controller
    {
        public static readonly string ApiVersion = "1.0.0";

        public MeController()
        {
            
        }

        [HttpGet]
        public IActionResult Me()
        {
            try
            {
                var Claims = User.Claims.ToList();
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("username", Claims.Find(c => c.Type.Equals("username")).Value);
                data.Add("profile", JsonConvert.DeserializeObject(Claims.Find(c => c.Type.Equals("profile")).Value));
                data.Add("permission", JsonConvert.DeserializeObject(Claims.Find(c => c.Type.Equals("permission")).Value));
                List<object> storeViews = new List<object>();
                foreach (var c in Claims.Where(c => c.Type.Equals("stores")).ToList())
                {
                    storeViews.Add(JsonConvert.DeserializeObject(c.Value));
                }
                data.Add("stores", storeViews);
                data.Add("iat", Claims.Find(c => c.Type.Equals("iat")).Value);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok();

                Result.Add("data", data);
                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }
    }
}
