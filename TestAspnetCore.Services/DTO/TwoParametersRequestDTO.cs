using System.ComponentModel.DataAnnotations;

namespace TestAspnetCore.Services.DTO
{
    public class TwoParametersRequestDTO
    {
        #region properties

        [Required]
        public string Name {get;set;}

        [Required]
        public int Age {get; set;}

        #endregion


    }
}