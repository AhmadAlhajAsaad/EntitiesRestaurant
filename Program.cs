using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class RestaurantDeliveryInformation
{
    public Guid ID { get; set; } // PK
    public double MinimumOrderCost { get; set; }
    
    [ForeignKey("ZeroFeeAmount")]
    public double ZeroFeeAmount { get; set; } // FK
    
    [ForeignKey("DeliveryFee")]
    public double DeliveryFee { get; set; } // FK

    // Navigation property
    public Restaurant Restaurant { get; set; } = null!;
}


public class Restaurant
{
    public Guid Id { get; set; } // PK
    public string Name { get; set; } = null!;
    public Location Location { get; set; } = null!; // Navigation property
    public OpeningHours OpeningHours { get; set; } = null!; // Navigation property
    public string Category { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Description { get; set; } = null!;
    public RestaurantDeliveryInformation RestaurantDeliveryInformation { get; set; } = null!; // Navigation property
}


public class Location
{
    public Guid ID { get; set; } // PK
    public string StreetName { get; set; } = null!;
    public string Zipcode { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string City { get; set; } = null!;
}


public class OpeningHours
{
    public Guid ID { get; set; } // PK
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
    public WeekDay Weekday { get; set; }
}

public enum WeekDay
{
    Monday, Tuesday,  Wednesday, Thursday, Friday, Saturday, Sunday
}



public class Menu
{
    public Guid ID { get; set; } // PK
    public Guid RestaurantID { get; set; } // FK
    public string Name { get; set; } = null!;
    public ICollection<MenuItem> MenuItems { get; set; } = null!; // Navigation property
    public Restaurant Restaurant { get; set; } = null!; // Navigation property
}

public class MenuItem
{
    public Guid ID { get; set; } // PK
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public Guid RestaurantID { get; set; } // FK
    public string ImageUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public MenuCategory MenuCategory { get; set; } = null!; // Navigation property
}

public class MenuCategory
{
    public Guid ID { get; set; } // PK
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid MenuItemId { get; set; } // FK
}


public class Order
{
    public Guid ID { get; set; } // PK
    public OrderStatusEnum OrderStatus { get; set; }
    public Courier Courier { get; set; } = null!; // Navigation property
    public Location PickupLocation { get; set; } = null!; // Navigation property
    public Location DeliveryLocation { get; set; } = null!; // Navigation property
    public ICollection<MenuItem> MenuItems { get; set; } = null!; // Navigation property
    public decimal TotalPrice { get; set; }
    public string Note { get; set; } = null!;
}


public enum OrderStatusEnum
{
    OrderPlaced, OrderAssignedToCourier, CourierDelivering, OrderDelivered
}


public class OrderAssignedToCourier
{
    public Guid OrderPlacedId { get; set; } // FK
    public Guid OrderAssignedToCourierId { get; set; } // FK
    public Guid CourierDeliveringId { get; set; } // FK
    public Guid OrderDeliveredId { get; set; } // FK
}



public class User
{
    public Guid ID { get; set; } // PK
    public string Username { get; set; } = null!;
    public UserType UserType { get; set; } // FK
}


public class Customer
{
    public Guid ID { get; set; } // PK
    public Guid UserId { get; set; } // PK, FK
    public Guid LocationId { get; set; } // FK
    public Guid OrderID { get; set; } // FK
    public string PhoneNumber { get; set; } = null!;
}


public class RestaurantAdmin
{
    public Guid ID { get; set; } // PK
    public Guid UserId { get; set; } // PK, FK
}


public enum UserType
{  Admin, Customer, RestaurantAdmin, Courier}


public class Courier
{
    public Guid ID { get; set; } // PK
    public Guid UserId { get; set; } // PK, FK
    public bool OnDuty { get; set; }
    public OnDutyStatus OnDutyStatus { get; set; }
    public string PhoneNumber { get; set; } = null!;
}


public enum OnDutyStatus
{  Available, Busy, Offline }

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("EntitiesRestaurant compiled successfully.");
    }
}
