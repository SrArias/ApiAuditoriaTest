using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test.Models;

namespace test.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase 

    {
        
      
            [HttpGet]
            [Route("Listar")]
            public dynamic ListarCliente()
            {
                List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id= "1",
                    correo="AuditoriaTest1@test.com",
                    nombre="Juanito Perez",
                    edad="22"
                },
                new Cliente
                {
                    id= "2",
                    correo="AuditoriaTest2@test.com",
                    nombre="Camilo Torres",
                    edad="20"
                }
            };
                return clientes;

            }
            [HttpGet]
            [Route("Listarid")]
            public dynamic ListarCliente_id(int id)
            {

                return new
                {
                    id = id.ToString(),
                    correo = "AuditoriaTest2@test.com",
                    nombre = "Camilo Torres",
                    edad = "20"
                };

            }
            [HttpPost]
            [Route("guardar")]
            public dynamic GuardarCliente(Cliente cliente)
            {
                cliente.id = "3";

                return new
                {
                    success = true,
                    messagge = "Cliente Registrado",
                    result = cliente
                };

            }
            [HttpPost]
            [Route("eliminar")]
            public dynamic EliminarCliente(Cliente cliente)
            {
                string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
                if (token != "test1")
                {
                    return new
                    {
                        success = false,
                        messagge = "token incorrecto",
                        result = ""
                    };


                }
                return new
                {
                    success = true,
                    messagge = "Cliente eliminado",
                    result = cliente
                };

            }

        }
    
}
