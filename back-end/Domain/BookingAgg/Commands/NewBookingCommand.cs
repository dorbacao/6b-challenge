/// <summary>
/// Command to be used by api controller to represent structure data to create new booking
/// </summary>
public class NewBookingCommand
{
    public DateTime? BookingDate { get; set; }
    public Flexibility? Flexibility { get; set; }
    public VehicleSize? VehicleSize { get; set; }
    public string? ContactNumber { get; set; }
    public string? EmailAddress { get; set; }
}