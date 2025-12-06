namespace jahitpintar.Features.Customer.Models;

/// <summary>
///     Represents a customer in the JahitPintar application with identity information, measurements, and preferences.
/// </summary>
public class Customer
{
    /// <summary>
    ///     Gets or sets the unique identifier for the customer.
    /// </summary>
    public string Id { get; init; } = Guid.NewGuid().ToString();

    /// <summary>
    ///     Gets or sets the user identifier associated with this customer.
    /// </summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the identity information for the customer.
    /// </summary>
    public IdentityInfo Identity { get; init; } = new();

    /// <summary>
    ///     Gets or sets the measurement information for the customer.
    /// </summary>
    public Measurements Measurements { get; init; } = new();

    /// <summary>
    ///     Gets or sets the preferences for the customer.
    /// </summary>
    public Preferences Preferences { get; init; } = new();

    /// <summary>
    ///     Gets or sets additional notes about the customer.
    /// </summary>
    public string AdditionalNotes { get; set; } = string.Empty;
}

/// <summary>
///     Represents identity information for a customer.
/// </summary>
public class IdentityInfo
{
    /// <summary>
    ///     Gets or sets the customer's full name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the customer's phone number.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the list of social media platforms the customer uses.
    /// </summary>
    public List<string> SocialMediaPlatforms { get; set; } = new();

    /// <summary>
    ///     Gets or sets the customer's address.
    /// </summary>
    public string Address { get; set; } = string.Empty;
}

/// <summary>
///     Represents measurement information for a customer.
/// </summary>
public class Measurements
{
    /// <summary>
    ///     Gets or sets the upper body measurements.
    /// </summary>
    public UpperBody Upper { get; set; } = new();

    /// <summary>
    ///     Gets or sets the lower body measurements.
    /// </summary>
    public LowerBody Lower { get; set; } = new();

    /// <summary>
    ///     Gets or sets the customer's height in centimeters.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    ///     Gets or sets the customer's weight in kilograms.
    /// </summary>
    public double Weight { get; set; }
}

/// <summary>
///     Represents upper body measurements for a customer.
/// </summary>
public class UpperBody
{
    /// <summary>
    ///     Gets or sets the chest circumference in centimeters.
    /// </summary>
    public double ChestCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the waist circumference in centimeters.
    /// </summary>
    public double WaistCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the hip circumference in centimeters.
    /// </summary>
    public double HipCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the neck circumference in centimeters.
    /// </summary>
    public double NeckCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the shoulder width in centimeters.
    /// </summary>
    public double ShoulderWidth { get; set; }

    /// <summary>
    ///     Gets or sets the sleeve length in centimeters.
    /// </summary>
    public double SleeveLength { get; set; }

    /// <summary>
    ///     Gets or sets the armhole circumference in centimeters.
    /// </summary>
    public double ArmholeCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the arm circumference in centimeters.
    /// </summary>
    public double ArmCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the wrist circumference in centimeters.
    /// </summary>
    public double WristCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the front width in centimeters.
    /// </summary>
    public double FrontWidth { get; set; }

    /// <summary>
    ///     Gets or sets the back width in centimeters.
    /// </summary>
    public double BackWidth { get; set; }

    /// <summary>
    ///     Gets or sets the shirt length in centimeters.
    /// </summary>
    public double ShirtLength { get; set; }

    /// <summary>
    ///     Gets or sets the hip height in centimeters.
    /// </summary>
    public double HipHeight { get; set; }
}

/// <summary>
///     Represents lower body measurements for a customer.
/// </summary>
public class LowerBody
{
    /// <summary>
    ///     Gets or sets the waist circumference in centimeters.
    /// </summary>
    public double WaistCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the hip circumference in centimeters.
    /// </summary>
    public double HipCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the leg length in centimeters.
    /// </summary>
    public double LegLength { get; set; }

    /// <summary>
    ///     Gets or sets the thigh circumference in centimeters.
    /// </summary>
    public double ThighCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the crotch circumference in centimeters.
    /// </summary>
    public double CrotchCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the knee circumference in centimeters.
    /// </summary>
    public double KneeCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the ankle circumference in centimeters.
    /// </summary>
    public double AnkleCircumference { get; set; }

    /// <summary>
    ///     Gets or sets the pants length in centimeters.
    /// </summary>
    public double PantsLength { get; set; }

    /// <summary>
    ///     Gets or sets the seated height in centimeters.
    /// </summary>
    public double SeatedHeight { get; set; }
}

/// <summary>
///     Represents customer preferences.
/// </summary>
public class Preferences
{
    /// <summary>
    ///     Gets or sets the preferred fitting style.
    /// </summary>
    public string FittingStyle { get; set; } = "Regular";

    /// <summary>
    ///     Gets or sets the customer's favorite fabric.
    /// </summary>
    public string FabricFavorite { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the customer's order history.
    /// </summary>
    public List<string> OrderHistory { get; set; } = new();
}