using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.models
{
    public class Comercio
    {
        Queue<Pago> pagos = new Queue<Pago>();
        Queue<Cliente> clientes = new Queue<Cliente>();
        Queue<Ticket> atendidos = new Queue<Ticket>();
        List<CuentaCorriente> cuentas = new List<CuentaCorriente>();
        public void AgregarTicket(Ticket t)
        {
            if(t!= null)
            {
                if (t is Cliente)
                {
                    clientes.Enqueue((Cliente)t);
                }
                if (t is Pago)
                {
                    pagos.Enqueue((Pago)t);
                }
            }
        }
        public CuentaCorriente? VerCC(int nro)
        {
            cuentas.Sort();
            int i = cuentas.BinarySearch(new CuentaCorriente(nro,null));
            if (i >= 0)
            {
                return cuentas[i];
            }
            return null;
        }
        public CuentaCorriente? AgregarCuentaCorriente(int nro,string dni)
        {
            
            CuentaCorriente? cc = VerCC(nro);
            if (cc == null)
            {
                Cliente c = new Cliente(Convert.ToInt32(dni));
                cc = new CuentaCorriente(nro, c);
                cuentas.Add(cc);                
            }
            return cc;
            
        }
        public Ticket? AtenderTicket(int tipo)
        {
            Ticket? t = null;
            if (tipo == 1)
            {
                if(clientes.Count > 0)
                {
                    t = clientes.Dequeue();
                }
            }
            if (tipo == 2)
            {
                if(pagos.Count > 0)
                {
                    t = pagos.Dequeue();
                }
            }
            return t;
        }
    }
}
