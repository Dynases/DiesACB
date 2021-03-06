USE [DBDies]
GO
/****** Object:  StoredProcedure [dbo].[sp_Mam_TCL005]    Script Date: 28/11/2019 06:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--drop procedure sp_Mam_TCL005
ALTER PROCEDURE [dbo].[sp_Mam_TCL005] (@tipo int,@lfnumi int=-1,@lffecha date=null,@lffechaRecepcion date=null,
@lfprov int=-1,@lfobs nvarchar(100)='',@lfuact nvarchar(10)='',@TCL0051 TCL0051Type Readonly)

AS
BEGIN
	DECLARE @newHora nvarchar(5)
	set @newHora=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))

	DECLARE @newFecha date
	set @newFecha=GETDATE()

	IF @tipo=-1 --ELIMINAR REGISTRO
	BEGIN
		BEGIN TRY 
			DELETE from TCL005  where lfnumi   =@lfnumi 
			DELETE FROM TCL0051 WHERE lgnumi  =@lfnumi  ;
			select @lfnumi as newNumi  --Consultar que hace newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),-1,@newFecha,@newHora,@lfuact)
		END CATCH
	END

	IF @tipo=1 --NUEVO REGISTRO
	BEGIN
		BEGIN TRY 

		   set @lfnumi=IIF((select COUNT(lfnumi) from TCL005)=0,0,(select MAX(lfnumi) from TCL005))+1
			INSERT INTO TCL005 VALUES(@lfnumi ,@lffecha,@lffechaRecepcion  ,@lfprov ,@lfobs ,@newFecha,@newHora,@lfuact)

			----INSERTO EL DETALLE
				INSERT INTO TCL0051 (lgnumi ,lgtcl3cpro ,lgcant ,lgpc,lgpv ,lgpvSocio ,lgpvInterno ,lgstocka ,lgstockf)

			SELECT @lfnumi,td.lgtcl3cpro ,td.lgcant ,td.lgpc ,td.lgpv,td.lgpvSocio ,td.lgpvInterno ,td.lgstocka ,td.lgstockf   FROM @TCL0051 AS td
			where td.estado =0
			
			select @lfnumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),1,@newFecha,@newHora,@lfuact)
		END CATCH
	END
	
	IF @tipo=2--MODIFICACION
	BEGIN
		BEGIN TRY 

			UPDATE TCL005 SET lffecha =@lffecha ,lfprov =@lfprov ,lfobs =@lfobs 
			,lffact =@newFecha,lfhact =@newHora ,lfuact =@lfuact 
					 Where lfnumi = @lfnumi


		 ----------MODIFICO EL DETALLE DE EQUIPO------------
			--INSERTO LOS NUEVOS

				INSERT INTO TCL0051 (lgnumi ,lgtcl3cpro ,lgcant ,lgpc ,lgpv,lgpvSocio ,lgpvInterno ,lgstocka ,lgstockf)

			SELECT @lfnumi,td.lgtcl3cpro ,td.lgcant ,td.lgpc ,td.lgpv,td.lgpvSocio ,td.lgpvInterno ,td.lgstocka ,td.lgstockf   FROM @TCL0051 AS td
			where td.estado =0

			--MODIFICO LOS REGISTROS
			UPDATE TCL0051
			SET lgtcl3cpro =td.lgtcl3cpro ,lgcant =td.lgcant ,lgpc =td.lgpc ,lgpvSocio =td.lgpvSocio ,lgpvInterno =td.lgpvInterno ,
			lgpv =td.lgpv,lgstocka =td.lgstocka ,lgstockf =td.lgstockf 
			FROM TCL0051  INNER JOIN @TCL0051 AS td
			ON TCL0051 .lglin    = td.lglin  and td.estado=2;

			--ELIMINO LOS REGISTROS
			DELETE FROM TCL0051 WHERE lglin  in (SELECT td.lglin  FROM @TCL0051 AS td WHERE td.estado=-1)

			select @lfnumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),2,@newFecha,@newHora,@lfuact)
		END CATCH
	END

	IF @tipo=3 --MOSTRaR TODOS
	BEGIN
		BEGIN TRY
		
			select a.lfnumi ,a.lffecha ,a.lffechaRecepcion,a.lfprov,'' as proveedor ,a.lfobs ,a.lffact ,a.lfhact ,a.lfuact 
			from TCL005 as a
			order by lfnumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lfuact)
		END CATCH

END

IF @tipo=4 --MOSTRaR DETALLE
	BEGIN
		BEGIN TRY
		select a.lglin,a.lgnumi ,a.lgtcl3cpro,b.ldcdprod1 as descripcion
		  ,a.lgcant ,a.lgpc ,a.lgpv,isnull(a.lgpvSocio,0) as  lgpvSocio,isnull(a.lgpvInterno,0) as lgpvInterno  ,(a.lgpc *a.lgcant ) as precioTotal,isnull(a.lgstocka,0) as lgstocka
		   ,isnull(a.lgstockf,0) as lgstockf,
		1 as estado
		from TCL0051 as a 
		inner join TCL003 as b on b.ldnumi =a.lgtcl3cpro and a.lgnumi =@lfnumi 
			order by lglin asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lfuact)
		END CATCH

END

IF @tipo=5 --MOSTRaR PRODUCTOS
	BEGIN
		BEGIN TRY
		select a.ldnumi ,a.ldcdprod1 ,a.ldgr1 ,grupo.cedesc1 as GrupoProducto,a.ldprec ,a.ldprev ,Isnull(a.ldprevSocio,0)as ldprevSocio ,isnull(a.ldprevInternos,0) as ldprevInterno ,a.ldsmin,c.iccven as stock
		from TCL003  as a inner join TC0051 as grupo on grupo.cecod1 =16 and grupo .cecod2 =1
			and grupo .cenum =a.ldgr1
			inner join TI001 as c on c.iccprod =a.ldnumi 
			order by a.ldnumi  asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lfuact)
		END CATCH

END
 --OPENROWSET(Bulk 'C:\Photo\DSC_000873.jpg', SINGLE_BLOB) AS BLOB
End




