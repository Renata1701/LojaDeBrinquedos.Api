# 🐳 Docker - LojaDeBrinquedos.API

Guia completo para execução da aplicação LojaDeBrinquedos.API usando Docker e Docker Compose.

## 📋 Índice

- [Visão Geral](#visão-geral)
- [Pré-requisitos](#pré-requisitos)
- [Configuração](#configuração)
- [Execução](#execução)
- [Desenvolvimento](#desenvolvimento)
- [Troubleshooting](#troubleshooting)

## 🎯 Visão Geral

Este projeto utiliza **Docker** e **Docker Compose** para facilitar o desenvolvimento e deploy da aplicação, fornecendo um ambiente isolado e reproduzível.

### 🏗️ Arquitetura Docker

```
┌─────────────────────────────────────────────────────────────┐
│                    Docker Compose                           │
├─────────────────────────────────────────────────────────────┤
│  ┌─────────────────┐    ┌─────────────────────────────────┐ │
│  │   MySQL 8.0     │    │    LojaDeBrinquedos.API        │ │
│  │   Port: 3306    │◄──►│    Port: 5000                  │ │
│  │   Database:     │    │    .NET 8                      │ │
│  │   LojaDeBrinquedos│    │    ASP.NET Core               │ │
│  └─────────────────┘    └─────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

## ⚙️ Pré-requisitos

### Software Necessário

- [Docker Desktop](https://www.docker.com/products/docker-desktop) (Windows/Mac)
- [Docker Engine](https://docs.docker.com/engine/install/) (Linux)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Verificação da Instalação

```bash
# Verificar versão do Docker
docker --version

# Verificar versão do Docker Compose
docker-compose --version

# Verificar se o Docker está rodando
docker info
```

## ⚙️ Configuração

### Estrutura de Arquivos Docker

```
LojaDeBrinquedos.API/
├── 📄 docker-compose.yml          # Orquestração dos containers
├── 📄 Dockerfile                  # Imagem da aplicação (futuro)
├── 📁 mysql/
│   └── 📁 init/
│       └── 📄 01-init-database.sql # Script de inicialização
└── 📄 .dockerignore               # Arquivos ignorados pelo Docker
```

### Docker Compose

O arquivo `docker-compose.yml` define:

```yaml
services:
  mysql:
    image: mysql:8.0
    container_name: loja_brinquedos_mysql
    restart: unless-stopped
    environment:
      MYSQL_ROOT_PASSWORD: root123
      MYSQL_DATABASE: LojaDeBrinquedos
      MYSQL_USER: loja_user
      MYSQL_PASSWORD: loja123
    ports:
      - "3306:3306"
    volumes:
      - mysql_data:/var/lib/mysql
      - ./mysql/init:/docker-entrypoint-initdb.d
    networks:
      - loja_network
    command: --default-authentication-plugin=mysql_native_password

volumes:
  mysql_data:
    driver: local

networks:
  loja_network:
    driver: bridge
```

### Configurações do MySQL

| Configuração | Valor |
|--------------|-------|
| **Imagem** | mysql:8.0 |
| **Porta** | 3306 |
| **Database** | LojaDeBrinquedos |
| **Usuário** | loja_user |
| **Senha** | loja123 |
| **Root Password** | root123 |

## 🚀 Execução

### 1. Iniciar o Ambiente Completo

```bash
# Iniciar todos os serviços
docker-compose up -d

# Verificar status dos containers
docker-compose ps
```

### 2. Verificar Logs

```bash
# Logs do MySQL
docker-compose logs mysql

# Logs em tempo real
docker-compose logs -f mysql

# Logs de todos os serviços
docker-compose logs
```

### 3. Acessar o MySQL

```bash
# Conectar via linha de comando
docker-compose exec mysql mysql -u loja_user -p

# Conectar como root
docker-compose exec mysql mysql -u root -p
```

### 4. Parar o Ambiente

```bash
# Parar todos os serviços
docker-compose down

# Parar e remover volumes (⚠️ CUIDADO: Remove dados)
docker-compose down -v

# Parar e remover imagens
docker-compose down --rmi all
```

## 🛠️ Desenvolvimento

### Executar Apenas o Banco de Dados

```bash
# Iniciar apenas o MySQL
docker-compose up -d mysql

# Executar a aplicação localmente
dotnet run
```

### Reset do Banco de Dados

```bash
# Parar e remover volumes
docker-compose down -v

# Iniciar novamente (recria o banco)
docker-compose up -d mysql
```

### Backup e Restore

```bash
# Backup do banco
docker-compose exec mysql mysqldump -u loja_user -p LojaDeBrinquedos > backup.sql

# Restore do banco
docker-compose exec -T mysql mysql -u loja_user -p LojaDeBrinquedos < backup.sql
```

### Persistência de Dados

Os dados do MySQL são persistidos através do volume `mysql_data`:

```bash
# Localizar o volume
docker volume ls | grep loja_brinquedos

# Inspecionar o volume
docker volume inspect loja_brinquedos_mysql_data
```

## 🔧 Troubleshooting

### Problemas Comuns

#### 1. Porta 3306 já em uso

```bash
# Verificar o que está usando a porta
netstat -ano | findstr :3306

# Parar o serviço MySQL local (Windows)
net stop mysql

# Ou alterar a porta no docker-compose.yml
ports:
  - "3307:3306"  # Usar porta 3307 externamente
```

#### 2. Container não inicia

```bash
# Verificar logs detalhados
docker-compose logs mysql

# Verificar recursos do sistema
docker system df

# Limpar recursos não utilizados
docker system prune
```

#### 3. Problemas de Conexão

```bash
# Testar conectividade
docker-compose exec mysql mysql -u loja_user -p -e "SELECT 1;"

# Verificar variáveis de ambiente
docker-compose exec mysql env | grep MYSQL
```

#### 4. Dados não persistem

```bash
# Verificar se o volume está sendo usado
docker-compose exec mysql mysql -u root -p -e "SHOW VARIABLES LIKE 'datadir';"

# Recriar o volume
docker-compose down -v
docker-compose up -d
```

### Comandos Úteis

```bash
# Verificar uso de recursos
docker stats

# Limpar containers parados
docker container prune

# Limpar imagens não utilizadas
docker image prune

# Limpar tudo (⚠️ CUIDADO)
docker system prune -a
```

## 📊 Monitoramento

### Health Check

```bash
# Verificar saúde do container
docker-compose ps

# Verificar logs de saúde
docker-compose logs mysql | grep -i health
```

### Métricas

```bash
# Uso de CPU e memória
docker stats loja_brinquedos_mysql

# Tamanho do volume
docker system df -v
```

## 🔒 Segurança

### Boas Práticas

1. **Não usar senhas fracas em produção**
2. **Limitar acesso às portas**
3. **Usar secrets para senhas**
4. **Manter imagens atualizadas**

### Configuração Segura

```yaml
# Exemplo de configuração mais segura
environment:
  MYSQL_ROOT_PASSWORD: ${MYSQL_ROOT_PASSWORD}
  MYSQL_DATABASE: ${MYSQL_DATABASE}
  MYSQL_USER: ${MYSQL_USER}
  MYSQL_PASSWORD: ${MYSQL_PASSWORD}
```

## 📚 Recursos Adicionais

- [Docker Documentation](https://docs.docker.com/)
- [Docker Compose Documentation](https://docs.docker.com/compose/)
- [MySQL Docker Hub](https://hub.docker.com/_/mysql)
- [.NET Docker Hub](https://hub.docker.com/_/microsoft-dotnet)

---

**🐳 Docker torna o desenvolvimento mais fácil e consistente!**
