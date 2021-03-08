using handleFileCertificados.Data;
using handleFileCertificados.Interfaces;
using handleFileCertificados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace handleFileCertificados.Repository
{
    public class AsignacionRepository : IAsignacionRepository
    {
        private readonly onixcertisysContext _context;
        public AsignacionRepository(onixcertisysContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asignacion>> Get()
        {
            var asig = await _context.Asignacion.ToListAsync();
            return asig;
        }

        public async Task<Asignacion> GetById(int id)
        {
            var asig = await _context.Asignacion.FirstOrDefaultAsync(x => x.Idruta == id);
            return asig;
        }

        public async Task Insert(Asignacion asig)
        {
             _context.Asignacion.AddAsync(asig);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Asignacion asig)
        {
             _context.Asignacion.Update(asig);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var data =await  GetById(id);
            _context.Asignacion.Remove(data);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
