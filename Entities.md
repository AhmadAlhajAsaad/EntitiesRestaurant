# Entity Class Summary

The `Entity` class is an abstract base class designed for all entities in the system. It enforces consistent properties across entities and includes fields for creation and modification tracking, as well as concurrency control. The key properties are:

- **Id:** Unique identifier for the entity.
- **CreatedAt:** Timestamp of entity creation.
- **CreatedById:** Unique identifier of the creator. 
- **CreatedByName:** Name of the creator (defaulted to an empty string).
- **UpdatedAt:** Timestamp of the last update.
- **UpdatedById:** Unique identifier of the last updater.
- **UpdatedByName:** Name of the last updater (defaulted to an empty string).

Being abstract, it cannot be instantiated independently and serves as a foundation for specific entity types.

# Entity Creation Workflow - ExampleEntity

The creation workflow for the `ExampleEntity` class is summarized below:

## 1. Inheritance from `Entity`:
```csharp
/// <summary>
/// Because it inherits from the Entity class, this class has the properties CreatedAt, CreatedById, CreatedByName, UpdatedAt, UpdatedById, UpdatedByName.
/// </summary>
public class ExampleEntity : Entity
{
    
}
```

## 2. Define Entity Properties:
```csharp
// Define properties of the entity
public string Name { get; set; }
public string Description { get; set; }
public decimal Price { get; set; }
```

## 3. Define Entity Constructor:
```csharp
// Define a constructor for the entity
public ExampleEntity(string name, string description, decimal price)
{
    Name = name;
    Description = description;
    Price = price;
}
```

## 4. Define Entity Factory Method for `ef core`:
```csharp
// Define a private constructor for ef core
private ExampleEntity()
{
    // needed for ef core
}

```

## 5. Create Domain specific methods when needed:
```csharp
// Define domain specific methods
public void Update(string name, string description, decimal price)
{
    Name = name;
    Description = description;
    Price = price;
}
```
## 6. Review the Entity Class:
```csharp
// Review the entity class
public class ExampleEntity : Entity
{
    private ExampleEntity()
    {
        // needed for ef core
    }
    
    public ExampleEntity(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    public void Update(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}
```