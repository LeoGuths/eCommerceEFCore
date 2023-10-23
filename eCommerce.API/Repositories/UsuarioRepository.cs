using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
    private readonly ECommerceContext _db;
    public UsuarioRepository(ECommerceContext db)
    {
        _db = db;
    }

    public IList<Usuario> Get()
    {
        return _db.Usuarios
            .Include(x => x.Contato)
            .OrderBy(x => x.Id)
            .ToList();
    }

    public Usuario Get(int id)
    {
        return _db.Usuarios
            .Include(x => x.Contato)
            .Include(x => x.EnderecosEntrega)
            .Include(x => x.Departamentos)
            .FirstOrDefault(x => x. Id == id)!;
    }

    public void Add(Usuario usuario)
    {
        _db.Add(usuario);
        _db.SaveChanges();
    }

    public void Update(Usuario usuario)
    {
        _db.Update(usuario);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        _db.Remove(Get(id));
        _db.SaveChanges();
    }
}