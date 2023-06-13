using eCommerce.API.Database;

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
        return _db.Usuarios.ToList();
    }

    public Usuario Get(int id)
    {
        return _db.Usuarios.Find(id)!;
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