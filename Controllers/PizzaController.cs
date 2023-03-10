using Microsoft.AspNetCore.Mvc;
using PizzaAPI.API.Models;
namespace PizzaAPI.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PizzasController : ControllerBase {
		[HttpGet]
		public IActionResult GetAll(){
			List<Pizza> lista = BD.ObtenerPizza();
			return Ok(lista);
		}
		
		[HttpGet("{id}")]
		public IActionResult GetById(int id){
		
		}
		
		[HttpPost]
		public IActionResult Create(Pizza pizza){

		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Pizza pizza){

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteById(int id){
		
		}
	}
}