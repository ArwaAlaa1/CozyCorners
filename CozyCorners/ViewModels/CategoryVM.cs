using CozyCorners.Core.Models;

namespace CozyCorners.ViewModels
{
    public class CategoryVM
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }

    }
}
