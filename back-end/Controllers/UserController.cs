using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Controller is used to authenticate user by email and password
    /// </summary>
    [ApiController]
    [Route("api/identity/user")]
    [ApiExplorerSettings(GroupName = "identity/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly BookingDataContext dataContext;


        public UserController(ILogger<UserController> logger, BookingDataContext dataContext)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await dataContext.Set<User>().ToListAsync();

            return Ok(users);

        }
    
}