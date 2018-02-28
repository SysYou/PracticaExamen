using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BS
{
    public interface IMantenimiento
    {
        void Insertar(Persona persona);
        List<Persona> Mostrar();
        void Actualizar(Persona persona);
        void Borrar(Persona persona);
    }
}
