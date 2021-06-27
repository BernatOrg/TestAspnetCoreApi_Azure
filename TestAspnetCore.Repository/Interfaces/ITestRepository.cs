using System.Collections.Generic;
using System.Threading.Tasks;
using TestAspnetCore.Model.Models;

namespace TestAspnetCore.Repository.Interfaces
{
    public interface ITestRepository
    {
         #region methods

            Task<List<Person>> GetElements(string name);

         #endregion

    }
}