using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenGourWS.Modelo;
using OpenGourWS.Modelo.Helper;

namespace OpenGourWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly OpenGroupContext _context;

        public PedidoController(OpenGroupContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public Pedido Pedido
        {
            get => default;
            set
            {
            }
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoResponse>>> GetPedidos()
        {
            List<PedidoResponse> groups = new List<PedidoResponse>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "SELECT Pedido_Id, c.Nombre Cliente, pr.Nombre Producto, pr.Precio, "
                        +"p.Cantidad, p.Precio Total FROM Pedido p INNER JOIN Cliente c "
                        +"ON c.Cliente_Id = p.Fk_Cliente_Id INNER JOIN Producto pr ON pr.Producto_Id = p.Fk_Producto_Id";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new PedidoResponse { pedido_Id = reader.GetInt32(0),
                                cliente = reader.GetString(1),
                                producto = reader.GetString(2),
                                precio = reader.GetDouble(3),
                                cantidad = reader.GetInt32(4),
                                total = reader.GetDouble(5)
                            };
                            groups.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
            return new ActionResult<IEnumerable<PedidoResponse>> (groups);
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.FkCliente)
                .Include(p => p.FkProducto)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return new ActionResult<Pedido>(pedido);
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, int c)
        {
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "UPDATE Pedido SET Cantidad="+c+" where Pedido.Cantidad="+id+";";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        return (IActionResult)_context.Pedidos.Find(id);
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
            return NoContent();
        }

        // POST: api/Pedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.PedidoId }, pedido);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Activo = false;
            await _context.SaveChangesAsync();

            return pedido;
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
