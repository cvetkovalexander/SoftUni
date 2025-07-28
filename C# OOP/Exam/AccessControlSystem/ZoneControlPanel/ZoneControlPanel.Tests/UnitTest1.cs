using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ZoneControlPanel.Tests
{
    public class Tests
    {
        private const int _defaultNumberOfZones = 3;
        private  ControlPanel _defaultPanel;
        private  string[] _defaultZones;

        [SetUp]
        public void SetUp()
        {
            this._defaultZones = this.CreateSecureZones(_defaultNumberOfZones);
            this._defaultPanel = new(this._defaultZones);
        }


        [Test]
        public void InitialStateShouldBeCorrect()
        {
            Assert.That(this._defaultPanel.Employees, Is.Not.Null);
            Assert.That(this._defaultPanel.SecureZones, Is.Not.Null);
            Assert.That(this._defaultPanel.SecureZones.Count, Is.EqualTo(_defaultNumberOfZones));
        }

        [TestCase(1), TestCase(2), TestCase(5)]
        public void AddEmployeeShouldWorkCorrectly(int n)
        {
            Employee[] employees = this.CreateEmployees(n);

            for (int i = 0; i < n; i++)
            {
                this._defaultPanel.AddEmployee(employees[i]);
                Assert.That(this._defaultPanel.Employees.Count, Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void AddEmployeesShouldWorkCorrectlyIfEmployeeWithNotUniqueNameIsGiven()
        {
            Employee first = new("E-1", "P-1" ,1);
            Employee second = new("E-1", "P-1" ,1);

            this._defaultPanel.AddEmployee(first);
            this._defaultPanel.AddEmployee(second);
            Assert.That(this._defaultPanel.Employees.Count, Is.EqualTo(1));
        }

        [TestCase(1), TestCase(5), TestCase(10)]
        public void AuthorizeEmployeeShouldWorkCorrectly(int n)
        {
            string[] secureZones = this.CreateSecureZones(n);
            Employee[] employees = this.CreateEmployees(n);
            this._defaultPanel = new(secureZones);
            for (int i = 0; i < n; i++)
            {
                Assert.That(this._defaultPanel.AuthorizeEmployee(employees[i].FullName, secureZones[i]), Is.False);
                this._defaultPanel.AddEmployee(employees[i]);
                Assert.That(this._defaultPanel.AuthorizeEmployee(employees[i].FullName, secureZones[i]), Is.True);
            }
        }

        [TestCase(0), TestCase(1), TestCase(5)]
        public void AuthorizeEmployeeShouldThrowAnExceptionIfEmployeeOrZoneIsNotFound(int n)
        {
            Employee[] employees = this.CreateEmployees(n);
            for (int i = 0; i < n; i++)
            {
                this._defaultPanel.AddEmployee(employees[i]);
                this._defaultPanel.AuthorizeEmployee(employees[i].FullName, this._defaultZones[0]);
                Assert.That(() => this._defaultPanel.AuthorizeEmployee(employees[i].FullName, this._defaultZones[0]), Throws.InvalidOperationException);
            }
        }

        [TestCase(1), TestCase(5), TestCase(10)]
        public void SecureZonesStatusShouldWorkCorrectly(int n)
        {
            Employee[] employees = this.CreateEmployees(n);
            for (int i = 0; i < n; i++)
            {
                this._defaultPanel.AddEmployee(employees[i]);
                this._defaultPanel.AuthorizeEmployee(employees[i].FullName, this._defaultZones[0]);
            }

            StringBuilder sb = new();
            SecureZone zone = this._defaultPanel.SecureZones.Single(s => s.Name == this._defaultZones[0]);
            sb.AppendLine($"Secure zone: {zone.Name}");
            sb.AppendLine("Access log:");
            foreach (int accessStamp in zone.AccessLog)
            {
                Employee? employee = this._defaultPanel.Employees.Single(e => e.AccessStamp == accessStamp);
                if (employee != null)
                {
                    sb.AppendLine(employee.ToString().TrimEnd());
                }
            }

            Assert.That(this._defaultPanel.SecureZonesStatus(this._defaultZones[0]), Is.EqualTo(sb.ToString().TrimEnd()));
        }

        [Test]
        public void SecureZonesStatusShouldWorkCorrectlyIfZoneIsNotFound()
        {
            Assert.That(this._defaultPanel.SecureZonesStatus("TestZone"), Is.EqualTo("Secure zone not found"));
        }

        private string[] CreateSecureZones(int n)
        {
            string[] zones = new string[n];
            for (int i = 0; i < n; i++)
                zones[i] = $"SZ-{i + 1}";
            return zones;
        }

        private Employee[] CreateEmployees(int n)
        {
            Employee[] employees = new Employee[n];
            for (int i = 0; i < n; i++)
                employees[i] = new Employee($"E-{i + 1}", $"P-{i + 1}", i + 1);
            return employees;
        }
    }
}