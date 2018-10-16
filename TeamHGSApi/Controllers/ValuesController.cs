using System;
using Microsoft.AspNetCore.Mvc;
using TeamHGSApi.Models;

namespace TeamHGSApi.Controllers
{
    [Route("api/[action]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public IActionResult CompareStrings([FromBody] InputObject strings)
        {
            if (strings == null)
            {
                throw new ArgumentNullException(nameof(strings));
            }

            if (string.IsNullOrWhiteSpace(strings.Str1))
            {
                return BadRequest(strings);
            }

            var comparison = string.Equals(strings.Str1, strings.Str2, StringComparison.OrdinalIgnoreCase);
            var returnObj = new ReturnObject
            {
                Result = comparison
            };
            return Ok(returnObj);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CompareEmail([FromBody] InputObject strings)
        {
            if (strings == null)
            {
                throw new ArgumentNullException(nameof(strings));
            }

            if (string.IsNullOrWhiteSpace(strings.Str1))
            {
                return BadRequest(strings);
            }

            var returnObj = new ReturnObject
            {
                Result = false,
                ResultStatus = 0,
                ResultValue = "ZoomInfo Email Blank"
            };

            if (string.IsNullOrWhiteSpace(strings.Str2)) return Ok(returnObj);

            var comparison = string.Equals(strings.Str1, strings.Str2, StringComparison.OrdinalIgnoreCase);
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
}
