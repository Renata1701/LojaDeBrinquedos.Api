# 🐳 Docker Compose - Loja de Brinquedos API

Este projeto inclui uma configuração Docker Compose completa com MySQL para desenvolvimento local.

## 🚀 Início Rápido

### 1. Subir os Containers
```bash
docker-compose up -d
```

### 2. Verificar Status
```bash
docker-compose ps
```

### 3. Acessar o Banco de Dados
- **MySQL**: `localhost:3306`
- **phpMyAdmin**: `http://localhost:8080`
  - Usuário: `root`
  - Senha: `root123`

## 📋 Configurações

### MySQL Container
- **Imagem**: MySQL 8.0
- **Porta**: 3306
- **Database**: LojaDeBrinquedos
- **Usuário Root**: root
- **Senha Root**: root123
- **Usuário Aplicação**: loja_user
- **Senha Aplicação**: loja123

### phpMyAdmin Container
- **Porta**: 8080
- **Acesso**: http://localhost:8080

## 🔧 Comandos Úteis

### Gerenciar Containers
```bash
# Subir containers
docker-compose up -d

# Parar containers
docker-compose down

# Ver logs
docker-compose logs mysql

# Reiniciar containers
docker-compose restart

# Remover containers e volumes
docker-compose down -v
```

### Acessar MySQL via CLI
```bash
# Conectar ao MySQL
docker exec -it loja_brinquedos_mysql mysql -u root -p

# Backup do banco
docker exec loja_brinquedos_mysql mysqldump -u root -proot123 LojaDeBrinquedos > backup.sql

# Restaurar backup
docker exec -i loja_brinquedos_mysql mysql -u root -proot123 LojaDeBrinquedos < backup.sql
```

## 📊 Estrutura do Banco

O script de inicialização (`mysql/init/01-init-database.sql`) cria automaticamente:

### Tabelas Principais
- **Categorias** - Categorias de brinquedos
- **Fornecedores** - Fornecedores da loja
- **Produtos** - Produtos disponíveis
- **Clientes** - Cadastro de clientes
- **Funcionarios** - Funcionários da loja
- **Pedidos** - Pedidos realizados
- **ItensComprados** - Itens de cada pedido
- **Pagamentos** - Informações de pagamento
- **Entregas** - Controle de entregas
- **CuponsDesconto** - Cupons promocionais
- **NewsLetter** - Inscrições na newsletter

### Dados de Exemplo
- 4 categorias de brinquedos
- 2 fornecedores
- 4 produtos de exemplo

## 🔗 Conexão da API

A API está configurada para conectar automaticamente ao MySQL:

```json
{
  "ConnectionStrings": {
    "LojaDeBrinquedos": "Server=localhost;Port=3306;Database=LojaDeBrinquedos;User Id=root;Password=root123;"
  }
}
```

## 🛠️ Troubleshooting

### Problema: Porta 3306 já em uso
```bash
# Verificar processos na porta
netstat -ano | findstr :3306

# Parar serviço MySQL local (se houver)
net stop mysql
```

### Problema: Container não inicia
```bash
# Verificar logs
docker-compose logs mysql

# Remover volumes e recriar
docker-compose down -v
docker-compose up -d
```

### Problema: Acesso negado ao banco
```bash
# Verificar se o container está rodando
docker-compose ps

# Testar conexão
docker exec -it loja_brinquedos_mysql mysql -u root -proot123 -e "SHOW DATABASES;"
```

## 📝 Notas Importantes

1. **Primeira execução**: O MySQL pode levar alguns minutos para inicializar
2. **Dados persistentes**: Os dados são salvos no volume `mysql_data`
3. **Backup**: Sempre faça backup antes de atualizações importantes
4. **Desenvolvimento**: Esta configuração é para desenvolvimento local

## 🔒 Segurança

⚠️ **ATENÇÃO**: Esta configuração é para desenvolvimento local apenas!
- Senhas em texto plano
- Sem SSL/TLS
- Acesso root habilitado

Para produção, configure:
- Senhas fortes
- SSL/TLS
- Usuários com privilégios mínimos
- Firewall adequado
