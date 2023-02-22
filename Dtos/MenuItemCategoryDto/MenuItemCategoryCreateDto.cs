using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos.MenuItemCategoryDto
{
    public class MenuItemCategoryCreateDto
    {
        [Required(ErrorMessage = "Field name is necessary")]
        public string Name { get; set; }
    }
}
