namespace jahitpintar.Models;

public class Customer
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public IdentityInfo Identity { get; init; } = new();
    public Measurements Measurements { get; init; } = new();
    public Preferences Preferences { get; init; } = new();
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
    public double WaistCircumference { get; set; }
    public double HipCircumference { get; set; }
    public double NeckCircumference { get; set; }
    public double ShoulderWidth { get; set; }
    public double SleeveLength { get; set; }
    public double ArmholeCircumference { get; set; }
    public double ArmCircumference { get; set; }
    public double WristCircumference { get; set; }
    public double FrontWidth { get; set; }
    public double BackWidth { get; set; }
    public double ShirtLength { get; set; }
    public double HipHeight { get; set; }
}

public class LowerBody
{
    public double WaistCircumference { get; set; }
    public double HipCircumference { get; set; }
    public double LegLength { get; set; }
    public double ThighCircumference { get; set; }
    public double CrotchCircumference { get; set; }
    public double KneeCircumference { get; set; }
    public double AnkleCircumference { get; set; }
    public double PantsLength { get; set; }
    public double SeatedHeight { get; set; }
}

public class Preferences
{
    public string FittingStyle { get; set; } = "Regular";
    public string FabricFavorite { get; set; } = string.Empty;
    public List<string> OrderHistory { get; set; } = new();
}