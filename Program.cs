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
    public Restaurant Restaurant { get; set; }
}


public class Restaurant
{
    public Guid Id { get; set; } // PK
    public string Name { get; set; }
    public Location Location { get; set; } // Navigation property
    public OpeningHours OpeningHours { get; set; } // Navigation property
    public string Category { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public RestaurantDeliveryInformation RestaurantDeliveryInformation { get; set; } // Navigation property
}


public class Location
{
    public Guid ID { get; set; } // PK
    public string StreetName { get; set; }
    public string Zipcode { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
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
    public string Name { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; } // Navigation property
    public Restaurant Restaurant { get; set; } // Navigation property
}

public class MenuItem
{
    public Guid ID { get; set; } // PK
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid RestaurantID { get; set; } // FK
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public MenuCategory MenuCategory { get; set; } // Navigation property
}

public class MenuCategory
{
    public Guid ID { get; set; } // PK
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid MenuItemId { get; set; } // FK
}


public class Order
{
    public Guid ID { get; set; } // PK
    public OrderStatusEnum OrderStatus { get; set; }
    public Courier Courier { get; set; } // Navigation property
    public Location PickupLocation { get; set; } // Navigation property
    public Location DeliveryLocation { get; set; } // Navigation property
    public ICollection<MenuItem> MenuItems { get; set; } // Navigation property
    public decimal TotalPrice { get; set; }
    public string Note { get; set; }
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
    public string Username { get; set; }
    public UserType UserType { get; set; } // FK
}


public class Customer
{
    public Guid ID { get; set; } // PK
    public Guid UserId { get; set; } // PK, FK
    public Guid LocationId { get; set; } // FK
    public Guid OrderID { get; set; } // FK
    public string PhoneNumber { get; set; }
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
    public string PhoneNumber { get; set; }
}


public enum OnDutyStatus
{  Available, Busy, Offline }
