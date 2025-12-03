namespace jahitpintar.Models;

public class Customer
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public IdentityInfo Identity { get; set; } = new();
    public Measurements Measurements { get; set; } = new();
    public Preferences Preferences { get; set; } = new();
}

public class IdentityInfo
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<string> SocialMediaPlatforms { get; set; } = new();
    public string Address { get; set; } = string.Empty;
}

public class Measurements
{
    public UpperBody Upper { get; set; } = new();
    public LowerBody Lower { get; set; } = new();
    public double Height { get; set; }
    public double Weight { get; set; }
}

public class UpperBody
{
    public double ChestCircumference { get; set; } 
    public double ShoulderWidth { get; set; } 
    public double SleeveLength { get; set; } 
    public double ArmholeCircumference { get; set; } 
    public double ShirtLength { get; set; } 
}

public class LowerBody
{
    public double WaistCircumference { get; set; } 
    public double HipCircumference { get; set; } 
    public double LegLength { get; set; } 
    public double ThighCircumference { get; set; } 
}

public class Preferences
{
    public string FittingStyle { get; set; } = "Regular"; 
    public string FabricFavorite { get; set; } = string.Empty;
    public List<string> OrderHistory { get; set; } = new();
}
