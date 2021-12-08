CREATE DATABASE Banco;

USE Banco;

CREATE TABLE Usuarios
(
Id INT IDENTITY (100,1) PRIMARY KEY,
Nombre VARCHAR (100),
Apellido VARCHAR (100),
Correo VARCHAR (100),
Contraseña VARCHAR (100),
Cedula VARCHAR (15),
Direccion VARCHAR (100),
Rol VARCHAR(20)
);

CREATE TABLE Cuenta_ahorro
(
Id_usuario INT,
Numero_cuenta VARCHAR(100) PRIMARY KEY,
Saldo VARCHAR(100),
CONSTRAINT FK_Usuario_CAhorro FOREIGN KEY (Id_usuario) REFERENCES Usuarios (Id)
);

CREATE TABLE Tarjetas_Credito
(
Id_usuario INT,
Numero_Tarjeta VARCHAR(100) PRIMARY KEY,
Balance_Consumido VARCHAR(100),
Monto_Disponible VARCHAR(100)
CONSTRAINT FK_Usuario_TCredito FOREIGN KEY (Id_usuario) REFERENCES Usuarios (Id)
);

CREATE TABLE Prestamos
(
Id INT IDENTITY(0,1) PRIMARY KEY,
Id_usuario INT,
Monto_pendiente INT,
Cuotas VARCHAR(100),
Estatus VARCHAR
CONSTRAINT FK_Usuario_Prestamo FOREIGN KEY (Id_usuario) REFERENCES Usuarios (Id)
);

CREATE TABLE Historial_Prestamos
(
Id INT IDENTITY (1,1) PRIMARY KEY,
Id_prestamo INT,
Monto VARCHAR(100),
Concepto VARCHAR (100),
Restante VARCHAR(100),
Fecha DATETIME,
CONSTRAINT FK_Usuario_HPrestamos FOREIGN KEY (Id_prestamo) REFERENCES Prestamos (Id)
);

CREATE TABLE Transacciones
(
Id INT IDENTITY (1,1) PRIMARY KEY,
Numero_cuenta VARCHAR (100),
Tipo VARCHAR(100),
Monto VARCHAR(100),
Fecha DATETIME
CONSTRAINT FK_Usuario_HAhorro FOREIGN KEY (Numero_cuenta) REFERENCES Cuenta_ahorro (Numero_cuenta)
);

CREATE TABLE Historial_Credito
(
Id INT IDENTITY (1,1) PRIMARY KEY,
Numero_Tarjeta VARCHAR(100),
Monto VARCHAR(100),
Concepto VARCHAR (100),
Restante VARCHAR(100),
Monto_disponible VARCHAR(100),
Fecha DATETIME,
CONSTRAINT FK_Usuario_HCredito FOREIGN KEY (Numero_Tarjeta) REFERENCES Tarjetas_Credito (Numero_Tarjeta)
);

CREATE VIEW CvCuentas
AS
SELECT c.Id_usuario, u.Nombre, u.Apellido, u.Cedula, c.Numero_cuenta, c.Saldo
FROM Cuenta_ahorro c 
INNER JOIN Usuarios u on (u.Id = c.Id_usuario)
Where u.Rol = 'Cliente'

CREATE VIEW CvPrestamos
AS
SELECT p.Id, p.Id_usuario, u.Nombre , u.Apellido, u.Cedula, p.Cuotas, p.Monto_pendiente, p.Estatus
FROM Prestamos p
INNER JOIN Usuarios u on (u.Id = p.Id_usuario)
Where u.Rol = 'Cliente'

CREATE VIEW CvTarjetas
AS
SELECT t.Id_usuario, u.Nombre, u.Apellido, u.Cedula, t.Numero_Tarjeta, t.Monto_Disponible, t.Balance_Consumido 
FROM Tarjetas_Credito t
INNER JOIN Usuarios u on (u.Id = t.Id_usuario)
Where u.Rol = 'Cliente'

CREATE VIEW CvClientes
AS
SELECT u.Id, u.Nombre, u.Apellido, u.Cedula, u.Correo, u.Contraseña, u.Direccion
FROM Usuarios u 
WHERE u.Rol ='Cliente'

select *from Usuarios;

select *from CvCuentas;

select *from CvPrestamos;

Select* from CvClientes;

Select* from CvTarjetas;

Select* from Cuenta_ahorro;

Select* from Prestamos;

Select* from Tarjetas_Credito;

Select* from Transacciones;

select *from Historial_Prestamos;

select *from Historial_Credito;

ALTER TABLE Tarjetas_Credito ADD Limite INT;

ALTER TABLE Usuarios ADD Status Char(1);

ALTER TABLE Historial_Prestamos ALTER COLUMN Fecha DATETIME;

alter table Prestamos alter column ;

insert into Usuarios values ('Erick', 'Betances', 'erickbetances209@gmail.com', 'Erick', '40212486837', 'Villa Consuelo', 'Administrador', 'A')