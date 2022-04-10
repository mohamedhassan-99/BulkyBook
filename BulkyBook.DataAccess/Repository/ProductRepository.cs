using BulkyBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        void IProductRepository.Update(Product product)
        {
            var productDb = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if(productDb != null)
            {
                productDb.Title = product.Title;
                productDb.ISBN = product.ISBN;
                productDb.Price = product.Price;
                productDb.Price50 = product.Price50;
                productDb.Price100 = product.Price100;
                productDb.ListPrice = product.ListPrice;
                productDb.Description = product.Description;
                productDb.CategoryId = product.CategoryId;
                productDb.Author = product.Author;
                productDb.CoverTypeId = product.CoverTypeId;
                if(product.ImageUrl != null)
                {
                    productDb.ImageUrl = product.ImageUrl;
                }

            }
        }
    }
}
