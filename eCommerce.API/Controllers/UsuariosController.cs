using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuariosController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = _usuarioRepository.Get();
        if (!usuarios.Any())
            return NoContent();
        return Ok(usuarios);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var usuario = _usuarioRepository.Get(id);
        if (usuario == null)
            return NotFound("Não Encontrado");
        return Ok(usuario);
    }
    
    [HttpPost]
    public IActionResult Add([FromBody]Usuario usuario)
    {
        _usuarioRepository.Add(usuario);
        return Ok(usuario);
    }
    
    [HttpPut]
    public IActionResult Update([FromBody]Usuario usuario)
    {
        _usuarioRepository.Update(usuario);

        return Ok(usuario);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Update(int id)
    {
        _usuarioRepository.Delete(id);
        return Ok();
    }
}