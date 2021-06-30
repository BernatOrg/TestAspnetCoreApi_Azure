using TestAspnetCore.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAspnetCore.Model.Models;

namespace TestAspnetCore.Services.Interfaces
{
    public interface ITestServices
    {
         
        #region methods

            Task<List<Person>> GetResultsFromRequestAsync(TwoParametersRequestDTO request);

        #endregion

    }
}