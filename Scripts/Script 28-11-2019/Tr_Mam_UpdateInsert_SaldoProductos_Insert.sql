USE [DBDies]
GO
/****** Object:  Trigger [dbo].[Tr_Mam_UpdateInsert_SaldoProductos_Insert]    Script Date: 28/11/2019 12:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Tr_Mam_UpdateInsert_SaldoProductos_Insert] ON [dbo].[TCL0051]
AFTER INSERT
AS
BEGIN

Declare 
		@lgnumi int, @lgtcl3cpro int, @lgcant decimal(18,2),  @lgpc decimal(18,2), @lgpv decimal(18,2), @lgpvSocio decimal(18,2), @lgpvInterno decimal(18,2),
		@lglin int, @fact date, 
		@hact nvarchar(5), @uact nvarchar(10),@fecha date,
		
		 @tcidesc nvarchar(30),
		@cantAct decimal(18,2), @maxid1 int, @maxid2 int, @obs nvarchar(100),
		@libreriaprod nvarchar(2),
		@ingreso int, @salida int,

		@cpcom int
	

		set @ingreso = 3

		
--Declarando el cursor
declare MiCursor Cursor
	for Select lgnumi, lgtcl3cpro , lgcant ,  lgpc , lgpv,lgpvSocio ,lgpvInterno ,lglin   --, a.chhact, a.chuact, b.cpmov, b.cpdesc
				From inserted   --INNER JOIN TCI001 b ON a.chtmov=b.cpnumi
--Abrir el cursor
open MiCursor
-- Navegar
Fetch MiCursor into @lgnumi, @lgtcl3cpro , @lgcant ,  @lgpc , @lgpv,@lgpvSocio,@lgpvInterno,@lglin
while (@@FETCH_STATUS = 0)
begin


	set @obs = CONCAT('I ', '- COMPRA DE PRODUCTOS') 

			if (exists (select TI001.iccprod from TI001 where TI001.iccprod = convert(int, @lgtcl3cpro)))
			begin 	
				begin try
					begin tran Tr_UpdateTI001
						--Obtener la cantidad actual
					--  set @cantAct = (select TI001.iacant from TI001 where TI001.iacprod = convert(int, @cpcom))
						set @cantAct = (select TI001.iccven  from TI001 where TI001.iccprod  = convert(int, @lgtcl3cpro))

						--Actualizar Saldo Inventario
						update TI001 
							set iccven = @cantAct + @lgcant  
							where TI001.iccprod  = CONVERT(int, @lgtcl3cpro) 
					    ---------------------------------
						update TCL003 
						set ldprec =@lgpc ,ldprevSocio =@lgpvSocio ,ldprevInternos =@lgpvInterno ,
						ldprev =@lgpv 
						where ldnumi =@lgtcl3cpro
						--------------------------------
						--Insertar Movimiento
						--Cabecera
						set @maxid1 = iif((select COUNT(a.ibid) from TI002 a) = 0, 0, (select max(a.ibid) from TI002 a))
						set @fact=(SElect a.lffact  from TCL005 as a where a.lfnumi =@lgnumi )
						set @hact =(SElect a.lfhact   from TCL005 as a where a.lfnumi =@lgnumi )
						set @uact =(SElect a.lfuact   from TCL005 as a where a.lfnumi =@lgnumi )
							set @fecha =(SElect a.lffecha   from TCL005 as a where a.lfnumi =@lgnumi )
					
						insert into TI002 values(@maxid1+1, @fecha ,  @ingreso, @obs, 5, 1, @lglin, @fact, @hact, @uact)

						--Detalle
						set @maxid2 = iif((select COUNT(a.icid) from TI0021 a) = 0, 0, (select max(a.icid) from TI0021 a))
						insert into TI0021 values(@maxid2+1, @maxid1+1, CONVERT(int, @lgtcl3cpro ), @lgcant)
					
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
			
						--Insertar Movimiento
						--Cabecera
						set @maxid1 = iif((select COUNT(a.ibid) from TI002 a) = 0, 0, (select max(a.ibid) from TI002 a))
						set @fecha =(SElect a.lffecha   from TCL005 as a where a.lfnumi =@lgnumi )
						insert into TI002 values(@maxid1+1, @fecha ,  @ingreso , @obs, 5, 1, @lglin, @fact, @hact, @uact)

						--Detalle
						--set @maxid2 = (select max(a.icid) from TI0021 a)
						set @maxid2 = iif((select COUNT(a.icid) from TI0021 a) = 0, 0, (select max(a.icid) from TI0021 a))
						insert into TI0021 values(@maxid2+1, @maxid1+1, CONVERT(int, @lgtcl3cpro), @lgcant)
					commit tran Tr_InsertTI001
					print concat('Se grabo el saldo del producto con codigo: ', @lgtcl3cpro, ' -> Código detalle Cliente : ',@lglin)
				end try
				begin catch
					rollback tran Tr_InsertTI001
					print concat('No se grabo el saldo del producto con codigo: ', @lgtcl3cpro, ' -> Código detalle Cliente : ',@lglin)
				end catch
			end
		
		--	FETCH MiCursor2 into @cpcom
		--END
		--CLOSE MiCursor2
		--DEALLOCATE MiCursor2
	--end	
	Fetch MiCursor into @lgnumi, @lgtcl3cpro , @lgcant ,  @lgpc , @lgpv,@lgpvSocio,@lgpvInterno,@lglin
end

--Cerrar el Curso

close MiCursor
--Liberar la memoria
deallocate MiCursor
END
