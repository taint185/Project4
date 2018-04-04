using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Repository
{
    public interface IProductRepository
    {
        List<Product> LatestProducts(int n);

        List<Product> FeaturedProducts(int n);

        Product find(int id);
        List<Product> ShowAll();
    }
}
