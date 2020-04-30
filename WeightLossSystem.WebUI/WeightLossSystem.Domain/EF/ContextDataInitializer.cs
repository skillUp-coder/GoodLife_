using System;
using System.Collections.Generic;
using System.Data.Entity;
using WeightLossSystem.Domain.Entities;

namespace WeightLossSystem.Domain.EF
{
    public class ContextDataInitializer:DropCreateDatabaseAlways<ContextDatabase>
    {
        
        private List<Category> CollectionsCategories = new List<Category> 
        {
            new Category{ Name ="Buy Sport Supplements", Discription = "We have a large selection of sports supplements. Faster go to buy." },
            new Category{ Name="Nutrition Blog", Discription = "Here you can find any article about sports nutrition." }
        };
        private List<User> AddUser = new List<User> 
        {
             new User{ Email = "student@gmail.com", Name="Travis Scott", Password = "Travis_123", _RoleId = 3  }
        };
        private List<Role> AddRole = new List<Role> 
        {
            new Role{ RoleId = 1, Name = "admin" },
            new Role{ RoleId = 2, Name = "manager" },
            new Role{ RoleId = 3, Name = "user" },
        };
        private List<SportSupplement> AddsportSupplements = new List<SportSupplement> 
        {
            new SportSupplement{ Name = "Ultimate Nutrition BCAA", CategoryName = "BCAA",  Description = "BCAA is a powerful complex containing the essential amino acids L-Leucine, L-Valine, L-Isoleucine in a ratio of 2: 1: 1. In addition to the listed components, the composition of this powdery substance does not contain other additives with which unscrupulous manufacturers are accustomed to supplement their products in order to dilute their total weight.", Price = 120, Date = DateTime.Now },
            new SportSupplement{ Name="Optimum Nutrition Opti-Men", CategoryName="Opti-Men",  Description = "The fortifying property of Opti-Men will benefit any man - both a professional athlete and a calm lifestyle. The preparation contains enzymes that beneficially affect metabolism, the immune system, the central nervous systems. Agree, a completely natural and certified drug, which consists of 25 different vitamins deserves special attention!", Price = 99, Date = DateTime.Now  }
        };
        private List<NutritionBlog> AddnutritionBlogs = new List<NutritionBlog> 
        {
             new NutritionBlog{ Description = "From the article we have prepared, you will find out whether chicory is good for our body?", Text = "Chicory is known to many as an excellent analogue of coffee, allowing you to get a charge of vigor throughout the day. Unlike coffee beans, it does not contain harmful caffeine, so it can be consumed by people with hypertension, gastrointestinal tract, blood vessels and heart pathologies. However, the benefits of chicory to the body are not limited to imitation of taste. In fact, this drink is used for medicinal purposes and is a good prevention of many diseases.", Title="Chicory - Health Benefits" }
        };
        protected override void Seed(ContextDatabase context)
        {

            foreach (var itemCategory in CollectionsCategories)
            {
                context.Categories.Add(itemCategory);
            }

            foreach (var itemUsers in AddUser) 
            {
                context.Users.Add(itemUsers);
            }

            foreach (var itemRole in AddRole) 
            {
                context.Roles.Add(itemRole);
            }

            foreach (var itemSportS in AddsportSupplements) 
            {
                context.SportSupplements.Add(itemSportS);
            }
            foreach (var item in AddnutritionBlogs)
            {
                context.NutritionBlogs.Add(item);
            }
            context.SaveChanges();
        }
    }
}
