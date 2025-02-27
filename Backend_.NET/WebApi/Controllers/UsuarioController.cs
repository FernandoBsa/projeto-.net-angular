using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DTO;
using WebApi.Services.Interface;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarUsuarios()
    {
        var usuarios = await _usuarioService.BuscarUsuarios();
        
        if(usuarios.Status == false)
            return NotFound(usuarios);
        
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarUsuarioPorId(Guid id)
    {
        var usuario = await _usuarioService.BuscarUsuarioPorId(id);
        
        if(usuario.Status == false)
            return NotFound(usuario);
        
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario(UsuarioCriarDTO usuario)
    {
        var usuarios = await _usuarioService.CriarUsuario(usuario);
        
        if (usuarios.Status == false)
            return BadRequest(usuarios);
        
        return Ok(usuarios);
    }

    [HttpPut]
    public async Task<IActionResult> EditarUsuario(UsuarioEditarDTO usuarioEditarDto)
    {
        var usuarios = await _usuarioService.EditarUsuario(usuarioEditarDto);
        
        if(usuarios.Status == false)
            return BadRequest(usuarios);
        
        return Ok(usuarios);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoverUsuario(Guid id)
    {
        var usuarios = await _usuarioService.RemoverUsuario(id);
        
        if (usuarios.Status == false)
            return BadRequest(usuarios);
        
        return Ok(usuarios);
    }
}