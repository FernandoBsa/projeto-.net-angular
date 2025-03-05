using AutoMapper;
using Dapper;
using Npgsql;
using WebApi.Models.DTO;
using WebApi.Models.Entity;
using WebApi.Models.Response;
using WebApi.Services.Interface;

namespace WebApi.Services.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UsuarioService(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }
    
    public async Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios()
    {
        ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();
        
        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");

            if (usuariosBanco.Count() == 0)
            {
                response.Mensagem = "Nenhum usuario encontrado";
                response.Status = false;
                return response;
            }
            
            var usuarios = _mapper.Map<List<UsuarioListarDTO>>(usuariosBanco);
            
            response.Dados = usuarios;
            response.Mensagem = "Usuario listados com sucesso";
        }
        
        return response;
    }

    public async Task<ResponseModel<Usuario>> BuscarUsuarioPorId(Guid id)
    {
        ResponseModel<Usuario> response = new ResponseModel<Usuario>();

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>("select * from Usuarios where id = @Id", new{Id = id});

            if (usuarioBanco == null)
            {
                response.Mensagem = "Nenhum usuario encontrado";
                response.Status = false;
                return response;
            }
            
            response.Dados = usuarioBanco;
            response.Mensagem = "Usuario listado com sucesso";
        }
        
        return response;
    }

    public async Task<ResponseModel<List<UsuarioListarDTO>>> CriarUsuario(UsuarioCriarDTO usuario)
    {
        ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var usuarioBanco = await connection.ExecuteAsync("insert into Usuarios (NomeCompleto, Email, Cargo, Salario, CPF, Senha, Situacao)" +
                                                             "values (@NomeCompleto, @Email, @Cargo, @Salario, @CPF, @Senha, @Situacao)", usuario);
            if (usuarioBanco == 0)
            {
                response.Mensagem = "Ocorreu um erro ao inserir um usuario";
                response.Status = false;
                return response;
            }

            var usuarios = await ListarUsuarios(connection);
            
            var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
            
            response.Dados = usuariosMapeados;
            response.Mensagem = "Usuarios listados com sucesso";
        }
        
        return response;
    }

    public async Task<ResponseModel<List<UsuarioListarDTO>>> EditarUsuario(UsuarioEditarDTO usuarioEditarDto)
    {
        ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var usuariosBanco = await connection.ExecuteAsync("update Usuarios set NomeCompleto = @NomeCompleto, Email = @Email, Cargo = @Cargo, Salario = @Salario, Situacao = @Situacao, CPF = @CPF where Id = @Id", usuarioEditarDto);

            if (usuariosBanco == 0)
            {
                response.Mensagem = "Ocorreu um erro ao editar um usuario";
                response.Status = false;
                return response;
            }
            
            var usuarios = await ListarUsuarios(connection);
            
            var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
            
            response.Dados = usuariosMapeados;
            response.Mensagem = "Usuarios listados com sucesso";
        }
        
        return response;
    }

    public async Task<ResponseModel<List<UsuarioListarDTO>>> RemoverUsuario(Guid id)
    {
        ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

        using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var usuariosBanco = await connection.ExecuteAsync("delete from Usuarios where Id = @Id", new{Id = id});
            
            if (usuariosBanco == 0)
            {
                response.Mensagem = "Ocorreu um erro ao editar um usuario";
                response.Status = false;
                return response;
            }
            
            var usuarios = await ListarUsuarios(connection);
            
            var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuarios); 
            
            response.Dados = usuariosMapeados;
            response.Mensagem = "Usuarios listados com sucesso";
        }
        
        return response;
    }

    private static async Task<IEnumerable<Usuario>> ListarUsuarios(NpgsqlConnection connection)
    {
        return await connection.QueryAsync<Usuario>("select * from Usuarios");
    }
}