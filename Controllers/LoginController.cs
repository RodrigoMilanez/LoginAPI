using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly WebApplication2Context _context;

        public LoginController(WebApplication2Context context)
        {
            _context = context;
        }

       
        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(LoginDTO l)
        {
            Usuarios m = _context.Usuarios.First(m => m.email == l.email);
            /*_context.Usuarios.Add(usuarios);*/
            await _context.SaveChangesAsync();
            if (l.email == null)
            {
                return NotFound();
            }
            else
            {
                if (m.senha == l.senha)
                {
                    HttpContext.Session.SetInt32("Userid", m.id);

                    return await _context.Usuarios.FindAsync(m.id);

                }
                throw new Exception("Email ou senha incorretos");
    }
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.id == id);
        }
    }
}
