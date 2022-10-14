using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.ViewModels
{
    public class UserProductViewModel
    {

        public long ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        // [Precision(14, 2)]
        public decimal Price { get; set; }

    }
}
