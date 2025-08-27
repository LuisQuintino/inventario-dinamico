CREATE TABLE Operador (
    Codigo VARCHAR(36) PRIMARY KEY,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Senha VARCHAR(200) NOT NULL,
    DtInclusao DATETIME NOT NULL,
    DtSituacao DATETIME NOT NULL,
    Situacao INT NOT NULL,
    TipoOperador INT NOT NULL
);

CREATE TABLE Categoria (
    Codigo VARCHAR(36) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    DtInclusao DATETIME NOT NULL,
    DtUltimaAtualizacao DATETIME NOT NULL,
    Situacao INT NOT NULL
);

CREATE TABLE Estoque (
    Codigo VARCHAR(36) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CodigoCategoria VARCHAR(36),
    QtdEmEstoque INT NOT NULL,
    DtUltimaAtualizacao DATETIME NOT NULL,
    DtInclusao DATETIME NOT NULL,
    Perecivel BIT NOT NULL,
    DtValidadeMedia DATETIME NOT NULL,
    FOREIGN KEY (CodigoCategoria) REFERENCES Categoria(Codigo)
);

CREATE TABLE Movimento (
    Codigo VARCHAR(36) PRIMARY KEY,
    CodigoEstoque VARCHAR(36),
    QtdEstoqueAntes INT NOT NULL,
    QtdEstoqueDepois INT NOT NULL,
    Diferenca INT NOT NULL,
    Motivo VARCHAR (350),
    CodigoOperador VARCHAR(36),
    FOREIGN KEY (CodigoEstoque) REFERENCES Estoque(Codigo),
    FOREIGN KEY (CodigoOperador) REFERENCES Operador(Codigo)
);

CREATE TABLE AuditTrail (
    Codigo VARCHAR(36) PRIMARY KEY,
    JsonAntigo VARCHAR(65535),
    JsonNovo VARCHAR(65535),
    NomeEntidade VARCHAR(100),
    DtAlteracao DATETIME NOT NULL
);