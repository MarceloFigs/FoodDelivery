using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos.MenuItemCategoryDto
{
    public class MenuItemCategoryUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field name is necessary")]
        public string Name { get; set; }
    }
}
