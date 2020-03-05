using System;
using System.Collections.Generic;

namespace ShoeShop.Models
{
  public class Location
  {
    public int Id { get; set; }

    public string Address { get; set; }

    public string ManagerName { get; set; }

    public string PhoneNumber { get; set; }

    public List<Shoe> Shoes { get; set; } = new List<Shoe>();
  }

}