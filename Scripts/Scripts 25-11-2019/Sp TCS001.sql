USE [DBDies]
GO
/****** Object:  StoredProcedure [dbo].[sp_go_TCS01]    Script Date: 26/11/2019 4:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


drop procedure sp_go_TCS01
go

DROP TYPE [dbo].[TCS013Type]
GO

/****** Object:  UserDefinedTableType [dbo].[TCS013Type]    Script Date: 25/11/2019 22:14:50 ******/
CREATE TYPE [dbo].[TCS013Type] AS TABLE(
	[cinumi] [int] NULL,
	[cimar] [int] NULL,
	[marca] [nvarchar](100) NULL,
	[cimod] [int] NULL,
	[modelo] [nvarchar](100) NULL,
	[ciplac] [nvarchar](10) NULL,
	[ciros] [int] NULL,
	[ciimg] [nvarchar](20) NULL,
	[cilin] [int] NULL,
	[imgVehiculo] [image] NULL,
	[estado] [int] NULL
)




go
CREATE PROCEDURE [dbo].[sp_go_TCS01](@tipo int, @numi int=-1, @tsoc int=-1, @nsoc int=-1, @fing date=null,
								    @fnac date=null, @lnac nvarchar(30)='', @nom nvarchar(30)='', @apat nvarchar(20)='',
									@amat nvarchar(20)='', @prof nvarchar(30)='', @dir1 nvarchar(100)='', @dir2 nvarchar(100)='',
									@sdir int=-1, @cas int=-1, @email nvarchar(50)='', @ci nvarchar(20)='', @ciemi int=-1,
									@nome nvarchar(50)='', @fnace date=null, @lnace nvarchar(30)='', @obs nvarchar(100)='',
									@mor int=-1, @tar int=-1, @ntar nvarchar(20)='', @est int=-1, @img nvarchar(30)='',
									@hmed nvarchar(100)='', @lati decimal(18,14)=0, @long decimal(18,14)=0, 
									@uact nvarchar(10)='', @TCS011 dbo.TCS011Type Readonly, @TCS012 dbo.TCS012Type Readonly,
									@TCS013 dbo.TCS013Type Readonly,
									@filtro INT=-1)
AS
BEGIN
	DECLARE @newHora nvarchar(5)
	set @newHora=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))

	DECLARE @newFecha date
	set @newFecha=GETDATE()
	
	IF @tipo=-1 --ELIMINAR REGISTRO
	BEGIN
		BEGIN TRY
			BEGIN TRAN ELIMINAR 
				DELETE FROM TCS01 WHERE cfnumi=@numi
				DELETE FROM TCS011 WHERE cgnumi=@numi
				DELETE FROM TCS012 WHERE chnumi=@numi
				DELETE FROM TCS013 WHERE cinumi=@numi
				SELECT @numi AS newNumi
			COMMIT TRAN ELIMINAR
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN ELIMNAR
			INSERT INTO TB001 (banum, baproc, balinea ,bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), -1, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=1 --NUEVO REGISTRO
	BEGIN
		BEGIN TRY 
			BEGIN TRAN INSERTAR
				set @numi=IIF((select COUNT(cfnumi) from TCS01)=0, 0, (select MAX(cfnumi) from TCS01))+1
				--set @nsoc=IIF((select COUNT(cfnsoc) from TCS01)=0, 0, (select MAX(cfnsoc) from TCS01))+1
				IF @img<>''
				BEGIN
					set @img = CONCAT('socio_', CONVERT(nvarchar(30), @numi), '.jpg')
				END
				INSERT INTO TCS01 VALUES(@numi, @tsoc, @nsoc, @fing, @fnac, @lnac, @nom, @apat, @amat, @prof, @dir1, @dir2,
										 @sdir, @cas, @email, @ci, @ciemi, @nome, @fnace, @lnace, @obs,
										 @mor, @tar, @ntar, @est, @img, @hmed, @lati, @long, @newFecha, @newHora, @uact)
			
				-- INSERTO EL DETALLE 1 
				INSERT INTO TCS011(cgnumi, cgttip, cgdesc)
				SELECT @numi, td.cgttip, td.cgdesc FROM @TCS011 AS td;

				-- INSERTO EL DETALLE 2 
				INSERT INTO TCS012(chnumi, chdesc, chci, chfnac, chimg)
				SELECT @numi, td.chdesc, td.chci, td.chfnac, td.chimg FROM @TCS012 AS td;

				-- INSERTO EL DETALLE 3 
				INSERT INTO TCS013(cinumi, cimar, cimod, ciplac, ciros, ciimg)
				SELECT @numi, td.cimar, td.cimod, td.ciplac, td.ciros, ciimg FROM @TCS013 AS td;

				-- DEVUELVO VALORES DE CONFIRMACION
				SELECT @numi AS newNumi
			COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 1, @newFecha, @newHora,@uact)
		END CATCH
	END
	
	IF @tipo=2--MODIFICACION
	BEGIN
		BEGIN TRY 
			BEGIN TRAN MODIFICACION
				IF @img<>''
				BEGIN
					set @img = CONCAT('socio_', CONVERT(nvarchar(30), @numi), '.jpg')
				END

				UPDATE TCS01 SET cftsoc=@tsoc, cfnsoc=@nsoc, cffing=@fing, cffnac=@fnac, cflnac=@lnac, cfnom=@nom,
								 cfapat=@apat, cfamat=@amat, cfprof=@prof, cfdir1=@dir1, cfdir2=@dir2, cfsdir=@sdir, cfcas=@cas,
								 cfemail=@email, cfci=@ci, cfciemi=@ciemi, cfnome=@nome, cffnace=@fnace, cflnace=@lnace, cfobs=@obs,
								 cfmor=@mor, cftar=@tar, cfntar=@ntar, cfest=@est, cfimg=@img, cfhmed=@hmed, cflati=@lati, cflong=@long,
								 cffact=@newFecha, cfhact=@newHora, cfuact=@uact
						 Where cfnumi = @numi

				----------MODIFICO EL DETALLE 1------------
				--INSERTO LOS NUEVOS
				INSERT INTO TCS011(cgnumi, cgttip, cgdesc)
				SELECT @numi, td.cgttip, td.cgdesc FROM @TCS011 AS td WHERE td.estado=0;

				--MODIFICO LOS REGISTROS
				UPDATE TCS011
				SET TCS011.cgttip = td.cgttip, TCS011.cgdesc=td.cgdesc
				FROM TCS011 INNER JOIN @TCS011 AS td
				ON TCS011.cglin = td.cglin and td.estado=2;

				--ELIMINO LOS REGISTROS
				DELETE FROM TCS011 WHERE TCS011.cglin in (SELECT td.cglin FROM @TCS011 AS td WHERE td.estado=-1)

				----------MODIFICO EL DETALLE 2------------
				--INSERTO LOS NUEVOS
				INSERT INTO TCS012(chnumi, chdesc, chci, chfnac, chimg)
				SELECT @numi, td.chdesc, td.chci, td.chfnac, td.chimg FROM @TCS012 AS td WHERE td.estado=0;

				--MODIFICO LOS REGISTROS
				UPDATE TCS012
				SET TCS012.chdesc = td.chdesc, TCS012.chci=td.chci, TCS012.chfnac=td.chfnac, TCS012.chimg=td.chimg
				FROM TCS012 INNER JOIN @TCS012 AS td
				ON TCS012.chlin = td.chlin and td.estado=2;

				--ELIMINO LOS REGISTROS
				DELETE FROM TCS012 WHERE TCS012.chlin in (SELECT td.chlin FROM @TCS012 AS td WHERE td.estado=-1)

				----------MODIFICO EL DETALLE 3------------
				--INSERTO LOS NUEVOS
				INSERT INTO TCS013(cinumi, cimar, cimod, ciplac, ciros, ciimg)
				SELECT @numi, td.cimar, td.cimod, td.ciplac, td.ciros, ciimg FROM @TCS013 AS td WHERE td.estado=0;

				--MODIFICO LOS REGISTROS
				UPDATE TCS013
				SET TCS013.cimar = td.cimar, TCS013.cimod=td.cimod, TCS013.ciplac=td.ciplac, TCS013.ciros=td.ciros, TCS013.ciimg=td.ciimg
				FROM TCS013 INNER JOIN @TCS013 AS td
				ON TCS013.cilin = td.cilin and td.estado=2;

				--ELIMINO LOS REGISTROS
				DELETE FROM TCS013 WHERE TCS013.cilin in (SELECT td.cilin FROM @TCS013 AS td WHERE td.estado=-1)

				--DEVUELVO VALORES DE CONFIRMACION
				select @numi as newNumi
			COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 2, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=3 --MOSTRAR TODOS
	BEGIN
		BEGIN TRY
			SELECT	a.cfnumi, a.cftsoc, b.cedesc1 as tsocio, a.cfnsoc, a.cffing, a.cffnac, a.cflnac, a.cfnom, a.cfapat, a.cfamat, a.cfprof, a.cfdir1,
					a.cfdir2, a.cfsdir, a.cfcas, a.cfemail, a.cfci, a.cfciemi, c.cedesc1 as lemision, a.cfnome, a.cffnace, a.cflnace, a.cfobs, 
					a.cfmor, a.cftar, a.cfntar, a.cfest, a.cfimg, a.cfhmed, a.cflati, a.cflong,
					a.cffact, a.cfhact, a.cfuact
			FROM 
				TCS01 a inner join TC0051 b on a.cftsoc = b.cenum and b.cecod1 = 7 and b.cecod2 = 1
				inner join TC0051 c on a.cfciemi = c.cenum and c.cecod1 = 9 and c.cecod2 = 1 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 3, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=4 --DETALLE 1
	BEGIN
		BEGIN TRY
			SELECT a.cgnumi, a.cgttip, b.cedesc1, a.cgdesc, a.cglin, 1 as estado
			FROM TCS011 a inner join TC0051 b on a.cgttip = b.cenum and b.cecod1 = 8 and b.cecod2 = 1
			WHERE a.cgnumi = @numi 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 4, @newFecha,@newHora,@uact)
		END CATCH
	END

	IF @tipo=5 --DETALLE 2
	BEGIN
		BEGIN TRY
			SELECT a.chnumi, a.chdesc, a.chci, a.chfnac, a.chimg, a.chlin, 1 as estado
			FROM TCS012 a
			WHERE a.chnumi = @numi 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 5, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=6 --DETALLE 3
	BEGIN
		BEGIN TRY
			SELECT a.cinumi, a.cimar, b.cedesc1 as marca, a.cimod, c.cedesc1 as modelo, a.ciplac, a.ciros, a.ciimg, a.cilin, 1 as estado
			FROM 
				TCS013 a inner join TC0051 b on a.cimar = b.cenum and b.cecod1 = 1 and b.cecod2 = 1
				inner join TC0051 c on a.cimod = c.cenum and c.cecod1 = 1 and c.cecod2 = 2
			WHERE a.cinumi = @numi 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 6, @newFecha, @newHora, @uact)
		END CATCH
	END
	IF @tipo=7 --REPORTE LISTA DE SOCIOS
	BEGIN
		BEGIN TRY
			IF(@numi=0)
			BEGIN
				SELECT *
				FROM VR_Socio a
				WHERE a.cfest=1
			END
			ELSE
			BEGIN
				SELECT *
				FROM VR_Socio a
				WHERE a.cftsoc=@numi and a.cfest=1
			END 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 7, @newFecha, @newHora, @uact)
		END CATCH
	END
	IF @tipo=8 --REPORTE CUMPLEAÑOS
	BEGIN
		BEGIN TRY
			--DECLARE @cd INT
			--SET @cd = DATEDIFF(DAY, @fnac, @fing)+1
			SELECT * 
			FROM (
					SELECT *, 
						DATEADD(Year, YEAR(GETDATE()) - YEAR(a.fnac), a.fnac) AS ThisYear--,
						--DATEADD(Year, YEAR(GETDATE()) - YEAR(a.fnac)+1, a.fnac) AS NextYear 
					FROM VR_GO_SocioCumpleanhos a WHERE a.est = 1) Nacimientos
			WHERE ThisYear>=@fnac AND ThisYear<=@fing
			--WHERE (ThisYear BETWEEN GETDATE()-1 AND GETDATE()-1+@cd) OR (NextYear BETWEEN GETDATE()-1 AND GETDATE()-1+@cd)
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 8, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=9 --PR_SocioPagos Combo Socio
	BEGIN
		BEGIN TRY
			SELECT a.cfnsoc AS [cod] , CONCAT(a.cfnom, ' ', a.cfapat, ' ', a.cfamat) AS [desc]
			FROM 
				TCS01 a inner join TC0051 b ON a.cftsoc = b.cenum and b.cecod1 = 7 and b.cecod2 = 1
				inner join TC0051 c ON a.cfciemi = c.cenum and c.cecod1 = 9 and c.cecod2 = 1
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 9, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=10 --PR_SocioPagos Combo Anho
	BEGIN
		BEGIN TRY
			SELECT distinct ROW_NUMBER() OVER (ORDER BY a.seano ASC) AS [cod] , a.seano AS [desc]
			FROM 
				TCS014 a
			GROUP BY a.seano
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 10, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=11 --PR_SocioListaSociosActivos
	BEGIN
		BEGIN TRY
			IF(@numi=0)
			BEGIN
				SELECT *
				FROM VR_GO_SocioListaSociosActivos a
				WHERE a.est=1
			END
			ELSE
			BEGIN
				SELECT *
				FROM VR_GO_SocioListaSociosActivos a
				WHERE a.tsoc=@numi AND a.est=1
			END
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 11, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=12 --CONSULTA PARA LLEVAR LOS DATOS DE LOS DETALLES DE LOS SOCIOS
	BEGIN
		BEGIN TRY
			IF(@filtro=1) --DETALLE DE TELEFONOS
			BEGIN
				SELECT a.cgdesc AS [telf], b.cedesc1 AS [tipo] 
				FROM TCS011 a INNER JOIN TC0051 b ON a.cgttip=b.cenum AND b.cecod1=8 AND b.cecod2=1
				WHERE a.cgnumi=@numi
			END
			
			IF(@filtro=2) --DETALLE DE HIJOS
			BEGIN
				SELECT a.chdesc AS [nom]
				FROM TCS012 a 
				WHERE a.chnumi=@numi
			END

			IF(@filtro=3) --DETALLE DE VEHICULOS
			BEGIN
				SELECT b.cedesc1 AS [marca], c.cedesc1 AS [modelo], a.ciplac AS [placa] 
				FROM TCS013 a INNER JOIN TC0051 b ON a.cimar=b.cenum AND b.cecod1=1 AND b.cecod2=1
					 INNER JOIN TC0051 c ON a.cimod=c.cenum AND c.cecod1=1 AND c.cecod2=2
				WHERE a.cinumi=@numi
			END
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 12, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=13 --CONSULTAR LA QUE NO EXISTA EL NRO DE SOCIO
	BEGIN
		BEGIN TRY
			IF(EXISTS(select a.cfnsoc from TCS01 a where a.cfnsoc=@nsoc))
			BEGIN
				SET @numi = 1
			END
			ELSE
			BEGIN
				SET @numi = 0
			END
			SELECT @numi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 13, @newFecha, @newHora, @uact)
		END CATCH
	END

	IF @tipo=14 --Obtener vehiculos del socio - programa de visualizador
	BEGIN
		BEGIN TRY
			SELECT a.cinumi, a.cimar, b.cedesc1 as marca, a.cimod, c.cedesc1 as modelo, a.ciplac, a.ciros, 
				   0 as quanImg, cast('' as image) as viewImg, cast('' as image) as addImg, 
				   cast('' as image) as editImg, cast('' as image) as delImg, a.cilin
			FROM 
				TCS013 a inner join TC0051 b on a.cimar = b.cenum and b.cecod1 = 1 and b.cecod2 = 1 and a.cinumi=@numi
				inner join TC0051 c on a.cimod = c.cenum and c.cecod1 = 1 and c.cecod2 = 2
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 14, @newFecha, @newHora, @uact)
		END CATCH
	END

	
	IF @tipo=15 --DETALLE 3
	BEGIN
		BEGIN TRY
			SELECT a.cinumi, a.cimar, b.cedesc1 as marca, a.cimod, c.cedesc1 as modelo, a.ciplac, a.ciros, a.ciimg, a.cilin,
			cast('' as image) as imgVehiculo, 1 as estado
			FROM 
				TCS013 a inner join TC0051 b on a.cimar = b.cenum and b.cecod1 = 1 and b.cecod2 = 1
				inner join TC0051 c on a.cimod = c.cenum and c.cecod1 = 1 and c.cecod2 = 2
			WHERE a.cinumi = @numi 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum, baproc, balinea, bamensaje, batipo, bafact, bahact, bauact)
				   VALUES(ERROR_NUMBER(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE(), 6, @newFecha, @newHora, @uact)
		END CATCH
	END

END


