using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Repository
{
    public interface IBrandRepository
    {
        List<Brand> findAll();
        Brand find(int id);
    }
}
