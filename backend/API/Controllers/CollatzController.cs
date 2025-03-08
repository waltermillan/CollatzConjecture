using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace API.Controllers
{
    public class CollatzController : BaseApiController
    {
        public CollatzController()
        {

        }

        // Método existente: obtener todas las secuencias
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<int>> Get(int value)
        {
            List<int> list = new List<int>();
            list.Add(value);
            try
            {
                while (value != 1) 
                {
                    if ( (value % 2) == 0) 
                        value = functionDivideByTwo(value);
                    else
                        value = functionThreeXplusOne(value);

                    list.Add(value);
                }

                return list;
            }
            catch (Exception ex)
            {
                // Loggeamos el error para fines de depuración y luego devolvemos una respuesta con un mensaje amigable
                return StatusCode(500, new { Message = "There was an issue retrieving the continents. Please try again later.", Details = ex.Message });
            }
        }

        private int functionThreeXplusOne(int number) {
            return ((number * 3) + 1);
        }

        private int functionDivideByTwo(int number)
        {
            return (number / 2);
        }
    }
}
