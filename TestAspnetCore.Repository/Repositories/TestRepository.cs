using TestAspnetCore.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAspnetCore.Model.Models;
using System.Linq;

namespace TestAspnetCore.Repository.Repositories
{
    public class TestRepository : ITestRepository
    {

        #region fields

        private List<Person> elements;

        #endregion

        #region constructors

        public TestRepository()
        {
            this.elements = new List<Person>();
            this.elements.Add(new Person() {Name = "John",Age = 45});
            this.elements.Add(new Person() {Name = "Peter",Age = 55});
            this.elements.Add(new Person() {Name = "Duke",Age = 21});
            this.elements.Add(new Person() {Name = "Linda",Age = 35});
        }

        #endregion

        #region ITestRepository

         Task<List<Person>> ITestRepository.GetElements(string name)
        {
            return new Task<List<Person>>(()=>
            {
                return this.elements.Where(x=> x.Name.ToUpper().Equals(name.ToUpper())).ToList();
            }
            );           
        }

        #endregion
        
    }
}