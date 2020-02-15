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
EstudianteBalance decimal,


);

drop database EstudianteDb

select * from Estudiante

create Table Inscripcion
(
InscripcionId int primary key identity,
Fecha datetime default getdate(),
Comentario varchar(400),
EstudianteId int ,
Monto decimal,
Pago decimal,
InscripcionBalance decimal,

);

select * from Inscripcion