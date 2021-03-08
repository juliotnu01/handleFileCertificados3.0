using handleFileCertificados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace handleFileCertificados.Interfaces
{
    public interface IAsignacionRepository
    {
        Task<IEnumerable<Asignacion>> Get();
        Task<Asignacion> GetById(int id);
        Task Insert(Asignacion asig);
        Task Put(Asignacion asig);
        Task<bool> Delete(int id);


    }
}
