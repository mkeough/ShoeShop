using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.Models;
using Microsoft.AspNetCore.Http;

namespace ShoeShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class LocationController : Controller
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();
    [HttpGet]
    public List<Location> GetAllLocations()
    {
      var locations = db.Locations.OrderBy(l => l.Address);
      return locations.ToList();
    }
    [HttpPost]
    public Location CreateLocation(Location location)
    {
      db.Locations.Add(location);
      db.SaveChanges();
      return location;
    }


  }
}