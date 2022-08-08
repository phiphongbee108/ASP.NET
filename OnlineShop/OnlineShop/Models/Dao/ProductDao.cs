﻿using OnlineShop.Models.EF;
using OnlineShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x=>x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListByCategoryId(long categoryId, ref int totalRecord, int pageIndex=1, int pageSize=2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryId).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryId).OrderBy(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;

            //Linq
            //var model = from a in db.Products
            //            join b in db.ProductCategories
            //            on a.CategoryID equals b.ID
            //            where a.CategoryID == categoryId
            //            select new ProductViewModel()
            //            {
            //                CateMetaTitle = b.MetaTitle,
            //                CateName = b.Name,
            //                CreatedDate = a.CreatedDate,
            //                ID = a.ID,
            //                Images = a.Image,
            //                Name = a.Name,
            //                MetaTitle = a.MetaTitle,
            //                Price = a.Price,
            //            };
            //model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //return model.ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList(); 
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}