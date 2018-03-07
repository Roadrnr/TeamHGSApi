using Microsoft.AspNetCore.Mvc;
using System;
using TeamHGSApi.Controllers;
using TeamHGSApi.Models;
using Xunit;

namespace TeamHGSApi.Tests
{
    public class ValuesControllerUnitTests
    {
        private readonly ValuesController _valuesController;
        public ValuesControllerUnitTests()
        {
            _valuesController = new ValuesController();
        }

        [Fact]
        public void StringsMatch()
        {
            var input = new InputObject
            {
                Str1 = "string",
                Str2 = "string"
            };
            var result = _valuesController.CompareStrings(input);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var returnObj = okObjectResult.Value as ReturnObject;

            Assert.True(returnObj.Result, "string should equal string");
        }

        [Fact]
        public void StringsDontMatch()
        {
            var input = new InputObject
            {
                Str1 = "string",
                Str2 = "string2"
            };
            var result = _valuesController.CompareStrings(input);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var returnObj = okObjectResult.Value as ReturnObject;

            Assert.False(returnObj.Result, "string should equal string");
        }

        [Fact]
        public void String2IsBlank()
        {
            var input = new InputObject
            {
                Str1 = "string",
                Str2 = ""
            };
            var result = _valuesController.CompareStrings(input);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var returnObj = okObjectResult.Value as ReturnObject;

            Assert.False(returnObj.Result, "string should equal string");
        }

        [Fact]
        public void String1IsBlank()
        {
            var input = new InputObject
            {
                Str1 = "",
                Str2 = "hasavalue"
            };
            var result = _valuesController.CompareStrings(input);

            var okObjectResult = result as OkObjectResult;
            Assert.Null(okObjectResult);
        }

        [Fact]
        public void InputObjectIsBlank()
        {
            InputObject input = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => _valuesController.CompareStrings(input));
        }


        //CompareEmails Tests
        [Fact]
        public void EmailsMatch()
        {
            var input = new InputObject
            {
                Str1 = "string@email.com",
                Str2 = "string@email.com"
            };
            var result = _valuesController.CompareEmail(input);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var returnObj = okObjectResult.Value as ReturnObject;

            Assert.True(returnObj.Result, "emails should be equal");
            Assert.True(returnObj.ResultStatus == 1);
            Assert.True(returnObj.ResultValue == "Match");
        }

        [Fact]
        public void EmailsDontMatch()
        {
            var input = new InputObject
            {
                Str1 = "string@email.com",
                Str2 = "string2@email.com"
            };
            var result = _valuesController.CompareEmail(input);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var returnObj = okObjectResult.Value as ReturnObject;

            Assert.False(returnObj.Result, "Emails should not be equal");
            Assert.True(returnObj.ResultStatus == 2);
            Assert.True(returnObj.ResultValue == "No Match");
        }

        [Fact]
        public void Email2IsBlank()
        {
            var input = new InputObject
            {
                Str1 = "string@email.com",
                Str2 = ""
            };
            var result = _valuesController.CompareEmail(input);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var returnObj = okObjectResult.Value as ReturnObject;

            Assert.False(returnObj.Result, "Email 2 is blank.");
            Assert.True(returnObj.ResultStatus == 0);
            Assert.True(returnObj.ResultValue == "ZoomInfo Email Blank");
        }

        [Fact]
        public void Email1IsBlank()
        {
            var input = new InputObject
            {
                Str1 = "",
                Str2 = "string2@email.com"
            };
            var result = _valuesController.CompareEmail(input);

            var okObjectResult = result as OkObjectResult;
            Assert.Null(okObjectResult);
        }

        [Fact]
        public void EmailInputObjectIsBlank()
        {
            InputObject input = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => _valuesController.CompareStrings(input));
        }
    }
}
