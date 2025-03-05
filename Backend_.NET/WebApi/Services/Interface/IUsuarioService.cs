using WebApi.Models.DTO;
using WebApi.Models.Entity;
using WebApi.Models.Response;

namespace WebApi.Services.Interface;

public interface IUsuarioService
{
   Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios();
   Task<ResponseModel<Usuario>> BuscarUsuarioPorId(Guid id);
   Task<ResponseModel<List<UsuarioListarDTO>>> CriarUsuario(UsuarioCriarDTO usuario);
   Task<ResponseModel<List<UsuarioListarDTO>>> EditarUsuario(UsuarioEditarDTO usuarioEditarDto);
   Task<ResponseModel<List<UsuarioListarDTO>>> RemoverUsuario(Guid id);
}
