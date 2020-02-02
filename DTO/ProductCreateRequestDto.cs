using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeJuniorApi.DTO
{
    public class ProductCreateRequestDto
    {
        public Guid Id {get;set;}
        
        [Required]
        [StringLength(100)]
        public string Name {get; set;}

        [Required]
        [Range(0,double.PositiveInfinity, ErrorMessage="Positive numbers only")]
        public decimal Price {get; set;}   
    }
}