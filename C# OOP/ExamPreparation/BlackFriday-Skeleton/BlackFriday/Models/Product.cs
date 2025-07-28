using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models;

public abstract class Product : IProduct
{
    private string _productName;
    private double _basePrice;

    public Product(string productName, double basePrice)
    {
        this.ProductName = productName;
        this.BasePrice = basePrice;
        this.IsSold = false;
    }

    public string ProductName
    {
        get => this._productName;
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.ProductNameRequired);
            this._productName = value;
        }
    }

    public double BasePrice
    {
        get => this._basePrice;
        private set
        {
            if (value <= 0)
                throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
            this._basePrice = value;
        }
    }

    public virtual double BlackFridayPrice { get; }
    public bool IsSold { get; private set; }
    public void UpdatePrice(double newPriceValue)
        => this.BasePrice = newPriceValue;

    public void ToggleStatus()
        => this.IsSold = !this.IsSold;

    public override string ToString()
        => $"Product: {this.ProductName}, Price: {this.BasePrice:F2}, You Save: {(this.BasePrice-this.BlackFridayPrice):F2}";
}