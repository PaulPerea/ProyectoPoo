create database proyectoEFP
use proyectoEFP
create table curso(
idcurso int Identity primary key ,
nombre varchar(50),
creditos int,
ciclo varchar(20),
descripcion varchar(20)
)

create table sede(
idSede int identity primary key,
nombre varchar(25),
direccion varchar(25),
CapasMax int
)

create table alumno(
idalu int identity primary key,
nombre varchar(25),
apellido varchar(25),
dni char(8),
correo varchar(30),
direccion varchar(30),
IDCurso int ,
IDSede int,

constraint fk_contra FOREIGN KEY (IDCurso)
References curso (idcurso),

constraint fk_contra1 FOREIGN KEY (IDSede)
References sede (idSede)
)

insert into curso values ('Programacion Orientada a Objeto',5,'III','Desarrollo con C#')
insert into curso values ('Lenguaje de Programacion',2,'II','Desarrollo con Java')
insert into curso values ('Habilidades Comunicativas',1,'IV','Desarrollo Habiliry') 

insert into sede values('CibertSamSH','Independencia',12000)
insert into sede values('CiberMaxm','San Juan de Lurigancho',12344)
insert into sede values('CibertPath','Miraflores',12331)

insert into alumno values('Jean Paul','Perea Camacho','83927342','pa@gmail.com','Los portes',3,1)
insert into alumno values('Jean Carlos','Ramoz Camsh','38346346','papapa@gmail.com','Los Jasmine',1,2)
insert into alumno values('Zach Paul','Masha TRrhon','11111111','paluje@gmail.com','Av Macias',2,2)


select * from curso 
select * from sede
select * from alumno

--procedures para el ensayo , listado , consulta , ver por inicial (word) , insertar , Reportes
create procedure RegistrarAlumno
	@nom varchar(25),
	@ape varchar(25),
	@dni char(8),
	@correo varchar(30),
	@direc varchar(25),
	@idc int,
	@ids int
as
begin
	insert into alumno values(@nom,@ape,@dni,@correo,@direc,@idc,@ids)
end

exec RegistrarAlumno 'Bean','Toreto','11111111','paluje@gmail.com','Av Macias',2,2

---------------------
--ListadoAlumno

create or alter procedure ListarAlumno
AS
BEGIN
    SELECT P.idalu, P.nombre, P.apellido, P.dni, P.correo, P.direccion, PS.nombre as nombre_pais, PE.nombre
           
    FROM alumno P
    INNER JOIN curso PS ON P.IDCurso = PS.idcurso
	INNER JOIN sede PE ON P.IDSede = PE.idSede
END

exec ListarAlumno
drop procedure ListarAlumno
