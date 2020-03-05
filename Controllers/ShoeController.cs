using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Models;

//http://shoe-shop1.herokuapp.com/index.html

namespace ShoeShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShoeController : Controller
  {

    public DatabaseContext db { get; set; } = new DatabaseContext();
    [HttpGet]
    public List<Shoe> GetAllShoes()
    {
      var shoes = db.Shoes.OrderBy(s => s.Name);
      return shoes.ToList();
    }

    [HttpGet("location/{location}")]
    public List<Shoe> GetAllShoes(int location)
    {
      var shoes = db.Shoes.OrderBy(s => s.Name);
      return shoes.ToList();
    }

    [HttpGet("{id}/{location}")]
    public ActionResult<Shoe> GetOneShoe(int id, int location)
    {
      var shoe = db.Shoes.FirstOrDefault(s => s.Id == id && s.LocationId == location);
      if (shoe == null)
      {
        return NotFound();
      }
      return Ok(shoe);
    }
    [HttpPost]
    public Shoe CreateShoe(Shoe shoe)
    {
      db.Shoes.Add(shoe);
      db.SaveChanges();
      return shoe;
    }
    [HttpPut("{id}/stock/{location}")]

    public Shoe UpdateStock(int id, Shoe Data)
    {
      var shoe = db.Shoes.FirstOrDefault(s => s.Id == id);
      shoe.NumberInStock -= 1;
      db.SaveChanges();
      return shoe;

    }
    [HttpDelete("{id}/delete/{location}")]
    public ActionResult DeleteShoe(int id, int location)
    {
      var shoe = db.Shoes.FirstOrDefault(s => s.Id == id);
      if (shoe == null)
      {
        return NotFound();
      }
      db.Shoes.Remove(shoe);
      db.SaveChanges();
      return Ok();
    }

    [HttpGet("sku/{SKU}")]
    public List<Shoe> GetAllSKU(string sku)
    {
      var shoes = db.Shoes.Where(s => s.SKU == sku);
      return shoes.ToList();
    }
    [HttpGet("noneleft")]
    public List<Shoe> OutOfStock(int NumberInStock)
    {
      var shoe = db.Shoes.Where(s => s.NumberInStock < 0);
      foreach (var s in shoe)
      {
        Console.WriteLine(s.Name);
      }
      return shoe.ToList();
    }

    [HttpGet("noneleft/{location}")]
    public List<Shoe> OutOfStockInLocation(int NumberInStock)
    {
      var shoe = db.Shoes.Where(s => s.NumberInStock <= 0);
      foreach (var s in shoe)
      {
        Console.WriteLine(s.Name);
      }
      return shoe.ToList();
    }







  }
}