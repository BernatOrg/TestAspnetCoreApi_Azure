using TestAspnetCore.Services.DTO;
using Xunit;
using Moq;
using TestAspnetCore.Repository.Interfaces;
using System.Collections.Generic;
using TestAspnetCore.Model.Models;
using System.Threading.Tasks;
using System.Linq;
using TestAspnetCore.Services.Interfaces;
using TestAspnetCore.Services.Services;

namespace TestAspnetCore.UnitTest.Services
{
    public class UnitTest
    {
         [Theory]
         [Trait("Services", "TestServices")]
         [InlineData(null,0)]
         [InlineData("",0)]
         [InlineData("1",0)]
         [InlineData(".",0)]
         [InlineData("John",1)]
         [InlineData("Peter",3)]
         public async Task TestServices_Class_Test(string name, int expectedResult)
         {
             //Arrange
             var mockService = new Mock<ITestRepository>();

             List<Person> fakeList = new List<Person>();
             fakeList.Add(new Person() {Name = "John",Age = 45});
             fakeList.Add(new Person() {Name = "Peter",Age = 55});
             fakeList.Add(new Person() {Name = "PETER",Age = 21});
             fakeList.Add(new Person() {Name = "PeTeR",Age = 11});
             fakeList.Add(new Person() {Name = "Linda",Age = 35});

             mockService.Setup(repo => repo.GetElements(It.IsAny<string>())).
             Returns((string value) => {return new Task<List<Person>>(()=>
            {
                return fakeList.Where(x=> x.Name.ToUpper().Equals(name.ToUpper())).ToList();
            }
            );  });

             TwoParametersRequestDTO request = new TwoParametersRequestDTO()
             {
                Name = name
             };

             ITestServices service = new TestServices(mockService.Object);

             //Act
             List<Person> result = await service.GetResultsFromRequestAsync(request);

             //Assert
             Assert.Equal(expectedResult,result.Count);
         }
    }
}