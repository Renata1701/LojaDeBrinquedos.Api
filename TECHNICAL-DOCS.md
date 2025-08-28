# 📚 Documentação Técnica - LojaDeBrinquedos.API

Documentação técnica detalhada da arquitetura, padrões e implementação da aplicação.

## 📋 Índice

- [Arquitetura](#arquitetura)
- [Padrões de Projeto](#padrões-de-projeto)
- [Estrutura de Dados](#estrutura-de-dados)
- [API Design](#api-design)
- [Segurança](#segurança)
- [Performance](#performance)
- [Testes](#testes)
- [Deploy](#deploy)

## 🏗️ Arquitetura

### Clean Architecture

A aplicação segue os princípios da **Clean Architecture** com separação clara de responsabilidades:

```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                       │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐ │
│  │   Controllers   │  │   Middleware    │  │   Filters   │ │
│  └─────────────────┘  └─────────────────┘  └─────────────┘ │
└─────────────────────────────────────────────────────────────┘
                                │
┌─────────────────────────────────────────────────────────────┐
│                   Application Layer                         │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐ │
│  │    Services     │  │      DTOs       │  │  Interfaces │ │
│  └─────────────────┘  └─────────────────┘  └─────────────┘ │
└─────────────────────────────────────────────────────────────┘
                                │
┌─────────────────────────────────────────────────────────────┐
│                     Domain Layer                            │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐ │
│  │    Entities     │  │   Enums         │  │  Value Obj. │ │
│  └─────────────────┘  └─────────────────┘  └─────────────┘ │
└─────────────────────────────────────────────────────────────┘
                                │
┌─────────────────────────────────────────────────────────────┐
│                 Infrastructure Layer                        │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐ │
│  │   DbContext     │  │   Repositories  │  │  External   │ │
│  └─────────────────┘  └─────────────────┘  └─────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

### Camadas da Aplicação

#### 1. Presentation Layer (API)
- **Responsabilidade**: Exposição da API REST
- **Componentes**: Controllers, Middleware, Filters
- **Tecnologias**: ASP.NET Core, Swagger

#### 2. Application Layer
- **Responsabilidade**: Casos de uso e regras de aplicação
- **Componentes**: Services, DTOs, Interfaces
- **Tecnologias**: .NET 8, Dependency Injection

#### 3. Domain Layer
- **Responsabilidade**: Regras de negócio e entidades
- **Componentes**: Entities, Enums, Value Objects
- **Tecnologias**: .NET 8

#### 4. Infrastructure Layer
- **Responsabilidade**: Acesso a dados e serviços externos
- **Componentes**: DbContext, Repositories, External APIs
- **Tecnologias**: Entity Framework Core, MySQL

## 🎯 Padrões de Projeto

### Repository Pattern

```csharp
// Interface do Repository
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

// Implementação
public class Repository<T> : IRepository<T> where T : class
{
    private readonly LojaDbContext _context;
    
    public Repository(LojaDbContext context)
    {
        _context = context;
    }
    
    // Implementação dos métodos...
}
```

### Service Layer Pattern

```csharp
// Interface do Service
public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> GetAllAsync();
    Task<ProdutoDto> GetByIdAsync(int id);
    Task<ProdutoDto> CreateAsync(CreateProdutoDto dto);
    Task UpdateAsync(int id, UpdateProdutoDto dto);
    Task DeleteAsync(int id);
}

// Implementação
public class ProdutoService : IProdutoService
{
    private readonly IRepository<Produto> _repository;
    private readonly IMapper _mapper;
    
    public ProdutoService(IRepository<Produto> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    // Implementação dos métodos...
}
```

### DTO Pattern

```csharp
// DTOs para transferência de dados
public class ProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string CategoriaNome { get; set; }
}

public class CreateProdutoDto
{
    [Required]
    [StringLength(200)]
    public string Nome { get; set; }
    
    [StringLength(1000)]
    public string Descricao { get; set; }
    
    [Range(0.01, double.MaxValue)]
    public decimal Preco { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Estoque { get; set; }
    
    [Required]
    public int CategoriaId { get; set; }
}
```

## 📊 Estrutura de Dados

### Entidades do Domínio

#### Produto
```csharp
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public int CategoriaId { get; set; }
    
    // Relacionamentos
    public virtual Categoria Categoria { get; set; }
    public virtual ICollection<ItensComprados> ItensComprados { get; set; }
}
```

#### Cliente
```csharp
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public TipoDeCliente TipoCliente { get; set; }
    
    // Relacionamentos
    public virtual ICollection<Pedido> Pedidos { get; set; }
}
```

#### Pedido
```csharp
public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime DataPedido { get; set; }
    public StatusPedido Status { get; set; }
    public decimal ValorTotal { get; set; }
    public string Observacoes { get; set; }
    
    // Relacionamentos
    public virtual Cliente Cliente { get; set; }
    public virtual Funcionarios Funcionario { get; set; }
    public virtual ICollection<ItensComprados> ItensComprados { get; set; }
    public virtual Pagamento Pagamento { get; set; }
    public virtual Entrega Entrega { get; set; }
}
```

### Enums

```csharp
public enum StatusPedido
{
    Pendente,
    Aprovado,
    EmPreparo,
    Enviado,
    Entregue,
    Cancelado
}

public enum TipoDeCliente
{
    Comum,
    Premium,
    VIP
}

public enum TipoDePagamento
{
    CartaoCredito,
    CartaoDebito,
    Dinheiro,
    PIX,
    Boleto
}
```

## 🌐 API Design

### RESTful Endpoints

#### Padrão de URLs
```
GET    /api/{resource}           # Listar todos
GET    /api/{resource}/{id}      # Obter por ID
POST   /api/{resource}           # Criar novo
PUT    /api/{resource}/{id}      # Atualizar
DELETE /api/{resource}/{id}      # Excluir
```

#### Exemplos de Endpoints

```csharp
[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAll()
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoDto>> GetById(int id)
    
    [HttpPost]
    public async Task<ActionResult<ProdutoDto>> Create(CreateProdutoDto dto)
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProdutoDto dto)
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
}
```

### Response Patterns

#### Success Response
```json
{
  "success": true,
  "data": {
    "id": 1,
    "nome": "Cubo Mágico",
    "preco": 29.90
  },
  "message": "Produto criado com sucesso"
}
```

#### Error Response
```json
{
  "success": false,
  "errors": [
    {
      "field": "nome",
      "message": "O nome é obrigatório"
    }
  ],
  "message": "Dados inválidos"
}
```

### Status Codes

| Código | Descrição | Uso |
|--------|-----------|-----|
| 200 | OK | Sucesso na operação |
| 201 | Created | Recurso criado |
| 204 | No Content | Sucesso sem retorno |
| 400 | Bad Request | Dados inválidos |
| 401 | Unauthorized | Não autenticado |
| 403 | Forbidden | Não autorizado |
| 404 | Not Found | Recurso não encontrado |
| 500 | Internal Server Error | Erro interno |

## 🔒 Segurança

### Validação de Dados

```csharp
public class CreateProdutoDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, MinimumLength = 3, 
        ErrorMessage = "O nome deve ter entre 3 e 200 caracteres")]
    public string Nome { get; set; }
    
    [Range(0.01, double.MaxValue, 
        ErrorMessage = "O preço deve ser maior que zero")]
    public decimal Preco { get; set; }
    
    [Range(0, int.MaxValue, 
        ErrorMessage = "O estoque não pode ser negativo")]
    public int Estoque { get; set; }
}
```

### Sanitização de Input

```csharp
public static class InputSanitizer
{
    public static string SanitizeString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
            
        return input.Trim()
                   .Replace("<", "&lt;")
                   .Replace(">", "&gt;")
                   .Replace("\"", "&quot;")
                   .Replace("'", "&#x27;");
    }
}
```

### Configuração de CORS

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
```

## ⚡ Performance

### Otimizações de Banco de Dados

#### Índices
```sql
-- Índices para melhor performance
CREATE INDEX idx_produtos_categoria ON Produtos(CategoriaId);
CREATE INDEX idx_produtos_fornecedor ON Produtos(FornecedorId);
CREATE INDEX idx_pedidos_cliente ON Pedidos(ClienteId);
CREATE INDEX idx_pedidos_status ON Pedidos(Status);
CREATE INDEX idx_itens_pedido ON ItensComprados(PedidoId);
```

#### Queries Otimizadas
```csharp
// Usando Include para evitar N+1 queries
public async Task<IEnumerable<ProdutoDto>> GetAllWithCategoryAsync()
{
    return await _context.Produtos
        .Include(p => p.Categoria)
        .Include(p => p.Fornecedor)
        .Select(p => new ProdutoDto
        {
            Id = p.Id,
            Nome = p.Nome,
            CategoriaNome = p.Categoria.Nome,
            FornecedorNome = p.Fornecedor.Nome
        })
        .ToListAsync();
}
```

### Caching

```csharp
// Cache de categorias
public async Task<IEnumerable<CategoriaDto>> GetAllCategoriasAsync()
{
    var cacheKey = "categorias_all";
    
    if (!_cache.TryGetValue(cacheKey, out IEnumerable<CategoriaDto> categorias))
    {
        categorias = await _repository.GetAllAsync();
        
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(30));
            
        _cache.Set(cacheKey, categorias, cacheOptions);
    }
    
    return categorias;
}
```

### Paginação

```csharp
public class PaginatedResult<T>
{
    public IEnumerable<T> Data { get; set; }
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}

public async Task<PaginatedResult<ProdutoDto>> GetPaginatedAsync(
    int pageNumber, int pageSize)
{
    var totalCount = await _context.Produtos.CountAsync();
    var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    
    var produtos = await _context.Produtos
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
        
    return new PaginatedResult<ProdutoDto>
    {
        Data = _mapper.Map<IEnumerable<ProdutoDto>>(produtos),
        TotalCount = totalCount,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalPages = totalPages
    };
}
```

## 🧪 Testes

### Estrutura de Testes

```
Tests/
├── 📁 Unit/
│   ├── 📁 Services/
│   ├── 📁 Controllers/
│   └── 📁 Domain/
├── 📁 Integration/
│   ├── 📁 API/
│   └── 📁 Database/
└── 📁 E2E/
    └── 📁 Scenarios/
```

### Testes Unitários

```csharp
[TestClass]
public class ProdutoServiceTests
{
    private Mock<IRepository<Produto>> _mockRepository;
    private Mock<IMapper> _mockMapper;
    private ProdutoService _service;
    
    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<IRepository<Produto>>();
        _mockMapper = new Mock<IMapper>();
        _service = new ProdutoService(_mockRepository.Object, _mockMapper.Object);
    }
    
    [TestMethod]
    public async Task GetAllAsync_ShouldReturnAllProdutos()
    {
        // Arrange
        var produtos = new List<Produto> { /* dados de teste */ };
        var dtos = new List<ProdutoDto> { /* DTOs esperados */ };
        
        _mockRepository.Setup(r => r.GetAllAsync())
            .ReturnsAsync(produtos);
        _mockMapper.Setup(m => m.Map<IEnumerable<ProdutoDto>>(produtos))
            .Returns(dtos);
            
        // Act
        var result = await _service.GetAllAsync();
        
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(dtos.Count, result.Count());
    }
}
```

### Testes de Integração

```csharp
[TestClass]
public class ProdutoControllerIntegrationTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;
    
    [TestInitialize]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("ConnectionStrings:MinhaConexaoSQL", 
                    "Server=localhost;Database=LojaDeBrinquedos_Test;");
            });
        _client = _factory.CreateClient();
    }
    
    [TestMethod]
    public async Task GetProdutos_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/api/Produto");
        
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.AreEqual("application/json", 
            response.Content.Headers.ContentType.MediaType);
    }
}
```

## 🚀 Deploy

### Configuração de Produção

#### appsettings.Production.json
```json
{
  "ConnectionStrings": {
    "MinhaConexaoSQL": "Server=[SERVER];Database=LojaDeBrinquedos;User Id=[USER];Password=[PASSWORD];"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

#### Dockerfile para Produção
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LojaDeBrinquedos.API.csproj", "./"]
RUN dotnet restore "LojaDeBrinquedos.API.csproj"
COPY . .
RUN dotnet build "LojaDeBrinquedos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaDeBrinquedos.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaDeBrinquedos.API.dll"]
```

### Docker Compose para Produção

```yaml
version: '3.8'
services:
  api:
    build: .
    ports:
      - "80:80"
      - "443:443"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__MinhaConexaoSQL=${DB_CONNECTION_STRING}
    depends_on:
      - mysql
    restart: unless-stopped

  mysql:
    image: mysql:8.0
    environment:
      MYSQL_ROOT_PASSWORD: [CONFIGURAR]
      MYSQL_DATABASE: LojaDeBrinquedos
      MYSQL_USER: [CONFIGURAR]
      MYSQL_PASSWORD: [CONFIGURAR]
    volumes:
      - mysql_data:/var/lib/mysql
    restart: unless-stopped

volumes:
  mysql_data:
```

### CI/CD Pipeline

```yaml
# .github/workflows/deploy.yml
name: Deploy to Production

on:
  push:
    branches: [ main ]

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
    
    - name: Restore dependencies
      run: dotnet restore
    
    - name: Build
      run: dotnet build --no-restore
    
    - name: Test
      run: dotnet test --no-build --verbosity normal
    
    - name: Build Docker image
      run: docker build -t loja-brinquedos-api .
    
    - name: Deploy to server
      run: |
        # Comandos de deploy
```

## 📈 Monitoramento

### Logging

```csharp
public class ProdutoController : ControllerBase
{
    private readonly ILogger<ProdutoController> _logger;
    
    public ProdutoController(ILogger<ProdutoController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Buscando todos os produtos");
        
        try
        {
            var produtos = await _service.GetAllAsync();
            _logger.LogInformation("Produtos encontrados: {Count}", produtos.Count());
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar produtos");
            return StatusCode(500, "Erro interno do servidor");
        }
    }
}
```

### Health Checks

```csharp
builder.Services.AddHealthChecks()
    .AddMySql(builder.Configuration.GetConnectionString("MinhaConexaoSQL"))
    .AddCheck("database", () => 
    {
        // Verificação customizada
        return HealthCheckResult.Healthy();
    });

app.MapHealthChecks("/health");
```

---

**📚 Esta documentação técnica deve ser mantida atualizada conforme a evolução do projeto.**
