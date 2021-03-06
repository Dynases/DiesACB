USE [DBDies]
GO
/****** Object:  Trigger [dbo].[Tr_GO_Insert_SocioLavaderoHotelRemolque]    Script Date: 26/11/2019 5:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Tr_GO_Insert_SocioLavaderoHotelRemolque] ON [dbo].[TCS01]
AFTER INSERT
AS
BEGIN

Declare 
		@numi int, @tipo int, @nsoc int, @fing date, @fnac date, @nom nvarchar(50), @apat nvarchar(50), @amat nvarchar(50),
		@dir nvarchar(100), @email nvarchar(100), @ci nvarchar(20), @fot nvarchar(20), @obs nvarchar(100), @est int,
		@telf1 nvarchar(15), @telf2 nvarchar(15), @fact date, @hact nvarchar(5), @uact nvarchar(10)

--Declarando el cursor
declare MiCursor Cursor
	for Select a.cfnumi, a.cfnsoc, a.cffing, a.cffnac, a.cfnom, a.cfapat, a.cfamat, a.cfdir2, a.cfemail, a.cfci,
			   a.cfimg, a.cfobs, a.cfest, a.cffact, a.cfhact, a.cfuact
		From inserted a 
--Abrir el cursor
open MiCursor
--Navegar
Fetch MiCursor into @numi, @nsoc, @fing, @fnac, @nom, @apat, @amat, @dir, @email, @ci, @fot, @obs, @est,
					@fact, @hact, @uact
while (@@FETCH_STATUS = 0)
begin 	
	begin try
		begin tran Tr_InsertLHR
			--Insertar en la tabla de Lavadero
			set @numi=IIF((select COUNT(lanumi) from TCL001)=0, 0, (select MAX(lanumi) from TCL001))+1

			insert into TCL001 values(@numi, 2, @nsoc, @fing, @fnac, concat(@nom,' ', @apat, ' ', @amat), '', '', @dir, @email, @ci, @fot, 
									  @obs, @est, '', '', @fact, @hact, @uact)

			--Insertar en la tabla de Hotel
			set @numi=IIF((select COUNT(hanumi) from TCH001)=0, 0, (select MAX(hanumi) from TCH001))+1

			insert into TCH001 values(@numi, 0, @nsoc, @fing, @fnac, concat(@nom,' ', @apat, ' ', @amat), '', '', @dir, @email, @ci, @fot, 
									  @obs, @est, '', '', @fact, @hact, @uact)

			--Insertar en la tabla de Remolque
			set @numi=IIF((select COUNT(ranumi) from TCR001)=0, 0, (select MAX(ranumi) from TCR001))+1

			insert into TCR001 values(@numi, 0, @nsoc, @fing, @fnac, concat(@nom,' ', @apat, ' ', @amat), '', '', @dir, @email, @ci, @fot, 
									  @obs, @est, '', '', '', '', @fact, @hact, @uact)
		commit tran Tr_InsertLHR
		print ('Se inserto correctamente el socio en LHR')
	end try
	begin catch
		rollback tran Tr_InsertLHR
		print ('No se pudo insertar el socio en LHR')
	end catch
	Fetch MiCursor into @numi, @nsoc, @fing, @fnac, @nom, @apat, @amat, @dir, @email, @ci, @fot, @obs, @est,
						@fact, @hact, @uact
end
--Cerrar el Cursor
close MiCursor
--Liberar la memoria
deallocate MiCursor
END
