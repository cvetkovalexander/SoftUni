using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export.Problem_06;
using ProductShop.DTOs.Export.Problem_07;
using ProductShop.DTOs.Export.Problem_08;
using ProductShop.DTOs.Export.Problem05;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        using var context = new ProductShopContext();

        //string result = GetUsersWithProducts(context);
        //Console.WriteLine(result);

        //WriteSerializationResult("users-and-products.xml", result);

        string xmlFile = ReadXmlFile("users.xml");

        Console.WriteLine(ImportUsers(context, xmlFile));
    }


    // Problem 01
    public static string ImportUsers(ProductShopContext context, string inputXml) 
    {
        ICollection<User> usersToImport = new List<User>();

        ImportUserDto[]? userDtos = XmlSerializerWrapper
            .Deserialize<ImportUserDto[]>(inputXml, "Users");

        if (userDtos != null) 
        {
            foreach (var dto in userDtos) 
            {
                if (!IsValid(dto))
                    continue;

                bool isAgeValid = TryParseNullableInt(dto.Age, out int? age);

                if (!isAgeValid)
                    continue;

                User user = new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = age
                };

                usersToImport.Add(user);
            }

            context.Users.AddRange(usersToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {usersToImport.Count}";
    }

    // Problem 02
    public static string ImportProducts(ProductShopContext context, string inputXml) 
    {
        ICollection<Product> productsToImport = new List<Product>();

        ImportProductDto[]? productDtos = XmlSerializerWrapper
            .Deserialize<ImportProductDto[]>(inputXml, "Products");

        if (productDtos != null) 
        {
            foreach (var dto in productDtos) 
            {
                bool isPriceValid = decimal
                    .TryParse(dto.Price, out var price);

                if (!isPriceValid || !IsValid(dto))
                    continue;

                bool isSellerIdValid = int 
                    .TryParse(dto.SellerId, out var sellerId);

                if (!isSellerIdValid)
                    continue;

                bool isBuyerIdValid = TryParseNullableInt(dto.BuyerId, out int? buyerId);

                if (!isBuyerIdValid)
                    continue;

                var product = new Product()
                {
                    Name = dto.Name,
                    Price = price,
                    SellerId = sellerId,
                    BuyerId = buyerId,
                };

                productsToImport.Add(product);
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {productsToImport.Count}";
    }

    // Problem 03
    public static string ImportCategories(ProductShopContext context, string inputXml) 
    {
        ICollection<Category> categoriesToImport = new List<Category>();

        ImportCategoryDto[]? categoryDtos = XmlSerializerWrapper
            .Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

        if (categoryDtos != null) 
        {
            foreach (var dto in categoryDtos) 
            {
                if (!IsValid(dto))
                    continue;

                var category = new Category()
                {
                    Name = dto.Name
                };

                categoriesToImport.Add(category);
            }

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();
        }

        return $"Successfully imported {categoriesToImport.Count}"; ;
    }

    // Problem 04
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml) 
    {
        ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

        ImportCategoryProductDto[]? dtos = XmlSerializerWrapper
            .Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

        if (dtos != null) 
        {
            foreach (var dto in dtos) 
            {
                bool isCategoryIdValid = int
                    .TryParse(dto.CategoryId, out int categoryId);

                bool isProductIdValid = int
                    .TryParse(dto.ProductId, out int productId);

                if (!IsValid(dto) || !isCategoryIdValid || !isProductIdValid)
                    continue;

                if (!context.Categories.Any(c => c.Id == categoryId) ||
                    !context.Products.Any(p => p.Id == productId))
                    continue;

                var categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryId,
                    ProductId = productId,
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        return $"Successfully imported {categoryProducts.Count}";
    }

    // Problem 05
    public static string GetProductsInRange(ProductShopContext context) 
    {
        ExportProductsInRangeDto dto = new ExportProductsInRangeDto()
        {
            Products = context
                .Products
                .AsNoTracking()
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new DTOs.Export.Problem05.ExportProductDto() 
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray()
        };

        return XmlSerializerWrapper
            .Serialize(dto, "Products");
    }

    // Problem 06
    public static string GetSoldProducts(ProductShopContext context) 
    {
        DTOs.Export.Problem_06.ExportUsersWithSoldProductsDto dto = new DTOs.Export.Problem_06.ExportUsersWithSoldProductsDto()
        {
            Users = context
                .Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new DTOs.Export.Problem_06.ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u
                        .ProductsSold
                        .Select(p => new ExportSoldProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray()
        };

        return XmlSerializerWrapper
            .Serialize(dto, "Users");
    }

    // Problem 07
    public static string GetCategoriesByProductsCount(ProductShopContext context) 
    {
        ExportCategoriesByProductCountDto dto = new ExportCategoriesByProductCountDto()
        {
            Categories = context.
                Categories
                .AsNoTracking()
                .Select(c => new ExportCategoryByCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts
                        .Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts
                        .Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray()
        };

        return XmlSerializerWrapper
            .Serialize(dto, "Categories");
    }

    // Problem 08
    public static string GetUsersWithProducts(ProductShopContext context) 
    {
        DTOs.Export.Problem_08.ExportUsersWithSoldProductsDto dto = new DTOs.Export.Problem_08.ExportUsersWithSoldProductsDto()
        {
            Count = context
                .Users
                .AsNoTracking()
                .Count(u => u.ProductsSold.Any()),
            Users = context
                .Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new DTOs.Export.Problem_08.ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u
                            .ProductsSold
                            .Select(p => new DTOs.Export.Problem_08.ExportProductDto()
                            {
                                Name = p.Name,
                                Price = p.Price,
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()

                    }

                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray()
        };

        return XmlSerializerWrapper
            .Serialize(dto, "Users");
    }


    /*------------------------- */
    //Helper methods:

    private static bool TryParseNullableInt(string? input, out int? val) 
    {
        int? outValue = null;
        if (input != null)
        {
            bool isBuyerIdValid = int
                .TryParse(input, out var value);

            if (!isBuyerIdValid) 
            {
                val = outValue;
                return false;
            }    

            outValue = value;
        }

        val = outValue;
        return true;
    }

    private static void WriteSerializationResult(string fileName, string text) 
    {
        string xmlFileDirPath = Path
            .Combine(Directory.GetCurrentDirectory(), "../../../Results/");

        File
            .WriteAllText(xmlFileDirPath + fileName, text, Encoding.Unicode);
    }

    private static void ResetDatabase(ProductShopContext context) 
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    private static void ImportProblems(ProductShopContext context) 
    {
        string xmlFile = ReadXmlFile("users.xml");

        Console.WriteLine(ImportUsers(context, xmlFile));

        xmlFile = ReadXmlFile("products.xml");

        Console.WriteLine(ImportProducts(context, xmlFile));

        xmlFile = ReadXmlFile("categories.xml");
        Console.WriteLine(ImportCategories(context, xmlFile));

        xmlFile = ReadXmlFile("categories-products.xml");
        Console.WriteLine(ImportCategoryProducts(context, xmlFile));
    }

    private static string ReadXmlFile(string fileName) 
    {
        string xmlDirFilePath = Path
            .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

        string xmlFile = File
            .ReadAllText(xmlDirFilePath + fileName);

        return xmlFile;
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