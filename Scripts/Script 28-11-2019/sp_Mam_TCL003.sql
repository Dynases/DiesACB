USE [DBDies]
GO
/****** Object:  StoredProcedure [dbo].[sp_Mam_TCL003]    Script Date: 28/11/2019 06:13:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--drop procedure sp_Mam_TCL003
ALTER PROCEDURE [dbo].[sp_Mam_TCL003] (@tipo int,@ldnumi int=-1,@ldcprod nvarchar(10)='' 
,@ldcdprod1 nvarchar(50)='',@ldgr1 int=-1,@ldumed nvarchar(30)='',@ldsmin int=-1,
@ldap int=-1,@ldimg nvarchar(255)='',@ldprec decimal(18,2)=0,@ldprev decimal(18,2)=0,@lduact nvarchar(10)='',@concepto int=-1,
@fechaI date=null,@fechaF date=null)
AS
BEGIN
	DECLARE @newHora nvarchar(5)
	set @newHora=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))

	DECLARE @newFecha date
	set @newFecha=GETDATE()

	IF @tipo=-1 --ELIMINAR REGISTRO
	BEGIN
		BEGIN TRY 
			DELETE from TCL003  where ldnumi=@ldnumi
			select @ldnumi as newNumi  --Consultar que hace newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),-1,@newFecha,@newHora,@lduact)
		END CATCH
	END

	IF @tipo=1 --NUEVO REGISTRO
	BEGIN
		BEGIN TRY 
			set @ldnumi=IIF((select COUNT(ldnumi) from TCL003)=0,0,(select MAX(ldnumi) from TCL003))+1
			INSERT INTO TCL003  VALUES(@ldnumi ,@ldcprod  ,@ldcdprod1 ,@ldgr1   
			,@ldumed   ,@ldsmin ,@ldap ,@ldimg,@ldprec ,@ldprev,0,0  ,@newFecha,@newHora,@lduact)
			select @ldnumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),1,@newFecha,@newHora,@lduact)
		END CATCH
	END
	
	IF @tipo=2--MODIFICACION
	BEGIN
		BEGIN TRY 
			UPDATE TCL003  SET ldcprod =@ldcprod ,ldcdprod1 =@ldcdprod1 ,
			ldgr1 =@ldgr1 ,ldumed =@ldumed ,ldsmin =@ldsmin ,ldap =@ldap ,ldimg =@ldimg,
			ldprec =@ldprec ,ldprev =@ldprev  ,ldfact=@newFecha
			,ldhact=@newHora,lduact=@lduact  
					 Where ldnumi = @ldnumi
			select @ldnumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),2,@newFecha,@newHora,@lduact)
		END CATCH
	END

	IF @tipo=3 --MOSTRAR TODOS
	BEGIN
		BEGIN TRY
		select distinct ldnumi ,ldcprod ,ldcdprod1,ldprec ,ldprev  ,ldgr1,grupo.cedesc1 as GrupoProducto ,ldumed 
			,ldsmin ,ldap,CAST(IIF(ldap=1,1,0) as bit) as estado,ldimg , '' as img,ldfact ,ldhact ,lduact 
		from TCL003 Inner join TC0051 as grupo on grupo.cecod1 =16 and grupo .cecod2 =1
			and grupo .cenum =ldgr1 Inner join TC0051 as umedida on
			umedida .cecod1 =16 and umedida .cecod2 =2 and umedida .cedesc1 =ldumed 
		
			order by ldnumi asc 

		
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=4 --MOSTRAR TODOS
	BEGIN
		BEGIN TRY
		select ldnumi ,ldcprod ,ldcdprod1,ldprec ,ldprev  ,ldgr1,grupo.cedesc1 as GrupoProducto ,ldumed 
			,ldsmin ,ldap,CAST(IIF(ldap=1,1,0) as bit) as estado,ldimg 
			, CAST('' as Image) as img,ldfact ,ldhact ,lduact,ISNULL(ti.iccven,0 ) as inventario
		from TCL003 left join TC0051 as grupo on grupo.cecod1 =16 and grupo .cecod2 =1
			and grupo .cenum =ldgr1 left join TC0051 as umedida on
			umedida .cecod1 =16 and umedida .cecod2 =2 and umedida .cedesc1 =ldumed
			left join TI001 as ti on ti.iccprod =ldnumi 
			order by ldnumi asc 

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=5 --KARDEX DE PRODUCTOS DEL ACB ESCUELA GENERAL
	BEGIN
		BEGIN TRY
	SELECT a.ldnumi AS codproducto, a.ldcdprod1 AS producto, a.ldumed AS medida, SUM(b.iccant) AS cantidad
FROM     dbo.TCL003 AS a INNER JOIN
                  dbo.TI0021 AS b ON b.iccprod = a.ldnumi INNER JOIN
                  dbo.TI002 AS c ON c.ibid = b.icibid
WHERE   c.ibfdoc >=@fechaI  and c.ibfdoc <=@fechaF and c.ibconcep =@concepto 
GROUP BY a.ldnumi, a.ldcdprod1, a.ldumed

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=6 --KARDEX DE PRODUCTOS DEL ACB ESCUELA DETALLADO
	BEGIN
		BEGIN TRY
SELECT Format(c.ibfdoc,'dd/MM/yyyy') AS fecha, c.ibobs AS observacion, a.ldnumi AS codproducto, a.ldcdprod1 AS producto, a.ldumed AS medida, b.iccant
FROM     dbo.TCL003 AS a INNER JOIN
                  dbo.TI0021 AS b ON b.iccprod = a.ldnumi INNER JOIN
                  dbo.TI002 AS c ON c.ibid = b.icibid
WHERE   c.ibfdoc >=@fechaI  and c.ibfdoc <=@fechaF and c.ibconcep =@concepto 
GROUP BY a.ldcdprod1, a.ldnumi, c.ibfdoc, a.ldumed, c.ibobs, b.iccant

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
End






