using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.models
{
    public class Pago:Ticket
    {

        CuentaCorriente ficha;
        static int nroInicio = 0;
        public Pago(CuentaCorriente cc)
        {
            ficha = cc;
            nroOrden = ++nroInicio;
        }
        public CuentaCorriente VerCC()
        {
            return ficha;
        }
    }
}
