using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users =await _context.AppUsers.ToListAsync();
            if(users is null){
                return NotFound();
            }
            return users;
        }

         [HttpGet("{id}")]
         [Authorize]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user =await _context.AppUsers?.SingleOrDefaultAsync(x=>x.Id == id);
            if(user is null){
                return NotFound();
            }
            
            return user;
        }
    }
}