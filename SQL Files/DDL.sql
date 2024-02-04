CREATE DATABASE crud_vehicle;

CREATE SCHEMA dbo;

CREATE TABLE crud_vehicle.dbo.veiculos (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	chassi varchar(17) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	montadora varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	modelo varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	placa varchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ano_fabricacao int NULL,
);


CREATE PROCEDURE sp_InserirVeiculo
    @chassi VARCHAR(17),
    @montadora VARCHAR(50),
    @modelo VARCHAR(50),
    @placa VARCHAR(8),
    @ano_fabricacao INT
AS
BEGIN
    IF EXISTS(SELECT 1 FROM veiculos WHERE chassi = @chassi)
    BEGIN
        RAISERROR('Erro: Chassi já cadastrado.', 16, 1);
        RETURN
    END

    IF EXISTS(SELECT 1 FROM veiculos WHERE placa = @placa)
    BEGIN
        RAISERROR('Erro: Placa já cadastrada.', 16, 1);
        RETURN
    END

    INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao)
    VALUES (@chassi, @montadora, @modelo, @placa, @ano_fabricacao)
END


CREATE PROCEDURE sp_GetTodosVeiculos
AS
BEGIN
    SELECT * FROM veiculos
END

 
CREATE PROCEDURE sp_GetVeiculoPorID
    @id INT
AS
BEGIN
    SELECT * FROM veiculos WHERE id = @id
END

drop PROCEDURE sp_AtualizarVeiculo

CREATE PROCEDURE sp_AtualizarVeiculo
	@id INT,    
	@chassi VARCHAR(17),
    @montadora VARCHAR(50),
    @modelo VARCHAR(50),
    @placa VARCHAR(8),
    @ano_fabricacao INT
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM veiculos WHERE id = @id)
    BEGIN
	    RAISERROR('Erro: Veículo não encontrado.', 16, 1);
        RETURN
    END
    
    IF EXISTS(SELECT 1 FROM veiculos WHERE id != @id AND chassi = @chassi)
    BEGIN
	    RAISERROR('Erro: Chassi já cadastrado.', 16, 1);
        RETURN
    END

    IF EXISTS(SELECT 1 FROM veiculos WHERE id != @id AND placa = @placa)
    BEGIN
        RAISERROR('Erro: Placa já cadastrada.', 16, 1);
        RETURN
    END

    UPDATE veiculos
    SET chassi = @chassi, montadora = @montadora, modelo = @modelo, placa = @placa, ano_fabricacao = @ano_fabricacao
    WHERE id = @id
END


CREATE PROCEDURE sp_DeletarVeiculo
    @id INT
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM veiculos WHERE id = @id)
    BEGIN
        RAISERROR('Erro: Veículo não encontrado.', 16, 1);
        RETURN
    END

    DELETE FROM veiculos WHERE id = @id
END

INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('1HGCM82633A004352', 'Honda', 'Civic', 'FFF-5498', 2020);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('2T1BURHE5JC973672', 'Toyota', 'Corolla', 'GGG-1122', 2019);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('3VWFE21C04M000428', 'Volkswagen', 'Golf', 'HHH-3344', 2018);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('1N4AL3AP3FC577331', 'Nissan', 'Sentra', 'JJJ-5566', 2020);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('19UDE2F32GA001234', 'Acura', 'TLX', 'KKK-7788', 2021);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('SAJWA4GB4BLB48529', 'Jaguar', 'XF', 'LLL-9900', 2017);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('WBA3B9C50DF585671', 'BMW', '335i', 'MMM-1234', 2015);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('WAUB8GFF6J1012345', 'Audi', 'A3', 'NNN-5678', 2018);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('ZHWGU43T78LA11738', 'Lamborghini', 'Gallardo', 'OOO-9101', 2008);
INSERT INTO veiculos (chassi, montadora, modelo, placa, ano_fabricacao) VALUES ('1G1YZ23J9P5800342', 'Chevrolet', 'Corvette', 'PPP-1122', 1993);


