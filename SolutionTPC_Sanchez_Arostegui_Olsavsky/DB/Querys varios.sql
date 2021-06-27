USE Mediturnos

SELECT * From Medicos

SELECT M.ID, M.IDUsuario, M.IDEsPecialidad, M.APellido, M.Nombre, M.FechaNacimiento,
M.Domicilio, M.Celular, M.Genero, M.Matricula
FROM Medicos M


SELECT * FROM Pacientes

SELECT P.id, P.IDUsuario, P.IDObraSocial, P.APellido, P.Nombre, P.FechaNacimiento,
P.Domicilio, P.Celular, P.Genero, P.NroAfiliado
FROM Pacientes P

SELECT * FROM Usuarios

SELECT M.ID, M.IDUsuario, M.IDEspecialidad, M.APellido, M.Nombre, M.FechaNacimiento
, M.Domicilio, M.Celular, M.Genero,
M.Matricula, U.Email, U.Contasena FROM Medicos M JOIN Usuarios U on M.IDUsuario = U.ID
