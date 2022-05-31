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
    private readonly IJwtTokenService jwtTokenService;

    public UserController(ILogger<UserController> logger, BookingDataContext dataContext, IJwtTokenService jwtTokenService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        this.jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
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


    /// <summary>
    /// Public services to can be used for generate jwt token
    /// </summary>
    /// <param name="loginCommand"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("token")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateTokenAsync([FromBody] LoginCommand loginCommand)
    {
        if (!loginCommand.Login.IsValidEmail())
            return BadRequest("invalid_mail");

        var user = await dataContext.Set<User>().FirstOrDefaultAsync(a => a.Login == loginCommand.Login);

        if (user == null)
            return BadRequest("invalid_login_password");

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginCommand.Password, user.Password))
            return BadRequest("invalid_login_password");

        var jwtToken = jwtTokenService.GenerateJwtToken(user);

        return Ok(new { user.Login, user.Name, Token = jwtToken });
    }

}