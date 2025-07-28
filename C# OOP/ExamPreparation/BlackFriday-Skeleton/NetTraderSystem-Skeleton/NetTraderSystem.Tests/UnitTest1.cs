using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests;

public class Tests
{
    private int _defaultInventoryLimit = 8;
    private TradingPlatform _tradingPlatform;
    [SetUp]
    public void Setup()
    {
        this._tradingPlatform = new(this._defaultInventoryLimit);
    }

    [Test]
    public void InitialStateShouldBeCorrect()
    {
        Assert.That(this._tradingPlatform.Products, Is.Not.Null);
    }

    [TestCase(1), TestCase(5), TestCase(7)]
    public void AddProductShouldWorkCorrectly(int n)
    {
        Product[] products = this.CreateProducts(n);
        for (int i = 0; i < n; i++)
        {
            Assert.That(this._tradingPlatform.AddProduct(products[i]), Is.EqualTo($"Product {products[i].Name} added successfully"));
            Assert.That(this._tradingPlatform.Products.Count, Is.EqualTo(i + 1));
        }
    }

    [TestCase(4), TestCase(5)]
    public void AddMethodShouldWorkCorrectlyIfInventoryIsFull(int n)
    {
        this._tradingPlatform = new TradingPlatform(1);
        Product[] products = this.CreateProducts(n);
        this._tradingPlatform.AddProduct(products[0]);

        for (int i = 1; i < n; i++)
        {
            Assert.That(this._tradingPlatform.AddProduct(products[i]), Is.EqualTo("Inventory is full"));
            Assert.That(this._tradingPlatform.Products.Count, Is.EqualTo(1));
        }
    }
    [TestCase(1), TestCase(5), TestCase(7)]
    public void RemoveProductShouldWorkCorrectly(int n)
    {
        Product[] products = this.CreateProducts(n);
        this.AddProducts(products);

        for (int i = 0; i < n; i++)
        {
            Assert.That(this._tradingPlatform.RemoveProduct(products[i]), Is.True);
        }
    }

    [TestCase(1), TestCase(5), TestCase(7)]
    public void SellProductShouldWorkCorrectly(int n)
    {
        Product[] products = this.CreateProducts(n);
        this.AddProducts(products);

        for (int i = n - 1; i >= 0; i--)
        {
            Product current = products[i];
            Assert.That(this._tradingPlatform.SellProduct(products[i]), Is.EqualTo(current));
        }
    }

    [TestCase(0), TestCase(1), TestCase(5)]
    public void SellProductShouldReturnNullIfThereAreNoProducts(int n)
    {
        Product product = new("A", "B", 1);
        Product[] products = CreateProducts(n);
        this.AddProducts(products);

        for (int i = 0; i < n; i++)
            this._tradingPlatform.RemoveProduct(products[i]);

        Assert.That(this._tradingPlatform.SellProduct(product), Is.Null);
    }

    [TestCase(0), TestCase(1), TestCase(5)]
    public void InventoryReportShouldWorkCorrectly(int n)
    {
        this.AddProducts(this.CreateProducts(n));
        StringBuilder sb = new();
        sb.AppendLine("Inventory Report:");
        sb.AppendLine($"Available Products: {this._tradingPlatform.Products.Count}");

        foreach (var product in this._tradingPlatform.Products)
        {
            sb.AppendLine(product.ToString());
        }

        Assert.That(sb.ToString().TrimEnd(), Is.EqualTo(this._tradingPlatform.InventoryReport()));
    }

    private void AddProducts(Product[] products)
    {
        foreach (Product product in products)
            this._tradingPlatform.AddProduct(product);
    }

    private Product[] CreateProducts(int n)
    {
        Product[] products = new Product[n];
        for (int i = 0; i < n; i++)
            products[i] = new Product($"P-{i + 1}", $"C-{i + 1}", i + 1);

        return products;
    }
}