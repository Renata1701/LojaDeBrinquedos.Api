# 🏪 LojaDeBrinquedos.API

Sistema completo de gerenciamento para loja de brinquedos desenvolvido em .NET 8 com arquitetura limpa e containerização Docker.

## 📋 Índice

- [Visão Geral](#visão-geral)
- [Funcionalidades](#funcionalidades)
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Uso](#uso)
- [API Endpoints](#api-endpoints)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Contribuição](#contribuição)

## 🎯 Visão Geral

A **LojaDeBrinquedos.API** é uma aplicação RESTful completa para gerenciamento de loja de brinquedos, oferecendo controle total sobre produtos, clientes, pedidos, estoque e operações comerciais.

### ✨ Principais Características

- **API RESTful** com documentação Swagger
- **Arquitetura Limpa** (Clean Architecture)
- **Containerização** com Docker e Docker Compose
- **Banco de Dados MySQL** com dados de exemplo
- **Autenticação e Autorização** (em desenvolvimento)
- **Validação de Dados** e tratamento de erros

## 🚀 Funcionalidades

### 📦 Gestão de Produtos
- Cadastro, edição e exclusão de produtos
- Controle de estoque em tempo real
- Categorização de produtos
- Código de barras único
- Relacionamento com fornecedores

### 👥 Gestão de Clientes
- Cadastro de clientes com diferentes tipos (Comum, Premium, VIP)
- Histórico de compras
- Dados pessoais e de contato
- Sistema de fidelidade

### 🛒 Gestão de Pedidos
- Criação e acompanhamento de pedidos
- Status de pedidos (Pendente, Aprovado, Em Preparo, Enviado, Entregue, Cancelado)
- Cálculo automático de valores
- Itens comprados por pedido

### 💳 Sistema de Pagamento
- Múltiplas formas de pagamento (Cartão de Crédito, Débito, Dinheiro, PIX, Boleto)
- Status de pagamentos
- Histórico de transações

### 🚚 Gestão de Entregas
- Controle de entregas
- Previsão de entrega
- Status de entrega
- Endereços de entrega

### 🏢 Gestão de Funcionários
- Cadastro de funcionários
- Controle de cargos e salários
- Histórico de vendas por funcionário

### 🏭 Gestão de Fornecedores
- Cadastro de fornecedores
- Controle de produtos por fornecedor
- Dados de contato

### 🎫 Sistema de Cupons
- Cupons de desconto percentual e fixo
- Validação de datas
- Controle de quantidade de uso

### 📧 Newsletter
- Inscrição e gestão de newsletter
- Controle de status de inscrição

### 📊 Relatórios
- Relatórios de estoque
- Controle de vendas
- Análise de produtos

## 🛠️ Tecnologias

### Backend
- **.NET 8** - Framework principal
- **ASP.NET Core** - Web API
- **Entity Framework Core** - ORM (em desenvolvimento)
- **Swagger/OpenAPI** - Documentação da API

### Banco de Dados
- **MySQL 8.0** - Banco de dados principal
- **Microsoft.Data.SqlClient** - Driver de conexão

### Containerização
- **Docker** - Containerização da aplicação
- **Docker Compose** - Orquestração de containers

### Arquitetura
- **Clean Architecture** - Separação de responsabilidades
- **Repository Pattern** - Padrão de acesso a dados
- **Service Layer** - Camada de serviços
- **DTO Pattern** - Transferência de dados

## 🏗️ Arquitetura

```
LojaDeBrinquedos.API/
├── 📁 Controllers/          # Controladores da API
├── 📁 Configuration/        # Configurações da aplicação
├── 📁 Model/               # Modelos de view
├── 📁 ResultModel/         # Modelos de resposta
├── 📁 LojaDeBrinquedos/
│   ├── 📁 LojaDeBrinquedos.Domain/     # Camada de domínio
│   │   ├── 📁 Entities/                # Entidades do domínio
│   │   └── 📁 Enums/                   # Enumerações
│   ├── 📁 LojaDeBrinquedos.Application/ # Camada de aplicação
│   │   ├── 📁 Dtos/                    # Data Transfer Objects
│   │   ├── 📁 Interfaces/              # Interfaces dos serviços
│   │   └── 📁 Services/                # Implementação dos serviços
│   └── 📁 LojaDeBrinquedos.Infrastructure/ # Camada de infraestrutura
│       └── 📁 Data/                    # Contexto do banco de dados
└── 📁 mysql/               # Scripts de inicialização do banco
```

## ⚙️ Instalação

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)

### Passos para Instalação

1. **Clone o repositório**
```bash
git clone <url-do-repositorio>
cd LojaDeBrinquedos.API
```

2. **Configure as credenciais do banco**
```bash
# Copie o arquivo de exemplo
cp env.example .env

# Edite o arquivo .env com suas credenciais
nano .env
```

3. **Inicie o banco de dados com Docker**
```bash
docker-compose up -d
```

4. **Restaura as dependências**
```bash
dotnet restore
```

5. **Execute a aplicação**
```bash
dotnet run
```

## ⚙️ Configuração

### 🔒 Configurações de Segurança

⚠️ **IMPORTANTE**: Antes de executar a aplicação, configure as credenciais do banco de dados:

1. **Crie um arquivo `.env`** na raiz do projeto com suas configurações:
```bash
MYSQL_ROOT_PASSWORD=sua_senha_root
MYSQL_USER=seu_usuario
MYSQL_PASSWORD=sua_senha_usuario
DB_CONNECTION_STRING=Server=localhost;Port=3306;Database=LojaDeBrinquedos;User Id=seu_usuario;Password=sua_senha_usuario;
```

2. **Nunca commite** o arquivo `.env` no repositório
3. **Use variáveis de ambiente** em produção
4. **Altere as senhas padrão** antes de usar em produção

### Variáveis de Ambiente

O arquivo `appsettings.json` contém as configurações principais:

```json
{
  "ConnectionStrings": {
    "MinhaConexaoSQL": "Server=localhost;Port=3306;Database=LojaDeBrinquedos;User Id=***;Password=***;"
  }
}
```

### Docker Compose

O arquivo `docker-compose.yml` configura:
- **MySQL 8.0** na porta 3306
- **Usuário**: [CONFIGURAR]
- **Senha**: [CONFIGURAR]
- **Database**: LojaDeBrinquedos

## 🚀 Uso

### Acessando a API

Após executar a aplicação, acesse:

- **API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger
- **Health Check**: http://localhost:5000/health

### Exemplo de Uso

```bash
# Listar produtos
curl -X GET "http://localhost:5000/api/Produto"

# Criar novo produto
curl -X POST "http://localhost:5000/api/Produto" \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Cubo Mágico",
    "descricao": "Cubo mágico 3x3x3",
    "preco": 29.90,
    "estoque": 50,
    "categoriaId": 1
  }'
```

## 📡 API Endpoints

### Produtos
- `GET /api/Produto` - Listar todos os produtos
- `GET /api/Produto/{id}` - Obter produto por ID
- `POST /api/Produto` - Criar novo produto
- `PUT /api/Produto/{id}` - Atualizar produto
- `DELETE /api/Produto/{id}` - Excluir produto

### Clientes
- `GET /api/Cliente` - Listar todos os clientes
- `GET /api/Cliente/{id}` - Obter cliente por ID
- `POST /api/Cliente` - Criar novo cliente
- `PUT /api/Cliente/{id}` - Atualizar cliente
- `DELETE /api/Cliente/{id}` - Excluir cliente

### Pedidos
- `GET /api/Pedido` - Listar todos os pedidos
- `GET /api/Pedido/{id}` - Obter pedido por ID
- `POST /api/Pedido` - Criar novo pedido
- `PUT /api/Pedido/{id}` - Atualizar pedido
- `DELETE /api/Pedido/{id}` - Excluir pedido

### Categorias
- `GET /api/Categoria` - Listar todas as categorias
- `GET /api/Categoria/{id}` - Obter categoria por ID
- `POST /api/Categoria` - Criar nova categoria
- `PUT /api/Categoria/{id}` - Atualizar categoria
- `DELETE /api/Categoria/{id}` - Excluir categoria

### Outros Endpoints
- **Funcionários**: `/api/Funcionarios`
- **Fornecedores**: `/api/Fornecedor`
- **Pagamentos**: `/api/Pagamento`
- **Entregas**: `/api/Entrega`
- **Cupons**: `/api/CupomDeDesconto`
- **Newsletter**: `/api/NewsLetter`
- **Estoque**: `/api/Estoque`
- **Frete**: `/api/Frete`

## 📊 Estrutura do Banco de Dados

### Principais Tabelas

| Tabela | Descrição |
|--------|-----------|
| `Produtos` | Cadastro de produtos |
| `Clientes` | Cadastro de clientes |
| `Pedidos` | Pedidos realizados |
| `ItensComprados` | Itens de cada pedido |
| `Categorias` | Categorias de produtos |
| `Fornecedores` | Fornecedores dos produtos |
| `Funcionarios` | Funcionários da loja |
| `Pagamentos` | Pagamentos dos pedidos |
| `Entregas` | Controle de entregas |
| `CuponsDesconto` | Cupons de desconto |
| `NewsLetter` | Inscrições em newsletter |

### Relacionamentos

- **Produtos** ↔ **Categorias** (N:1)
- **Produtos** ↔ **Fornecedores** (N:1)
- **Pedidos** ↔ **Clientes** (N:1)
- **Pedidos** ↔ **Funcionarios** (N:1)
- **ItensComprados** ↔ **Pedidos** (N:1)
- **ItensComprados** ↔ **Produtos** (N:1)
- **Pagamentos** ↔ **Pedidos** (N:1)
- **Entregas** ↔ **Pedidos** (N:1)

## 🤝 Contribuição

### Padrões de Desenvolvimento

1. **Commits**: Use [Conventional Commits](https://www.conventionalcommits.org/)
   - `feat:` - Nova funcionalidade
   - `fix:` - Correção de bug
   - `refactor:` - Refatoração
   - `test:` - Adição de testes
   - `docs:` - Documentação

2. **Código**: Siga as convenções C#
   - PascalCase para classes e métodos
   - camelCase para variáveis
   - Comentários em português

3. **Arquitetura**: Mantenha a separação de responsabilidades
   - Domain: Entidades e regras de negócio
   - Application: Casos de uso e serviços
   - Infrastructure: Acesso a dados e APIs externas

### Como Contribuir

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'feat: Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 📞 Suporte

Para dúvidas ou suporte, entre em contato através dos issues do GitHub.

---

**Desenvolvido com ❤️ usando .NET 8 e Clean Architecture**
