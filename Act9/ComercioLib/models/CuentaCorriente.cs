using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.models
{
    public class CuentaCorriente : IComparable<CuentaCorriente>
    {
        int nroCuenta;
        Cliente? cliente;
        double saldo;
        public CuentaCorriente(int nroCuenta, Cliente? cliente)
        {
            this.nroCuenta = nroCuenta;
            this.cliente = cliente;
        }
        public int CompareTo(CuentaCorriente? other)
        {
            if (other != null)
            {
                return nroCuenta.CompareTo(other.nroCuenta);
            }
            return 1;
        }
    }
}
