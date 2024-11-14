using ComercioLib.DTOs;
using ComercioLib.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapiServicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        readonly static Comercio comercio = new Comercio();//el readonly hace q la primera vez se instancie y después ya queda guardado
        [HttpGet("AgregarTicket")]
        public IActionResult GetAgregarTicket(int tipo, int dni, int nroCC)
        {
            Ticket t = null;
            if (tipo == 1)
            {
                t = new Cliente(dni);
            }
            if (tipo == 2)
            {
                CuentaCorriente? cc = comercio.VerCC(nroCC);
                if (cc != null)
                {
                    t = new Pago(cc);
                }
                else
                {
                    return NotFound("No encontró la cuenta corriente");
                }


            }
            if (t != null)
            {
                comercio.AgregarTicket(t);
                return Ok("Turno solicitado ok!");
            }
            return NoContent();
        }

        [HttpGet("Agregar Cuenta Corriente")]
        public IActionResult GetAgregarCuentaCorriente(int nro, string dni)
        {
            CuentaCorriente? cc = comercio.AgregarCuentaCorriente(nro, dni);
            if (cc != null) return Ok("La cuenta fue agregada");
            return NotFound();
        }

        [HttpGet("Atender ticket")]
        public IActionResult GetAtenderTicket(int tipo)
        {
            Ticket? atendido = comercio.AtenderTicket(tipo);
            if (atendido != null)
            {
                TicketDTO dto = new TicketDTO(atendido);
                return Ok(dto);
            }
            return NotFound("no se encontraron tickets");
        }
    }
}
