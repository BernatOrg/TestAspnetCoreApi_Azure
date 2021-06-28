using TestAspnetCore.Services.DTO;
using Xunit;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestAspnetCore.UnitTest.Validation
{
    public class UnitTest
    {
        [Theory]
        [Trait("Validation", "TwoParametersRequestDTO")]
        [InlineData(null,false)]
        [InlineData("",false)]
        [InlineData("1",true)]
        [InlineData(".",true)]
        [InlineData("John",true)]
        public void TwoParametersRequest_Class_Test(string name, bool expectedResult)
        {
            //Arrange
            TwoParametersRequestDTO request = new TwoParametersRequestDTO()
            {
                Name = name
            };
            var validationResults = new List<ValidationResult>();

            //Act
            var actualResult = Validator.TryValidateObject(request,
                                                          new ValidationContext(request),
                                                          validationResults,
                                                          true);
            //Assert
            Assert.Equal(expectedResult, actualResult);
            if(!actualResult)
                Assert.Single(validationResults);
        }
    }
}
