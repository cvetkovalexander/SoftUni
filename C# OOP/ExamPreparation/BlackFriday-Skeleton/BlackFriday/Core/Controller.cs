using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;

namespace BlackFriday.Core;

public class Controller : IController
{
    private IApplication _application = new Application();

    public string RegisterUser(string userName, string email, bool hasDataAccess)
    {
        if (this._application.Users.Exists(userName))
            return $"{userName} is already registered.";

        if (this._application.Users.Models.Any(u => u.Email == email))
            return $"{email} is already used by another user.";

        if (hasDataAccess == true)
        {
            if (this._application.Users.Models.Count(x => x.GetType().Name == nameof(Admin)) == 2)
                return "The number of application administrators is limited.";

            this._application.Users.AddNew(new Admin(userName, email));
            return $"Admin {userName} is successfully registered with data access.";
        }

        this._application.Users.AddNew(new Client(userName, email));
            return $"Client {userName} is successfully registered.";
    }

    public string AddProduct(string productType, string productName, string userName, double basePrice)
    {
        if (productType != nameof(Item) && productType != nameof(Service))
            return $"{productType} is not a valid type for the application.";

        if (this._application.Products.Models.Any(p => p.ProductName == productName))
            return $"{productName} already exists in the application.";

        if (!this._application.Users.Models.Any(u =>
                u.UserName == userName) || this._application.Users.Models.Single(u => u.UserName == userName).HasDataAccess == false)
            return $"{userName} has no data access.";

        IProduct product = productType == nameof(Item)
            ? new Item(productName, basePrice)
            : new Service(productName, basePrice);

        this._application.Products.AddNew(product);
        return $"{productType}: {productName} is added in the application. Price: {basePrice:F2}";
    }

    public string UpdateProductPrice(string productName, string userName, double newPriceValue)
    {
        if (!this._application.Products.Models.Any(p => p.ProductName == productName))
            return $"{productName} does not exist in the application.";

        if (!this._application.Users.Exists(userName) || this._application.Users.Models.Single(u => u.UserName == userName).HasDataAccess == false)
            return $"{userName} has no data access.";

        double oldPrice = this._application.Products.Models.Single(p => p.ProductName == productName).BasePrice;
        this._application.Products.Models.Single(p => p.ProductName == productName).UpdatePrice(newPriceValue);
        return $"{productName} -> Price is updated: {oldPrice:F2} -> {newPriceValue:F2}";
    }

    public string RefreshSalesList(string userName)
    {
        if (!this._application.Users.Models.Any(u => u.UserName == userName) || this._application.Users.Models.Single(u => u.UserName == userName).HasDataAccess == false)
            return $"{userName} has no data access.";

        int count = 0;
        foreach (var product in this._application.Products.Models.Where(p => p.IsSold == true))
        {
            count++;
            product.ToggleStatus();
        }

        return $"{count} products are listed again.";
    }

    public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
    {
        if (!this._application.Users.Models.Any(u =>
                u.UserName == userName) || this._application.Users.Models.Single(u => u.UserName == userName).HasDataAccess == true)
            return $"{userName} has no authorization for this functionality.";

        if (!this._application.Products.Models.Any(p => p.ProductName == productName))
            return $"{productName} does not exist in the application.";

        if (this._application.Products.Models.Single(p => p.ProductName == productName).IsSold == true)
            return $"{productName} is out of stock.";

        //Client client = (Client)this._application.Users.Models.Single(u => u.UserName == userName);
        //client.PurchaseProduct(productName, blackFridayFlag);

        foreach (var user in this._application.Users.Models.Where(u => u.UserName == userName))
        {
            var client = (Client)user;
            client.PurchaseProduct(productName, blackFridayFlag);
        }

        //IProduct product = this._application.Products.Models.Single(p => p.ProductName == productName);
        double price = 0;;
        foreach (var product in this._application.Products.Models.Where(p => p.ProductName == productName))
        {
            product.ToggleStatus();
            price = blackFridayFlag ? product.BlackFridayPrice : product.BasePrice;
        }

        return $"{userName} purchased {productName}. Price: {price:F2}";
    }

    public string ApplicationReport()
    {
        StringBuilder sb = new();
        sb.AppendLine("Application administration:");
        foreach (var admin in this._application.Users.Models.Where(u => u is Admin).OrderBy(u => u.UserName))
            sb.AppendLine(admin.ToString());
        sb.AppendLine("Clients:");
        foreach (var user in this._application.Users.Models.Where(u => u is Client).OrderBy(u => u.UserName))
        {
            sb.AppendLine(user.ToString());
            var client = (Client)user;
            if (client.Purchases.Values.Any(p => p == true))
            {
                int count = client.Purchases.Count(p => p.Value == true);
                sb.AppendLine($"-Black Friday Purchases: {count}");
                foreach (var product in client.Purchases.Where(p => p.Value == true))
                    sb.AppendLine($"--{product.Key}");
            }
        }

        return sb.ToString().Trim();
    }
}