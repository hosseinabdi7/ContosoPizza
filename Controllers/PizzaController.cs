using ContosoPizza.Services;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        [HttpGet]

        public ActionResult<List<Pizza>> GetAll()
        {
            return PizzaServise.GetAll();
        }

        [HttpGet("{id}")]

        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaServise.Get(id);
            if (pizza == null)
                return NotFound();
            else
                return pizza;

        }


        //Post Action 
        [HttpPost]
        public ActionResult<Pizza> AddPizza(Pizza pizza)
        {
            try
            {
                PizzaServise.Add(pizza);
                return CreatedAtAction(nameof(GetAll), pizza.Id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new pizza");
            }

        }
        //Put Action 
        [HttpPut]
        public ActionResult<Pizza> EditPizza(int id, Pizza pizza)
        {
            if (id == pizza.Id)
            {
                try
                {
                    PizzaServise.Update(pizza);
                    return CreatedAtAction(nameof(GetAll), pizza.Id);
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Pizza Object Not Found");
                }
            }
            else
                return BadRequest();
        }
        //Delete Action 
        [HttpDelete]
        public ActionResult Delete(Pizza pizza)
        {
            var result = Get(pizza.Id);
            if (result != null)
                PizzaServise.Delete(pizza);
            return Ok(pizza);
        }


    }

}