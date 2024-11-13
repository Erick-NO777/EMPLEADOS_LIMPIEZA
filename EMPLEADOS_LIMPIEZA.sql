/**
Tabla de Empleados (CedulaEmpleado PK, NombreEmpleado, FechaNacimiento) - Tabla Fuerte

Tabla de TelefonosEmpleado (IdTelefono PK, CedulaEmpleado FK, NumeroTelefono) - Tabla Débil

Tabla de DireccionesEmpleado (IdDireccion PK, CedulaEmpleado FK, Direccion) - Tabla Débil

Tabla de PuestosEmpleado (IdPuesto PK, CedulaEmpleado FK, PuestoDesempenado) - Tabla Débil

Tabla de HistorialPuestosEmpleado (IdHistorial PK, CedulaEmpleado FK, PuestoDesempenado, AniosTrabajados, AniosTrabajadosEnPuestosDiferentes) - Tabla Débil
**/

-- Crear la base de datos
CREATE DATABASE EMPLEADOS_LIMPIEZA
GO

-- Usar la base de datos
USE EMPLEADOS_LIMPIEZA
GO

-- Tabla de empleados
CREATE TABLE Empleados (
    CedulaEmpleado INT PRIMARY KEY,
    NombreEmpleado NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL
);

-- Tabla de teléfonos de empleados
CREATE TABLE TelefonosEmpleado (
    IdTelefono INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT NOT NULL,
    NumeroTelefono NVARCHAR(15) NOT NULL,
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado)
);

-- Tabla de direcciones de empleados
CREATE TABLE DireccionesEmpleado (
    IdDireccion INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT NOT NULL,
    Direccion NVARCHAR(200) NOT NULL,
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado)
);

-- Tabla de puestos desempeñados por empleados
CREATE TABLE PuestosEmpleado (
    IdPuesto INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT NOT NULL,
    PuestoDesempenado NVARCHAR(50) NOT NULL,
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado)
);

-- Tabla de historial de puestos empleados, incluyendo años trabajados
CREATE TABLE HistorialPuestosEmpleado (
    IdHistorial INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT NOT NULL,
    PuestoDesempenado NVARCHAR(50) NOT NULL,
    AniosTrabajados INT NOT NULL,
    AniosTrabajadosEnPuestosDiferentes INT NOT NULL,
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado)
);

-- Insertar datos en la tabla Empleados
INSERT INTO Empleados (CedulaEmpleado, NombreEmpleado, FechaNacimiento)
VALUES 
(1001, 'Juan Pérez', '1980-05-12'),
(1002, 'María Gómez', '1990-11-23'),
(1003, 'Luis Ramírez', '1985-08-09'),
(1004, 'Ana Sánchez', '1992-04-15'),
(1005, 'Pedro Castillo', '1978-01-30'),
(1006, 'Rosa Martínez', '1983-07-20'),
(1007, 'Javier López', '1995-12-05'),
(1008, 'Lucía Fernández', '1987-09-30');

-- Insertar datos en la tabla TelefonosEmpleado
INSERT INTO TelefonosEmpleado (CedulaEmpleado, NumeroTelefono)
VALUES 
(1001, '555-1234'),
(1001, '555-5678'),
(1002, '555-2345'),
(1003, '555-3456'),
(1004, '555-4567'),
(1004, '555-6789'),
(1005, '555-7890'),
(1006, '555-8901'),
(1007, '555-9012'),
(1008, '555-0123');

-- Insertar datos en la tabla DireccionesEmpleado
INSERT INTO DireccionesEmpleado (CedulaEmpleado, Direccion)
VALUES 
(1001, 'Calle 10, Ciudad A, 101'),
(1002, 'Av. 2, Ciudad B, 202'),
(1003, 'Calle 5, Ciudad C, 303'),
(1004, 'Calle 15, Ciudad A, 404'),
(1005, 'Calle 20, Ciudad D, 505'),
(1006, 'Av. 7, Ciudad B, 606'),
(1007, 'Calle 30, Ciudad E, 707'),
(1008, 'Calle 40, Ciudad F, 808');

-- Insertar datos en la tabla PuestosEmpleado
INSERT INTO PuestosEmpleado (CedulaEmpleado, PuestoDesempenado)
VALUES 
(1001, 'Supervisor'),
(1001, 'Operador1'),
(1002, 'Mensajero'),
(1003, 'Operador2'),
(1004, 'Supervisor'),
(1004, 'Operador1'),
(1005, 'Mensajero'),
(1006, 'Operador2'),
(1007, 'Supervisor'),
(1008, 'Operador1');

-- Insertar datos en la tabla HistorialPuestosEmpleado
INSERT INTO HistorialPuestosEmpleado (CedulaEmpleado, PuestoDesempenado, AniosTrabajados, AniosTrabajadosEnPuestosDiferentes)
VALUES 
(1001, 'Supervisor', 10, 3),
(1001, 'Operador1', 10, 3),
(1002, 'Mensajero', 5, 2),
(1003, 'Operador2', 7, 7),
(1004, 'Supervisor', 3, 3),
(1004, 'Operador1', 3, 3),
(1005, 'Mensajero', 15, 5),
(1006, 'Operador2', 12, 4),
(1007, 'Supervisor', 2, 1),
(1008, 'Operador1', 6, 6);

-- Tabla de Usuarios para autenticación
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY,
    Usuario NVARCHAR(50) NOT NULL UNIQUE,
    Clave NVARCHAR(256) NOT NULL
);

INSERT INTO Usuarios (Usuario, Clave)
VALUES ('admin', '1234');
