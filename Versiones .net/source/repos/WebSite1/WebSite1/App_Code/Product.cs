using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Un producto se describe por su Id, el precio,producto y su descripcion
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}