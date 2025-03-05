# Projeto CRUD Simples - .NET & Angular

## Descrição
Este projeto é um CRUD simples desenvolvido para praticar conhecimentos em backend com .NET e frontend com Angular. Ele permite listar, cadastrar, editar, remover e visualizar detalhes de usuários.

## Tecnologias Utilizadas
### Backend (ASP.NET Core)
- **.NET** com camada **WebApi**
- **Dapper** para acesso a dados
- **AutoMapper** para mapeamento de objetos
- **Response Model** para padronização de respostas da API
- **Injeção de Dependência (DI)** para gestão de serviços

### Frontend (Angular 19)
- Estruturado com pastas para **componentes, models, pages e services**
- Utiliza **HttpClient** para comunicação com a API
- Interface simples exibindo uma **tabela com todos os usuários** e operações de CRUD

## Estrutura do Projeto
```
/Backend_.NET
  /WebApi
    /Controllers
    /Models
    /Services
    /Properties
    Program.cs
    WebApi.csproj

/Frontend_Angular
  /src
    /componentes/formulario
    /models
    /pages
    /services
```

## Como Executar o Projeto
### Backend
1. Navegue até a pasta do backend:
   ```sh
   cd Backend_.NET/WebApi
   ```
2. Restaure as dependências:
   ```sh
   dotnet restore
   ```
3. Execute a aplicação:
   ```sh
   dotnet run
   ```
4. A API estará disponível em `https://localhost:5203`

### Frontend
1. Navegue até a pasta do frontend:
   ```sh
   cd Frontend_Angular
   ```
2. Instale as dependências:
   ```sh
   npm install
   ```
3. Inicie o servidor:
   ```sh
   ng serve
   ```
4. Acesse `http://localhost:4200` no navegador

## Funcionalidades
- **Listar Usuários**: Exibe todos os usuários cadastrados
- **Cadastrar Usuário**: Formulário para adicionar um novo usuário
- **Editar Usuário**: Permite modificar informações de um usuário existente
- **Remover Usuário**: Exclui um usuário do sistema
- **Detalhes do Usuário**: Exibe informações detalhadas

## Contribuição
Se desejar contribuir, fique à vontade para abrir um PR ou sugerir melhorias!

---

Desenvolvido para aprendizado e prática de tecnologias backend e frontend.

