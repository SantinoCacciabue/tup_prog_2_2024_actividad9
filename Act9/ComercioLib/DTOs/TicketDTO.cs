using ComercioLib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.DTOs
{
    public class TicketDTO
    {
        public int tipo {  get; set; }
        public int nroOrden { get; set; }
        public DateTime fechaHora { get; set; }
        public CuentaCorriente? ficha { get; set; }
        public int dni { get; set; }

        public TicketDTO(Ticket t)
        {
            nroOrden = t.VerNro();
            fechaHora = t.VerFecha();
            if(t is Cliente c)
            {
                tipo = 1;
                dni = c.VerDNI();
            }
            else if(t is Pago p)
            {
                tipo = 2;
                ficha = p.VerCC();

            }
        }

    }
}
