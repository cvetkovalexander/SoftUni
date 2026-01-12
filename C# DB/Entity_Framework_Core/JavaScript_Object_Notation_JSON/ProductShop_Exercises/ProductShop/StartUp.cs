using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        using var context = new ProductShopContext();
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();

        //string jsonDirFilePath = Path
        //    .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

        //string jsonFileName = "categories-products.json";

        //string jsonFile = File
        //    .ReadAllText(jsonDirFilePath + jsonFileName);

        //Console.WriteLine(ImportCategoryProducts(context, jsonFile));

        Console.WriteLine(GetUsersWithProducts(context));
    }

    // Problem 01
    public static string ImportUsers(ProductShopContext context, string inputJson) 
    {
        ICollection<User> usersToImport = new List<User>();

        IEnumerable<ImportUserDto>? userDtos = JsonConvert
            .DeserializeObject<ImportUserDto[]>(inputJson);

        if (userDtos != null) 
        {
            foreach (var dto in userDtos) 
            {
                if (!IsValid(dto))
                    continue;

                var newUser = new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                };

                usersToImport.Add(newUser);
            }

            context.Users.AddRange(usersToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {usersToImport.Count}";
    }

    // Problem 02
    public static string ImportProducts(ProductShopContext context, string inputJson) 
    {
        ICollection<Product> productsToImport = new List<Product>();

        IEnumerable<ImportProductDto>? productDtos = JsonConvert
            .DeserializeObject<ImportProductDto[]>(inputJson);

        if (productDtos != null) 
        {
            foreach (var dto in productDtos) 
            {
                bool isSellerIdValid = context
                    .Users
                    .Any(u => u.Id == dto.SellerId);

                if (isSellerIdValid || !IsValid(dto))
                    continue;

                var newProduct = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId,
                };

                productsToImport.Add(newProduct);
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {productsToImport.Count}";
    }

    // Problem 03
    public static string ImportCategories(ProductShopContext context, string inputJson) 
    {
        ICollection<Category> categoriesToImport = new List<Category>();
        
        IEnumerable<ImportCategoryDto>? categoryDtos = JsonConvert
            .DeserializeObject<ImportCategoryDto[]>(inputJson);

        if (categoryDtos != null) 
        {
            foreach (var dto in categoryDtos) 
            {
                if (!IsValid(dto))
                    continue;

                var category = new Category()
                {
                    Name = dto.Name,
                };

                categoriesToImport.Add(category);
            }

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {categoriesToImport.Count}";
    }

    // Problem 04
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        ICollection<CategoryProduct> categoryProductsToImport = new List<CategoryProduct>();

        IEnumerable<ImportCategoryProductDto>? categoryProductDtos = JsonConvert
            .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

        if (categoryProductDtos != null)
        {
            foreach (var dto in categoryProductDtos) 
            {
                var categoryProduct = new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                };

                categoryProductsToImport.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(categoryProductsToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {categoryProductsToImport.Count}";
    }

    // Problem 05
    public static string GetProductsInRange(ProductShopContext context) 
    {
        var products = context
            .Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                p.Name,
                p.Price,
                p.Seller
            })
            .ToArray();

        var res = products
            .Select(p => new 
            {
                name = p.Name,
                price = p.Price,
                seller = p.Seller.FirstName + " " + p.Seller.LastName
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(res, Formatting.Indented);
    }

    // Problem 06
    public static string GetSoldProducts(ProductShopContext context) 
    {
        var products = context
            .Users
            .AsNoTracking()
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer!.FirstName,
                            buyerLastName = p.Buyer!.LastName
                        })
                        .ToArray()
            })
            .Where(u => u.soldProducts.Any())
            .OrderBy(u => u.lastName)
            .ThenBy(u => u.firstName)
            .ToArray();

        return JsonConvert
            .SerializeObject(products, Formatting.Indented);
    }

    // Problem 07
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context
            .Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                ProductsCount = c.CategoriesProducts.Count,
                AveragePrice = c.CategoriesProducts
                    .Average(cp => cp.Product.Price),
                TotalRevenue = c.CategoriesProducts
                    .Sum(cp => cp.Product.Price)
            })
            .OrderByDescending(c => c.ProductsCount)
            .ToArray();

        var res = categories
            .Select(c => new 
            {
                category = c.Name,
                productsCount = c.ProductsCount,
                averagePrice = c.AveragePrice.ToString("f2"),
                totalRevenue = c.TotalRevenue.ToString("f2")
            })
            .ToArray();

        return JsonConvert
            .SerializeObject(res, Formatting.Indented);
    }

    // Problem 08
    public static string GetUsersWithProducts(ProductShopContext context) 
    {
        var users = context
            .Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId != null))
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                age = u.Age,
                soldProducts = new 
                {
                    count = u.ProductsSold.Count(p => p.BuyerId != null),
                    products = u.ProductsSold 
                    .Where(p => p.BuyerId != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price
                    })
                    .ToArray()
                }
            })
            .ToArray();

        var res = new
        {
            usersCount = users.Length,
            users
        };

        return JsonConvert
            .SerializeObject(res, Formatting.Indented,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
    }

    private static bool IsValid(object obj)
    {
        // These two variables are required by the Validator.TryValidateObject method
        // We will not use them for now...
        // We are just using the Validation result (true or false)


        ValidationContext validationContext = new ValidationContext(obj);
        ICollection<ValidationResult> validationResults
            = new List<ValidationResult>();

        return Validator
            .TryValidateObject(obj, validationContext, validationResults);
    }
}