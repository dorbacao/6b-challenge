using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B6Challenge.Api.Controllers
{
    /// <summary>
    /// ThiscController is used to managment booking 
    /// </summary>
    [ApiController]
    [Route("api/managment/booking")]
    [ApiExplorerSettings(GroupName = "managment/booking")]
    public class BookingController : ControllerBase
    {
        #region [ Private Attributes ]

        private readonly ILogger<BookingController> logger;
        private readonly BookingDataContext dataContext;

        #endregion


        public BookingController(ILogger<BookingController> logger, BookingDataContext dataContext)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        /// <summary>
        /// Services used to get all booking thats can be approved or deleted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBookingAsync()
        {
            var allBooking = await dataContext.Set<Booking>().OrderBy(a => a.BookingDate).ToListAsync();
            return Ok(allBooking);
        }

        /// <summary>
        /// Services to approve bookings
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{bookingId}/approved")]
        public async Task<IActionResult> ApproveBookingAsync(Guid bookingId)
        {
            var candidateBooking = await dataContext.Set<Booking>().FirstOrDefaultAsync(a => a.Id == bookingId);

            if (candidateBooking == null)
                return NotFound("booking_not_found");

            if (candidateBooking.Approved)
                return BadRequest("booking_can_not_be_approved");

            candidateBooking.Approved = true;

            dataContext.Update(candidateBooking);
            await dataContext.SaveChangesAsync();

            return Ok("booking_approved_successfully");
        }

        /// <summary>
        /// Service is used to Cancel booking
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{bookingId}/cancel")]
        public async Task<IActionResult> CancelBookingAsync(Guid bookingId)
        {
            var candidateBooking = await dataContext.Set<Booking>().FirstOrDefaultAsync(a => a.Id == bookingId);

            if (candidateBooking == null)
                return NotFound("booking_not_found");

            if (!candidateBooking.Approved)
                return BadRequest("booking_can_not_be_cancelled");

            candidateBooking.Approved = false;

            dataContext.Update(candidateBooking);
            await dataContext.SaveChangesAsync();

            return Ok("booking_canceled_successfully");
        }

        /// <summary>
        /// Use this service to create new resource Booking
        /// </summary>
        /// <param name="newBookingCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewBooking([FromBody] NewBookingCommand newBookingCommand)
        {
            var newBooking = new Booking();
            newBooking.Id = Guid.NewGuid();

            if(!newBookingCommand.BookingDate.HasValue)
                return BadRequest("bookingdate_is_required");

            if (!newBookingCommand.Flexibility.HasValue)
                return BadRequest("flexibility_is_required");

            if (!newBookingCommand.VehicleSize.HasValue)
                return BadRequest("vehiclesize_is_required");

            if (string.IsNullOrWhiteSpace(newBookingCommand.EmailAddress))
                return BadRequest("email_is_required");

            if (string.IsNullOrWhiteSpace(newBookingCommand.ContactNumber))
                return BadRequest("contactnumber_is_required");

            if (newBookingCommand.BookingDate.Value.Date < DateTime.Now.Date)
                return BadRequest("bookingdate_needs_to_be greater_than_today");

            newBooking.EmailAddress = newBookingCommand.EmailAddress;
            newBooking.CreatedOn = DateTime.Now;
            newBooking.ContactNumber = newBookingCommand.ContactNumber;
            newBooking.BookingDate = newBookingCommand.BookingDate.Value.Date;
            newBooking.Flexibility = newBookingCommand.Flexibility;
            newBooking.VehicleSize = newBookingCommand.VehicleSize;
            newBooking.Approved = false;

            dataContext.Add(newBooking);

            await dataContext.SaveChangesAsync();

            return Ok("booking_created_successfully");
        }

        /// <summary>
        /// Use this services to delete the specific booking
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{bookingId}")]
        public async Task<IActionResult> DeleteBookingAsync(Guid bookingId)
        {
            var candidateBooking = await dataContext.Set<Booking>().FirstOrDefaultAsync(a => a.Id == bookingId);

            if (candidateBooking == null)
                return NotFound("booking_not_found");

            dataContext.Remove(candidateBooking);
            await dataContext.SaveChangesAsync();

            return Ok("booking_deleted_successfully");
        }

    }
}