using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using webApiDotNet.Entity;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 10.99M },
        new Product { Id = 2, Name = "Product 2", Price = 20.99M }
    };

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return products;
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
}
