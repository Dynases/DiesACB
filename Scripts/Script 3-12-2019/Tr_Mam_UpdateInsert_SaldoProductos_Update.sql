USE [DBDies]
GO
/****** Object:  Trigger [dbo].[Tr_Mam_UpdateInsert_SaldoProductos_Update]    Script Date: 3/12/2019 04:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Tr_Mam_UpdateInsert_SaldoProductos_Update] ON [dbo].[TCL0051]
AFTER UPDATE
AS
BEGIN

Declare 
		@lgnumi int, @lgtcl3cpro int, @lgcant decimal(18,2),  @lgpc decimal(18,2), @lgpv decimal(18,2),
		@lglin int, @fact date, 
		@hact nvarchar(5), @uact nvarchar(10),@fecha date,@lgpvSocio decimal(18,2), @lgpvInterno decimal(18,2),

		@cantAct decimal(18,2), @can decimal(18,2), @cantE decimal(18,2), @maxid1 int, @maxid2 int, @obs nvarchar(100),@libreriaprod nvarchar(2),

		@ingreso int, @salida int,@cpcom int
		
		

		set @ingreso = 3
		

--Declarando el cursor
declare MiCursor Cursor
	for Select lgnumi, lgtcl3cpro , lgcant ,  lgpc ,lgpv,lgpvSocio ,lgpvInterno ,lglin   --, a.chhact, a.chuact, b.cpmov, b.cpdesc
				From inserted
--Abrir el cursor
open MiCursor
-- Navegar
Fetch MiCursor into @lgnumi, @lgtcl3cpro , @lgcant ,  @lgpc , @lgpv,@lgpvSocio,@lgpvInterno,@lglin
while (@@FETCH_STATUS = 0)
begin
			set @cantE = (select d.lgcant  from deleted d where d.lglin  = @lglin )
	set @obs = CONCAT('I ', '- COMPRA DE PRODUCTOS') 
			if (exists (select TI001.iccprod  from TI001 where TI001.iccprod  = convert(int, @lgtcl3cpro)))
			begin 	
				begin try
					begin tran Tr_UpdateTI001
						--Obtener la cantidad actual
						set @cantAct = (select TI001.iccven  from TI001 where TI001.iccprod  = convert(int, @lgtcl3cpro))
						set @can = (@cantAct - (@cantE -@lgcant ))

						--Actualizar Saldo Inventario
						update TI001 
							set iccven  = @can
							where TI001.iccprod  = CONVERT(int, @lgtcl3cpro) 

						update TCL003 
						set ldprec =@lgpc ,ldprevSocio =@lgpvSocio ,ldprevInternos =@lgpvInterno ,
						ldprev =@lgpv 
						where ldnumi =@lgtcl3cpro
						--Modificar Movimiento
						--Cabecera

						set @fact=(SElect a.lffact  from TCL005 as a where a.lfnumi =@lgnumi )
						set @hact =(SElect a.lfhact   from TCL005 as a where a.lfnumi =@lgnumi )
						set @uact =(SElect a.lfuact   from TCL005 as a where a.lfnumi =@lgnumi )
						Update TI002 
							set ibconcep = @ingreso , ibobs = @obs, ibfact = @fact, 
								ibhact = @hact, ibuact = @uact
								where ibiddc = @lglin  
						--set @maxid1 = (select ibid from TI002 where ibiddc = @lin)
						--Detalle
						update TI0021
							set iccant =@lgcant       --@cantE -@lccant Preguntar a Guido
								from TI0021 inner join TI002 ON TI002.ibid=TI0021.icibid AND TI002.ibiddc=@lglin 
								--where icibid = @maxid1
								
					commit tran Tr_UpdateTI001
					print concat('Se actualizo el saldo del producto con codigo: ', @lgtcl3cpro, ' -> Código detalle Cliente : ',@lglin)
				end try
				begin catch
					rollback tran Tr_UpdateTI001
					print concat('No se pudo actualizo el saldo del producto con codigo: ', @lgtcl3cpro, ' -> Código detalle Cliente : ',@lglin)
				end catch
			end
			else
			begin
				begin try
					begin tran Tr_InsertTI001

						--Insertar Saldo Inventario
						set @libreriaprod =(select g.ldumed from TCL003 as g where g.ldnumi =@lgtcl3cpro)
						Insert into TI001 values(1,CONVERT(int, @lgtcl3cpro), @lgcant, @libreriaprod)
			
						--Modificar Movimiento
						--Cabecera
						Update TI002 
							set ibconcep = 	@ingreso, ibobs = @obs, ibfact = @fact, 
								ibhact = @hact, ibuact = @uact
								where ibiddc = @lglin  
						--set @maxid1 = (select ibid from TI002 where ibiddc = @lin)

						
						update TCL003 
						set ldprec =@lgpc ,ldprevSocio =@lgpvSocio ,ldprevInternos =@lgpvInterno ,
						ldprev =@lgpv 
						where ldnumi =@lgtcl3cpro
						--Detalle
						update TI0021
							set iccant =@lgcant     --@cantE -@lccant Preguntar a Guido
								from TI0021 inner join TI002 ON TI002.ibid=TI0021.icibid AND TI002.ibiddc=@lglin 
								--where icibid = @maxid1

					commit tran Tr_InsertTI001
					print concat('Se grabo el saldo del producto con codigo: ', @lgtcl3cpro, ' -> Código detalle Cliente : ',@lglin)
				end try
				begin catch
					rollback tran Tr_InsertTI001
					print concat('No se grabo el saldo del producto con codigo: ', @lgtcl3cpro, ' -> Código detalle Cliente : ',@lglin)
				end catch
			end

			--FETCH MiCursor2 into @cpcom
	--	END
	--	CLOSE MiCursor2
--DEALLOCATE MiCursor2

	--end

	Fetch MiCursor into @lgnumi, @lgtcl3cpro , @lgcant ,  @lgpc , @lgpv,@lgpvSocio,@lgpvInterno,@lglin
end

--Cerrar el Cursor
close MiCursor
--Liberar la memoria
deallocate MiCursor
END
