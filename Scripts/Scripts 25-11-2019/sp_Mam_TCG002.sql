USE [DBDies]
GO
/****** Object:  StoredProcedure [dbo].[sp_Mam_TCG002]    Script Date: 26/11/2019 6:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--drop procedure sp_Mam_TCG002
ALTER PROCEDURE [dbo].[sp_Mam_TCG002](@tipo int,@gcnumi int=-1,@gcid nvarchar(15)='',@gcmar int=-1,@gcmod int=-1,@gcper int=-1,
@gcobs nvarchar(150)='',@gctipo int =-1,@gcsuc int =-1,@gcuact nvarchar(10)='',@cdcod1 int=-1,@cdcod2 int=-1
, @TCG0021 TCG0021Type Readonly
)

AS
BEGIN
    DECLARE @newHora nvarchar(5)
    set @newHora=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))
 
    DECLARE @newFecha date
    set @newFecha=GETDATE()
 
    IF @tipo=-1 --ELIMINAR REGISTRO
    BEGIN
        BEGIN TRY 
            DELETE from TCG002 where gcnumi=@gcnumi
			DELETE from TCG0021 where gdtcg2  =@gcnumi 
            select @gcnumi as newNumi
        END TRY
        BEGIN CATCH
            INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
                   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),-1,@newFecha,@newHora,@gcuact)
        END CATCH
    END
 
    IF @tipo=1 --NUEVO REGISTRO
    BEGIN
        BEGIN TRY 
            set @gcnumi=IIF((select COUNT(gcnumi) from TCG002)=0,0,(select MAX(gcnumi) from TCG002))+1
           -- set @caimg=CONCAT('vehiculo_',CONVERT(nvarchar(30),@canumi))
            INSERT INTO TCG002 VALUES(@gcnumi,@gcid,@gcmar,@gcmod,@gcper,@gcobs,@gctipo,@gcsuc,@newFecha,@newHora,@gcuact)
            
			INSERT INTO TCG0021 (gdtcg2   ,gdima   )
			SELECT @gcnumi ,td.gdima    FROM @TCG0021 AS td
			where td.estado =0

			select @gcnumi as newNumi
        END TRY
        BEGIN CATCH
            INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
                   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),1,@newFecha,@newHora,@gcuact)
        END CATCH
    END
     
    IF @tipo=2--MODIFICACION
    BEGIN
        BEGIN TRY 
            UPDATE TCG002 SET gcid=@gcid,gcmar=@gcmar,gcmod=@gcmod,gcper=@gcper,gcobs=@gcobs,
                         gctipo=@gctipo,gcsuc=@gcsuc,gcfact=@newFecha,gchact=@newHora,gcuact=@gcuact  
                     Where gcnumi = @gcnumi

					 
					 		 ----------MODIFICO EL DETALLE DE EQUIPO------------
			--INSERTO LOS NUEVOS
		INSERT INTO TCG0021 (gdtcg2   ,gdima  )
			SELECT @gcnumi ,td.gdima    FROM @TCG0021 AS td
			where td.estado =0
			--MODIFICO LOS REGISTROS
			UPDATE TCG0021
			SET gdima    = td.gdima 
			FROM TCG0021   INNER JOIN @TCG0021  AS td
			ON TCG0021 .gdnumi      = td.gdnumi   and td.estado=2;

			--ELIMINO LOS REGISTROS
			DELETE FROM TCG0021  WHERE gdnumi   in (SELECT td.gdnumi  FROM @TCG0021  AS td WHERE td.estado=-1)



            select @gcnumi as newNumi
        END TRY
        BEGIN CATCH
            INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
                   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),2,@newFecha,@newHora,@gcuact)
        END CATCH
    END
 
    IF @tipo=3 --MOSTRAR TODOS
    BEGIN
        BEGIN TRY
		
		SELECT TCG002.gcnumi,TCG002.gcid,TCG002.gctipo,tipo.cedesc1 as tipodesc,TCG002.gcmar,marc.cedesc1 as margcdesc
			,TCG002.gcmod,modelo.cedesc1 as modelodesc,TCG002.gcper,CONCAT(panom,' ',paape) as panom1,
                   TCG002.gcobs,TCG002.gcsuc,TC001.cadesc,TCG002.gcfact,TCG002.gchact,TCG002.gcuact
            from TCG002,TC0051 marc,TC0051 modelo, TC0051 tipo,TP001,TC001
            where gcmar=marc.cenum and marc.cecod1=1 and marc.cecod2=1 and
                  gcmod=modelo.cenum and modelo.cecod1=1 and modelo.cecod2=2 and
                  gctipo=tipo.cenum and tipo.cecod1=1 and tipo.cecod2=3 and
                  gcper=panumi and TC001.canumi=TCG002.gcsuc and
                  1=IIF(@gcsuc=-1,1,iif(TCG002.gcsuc=@gcsuc,1,0))
				  order by gcnumi asc
                  --TCE001.casuc=@casuc
        END TRY
        BEGIN CATCH
            INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
                   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@gcuact)
        END CATCH
    END
	

		IF @tipo=4 --MOSTRAR LIBRERIAS
	BEGIN
		BEGIN TRY
			SELECT b.cenum ,b.cedesc1  
			from TC005 as a,tc0051 as b where 
			a.cdcod1 =b.cecod1 and a.cdcod2 =b.cecod2 and a.cdcod1 =@cdcod1 and
			a.cdcod2 =@cdcod2 
			order by cenum 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@gcuact)
		END CATCH

END

IF @tipo=5 --MOSTRAR TODOS imagenes
	BEGIN
		BEGIN TRY
			SELECT gdnumi ,gdtcg2  ,gdima  ,Cast('' as image ) as img,1 as estado
			From TCG0021 where TCG0021 .gdtcg2  =@gcnumi 
			order by gdnumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@gcuact)
		END CATCH

END

IF @tipo=6 --MOSTRAR TODOS imagenes
	BEGIN
		BEGIN TRY
			SELECT canumi ,cadesc 
			FROM TC001 order by canumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@gcuact)
		END CATCH

END
		IF @tipo=7 --MOSTRAR LIBRERIAS
	BEGIN
		BEGIN TRY
			SELECT b.cenum ,b.cedesc1  
			from TC005 as a,tc0051 as b where 
			a.cdcod1 =b.cecod1 and a.cdcod2 =b.cecod2 and a.cdcod1 =@cdcod1 and
			a.cdcod2 =@cdcod2 and b.cenum <>2
			order by cenum 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@gcuact)
		END CATCH

END
END


