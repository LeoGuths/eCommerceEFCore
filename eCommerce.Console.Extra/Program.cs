using eCommerce.Console.Extra;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("GLOBAL FILTER");
var db = new ECommerceContext();
// var usuarios = db.Usuarios!.IgnoreQueryFilters().ToList();
var usuarios = db.Usuarios!.ToList();
foreach (var usuario in usuarios)
{
    Console.WriteLine($" - {usuario.Nome}");
}