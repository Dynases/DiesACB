USE [DBDies]
GO
/****** Object:  StoredProcedure [dbo].[sp_Mam_TCL001]    Script Date: 26/11/2019 5:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--drop procedure sp_Mam_TCL001
ALTER PROCEDURE [dbo].[sp_Mam_TCL001] (@tipo int,@lanumi int=-1,@latipo int=-1,@lansoc int=-1,@lafing date=null,
@lafnac date=null,@lanom nvarchar(30)='',@laapat nvarchar(20)='',@laamat nvarchar(20)=''
,@ladir nvarchar(35)='',@laemail nvarchar(50)='',@laci nvarchar(20)='',
@lafot nvarchar(20)='',@laobs nvarchar(30)='',@laest int=-1,
@latelf1 nvarchar(15)='',@latelf2 nvarchar(15)='',@lauact nvarchar(10)='',@lacod1 nvarchar(10)='',
@lacod2 nvarchar(10)='',@cfnumi int=-1,@TCL0011 TCL0011Type Readonly)

AS
BEGIN
	DECLARE @newHola nvarchar(5)
	set @newHola=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))
	DECLARE @cfnsoc  integer
	DECLARE @newFecha date
	set @newFecha=GETDATE()

	IF @tipo=-1 --ELIMINAR REGISTRO
	BEGIN
		BEGIN TRY 
			DELETE from TCL001  where lanumi=@lanumi
			DELETE FROM TCL0011 WHERE lbnumi =@lanumi ;
			select @lanumi as newNumi  --Consultar que hace newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),-1,@newFecha,@newHola,@lauact)
		END CATCH
	END

	IF @tipo=1 --NUEVO REGISTRO
	BEGIN
		BEGIN TRY 
		
	
			set @lanumi=IIF((select COUNT(lanumi) from TCL001)=0,0,(select MAX(lanumi) from TCL001))+1
			INSERT INTO TCL001 VALUES(@lanumi ,@latipo,0,@lafing   
			,@lafnac,@lanom,@laapat ,@laamat ,@ladir ,@laemail ,@laci  ,@lafot ,
			@laobs ,@laest ,@latelf1 ,@latelf2 ,@newFecha,@newHola,@lauact)

			----INSERTO EL DETALLE
				INSERT INTO TCL0011 (lbnumi ,lbmar ,lbmod  ,lbplac ,lbros ,lbimg,lbtip1_4 )
			SELECT @lanumi,td.lbmar ,td.lbmod ,td.lbplac ,td.lbros ,td.lbimg,td.lbtip1_4   FROM @TCL0011 AS td
		
			
			select @lanumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),1,@newFecha,@newHola,@lauact)
		END CATCH
	END
	
	IF @tipo=2--MODIFICACION
	BEGIN
		BEGIN TRY 
		
			UPDATE TCL001 SET latipo =@latipo,lansoc =0,lafing =@lafing ,
			lafnac =@lafnac ,lanom =@lanom ,laapat =@laapat ,laamat =@laamat ,
			ladir =@ladir ,laemail =@laemail ,laci =@laci ,lafot =@lafot ,laobs =@laobs ,
			laest =@laest ,latelf1 =@latelf1 ,latelf2 =@latelf2 
			,lafact=@newFecha,lahact=@newHola,lauact=@lauact  
					 Where lanumi = @lanumi


		 ----------MODIFICO EL DETALLE DE EQUIPO------------
			--INSERTO LOS NUEVOS
			INSERT INTO TCL0011 (lbnumi ,lbmar ,lbmod  ,lbplac ,lbros ,lbimg )
			SELECT @lanumi,td.lbmar ,td.lbmod ,td.lbplac ,td.lbros ,td.lbimg   FROM @TCL0011 AS td where td.estado =0;

			--MODIFICO LOS REGISTROS
			UPDATE TCL0011
			SET lbmar   = td.lbmar , lbmod  =td.lbmod  ,lbplac  =td.lbplac,lbros =td.lbros ,lbimg =td.lbimg   
			FROM TCL0011  INNER JOIN @TCL0011 AS td
			ON TCL0011 .lblin    = td.lblin  and td.estado=2;

			--ELIMINO LOS REGISTROS
			DELETE FROM TCL0011 WHERE lblin  in (SELECT td.lblin  FROM @TCL0011 AS td WHERE td.estado=-1)

			select @lanumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),2,@newFecha,@newHola,@lauact)
		END CATCH
	END

	IF @tipo=3 --MOSTRaR TODOS
	BEGIN
		BEGIN TRY
		
			SELECT d.lanumi ,d.latipo,tipo.cedesc1  as cedesc1 ,d.lansoc ,d.lafing ,d.lafnac ,d.lanom ,d.laapat ,d.laamat ,
			d.ladir ,d.laemail ,d.laci ,d.lafot ,d.laobs ,d.laest,CAST(IIF(laest=1,1,0) as bit) as estado,d.latelf1 ,d.latelf2 ,d.lafact ,
			d.lahact ,d.lauact, CAST('' as Image) as img
			From TCL001 as d , TC0051 as tipo where tipo.cecod1 =14 and tipo.cecod2 =4 and tipo .cenum =d.latipo 
			order by d.lanumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHola,@lauact)
		END CATCH

END
	IF @tipo=4 --MOSTlaR Socios
	BEGIN
		BEGIN TRY
		

	
			SELECT  cfnumi  ,cftsoc ,cfnsoc ,cffing ,cffnac ,
			cfnom ,cfapat ,cfamat ,cfprof ,cfdir1,cfdir2 ,cfemail ,cfci ,cfimg, Isnull (cgdesc,'') as telefono
			from TCS01 a Left JOIN TCS011 b on a.cfnumi =b.cgnumi and a.cfest =1 and b.cglin =1
		       order by cfnumi asc

			--LEFT JOIN coloca los valores nullos a a derecha si existiela
		
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHola,@lauact)
		END CATCH

END

IF @tipo=5 --MOSTlaR LIBRERIA
	BEGIN
		BEGIN TRY
		
			SELECT b.cenum ,cedesc1 
			from TC005 as a , TC0051 as b 
			where a.cdcod1 =b.cecod1 and a.cdcod2 =b.cecod2 
			and a.cdcod1 =@lacod1  and a.cdcod2 =@lacod2   
			order by cenum asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHola,@lauact)
		END CATCH

END

IF @tipo=6 --OBTENER DETALLE DE VEHICULO
	BEGIN
		BEGIN TRY
			SELECT lbnumi ,lbmar,lbmod,lbplac ,lbros ,lbimg  ,lblin,1 as estado,marca.cedesc1  as desmarc
			,modelo .cedesc1  as descmod,lbtip1_4   FROM TCL0011 
			inner join TC0051   as marca  on marca .cecod1 =1 and marca .cecod2 =1
			and marca .cenum =lbmar 
			inner join TC0051 as modelo on modelo.cecod1 =1 and modelo .cecod2 =2 and
			modelo .cenum =lbmod and  lbnumi  =@lanumi 
			order by lblin 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),5,@newFecha,@newHola,@lauact)
		END CATCH
	END

	IF @tipo=7 --OBTENER DETALLE DE VEHICULO
	BEGIN
		BEGIN TRY
			SELECT cinumi  ,cimar ,cimod ,ciplac  ,ciros ,ciimg   ,cilin  FROM TCS013 
			WHERE cinumi    =@cfnumi  
			order by cilin  
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),5,@newFecha,@newHola,@lauact)
		END CATCH
	END



	IF @tipo=8 --NUEVO REGISTRO Cliente Venta
	BEGIN
		BEGIN TRY 
		
			set @lanumi=IIF((select COUNT(lanumi) from TCL001)=0,0,(select MAX(lanumi) from TCL001))+1
			INSERT INTO TCL001 VALUES(@lanumi ,@latipo,0,@lafing   
			,@lafnac,@lanom,@laapat ,@laamat ,@ladir ,@laemail ,@laci  ,@lafot ,
			@laobs ,@laest ,@latelf1 ,@latelf2 ,@newFecha,@newHola,@lauact)

			----INSERTO EL DETALLE
				INSERT INTO TCL0011 (lbnumi ,lbmar ,lbmod  ,lbplac ,lbros ,lbimg,lbtip1_4 )
			SELECT @lanumi,td.lbmar ,td.lbmod ,td.lbplac ,td.lbros ,td.lbimg,td.lbtip1_4   FROM @TCL0011 AS td
			where td.estado =0
			
			select @lanumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),1,@newFecha,@newHola,@lauact)
		END CATCH
	END
End






