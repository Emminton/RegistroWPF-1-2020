Create DataBase EstudianteDb
go

use EstudianteDb
go

create Table Estudiante
(
EstudianteId int primary key identity,
Nombre varchar (40),
Telefono varchar (13),
Cedula varchar (15),
Direccion varchar (max),
FechaNacimiento dateTime,
Balance decimal,

);

create Table Inscripcion
(
InscripcionId int primary key identity,
Fecha datetime default getdate(),
EstudianteId int ,
Comentario varchar(400),
Monto decimal,
Pago decimal,
Balance decimal,

);