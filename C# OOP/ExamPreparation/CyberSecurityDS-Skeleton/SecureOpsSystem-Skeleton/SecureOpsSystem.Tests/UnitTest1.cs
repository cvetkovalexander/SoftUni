using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace SecureOpsSystem.Tests;

[TestFixture]
public class SecureHubTests
{
    private readonly int _defaultCapacity = 8;
    private SecureHub _secureHub;

    [SetUp]
    public void SetUp()
    {
        this._secureHub = new(this._defaultCapacity);
    }

    [Test]
    public void InitialStateShouldBeCorrect()
    {
        Assert.That(this._secureHub.Capacity, Is.EqualTo(this._defaultCapacity));
        Assert.That(this._secureHub.Tools, Is.Not.Null);
    }

    [TestCase(-1), TestCase(0)]
    public void SecureHubShouldThrowAnExceptionIfInvalidValueForCapacityIsProvided(int n)
    {
        Assert.That(() => this._secureHub = new(n), Throws.ArgumentException);
    }

    [TestCase(1), TestCase(5), TestCase(7)]
    public void AddToolShouldWorkCorrectlyWhenThereIsCapacity(int n)
    {
        SecurityTool[] tools = this.CreateTools(n);
        for (int i = 0; i < n; i++)
        {
            Assert.That(this._secureHub.AddTool(tools[i]), Is.EqualTo($"Security Tool {tools[i].Name} added successfully."));
            Assert.That(this._secureHub.Tools.Count, Is.EqualTo(i + 1));
        }
    }

    [Test]
    public void AddToolShouldWorkCorrectlyIfToolWithNotUniqueNameIsGiven()
    {
        SecurityTool first = new("A", "B", 1);
        SecurityTool second = new("A", "B", 1);

        Assert.That(this._secureHub.AddTool(first), Is.EqualTo($"Security Tool {first.Name} added successfully."));
        Assert.That(this._secureHub.AddTool(second), Is.EqualTo($"Security Tool {second.Name} already exists in the hub."));
    }

    [TestCase(1), TestCase(2), TestCase(10)]
    public void AddToolShouldWorkCorrectlyIfThereIsNoCapacity(int n)
    {
        SecurityTool[] tools = this.CreateTools(n);
        this._secureHub = new(n);
        for (int i = 0; i < n; i++)
        {
            Assert.That(this._secureHub.AddTool(tools[i]), Is.EqualTo($"Security Tool {tools[i].Name} added successfully."));
            Assert.That(this._secureHub.Tools.Count, Is.EqualTo(i + 1));
        }

        Assert.That(this._secureHub.AddTool(new SecurityTool("A", "A", 1)), Is.EqualTo("Secure Hub is at full capacity."));
    }

    [TestCase(1), TestCase(5), TestCase(7)]
    public void RemoveToolShouldWorkCorrectly(int n)
    {
        SecurityTool[] tools = CreateTools(n);
        for (int i = 0; i < n; i++)
            this._secureHub.AddTool(tools[i]);

        for (int i = 0; i < n; i++)
        {
            Assert.That(this._secureHub.RemoveTool(tools[i]), Is.True);
        }
    }

    [TestCase(1), TestCase(5), TestCase(7)]
    public void DeployToolShouldWorkCorrectlyIfThereAreTools(int n)
    {
        SecurityTool[] tools = CreateTools(n);
        for (int i = 0; i < n; i++)
            this._secureHub.AddTool(tools[i]);

        for (int i = n - 1; i >= 0; i--)
        {
            SecurityTool current = tools[i];
            Assert.That(this._secureHub.DeployTool(tools[i].Name), Is.EqualTo(current));
            Assert.That(this._secureHub.Tools.Count, Is.EqualTo(i));
        }
    }

    [Test]
    public void DeployToolShouldReturnNullIfNoToolsAreGiven()
    {
        Assert.That(this._secureHub.DeployTool("a"), Is.Null);
    }

    [TestCase(0), TestCase(1), TestCase(7)]
    public void SystemReportShouldWorkCorrectly(int n)
    {
        SecurityTool[] tools = CreateTools(n);
        for (int i = 0; i < n; i++)
            this._secureHub.AddTool(tools[i]);

        StringBuilder sb = new();
        sb.AppendLine("Secure Hub Report:");
        sb.AppendLine($"Available Tools: {this._secureHub.Tools.Count}");

        foreach (var tool in tools.OrderByDescending(t => t.Effectiveness))
        {
            sb.AppendLine(tool.ToString());
        }

        Assert.That(sb.ToString().TrimEnd(), Is.EqualTo(this._secureHub.SystemReport()));
    }

    private SecurityTool[] CreateTools(int n)
    {
        SecurityTool[] tools = new SecurityTool[n];
        for (int i = 0; i < n; i++)
            tools[i] = new SecurityTool($"T-{i +1}", $"C-{i + 1}", i + 1);

        return tools;
    }
}
   