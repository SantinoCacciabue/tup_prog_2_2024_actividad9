﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.models
{
    public class Ticket
    {
        protected int nroOrden;
        DateTime fechaHora = DateTime.Now;
        public int VerNro()
        {
            return nroOrden;
        }
        public DateTime VerFecha()
        {
            return fechaHora;
        }
    }
}
