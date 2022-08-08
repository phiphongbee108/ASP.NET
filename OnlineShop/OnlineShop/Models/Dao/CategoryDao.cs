﻿using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}