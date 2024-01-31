using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public interface IProductService
    {
        ProductList ListProducts(int page);
    }
    public interface ICustomerService
    {
        CustomerList ListCustomers(int page);
    }

    public class ProductService:IProductService
    {
        private readonly TestDbContext _ctx;
        private const int PageSize = 10; 

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public ProductList ListProducts(int page)
        {
            var totalCount = _ctx.Products.Count();
            var hasNext = (page * PageSize) < totalCount;

            var products = _ctx.Products
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return new ProductList
            {
                HasNext = hasNext,
                TotalCount = totalCount,
                Products = products
            };
        }
       

      
    }

}
