using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.models
{
    public class Cliente:Ticket
    {
        private int dni;
        static int nroInicio = 0;
        public Cliente(int dni)
        {
            this.dni = Convert.ToInt32(dni);
            nroOrden = ++nroInicio;
            if (this.dni < 300000 || this.dni > 45000000)
            {
                throw new Exception("Dni invalido");
            }
            
        }
        public int VerDNI()
        {
            return dni;
        }
    }
}
