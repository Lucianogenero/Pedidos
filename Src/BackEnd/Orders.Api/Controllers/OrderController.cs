using Microsoft.AspNetCore.Mvc;
using Orders.Application.UseCases.AddNewOrder;
using Orders.Comunication.Request;
using Orders.Comunication.Response;
using System.Diagnostics.CodeAnalysis;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResposeAddedNewOrderJson),StatusCodes.Status201Created)]
        public IActionResult NewOrder([FromServices] INewOrder order, [FromBody]RequestAddNewOrderJson request)
        {
            var result = order.Execute(request);

            return Created(string.Empty,result);
        }
        /*
        [HttpGet]
        public IActionResult OrdersList()
        {
            //Obter lista de todos os pedidos
            return Ok();
        }

        [HttpPost]
        public IActionResult OrderById(int id)
        {
            //listar o pedido pelo id

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddProduct()
        {
            //add classe produto ao pedido 
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveItem(int id)
        {
            return BadRequest();
        }

        [HttpPost]
        public IActionResult FinishOrder() 
        {
            return NotFound();
        }*/
    }
}
