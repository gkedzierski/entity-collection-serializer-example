namespace EntityCollectionSerializerExample.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EntityCollectionSerializerExample.Data;
    using EntityCollectionSerializerExample.DTO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("users")]
    public class UsersController
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<ICollection<UserDto>>> FindAll()
        {
            return await _context.Users.Select(user => new UserDto(user)).ToListAsync();
        }
    }
}
