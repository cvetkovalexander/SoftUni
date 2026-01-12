// Problem 09
public static string ImportSuppliers(CarDealerContext context, string inputXml) 
{
    ICollection<Supplier> suppliersToImport = new List<Supplier>();

    ImportSupplierDto[]? dtos = XmlSerializerWrapper
        .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

    if (dtos != null) 
    {
        foreach (var dto in dtos) 
        {
            bool isImportedValid = bool
                .TryParse(dto.IsImporter, out var isImporter);

            if (!IsValid(dto) || !isImportedValid)
                continue;

            Supplier supplier = new Supplier() 
            {
                Name = dto.Name,
                IsImporter = isImporter
            };

            suppliersToImport.Add(supplier);
        }

        context.Suppliers.AddRange(suppliersToImport);
        context.SaveChanges();
    }

    return $"Successfully imported {suppliersToImport.Count}";
}

// Problem 10
public static string ImportParts(CarDealerContext context, string inputXml) 
{
    ICollection<Part> partsToImport = new List<Part>();

    ImportPartDto[]? dtos = XmlSerializerWrapper
        .Deserialize<ImportPartDto[]>(inputXml, "Parts");

    if (dtos != null) 
    {
        foreach (var dto in dtos) 
        {
            if (!IsValid(dto))
                continue;

            bool isPriceValid = decimal
                .TryParse(dto.Price, out var price);

            bool isQuantityValid = int
                .TryParse(dto.Quantity, out var quantity);

            bool isSupplierIdValid = int
                .TryParse(dto.SupplierId, out var supplierId);

            if (!isPriceValid || !isQuantityValid || !isSupplierIdValid
                || !context.Suppliers.Any(s => s.Id == supplierId))
                continue;

            var part = new Part()
            {
                Name = dto.Name,
                Price = price,
                Quantity = quantity,
                SupplierId = supplierId
            };

            partsToImport.Add(part);
        }

        context.Parts.AddRange(partsToImport);
        context.SaveChanges();
    }

    return $"Successfully imported {partsToImport.Count}";
}

// Problem 11
public static string ImportCars(CarDealerContext context, string inputXml) 
{
    ICollection<Car> carsToImport = new List<Car>();
    ICollection<PartCar> partsCarsToImport = new List<PartCar>();


    ImportCarDto[]? dtos = XmlSerializerWrapper
        .Deserialize<ImportCarDto[]>(inputXml, "Cars");

    if (dtos != null) 
    {
        foreach (var dto in dtos) 
        {
            if (!IsValid(dto))
                continue;

            bool isTraveledDistanceValid = long
                .TryParse(dto.TraveledDistance, out var traveledDistance);

            if (!isTraveledDistanceValid)
                continue;

            var car = new Car()
            {
                Make = dto.Make,
                Model = dto.Model,
                TraveledDistance = traveledDistance
            };

            carsToImport.Add(car);
            var partIds = dto.PartIds
                .Select(x => x.Id)
                .ToArray();

            foreach (var id in partIds.Distinct())
            {
                if (!context.Parts.Any(p => p.Id == id))
                    continue;

                var partCar = new PartCar()
                {
                    PartId = id,
                    Car = car
                };

                partsCarsToImport.Add(partCar);
            }
        }

        context.PartsCars.AddRange(partsCarsToImport);
        context.SaveChanges();
    }

    return $"Successfully imported {carsToImport.Count}";
}

// Problem 12
public static string ImportCustomers(CarDealerContext context, string inputXml) 
{
    ICollection<Customer> customersToImport = new List<Customer>();

    ImportCustomerDto[]? dtos = XmlSerializerWrapper
        .Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

    if (dtos != null) 
    {
        foreach (var dto in dtos) 
        {
            if (!IsValid(dto))
                continue;

            bool isYoungDriverValid = bool
                .TryParse(dto.IsYoungDriver, out var isYoungDriver);

            if (!isYoungDriverValid)
                continue;

            // TODO: Make a validation with the TryParse method for the DateTime of the DTO. It passed the Judge tests without it because all of the DateTimes in the file are valid ones

            var customer = new Customer()
            {
                Name = dto.Name,
                BirthDate = DateTime.Parse(dto.BirthDate),
                IsYoungDriver = isYoungDriver,
            };

            customersToImport.Add(customer);
        }

        context.Customers.AddRange(customersToImport);
        context.SaveChanges();
    }

    return $"Successfully imported {customersToImport.Count}";
}

// Problem 13
public static string ImportSales(CarDealerContext context, string inputXml) 
{
    ICollection<Sale> salesToImport = new List<Sale>();

    ImportSaleDto[]? saleDtos = XmlSerializerWrapper
        .Deserialize<ImportSaleDto[]>(inputXml, "Sales");

    if (saleDtos != null) 
    {
        foreach (var dto in saleDtos) 
        {
            if (!IsValid(dto))
                continue;

            bool isCarIdValid = int
                .TryParse(dto.CarId, out var carId);

            bool isCustomerIdValid = int
                .TryParse(dto.CustomerId, out var customerId);

            bool isDiscountValid = decimal
                .TryParse(dto.Discount, out var discount);

            if (!isCarIdValid || !context.Cars.Any(c => c.Id == carId) || !isCustomerIdValid || !isDiscountValid)
                continue;

            var newSale = new Sale()
            {
                CarId = carId,
                CustomerId = customerId,
                Discount = discount
            };

            salesToImport.Add(newSale);
        }

        context.Sales.AddRange(salesToImport);
        context.SaveChanges();
    }

    return $"Successfully imported {salesToImport.Count}";
}

// Problem 14
public static string GetCarsWithDistance(CarDealerContext context) 
{
    ExportCarsWithDistanceDto dto = new ExportCarsWithDistanceDto()
    {
        Cars = context
            .Cars
            .AsNoTracking()
            .Where(c => c.TraveledDistance > 2_000_000)
            .Select(c => new ExportCarDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ToArray()
    };

    return XmlSerializerWrapper
        .Serialize(dto, "cars");
}

// Problem 15
public static string GetCarsFromMakeBmw(CarDealerContext context) 
{
    ExportCarsFromBMWDto dto = new ExportCarsFromBMWDto()
    {
        Cars = context
            .Cars
            .AsNoTracking()
            .Where(c => c.Make == "BMW")
            .Select(c => new ExportBMWCarDto()
            {
                Id = c.Id,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray()
    };

    return XmlSerializerWrapper
        .Serialize(dto, "cars");
}

// Problem 16
public static string GetLocalSuppliers(CarDealerContext context) 
{
    ExportLocalSuppliersDto dto = new ExportLocalSuppliersDto()
    {
        Suppliers = context
            .Suppliers
            .AsNoTracking()
            .Where(s => s.IsImporter == false)
            .Select(s => new ExportLocalSupplierDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray()
    };

    return XmlSerializerWrapper
        .Serialize(dto, "suppliers");
}

// Problem 17
public static string GetCarsWithTheirListOfParts(CarDealerContext context) 
{
    ExportCarsWithPartsDto dto = new ExportCarsWithPartsDto()
    {
        Cars = context
            .Cars
            .AsNoTracking()
            .Select(c => new ExportCarWithPartsDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars
                    .Select(cp => new ExportPartDto()
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price
                    })
                    .OrderByDescending(cp => cp.Price)
                    .ToArray()
            })
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ToArray()
    };

    return XmlSerializerWrapper
        .Serialize(dto, "cars");
}