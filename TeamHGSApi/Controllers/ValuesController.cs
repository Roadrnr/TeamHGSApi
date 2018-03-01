using System;
using Microsoft.AspNetCore.Mvc;

namespace TeamHGSApi.Controllers
{
    [Route("api/[action]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public IActionResult CompareStrings([FromBody] InputObject strings)
        {
            if (String.IsNullOrWhiteSpace(strings.Str1))
            {
                return BadRequest(strings);
            }

            var comparison = String.Equals(strings.Str1, strings.Str2, StringComparison.OrdinalIgnoreCase);
                        var returnObj = new ReturnObject
            {
                Result = comparison,
                LastUpdated = DateTime.UtcNow
            };
            return Ok(returnObj);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CompareEmail([FromBody] InputObject strings)
        {
            if (String.IsNullOrWhiteSpace(strings.Str1))
            {
                return BadRequest(strings);
            }

            var returnObj = new ReturnObject
            {
                Result = false,
                LastUpdated = DateTime.UtcNow,
                ResultStatus = 0,
                ResultValue = "ZoomInfo Email Blank"
            };

            if (String.IsNullOrWhiteSpace(strings.Str2)) return Ok(returnObj);

            var comparison = String.Equals(strings.Str1, strings.Str2, StringComparison.OrdinalIgnoreCase);
            returnObj.Result = comparison;
            if (comparison)
            {
                returnObj.ResultStatus = 1;
                returnObj.ResultValue = "Match";
            } else
            {
                returnObj.ResultStatus = 2;
                returnObj.ResultValue = "No Match";
            }

            return Ok(returnObj);
        }

    }

    public class InputObject
    {
        public string Str1 { get; set; }
        public string Str2 { get; set; }
    }
    public class ReturnObject
    {
        public bool Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ResultStatus { get; set; }
        public string ResultValue { get; set; }
    }
}
