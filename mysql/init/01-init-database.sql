-- Script de inicialização do banco de dados LojaDeBrinquedos
-- Criado automaticamente pelo Docker Compose

USE LojaDeBrinquedos;

-- Tabela de Categorias
CREATE TABLE IF NOT EXISTS Categorias (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao TEXT,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabela de Fornecedores
CREATE TABLE IF NOT EXISTS Fornecedores (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(200) NOT NULL,
    CNPJ VARCHAR(18) UNIQUE,
    Email VARCHAR(100),
    Telefone VARCHAR(20),
    Endereco TEXT,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabela de Produtos
CREATE TABLE IF NOT EXISTS Produtos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(200) NOT NULL,
    Descricao TEXT,
    Preco DECIMAL(10,2) NOT NULL,
    QuantidadeEstoque INT DEFAULT 0,
    CategoriaId INT,
    FornecedorId INT,
    CodigoBarras VARCHAR(50) UNIQUE,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id),
    FOREIGN KEY (FornecedorId) REFERENCES Fornecedores(Id)
);

-- Tabela de Clientes
CREATE TABLE IF NOT EXISTS Clientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(200) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    CPF VARCHAR(14) UNIQUE,
    Telefone VARCHAR(20),
    Endereco TEXT,
    TipoCliente ENUM('Comum', 'Premium', 'VIP') DEFAULT 'Comum',
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabela de Funcionários
CREATE TABLE IF NOT EXISTS Funcionarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(200) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    CPF VARCHAR(14) UNIQUE,
    Cargo VARCHAR(100),
    Salario DECIMAL(10,2),
    DataContratacao DATE,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabela de Pedidos
CREATE TABLE IF NOT EXISTS Pedidos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ClienteId INT,
    FuncionarioId INT,
    DataPedido DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status ENUM('Pendente', 'Aprovado', 'EmPreparo', 'Enviado', 'Entregue', 'Cancelado') DEFAULT 'Pendente',
    ValorTotal DECIMAL(10,2) DEFAULT 0.00,
    Observacoes TEXT,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(Id)
);

-- Tabela de Itens Comprados
CREATE TABLE IF NOT EXISTS ItensComprados (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PedidoId INT,
    ProdutoId INT,
    Quantidade INT NOT NULL,
    PrecoUnitario DECIMAL(10,2) NOT NULL,
    PrecoTotal DECIMAL(10,2) NOT NULL,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
);

-- Tabela de Pagamentos
CREATE TABLE IF NOT EXISTS Pagamentos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PedidoId INT,
    TipoPagamento ENUM('CartaoCredito', 'CartaoDebito', 'Dinheiro', 'PIX', 'Boleto') NOT NULL,
    Valor DECIMAL(10,2) NOT NULL,
    Status ENUM('Pendente', 'Aprovado', 'Recusado', 'Cancelado') DEFAULT 'Pendente',
    DataPagamento DATETIME,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);

-- Tabela de Entregas
CREATE TABLE IF NOT EXISTS Entregas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PedidoId INT,
    EnderecoEntrega TEXT NOT NULL,
    DataEntregaPrevista DATE,
    DataEntregaRealizada DATETIME,
    Status ENUM('Pendente', 'EmTransito', 'Entregue', 'Cancelada') DEFAULT 'Pendente',
    Observacoes TEXT,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);

-- Tabela de Cupons de Desconto
CREATE TABLE IF NOT EXISTS CuponsDesconto (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    DescontoPercentual DECIMAL(5,2),
    DescontoFixo DECIMAL(10,2),
    DataInicio DATE,
    DataFim DATE,
    QuantidadeMaxima INT,
    QuantidadeUsada INT DEFAULT 0,
    Ativo BOOLEAN DEFAULT TRUE,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabela de Newsletter
CREATE TABLE IF NOT EXISTS NewsLetter (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Nome VARCHAR(100),
    Ativo BOOLEAN DEFAULT TRUE,
    DataInscricao DATETIME DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Inserir dados de exemplo
INSERT INTO Categorias (Nome, Descricao) VALUES 
('Brinquedos Educativos', 'Brinquedos que estimulam o aprendizado'),
('Brinquedos Eletrônicos', 'Brinquedos com componentes eletrônicos'),
('Brinquedos de Montar', 'Brinquedos de construção e montagem'),
('Brinquedos de Pelúcia', 'Brinquedos macios e fofos');

INSERT INTO Fornecedores (Nome, CNPJ, Email, Telefone) VALUES 
('Brinquedos ABC Ltda', '12.345.678/0001-90', 'contato@abc.com', '(11) 99999-9999'),
('Distribuidora XYZ', '98.765.432/0001-10', 'vendas@xyz.com', '(11) 88888-8888');

INSERT INTO Produtos (Nome, Descricao, Preco, QuantidadeEstoque, CategoriaId, FornecedorId, CodigoBarras) VALUES 
('Cubo Mágico', 'Cubo mágico 3x3x3', 29.90, 50, 1, 1, '7891234567890'),
('Carrinho Controle Remoto', 'Carrinho com controle remoto', 89.90, 30, 2, 2, '7891234567891'),
('Lego Classic', 'Conjunto de peças Lego', 149.90, 25, 3, 1, '7891234567892'),
('Ursinho de Pelúcia', 'Ursinho macio 30cm', 39.90, 100, 4, 2, '7891234567893');

-- Criar índices para melhor performance
CREATE INDEX idx_produtos_categoria ON Produtos(CategoriaId);
CREATE INDEX idx_produtos_fornecedor ON Produtos(FornecedorId);
CREATE INDEX idx_pedidos_cliente ON Pedidos(ClienteId);
CREATE INDEX idx_pedidos_status ON Pedidos(Status);
CREATE INDEX idx_itens_pedido ON ItensComprados(PedidoId);
CREATE INDEX idx_pagamentos_pedido ON Pagamentos(PedidoId);
