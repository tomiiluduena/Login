using BE_login_Common;
using BE_login_Date.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_login_Repository

{
    public class Consultation
    {
        private readonly ApplicationDbContext _context;

        public Consultation(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios con el servicio 'Activo'
        public async Task<List<User>> ListarUsuariosActivos()
        {
            return await _context.Users
                .Where(u => u.Service == "Activo")
                .ToListAsync();
        }

        // Obtener un usuario por ID
        public async Task<User> ObtenerUsuarioPorId(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.IdUsers == id);
        }

        // Guardar un nuevo usuario
        public async Task<User> GuardarUsuario(string nombre, DateTime fecha, string servicio)
        {
            var nuevoUsuario = new User
            {
                Name = nombre,
                Date = fecha,
                Service = servicio
            };

            _context.Users.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return nuevoUsuario;
        }

        // Editar un usuario existente
        public async Task<User> EditarUsuario(int id, string nombre, DateTime fecha, string servicio)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.IdUsers == id);

            if (usuario != null)
            {
                usuario.Name = nombre;
                usuario.Date = fecha;
                usuario.Service = servicio;

                await _context.SaveChangesAsync();
            }

            return usuario;
        }

        // Eliminar un usuario por ID
        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.IdUsers == id);

            if (usuario != null)
            {
                _context.Users.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
