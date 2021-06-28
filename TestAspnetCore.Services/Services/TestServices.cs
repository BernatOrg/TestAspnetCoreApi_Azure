using TestAspnetCore.Services.Interfaces;
using TestAspnetCore.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAspnetCore.Model.Models;
using TestAspnetCore.Repository.Interfaces;

namespace TestAspnetCore.Services.Services
{
    public class TestServices : ITestServices
    {

        #region fields

            private ITestRepository repository;

        #endregion
        
        #region constructors

            public TestServices(ITestRepository repository) => this.repository = repository;

        #endregion

        #region ITestServices

        async Task<List<Person>> ITestServices.GetResultsFromRequestAsync(TwoParametersRequestDTO request)
        {
            if(request.Name is null)
                return new List<Person>();
            var task = this.repository.GetElements(request.Name);
            task.Start();
            return await task;
        }

        #endregion

    }
}