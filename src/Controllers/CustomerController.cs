namespace FusionTech.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        protected readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> SignUp(CustomerSignUpDTO createDto)
        {
            var personCreated = await _customerService.CreateOneAsync(createDto);
            return Ok(personCreated);
        }

        [Authorize(Policy = "Customer")]
        [HttpGet("age")]
        public async Task<ActionResult<int>> GetCustomerAge()
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;
            int age = await _customerService.getAgeByEmailAsync(userEmail);
            return Ok(age);
        }

        [Authorize(Policy = "Customer")]
        [HttpPut("updateAge")]
        public async Task<IActionResult> UpdateCustomerAge([FromQuery] int age)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;
            try
            {
                var result = await _customerService.UpdateAgeAsync(userEmail, age);
                return Ok(new { message = "Customer's age updated successfully." });
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        // I wasted so many hours on this
        // I could've done so many great things in these hours
        // Instead, I wasted it here, didn't progress nor learned anything

        // Please run away. don't try to solve it. This is impossible
        [Authorize(Policy = "EmployeeOrAdmin")]
        [HttpGet("SwitchToCustomer")]
        public async Task<ActionResult<CustomerReadDto>> SwitchToCustomer(
            [FromQuery] int? age = null
        )
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email)!;

            if (age.HasValue)
                try
                {
                    var token = await _customerService.SignInAsCustomer(userEmail, age.Value);
                    return Ok(token);
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest(new { message = e.Message });
                }
            else
            {
                var token = await _customerService.SignInAsCustomer(userEmail);
                return Ok(token);
            }
        }

        [HttpGet]
        [Authorize(Policy = "admin")]
        public async Task<ActionResult<CustomerListDto>> GetAllUsers(
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var users = await _customerService.GetAllAsync(paginationOptions);
            // Each time we call this API we calculate the number of persons. Isn't this kind of costly?
            var totalCount = await _customerService.CountCustomersAsync();
            var CustomerListDto = new CustomerListDto
            {
                Customers = users,
                TotalCount = totalCount,
            };
            return Ok(CustomerListDto);
        }

        [Authorize(Policy = "Customer")]
        [HttpGet("Profile")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomerProfile()
        {
            var authenticateClaims = HttpContext.User;
            var userIdClaim = authenticateClaims.FindFirst(c =>
                c.Type == ClaimTypes.NameIdentifier
            );

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return BadRequest("User ID not found in claims");
            }

            return Ok(await _customerService.GetOneById(userId));
        }
    }
}
