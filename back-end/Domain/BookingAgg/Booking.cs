/// <summary>
/// Class used to schedule a booking of reservation
/// </summary>
public class Booking
{
    public Guid? Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? BookingDate { get; set; }
    public Flexibility? Flexibility { get; set; }
    public VehicleSize? VehicleSize { get; set; }
    public string? ContactNumber { get; set; }
    public string? EmailAddress { get; set; }
    public bool Approved { get; set; }

}
