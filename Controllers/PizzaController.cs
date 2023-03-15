using Microsoft.AspNetCore.Mvc;
using PizzaAPI.API.Models;
using Dapper;
using System.Data.SqlClient;
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
		public IActionResult GetById(int id)
		{
		if(id<1){
			return BadRequest();
		}
		Pizza pizza =BD.ObtenerPizzaPorID(id);
		if(pizza != null)
		{
			return Ok(pizza);
		}
		else{
			return NotFound();
		}
		}
		
		[HttpPost]
		public IActionResult Create(Pizza pizza){
		BD.AgregarPizza(pizza);
		return Created(pizza);	
			
		}

		[HttpUpdate("{id}")]
		public IActionResult Update(int id, Pizza pizza2){
			if(id<1){
			return BadRequest();
			}
			Pizza pizza1 =BD.ObtenerPizzaPorID(id);
			if(pizza1 != null && pizza2 != null)
			{
				BD.ActualizarPizza(id);
				return Ok();
			}
			else{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteById(int id){
		if(id<1){
		return BadRequest();
		}
		Pizza pizza =BD.ObtenerPizzaPorID(id);
		if(pizza != null)
		{
			BD.EliminarPizza(id);
			return Ok();
		}
		else{
			return NotFound();
		}

		
		}
	}
}