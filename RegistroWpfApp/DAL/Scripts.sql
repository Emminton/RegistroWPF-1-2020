Create DataBase PersonaDb
go

use PersonaDb
go

create Table Persona
(
PersonaiId int primary key identity,
Nombre varchar (40),
Telefono varchar (13),
Cedula varchar (15),
Direccion varchar (max),
FechcaNacimiento dateTime,

);