using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void AddCategoryBL(Category category);
        Category GetByIdBL(int id);
        void DeleteCategoryBL(Category category);
        void UpdateCategoryBL(Category category);
    }
}
