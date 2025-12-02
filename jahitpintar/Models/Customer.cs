using System.Text.Json.Serialization;

namespace jahitpintar.Models;

public class Customer
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("identity")]
    public IdentityInfo Identity { get; set; } = new();

    [JsonPropertyName("measurements")]
    public Measurements Measurements { get; set; } = new();

    [JsonPropertyName("preferences")]
    public Preferences Preferences { get; set; } = new();
}

public class IdentityInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("whatsapp")]
    public string WhatsApp { get; set; } = string.Empty;

    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;

    [JsonPropertyName("date_of_birth")]
    public DateTime? DateOfBirth { get; set; }
}

public class Measurements
{
    [JsonPropertyName("upper_body")]
    public UpperBody Upper { get; set; } = new();

    [JsonPropertyName("lower_body")]
    public LowerBody Lower { get; set; } = new();

    [JsonPropertyName("height")]
    public double Height { get; set; }

    [JsonPropertyName("weight")]
    public double Weight { get; set; }
}

public class UpperBody
{
    [JsonPropertyName("chest_circumference")]
    public double ChestCircumference { get; set; } // Lingkar Dada

    [JsonPropertyName("shoulder_width")]
    public double ShoulderWidth { get; set; } // Lebar Bahu

    [JsonPropertyName("sleeve_length")]
    public string SleeveLength { get; set; } = string.Empty; // Panjang Lengan (Pendek/Panjang) - Can be numeric or string description. "Pendek/Panjang" implies type, but usually there's a value. I'll store the value as string for flexibility or maybe add "Type" and "Value". Let's stick to string description or number. The example "PJ 135" suggests number. "Panjang Lengan (Pendek/Panjang)" might mean "Short Sleeve" or "Long Sleeve" style, OR the measurement of the sleeve. I'll use a double for the measurement and maybe a string for the type? I'll just use double for measurement and assume style is in preferences or implied. Wait, "Pendek/Panjang" might mean the USER selects if it is short or long sleeve measurement. I'll use `double Value` and maybe `string Type`. For now, I'll use `double` for the length.

    [JsonPropertyName("armhole_circumference")]
    public double ArmholeCircumference { get; set; } // Lingkar Kerung Lengan

    [JsonPropertyName("shirt_length")]
    public double ShirtLength { get; set; } // Panjang Baju
}

public class LowerBody
{
    [JsonPropertyName("waist_circumference")]
    public double WaistCircumference { get; set; } // Lingkar Pinggang

    [JsonPropertyName("hip_circumference")]
    public double HipCircumference { get; set; } // Lingkar Pinggul

    [JsonPropertyName("leg_length")]
    public double LegLength { get; set; } // Panjang Celana/Rok

    [JsonPropertyName("thigh_circumference")]
    public double ThighCircumference { get; set; } // Lingkar Paha
}

public class Preferences
{
    [JsonPropertyName("fitting_style")]
    public string FittingStyle { get; set; } = "Regular"; // Slim Fit, Regular, Loose

    [JsonPropertyName("fabric_favorite")]
    public string FabricFavorite { get; set; } = string.Empty;

    [JsonPropertyName("order_history")]
    public List<string> OrderHistory { get; set; } = new();
}
