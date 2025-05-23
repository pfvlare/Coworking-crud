-- ===============================
-- CRIAÇÃO DO BANCO
-- ===============================
DROP DATABASE IF EXISTS CoworkingDB;
GO

CREATE DATABASE CoworkingDB;
GO

USE CoworkingDB;
GO

-- ===============================
-- TABELA Cliente
-- ===============================
CREATE TABLE Cliente (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Telefone NVARCHAR(20) NOT NULL,
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- ===============================
-- TABELA TipoSala
-- ===============================
CREATE TABLE TipoSala (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL,
    Capacidade INT NOT NULL,
    PrecoHora DECIMAL(10,2) NOT NULL
);
GO

-- ===============================
-- TABELA Sala
-- ===============================
CREATE TABLE Sala (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    TipoSalaId INT NOT NULL,
    FOREIGN KEY (TipoSalaId) REFERENCES TipoSala(Id)
);
GO

-- ===============================
-- TABELA Reserva
-- ===============================
CREATE TABLE Reserva (
    Id INT PRIMARY KEY IDENTITY,
    ClienteId INT NOT NULL,
    SalaId INT NOT NULL,
    DataReserva DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFim TIME NOT NULL,
    Observacoes NVARCHAR(MAX) NULL,
    Valor DECIMAL(10,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (ClienteId) REFERENCES Cliente(Id),
    FOREIGN KEY (SalaId) REFERENCES Sala(Id)
);
GO

-- ===============================
-- VIEW ReservaDetalhada
-- ===============================
CREATE VIEW ReservaDetalhada AS
SELECT 
    r.Id AS ReservaId,
    c.Nome AS Cliente,
    s.Nome AS Sala,
    ts.Nome AS TipoSala,
    ts.Capacidade,
    ts.PrecoHora,
    r.DataReserva,
    r.HoraInicio,
    r.HoraFim,
    r.Valor,
    r.Observacoes
FROM Reserva r
JOIN Cliente c ON r.ClienteId = c.Id
JOIN Sala s ON r.SalaId = s.Id
JOIN TipoSala ts ON s.TipoSalaId = ts.Id;
GO

-- ===============================
-- DADOS INICIAIS
-- ===============================

-- Clientes
INSERT INTO Cliente (Nome, Email, Telefone)
VALUES 
('Ana Souza', 'ana@email.com', '11999999999'),
('Carlos Lima', 'carlos@email.com', '11988888888');

-- Tipos de Sala
INSERT INTO TipoSala (Nome, Capacidade, PrecoHora)
VALUES 
('Sala de Reunião', 10, 120.00),
('Sala Compartilhada', 20, 80.00),
('Auditório', 50, 300.00);

-- Salas
INSERT INTO Sala (Nome, TipoSalaId)
VALUES 
('Sala 101', 1),
('Sala 202', 2),
('Auditório Central', 3);

-- Reservas
INSERT INTO Reserva (ClienteId, SalaId, DataReserva, HoraInicio, HoraFim, Observacoes, Valor)
VALUES 
(1, 1, '2025-05-25', '09:00:00', '11:00:00', 'Reunião com investidores', 240.00),
(2, 3, '2025-05-26', '14:00:00', '17:00:00', 'Palestra de tecnologia', 900.00);
GO
