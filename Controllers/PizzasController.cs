using Microsoft.AspNetCore.Mvc;

namespace Nueva_carpeta.Models;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    [HttpGet]
   public IActionResult GetAll()
   {
    List<Pizza> lista = BD.GetAll();
    return Ok(lista);
   }

   [HttpGet("{Id}")]
   public IActionResult GetById(int Id)
   {
    if(Id < 1)
    {
        return BadRequest();
    }
    Pizza pizza = BD.GetById(Id);
    if(pizza == null)
    {
        return NotFound();
    }
    return Ok(pizza);
   }
   
   [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        BD.Create(pizza);
        return Ok(pizza);
    }

    [HttpPut ("{Id}")]
    public IActionResult Update(int Id, Pizza pizza)
    {
        if(Id!=pizza.Id)
        {
        return BadRequest();
        }
        if(BD.GetById(Id) == null)
        {
            return NotFound();
        }

        BD.Update(pizza, Id);
       
        return Ok(pizza);
    }

    [HttpDelete("{Id}")]
   public IActionResult DeleteById(int Id)
   {
    if(Id < 1)
    {
        return BadRequest();
    }

    Pizza pizza = BD.GetById(Id);

    if(pizza == null) 
    {
        return NotFound();
    }

    BD.DeleteById(Id);
    return Ok();
   }
}
