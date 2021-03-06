USE [DBDies]
GO
/****** Object:  StoredProcedure [dbo].[sp_Mam_TCL002]    Script Date: 26/11/2019 5:51:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--drop procedure sp_Mam_TCL002
ALTER PROCEDURE [dbo].[sp_Mam_TCL002] (@tipo int,@ldnumi int=-1,@ldsuc int =-1,
@ldtcl1cli int =-1,@ldtcl11veh as int=-1,@ldtven int=-1,@ldfdoc nvarchar(30)='',
@ldfvcr nvarchar(30)='',@ldtmon int=-1,@ldpdes decimal(18,2)=0,
@ldmdes decimal(18,2)=0,@ldest int=-1,@ldtpago int =-1,
@ldmefec decimal(18,2)=0,@ldmtar decimal(18,2)=0,@lbtip1_4 int=-1,@ldnord nvarchar(100)='',
@ldtablet int=-1,@lduact nvarchar(10)='',@TCL0021 TCL0021Type Readonly,@edtipo int=-1,
@serv int=-1,@placa nvarchar(50)='',@ldfechaI nvarchar(30)='',@ldfechaF nvarchar(30)='',@ldnsoc nvarchar(10)='',@TCL004 TCL004Type Readonly,
@lfnumi int=-1,@ano int=-1,@ldbanco int=-1,@ldobs nvarchar(200)='',@tipoCliente int =-1)

AS
BEGIN
	DECLARE @newHora nvarchar(5)
	set @newHora=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))

	DECLARE @newFecha date
	set @newFecha=GETDATE()

	IF @tipo=-1 --ELIMINAR REGISTRO
	BEGIN
		BEGIN TRY 
		update TCL006 set lfest=0 
		from TCL006 as a inner join TCL002 as b on b.ldnord =a.lfnumi and b.ldnumi =@ldnumi 
		
			DELETE from TCL002  where ldnumi  =@ldnumi
			DELETE FROM TCL0021 WHERE lcnumi =@ldnumi 
			delete from TCL004 where letcl2 =@ldnumi 

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

		    update TCL0011 set lbtip1_4 =@lbtip1_4 where @lbtip1_4 >0 and lblin =@ldtcl11veh --Aqui modifico el tipo de Tamaño del vehiculo
			set @ldnumi=IIF((select COUNT(ldnumi) from TCL002)=0,0,(select MAX(ldnumi) from TCL002))+1
			INSERT INTO TCL002 VALUES(@ldnumi ,@ldsuc,@ldtcl1cli ,@ldtcl11veh  ,@ldtven,
			@ldfdoc ,@ldfvcr ,@ldtmon ,@ldpdes  ,@ldmdes ,1 ,@ldtpago ,@ldmefec  ,
			@ldmtar ,@lbtip1_4,@ldnord,@ldtablet ,@ldbanco ,@ldobs  ,@newFecha,@newHora,@lduact)


			update TCL006 set lfest=1 where lfnumi=@ldnord
			----INSERTO EL DETALLE
				INSERT INTO TCL0021 (lcnumi ,lctce4pro,lctcl3pro ,lctp1emp ,lctce42pro ,lcpuni ,lccant ,lcpdes ,lcmdes ,lcptot ,
				lcfpag ,lcppagper ,lcmpagper ,lcest)

			SELECT @ldnumi,td.lctce4pro ,td.lctcl3pro,td.lctp1emp ,td.lctce42pro ,td.lcpuni ,td.lccant ,td.lcpdes ,
			td.lcmdes ,td.lcptot ,td.lcfpag ,td.lcppagper ,td.lcmpagper ,td.lcest  FROM @TCL0021 AS td
			where td.estado =0
			
			insert into TCL004 (letcl1 ,letcl2 ,letce4pro ,leano ,lemes ,lecant )
			select a.letcl1 ,@ldnumi  ,a.letce4pro ,a.leano ,a.lemes ,a.lecant 
			from @TCL004 as a where a.estado =0


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

		    update TCL0011 set lbtip1_4 =@lbtip1_4 where @lbtip1_4 >0 and lblin =@ldtcl11veh --Aqui modifico el tipo de Tamaño del vehiculo
			
			UPDATE TCL002 SET ldsuc =@ldsuc ,ldtcl1cli =@ldtcl1cli,ldtcl11veh=@ldtcl11veh  ,ldtven =@ldtven ,
			ldfdoc =@ldfdoc ,ldfvcr =@ldfvcr ,ldtmon =@ldtmon ,ldpdes =@ldpdes,
			ldmdes =@ldmdes ,ldtpago =@ldtpago ,ldmefec =@ldmefec ,
			ldmtar =@ldmtar ,ldtip1_4=@lbtip1_4 
			,ldnord=@ldnord ,ldbanco=@ldbanco ,ldobs=@ldobs 
			,ldfact =@newFecha,ldhact =@newHora ,lduact =@lduact 

					 Where ldnumi = @ldnumi


		 ----------MODIFICO EL DETALLE DE EQUIPO------------
			--INSERTO LOS NUEVOS

			INSERT INTO TCL0021 (lcnumi ,lctce4pro,lctcl3pro ,lctp1emp ,lctce42pro ,lcpuni ,lccant ,lcpdes ,lcmdes ,lcptot ,
				lcfpag ,lcppagper ,lcmpagper ,lcest)

			SELECT @ldnumi,td.lctce4pro ,td.lctcl3pro,td.lctp1emp ,td.lctce42pro ,td.lcpuni ,td.lccant ,td.lcpdes ,
			td.lcmdes ,td.lcptot ,td.lcfpag ,td.lcppagper ,td.lcmpagper ,td.lcest  FROM @TCL0021 AS td
			where td.estado =0

			insert into TCL004 (letcl1 ,letcl2 ,letce4pro ,leano ,lemes ,lecant )
			select a.letcl1 ,@ldnumi ,a.letce4pro ,a.leano ,a.lemes ,a.lecant 
			from @TCL004 as a where a.estado =0

			--MODIFICO LOS REGISTROS
			UPDATE TCL0021
			SET lctce4pro =td.lctce4pro,lctcl3pro =td.lctcl3pro ,lctp1emp =td.lctp1emp ,lctce42pro =td.lctce42pro ,lcpuni =td.lcpuni ,
			lccant =td.lccant ,lcpdes =td.lcpdes ,lcmdes =td.lcmdes ,lcptot =td.lcptot,
			lcfpag =td.lcfpag 
			FROM TCL0021  INNER JOIN @TCL0021 AS td
			ON TCL0021 .lclin    = td.lclin  and td.estado=2;

			--ELIMINO LOS REGISTROS
			DELETE FROM TCL0021 WHERE lclin  in (SELECT td.lclin  FROM @TCL0021 AS td WHERE td.estado=-1)
			DELETE FROM TCL004 WHERE lenumi    in (SELECT td.lenumi  FROM @TCL004 AS td WHERE td.estado=-1)

			select @ldnumi as newNumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),2,@newFecha,@newHora,@lduact)
		END CATCH
	END

	IF @tipo=3 --MOSTRaR TODOS
	BEGIN
		BEGIN TRY
		
			SELECT ldnord,ldnumi ,ldsuc ,ldtcl1cli ,b.laci ,CONCAT (b.lanom ,' ',b.laapat ,' ',b.laamat) as nombre,
			ldtcl11veh,c.lbplac ,marca .cedesc1 as marcas,modelo .cedesc1 as modelos,b.lafot ,ldtven,
			IIF (ldtven =1,'CONTADO','CREDITO')as TipoVenta,tamano .cedesc1 as tamano,ldfdoc ,isnull(ldfvcr,GetDate()) as ldfvcr ,ldtmon,IIF(ldtmon =1,'BOLIVIANOS','DOLARES') as TipoMoneda,ldpdes ,ldmdes ,
			ldest,CAST(IIF(ldest=1,1,0) as bit)as Estado,ldtpago ,IIF(ldtpago =1,'EFECTIVO','TARJETA') as TipoPago,
			ldmefec ,ldmtar,ldtip1_4,ldfact ,ldhact ,lduact,lansoc  --Aumentado el tipo de tamaño
			,ldtablet,IIF(Exists(select * from TCE000 where ensocacb=lanumi),1,0)as acb,isnull(ldbanco,0) as ldbanco,
			isnull((select concat(aa.canombre,' ',aa.cacuenta)  from BA001 as aa where aa.canumi=ldbanco ),'') as banco,isnull(ldobs,'') as ldobs,
			b.latipo 
			from TCL002 ,TCL001 as b,TCL0011 as c,TC0051 as marca,TC0051 as modelo
			,TC0051 as tamano where ldtcl1cli =b.lanumi 
			and c.lbnumi=b.lanumi and marca.cecod1 =1 and marca .cecod2 =1
			and modelo.cecod1 =1 and modelo .cecod2 =2 and tamano .cecod1 =1 and tamano.cecod2 =4
			and tamano.cenum =ldtip1_4 and marca.cenum =c.lbmar 
			and modelo .cenum =c.lbmod and ldtcl11veh =c.lblin 

			order by ldnumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=4 --MOSTRaR DETALLE de la venta de servicios con personal y sin personal
	BEGIN
		BEGIN TRY
		
			SELECT lclin ,lcnumi ,lctce4pro,lctcl3pro  ,b.eddesc  ,lctp1emp,lctce42pro,'' as nombre 
			,lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
			,lcfpag ,lcppagper ,lcmpagper ,lcest,1 as estado,0 as stockminimo,0 as inventario
			from TCL0021, TCE004 as b where lcnumi =@ldnumi 
			 and lctce4pro =b.ednumi 

			union

			select lclin ,lcnumi ,lctce4pro,lctcl3pro  ,c.ldcdprod1   ,lctp1emp,lctce42pro,'' as nombre 
			,lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
			,lcfpag ,lcppagper ,lcmpagper ,lcest,1 as estado,c.ldsmin ,d.iccven as inventario
             from TCL0021 as a 
             inner join TCL003 as c on lctcl3pro =c.ldnumi  and lcnumi =@ldnumi 
			 inner join TI001 as d on d.iccprod =c.ldnumi 
			
			order by lclin 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
IF @tipo=5 --MOSTRaR
	BEGIN
		BEGIN TRY
SELECT lclin ,lcnumi ,lctce4pro,lctcl3pro  ,b.eddesc  ,lctp1emp,lctce42pro,CONCAT (a.panom ,' ',a.paape )as nombre 
			,lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
			,lcfpag ,lcppagper ,lcmpagper ,lcest,1 as estado,0 as stockminimo,0 as inventario
			from TCL0021,TP001 as a, TCE004 as b where lcnumi =@ldnumi  
			and lctp1emp =a.panumi and lctce4pro =b.ednumi 

			union

			select lclin ,lcnumi ,lctce4pro,lctcl3pro  ,c.ldcdprod1   ,lctp1emp,lctce42pro,CONCAT (b.panom ,' ',b.paape )as nombre 
			,lcpuni ,lccant,lcpdes ,lcmdes ,lcptot 
			,lcfpag ,lcppagper ,lcmpagper ,lcest,1 as estado,c.ldsmin ,d.iccven as inventario
             from TCL0021 as a 
           left join TP001 as b  on lctp1emp =b.panumi 
             inner join TCL003 as c on lctcl3pro =c.ldnumi  and lcnumi =@ldnumi  
			 inner join TI001 as d on d.iccprod =c.ldnumi 
			
			order by lclin 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=6 --MOSTRaR Servicios que existen Dependiendo al tipo de vehiculos= Pequeños , Medianos , Grandes
	BEGIN
		BEGIN TRY
		
select  a.ednumi,b.eqnumi as NumiDetalleServicio ,a.edcod ,a.eddesc, b.eqprecio ,b.eqmes 
		,b.eqano,a.edtipo ,a.edest,q.cedesc1 ,a.edfact ,a.edhact ,a.eduact
		from TCE004 as a,TCE0042 as b ,TC0051 as q where edtipo =@edtipo  and edest =1 and eqtce4 =ednumi and
		eqtip1_4 =@lbtip1_4  --2=Mediano 1=Pequeño 3=Grande
		and b.eqano in(select Max(d.eqano )  from TCE0042 as d where d.eqtce4 =a.ednumi and d.eqtip1_4 =@lbtip1_4)
		 and b.eqmes in(select Max(c.eqmes)   from TCE0042 as c where c.eqtce4 =a.ednumi  and c.eqtip1_4 =@lbtip1_4 and c.eqano =b.eqano )
		and q.cecod1 =1 and q.cecod2 =4 and q.cenum =@lbtip1_4 and a.tipo =@tipoCliente 
		and a.ednumi not in( select td.lctce4pro   from @TCL0021 as td where td.lctce4pro >0) 
			order by ednumi  
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=7 --MOSTRaR Personal del lavadero
	BEGIN
		BEGIN TRY
		
		select panumi ,paci ,panom ,paape ,patelef1 
		from TP001 where paest =1 and patipo =2  --tipo = 2 es Personal Lavadero colocado en librerias
			order by panumi  
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=8 --MOSTRaR Las politicas que existen para un Servicio y si el cliente es socio si no mostrara vacio
	BEGIN
		BEGIN TRY
 select b.ednumi ,b.eddesc ,a.cfcant ,a.cfdesc ,(DATEADD(mm, -3, GETDATE ())) as MesInicial
 from TC006 as a inner join
 TCE004 as b on a.cftce4ser =b.ednumi and b.ednumi =@serv
 and b.edtipo =3
 inner join TCL001 as c on c.lanumi =@ldtcl1cli  and c.lansoc >0
 order by cfcant asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=9 --MOSTRaR DETALLE SErvicios Lavadero
	BEGIN
		BEGIN TRY
		
select b.lblin,b.lbtip1_4 ,a.lanumi,Concat( a.lanom,' ',a.laapat ,' ',a.laamat) as nombre,a.lafot ,
marca .cedesc1 as marca,a.latipo 
	from TCL001 as a ,TCL0011 as b,TC0051 as marca
	where a.lanumi =b.lbnumi and 
	b.lbplac =@placa and marca .cecod1 =1 and marca.cecod2 =1
		and marca.cenum =b.lbmar 
			order by lblin 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

	IF @tipo=10 --MOSTRaR Cliente lavadero que tenga vehiculo
	BEGIN
		BEGIN TRY
		
			SELECT d.lanumi ,d.latipo,b.cedesc1 ,d.lansoc ,d.lafing ,d.lafnac ,d.lanom ,d.laapat ,d.laamat ,
			d.ladir ,d.laemail ,d.laci ,d.lafot ,d.laobs ,d.laest,CAST(IIF(laest=1,1,0) as bit) as estado,d.latelf1 ,d.latelf2 ,d.lafact ,
			d.lahact ,d.lauact, CAST('' as Image) as img
			From TCL001 as d,TC005  as a ,TC0051 as b where a.cdcod1 =b.cecod1 and 
			a.cdcod2 =b.cecod2 and b.cecod1 =14  and b.cecod2 =1  and d.latipo =b.cenum 
			and d.lanumi in (
			select h.lbnumi 
			from TCL0011 as h
			)
			order by d.lanumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=11 --Mostrar Cliente lavadero que tenga vehiculo
	BEGIN
		BEGIN TRY
		
	SELECT        d .cedesc1, e.lbplac, b.lctce4pro, a.eddesc,b.lccant , ISNULL(b.lcptot, 0) AS total, IIF(b.lcpdes > 0, Concat ('DESCUENTO ',b.lcmdes,' Bs'), '') AS observacion,c.ldnord,IIF(w.lansoc >0,'SOCIO','CLIENTE') as tipo
FROM            dbo.TCE004 AS a RIGHT OUTER JOIN
                         dbo.TCL0021 AS b ON a.ednumi = b.lctce4pro INNER JOIN
                         dbo.TCL002 AS c ON c.ldnumi = b.lcnumi and c.ldfdoc >=@ldfechaI and c.ldfdoc <=@ldfechaF    INNER JOIN
                         dbo.TCL0011 AS e ON e.lblin = c.ldtcl11veh INNER JOIN
                         dbo.TC0051 AS d ON d .cecod1 = 1 AND d .cecod2 = 4 AND c.ldtip1_4 = d .cenum AND b.lctce4pro > 0
						 inner join TCL001 as w on w.lanumi =c.ldtcl1cli
	UNION
	SELECT        d .cedesc1, e.lbplac, b.lctcl3pro AS lctce4pro, a.ldcdprod1 AS eddesc, b.lccant, ISNULL(b.lcptot, 0) AS total, IIF(b.lcpdes > 0, 'DESCUENTO', '') AS observacion, c.ldnord, IIF(w.lansoc > 0, 'SOCIO', 'CLIENTE') 
                         AS tipo
FROM            dbo.TCL003 AS a RIGHT OUTER JOIN
                         dbo.TCL0021 AS b ON a.ldnumi = b.lctcl3pro INNER JOIN
                         dbo.TCL002 AS c ON c.ldnumi = b.lcnumi AND c.ldfdoc >=@ldfechaI and c.ldfdoc <=@ldfechaF INNER JOIN
                         dbo.TCL0011 AS e ON e.lblin = c.ldtcl11veh INNER JOIN
                         dbo.TC0051 AS d ON d .cecod1 = 1 AND d .cecod2 = 4 AND c.ldtip1_4 = d .cenum AND b.lctcl3pro > 0 INNER JOIN
                         TCL001 AS w ON w.lanumi = c.ldtcl1cli 

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=12 --Reporte del servicio Venta por vehiculo
	BEGIN
		BEGIN TRY
		


SELECT       a.ldnord ,FORMAT (a.ldfdoc, 'dd-MM-yyyy') as ldfdoc , b.laci, b.lansoc, Concat(b.lanom, ' ', b.laapat, ' ', b.laamat) AS nombre, b.latelf1, c.lbplac, e.eddesc AS eddesc, d .lcpuni, d .lccant,d.lcpdes ,d.lcmdes , d .lcptot
FROM            TCL002 AS a INNER JOIN
                         TCL001 AS b ON a.ldtcl1cli = b.lanumi INNER JOIN
                         TCL0011 AS c ON c.lblin = a.ldtcl11veh AND a.ldnumi = @ldnumi  INNER JOIN
                         TCL0021 AS d ON d .lcnumi = a.ldnumi INNER JOIN
                         TCE004 AS e ON d .lctce4pro = e.ednumi
UNION
SELECT       a.ldnord ,FORMAT (a.ldfdoc, 'dd-MM-yyyy') as ldfdoc, b.laci, b.lansoc, Concat(b.lanom, ' ', b.laapat, ' ', b.laamat) AS nombre, b.latelf1, c.lbplac, e.ldcdprod1 AS eddesc, d .lcpuni, d .lccant,d.lcpdes ,d.lcmdes, d .lcptot
FROM            TCL002 AS a INNER JOIN
                         TCL001 AS b ON a.ldtcl1cli = b.lanumi INNER JOIN
                         TCL0011 AS c ON c.lblin = a.ldtcl11veh AND a.ldnumi = @ldnumi  INNER JOIN
                         TCL0021 AS d ON d .lcnumi = a.ldnumi INNER JOIN
                         TCL003 AS e ON d .lctcl3pro = e.ldnumi

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=13 --Reporte de los servicios con su detalle general
	BEGIN
		BEGIN TRY
		
	

select  d.cedesc1 ,a.eddesc ,b.lcpuni as preciou,Sum(b.lccant ) as cantidad,Count(e.lanumi )*bb.lccant  as socio,
		Count(f.lanumi)*bb.lccant  as cliente,Sum(b.lcptot ) as subtotal
from TCE004  as a inner join TCL0021 as b on a.ednumi =b.lctce4pro
inner join TCL002 as c on c.ldnumi =b.lcnumi and c.ldfdoc <=@ldfechaF and c.ldfdoc >=@ldfechaI
inner join  TC0051 as d on d.cecod1 =1 and d.cecod2 =4 and c.ldtip1_4   =d.cenum 
left join TCL001 as e on e.lanumi =c.ldtcl1cli and e.lansoc >0
left join TCL001 as f on f.lanumi =c.ldtcl1cli and f.lansoc =0
inner join TCL0021 as bb on a.ednumi =bb.lctce4pro and bb.lcnumi =c.ldnumi 
group by d.cedesc1 ,a.eddesc ,b.lcpuni ,bb.lccant 

union 
	select t.cedesc1 ,c.eddesc, b.eqprecio as preciou,0 as cantidad,0 as socio,0 as cliente,0 as subtotal
from TCE004 c,TC0051  t,TCE0042 as b
where t.cecod1 =1 and t.cecod2 =4  and 
	  c.edtipo=3 and c.ednumi not in(select d.lctce4pro from TCL002 b,TCL0021 d where d.lcnumi=b.ldnumi  
	  and b.ldtip1_4 =t.cenum and b.ldfdoc <=@ldfechaF  and b.ldfdoc >=@ldfechaI   ) and b.eqtce4 =c.ednumi and b.eqtip1_4 =t.cenum 
	  and b.eqano in(select Max(d.eqano )  from TCE0042 as d where d.eqtce4 =c.ednumi and d.eqtip1_4 =t.cenum )
		 and b.eqmes in(select Max(w.eqmes)   from TCE0042 as w where w.eqtce4 =c.ednumi  and w.eqtip1_4 =t.cenum  and w.eqano =b.eqano )
		
		union

	select t.cedesc1 ,c.eddesc, 0 as preciou,0 as cantidad,0 as socio ,0 as cliente,0 as subtotal
from TCE004 c,TC0051  t
where t.cecod1 =1 and t.cecod2 =4  and 
	  c.edtipo=3 and c.ednumi not in(select d.lctce4pro from TCL002 b,TCL0021 d where d.lcnumi=b.ldnumi  
	  and b.ldtip1_4 =t.cenum and b.ldfdoc <=@ldfechaF  and b.ldfdoc >=@ldfechaI  ) and c.ednumi not in(
	  select r.eqtce4 
	  from TCE0042 as r 
	  )  
	  UNION
SELECT     h.cedesc1,'PRODUCTOS' as eddesc,0 as preciou,0 as cantidad,0 as socio,0 as cliente,Sum(d.lcptot) as subtotal
FROM            TCL002 AS a INNER JOIN
                         TCL001 AS b ON a.ldtcl1cli = b.lanumi INNER JOIN
                         TCL0011 AS c ON c.lblin = a.ldtcl11veh and c.lbnumi =b.lanumi  INNER JOIN
                         TCL0021 AS d ON d .lcnumi = a.ldnumi INNER JOIN
                         TCL003 AS e ON d .lctcl3pro = e.ldnumi inner join
						  TC0051 AS h ON h.cecod1 = 1 AND h.cecod2 = 4 AND a.ldtip1_4 = h.cenum
						  and a.ldfdoc <=@ldfechaF  and a.ldfdoc >=@ldfechaI
group by h.cedesc1
union
SELECT     h.cedesc1,'PRODUCTOS' as eddesc,0 as preciou,0 as cantidad,0 as socio,0 as cliente,0 as subtotal
FROM            TC0051 AS h where  h.cecod1 = 1 AND h.cecod2 = 4  and h.cenum  not in (
select a.ldtip1_4  from TCL002 as a,TCL0021 as u where a.ldfdoc <=@ldfechaF  and a.ldfdoc >=@ldfechaI
and  u.lcnumi =a.ldnumi and u.lctcl3pro >0)

group by h.cedesc1 

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END



IF @tipo=14 --REPORTE HISTORIAL DE SERVICIOS POR CLIENTE EN RANGOS DE FECHAS
	BEGIN
		BEGIN TRY

SELECT  d .cedesc1,FORMAT(c.ldfdoc, 'yyyy-MM-dd') as ldfdoc ,c.ldnord , e.lbplac, b.lctce4pro, a.eddesc,b.lccant , ISNULL(b.lcptot, 0) AS total, IIF(b.lcpdes > 0, Concat('DESCUENTO',' DE ',b.lcmdes,' Bs'), '') AS observacion
FROM            dbo.TCE004 AS a RIGHT OUTER JOIN
                         dbo.TCL0021 AS b ON a.ednumi = b.lctce4pro INNER JOIN
                         dbo.TCL002 AS c ON c.ldnumi = b.lcnumi and c.ldfdoc <=@ldfechaF  and c.ldfdoc >=@ldfechaI   INNER JOIN
                         dbo.TCL0011 AS e ON e.lblin = c.ldtcl11veh and c.ldtcl1cli =@ldtcl1cli  INNER JOIN
                         dbo.TC0051 AS d ON d .cecod1 = 1 AND d .cecod2 = 4 AND c.ldtip1_4 = d .cenum AND b.lctce4pro > 0
union 
SELECT  d .cedesc1,FORMAT(c.ldfdoc, 'yyyy-MM-dd') as ldfdoc,c.ldnord  , e.lbplac, b.lctcl3pro as lctce4pro, a.ldcdprod1 as eddesc,b.lccant , ISNULL(b.lcptot, 0) AS total, IIF(b.lcpdes > 0, Concat('DESCUENTO',' DE ',b.lcmdes,' Bs'), '') AS observacion
FROM            dbo.TCL003  AS a RIGHT OUTER JOIN
                         dbo.TCL0021 AS b ON a.ldnumi = b.lctcl3pro  INNER JOIN
                         dbo.TCL002 AS c ON c.ldnumi = b.lcnumi and c.ldfdoc <=@ldfechaF  and c.ldfdoc >=@ldfechaI   INNER JOIN
                         dbo.TCL0011 AS e ON e.lblin = c.ldtcl11veh and c.ldtcl1cli =@ldtcl1cli  INNER JOIN
                         dbo.TC0051 AS d ON d .cecod1 = 1 AND d .cecod2 = 4 AND c.ldtip1_4 = d .cenum AND b.lctcl3pro  > 0




		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=15 --Politicas 
	BEGIN
		BEGIN TRY

		--declare @Fecha date
		--set @fecha=DATEDIFF (Month,Getdate(),3)

select a.lenumi ,a.letcl1 ,a.letcl2 ,a.letce4pro ,a.leano ,a.lemes ,a.lecant,1 as estado
from TCL004 as a inner join
TCL001 as b on b.lanumi  =a.letcl1 and b.lanumi =@ldtcl1cli   --Numi de Cliente
and a.letce4pro =@serv ---Numi de Servicio

--and lemes    >= (Month(@fecha))
-- and lemes <=Month(getdate()) 

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
IF @tipo=16 --Clientes  VehiculoRegistrado=nos dice que si un vehiculo ya esta registrado en la venta no debera poderse modificar su Tipo de Tamaño
	BEGIN
		BEGIN TRY
select b.lblin,a.lanumi ,b.lbplac,marca.cedesc1 as marca,modelo .cedesc1  as modelo
        ,Concat(a.lanom,' ',a.laapat ,' ',a.laamat  )as nombre,a.lafot ,b.lbtip1_4 ,a.lansoc,
		Isnull((select top 1 e.lfnumi   from TCL006 as e where e.lfcl1veh =lblin  ),0)as VehiculoRegistrado,a.laci 
		,Isnull(socio.cftsoc,0) as tipo,IIF((Exists(select * from TCE000 where TCE000.ensocacb=a.lanumi)),1,0) as acb,a.latipo
		from TCL001 as a 
		inner join TCL0011 as b on b.lbnumi =a.lanumi 
		inner join TC0051 as marca on marca .cecod1 =1 and marca.cecod2 =1
		and marca.cenum =b.lbmar inner join TC0051 as modelo on modelo.cecod1 =1 and
		modelo.cecod2 =2 and modelo .cenum =b.lbmod 
		left join TCS01 as socio on socio .cfnsoc =a.lansoc 
		order by a.lanumi asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=17 --Obtener El ultimos mes de Pago de un socio 
	BEGIN
		BEGIN TRY
select  a.selin,a.senumi ,a.semes ,a.seano ,a.sefec ,a.serec ,a.seimp1 ,a.sesaldo ,a.seest ,(select w.emora from TCE000 as w)as mora
from TCS014 as a inner join TCS01 as b
on b.cfnsoc =@ldnsoc and b.cfnumi =a.senumi 
and a.seest =2 and
	 a.seano in(select Max(d.seano  )  from TCS014  as d where d.senumi=a.senumi and d.seest =2)
	 and a.semes in(select Max (c.semes) from TCS014 as c where c.senumi =a.senumi and c.seest =2 and c.seano =a.seano )
group by a.selin ,a.senumi ,a.semes ,a.seano  ,a.sefec ,a.serec ,a.seimp1 ,a.sesaldo ,a.seest 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=18 --Historial de Servicios en Un Rango de Fechas Por Placa 
	BEGIN
		BEGIN TRY
SELECT  d .cedesc1,FORMAT(c.ldfdoc, 'yyyy-MM-dd') as ldfdoc ,c.ldnord , e.lbplac, b.lctce4pro, a.eddesc,b.lccant , ISNULL(b.lcptot, 0) AS total, IIF(b.lcpdes > 0, Concat('DESCUENTO',' DE ',b.lcmdes,' Bs'), '') AS observacion
FROM            dbo.TCE004 AS a inner join
                         dbo.TCL0021 AS b ON a.ednumi = b.lctce4pro INNER JOIN
                         dbo.TCL002 AS c ON c.ldnumi = b.lcnumi and c.ldfdoc <=@ldfechaF  and c.ldfdoc >=@ldfechaI and c.ldtcl11veh =@ldtcl11veh   
						 INNER JOIN dbo.TCL0011 AS e ON e.lblin = @ldtcl11veh   INNER JOIN
                         dbo.TC0051 AS d ON d .cecod1 = 1 AND d .cecod2 = 4 AND c.ldtip1_4 = d .cenum AND b.lctce4pro > 0

union 
SELECT  d .cedesc1,FORMAT(c.ldfdoc, 'yyyy-MM-dd') as ldfdoc,c.ldnord  , e.lbplac, b.lctcl3pro as lctce4pro, a.ldcdprod1 as eddesc,b.lccant , ISNULL(b.lcptot, 0) AS total, IIF(b.lcpdes > 0, Concat('DESCUENTO',' DE ',b.lcmdes,' Bs'), '') AS observacion
FROM            dbo.TCL003  AS a RIGHT OUTER JOIN
                         dbo.TCL0021 AS b ON a.ldnumi = b.lctcl3pro  INNER JOIN
                         dbo.TCL002 AS c ON c.ldnumi = b.lcnumi and c.ldfdoc <=@ldfechaF  and c.ldfdoc >=@ldfechaI and c.ldtcl11veh =@ldtcl11veh   INNER JOIN
                         dbo.TCL0011 AS e ON e.lblin = @ldtcl11veh   INNER JOIN
                         dbo.TC0051 AS d ON d .cecod1 = 1 AND d .cecod2 = 4 AND c.ldtip1_4 = d .cenum AND b.lctcl3pro  > 0

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
IF @tipo=19 --Obtener Numero de Orden 
	BEGIN
		BEGIN TRY

select a.ldnord 
from TCL002 as a where a.ldnumi =@ldnumi
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
IF @tipo=20 --Listar Todos los servicios que tienen Politicas
	BEGIN
		BEGIN TRY
		  select ednumi ,eddesc ,(DATEADD(mm, -3, GETDATE ())) as MesInicial from TCE004 as a where a.edtipo =3 and
  a.ednumi in(select b.cftce4ser  from TC006 as b)
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
IF @tipo=21 --Listar Todos los socios con meses para generar el seguimiento de descuentos
	BEGIN
		BEGIN TRY
	 select  a.lansoc ,CONCAT (b.cfapat ,' ',b.cfamat  ,' ',b.cfnom  ) as nombre,
  '' as Enero,
  '' as Febrero,
  '' as Marzo,
  '' as Abril,
 '' as Mayo,
'' as Junio,
  '' as Julio,
  '' as Agosto,
  '' as Septiembre,
 '' as Octubre,
  '' as Noviembre,
  '' as Diciembre
  from TCL001 as a ,TCS01 as b where a.lansoc =b.cfnsoc 
order by b.cfapat,b.cfamat ,b.cfnom   asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=22 --Listar Todos los socios con meses para generar el seguimiento de descuentos
	BEGIN
		BEGIN TRY
	  select  a.lansoc ,CONCAT (aa.cfapat ,' ',aa.cfamat  ,' ',aa.cfnom  ) as nombre,
  IIF(b.leano =@ano,IIF(b.lemes=1,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Enero,
  IIF(b.leano =@ano,IIF(b.lemes=2,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Febrero,
  IIF(b.leano =@ano,IIF(b.lemes=3,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Marzo,
  IIF(b.leano =@ano,IIF(b.lemes=4,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Abril,
  IIF(b.leano =@ano,IIF(b.lemes=5,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Mayo,
  IIF(b.leano =@ano,IIF(b.lemes=6,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Junio,
  IIF(b.leano =@ano,IIF(b.lemes=7,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Julio,
  IIF(b.leano =@ano,IIF(b.lemes=8,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Agosto,
  IIF(b.leano =@ano,IIF(b.lemes=9,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Septiembre,
  IIF(b.leano =@ano,IIF(b.lemes=10,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Octubre,
  IIF(b.leano =@ano,IIF(b.lemes=11,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Noviembre,
  IIF(b.leano =@ano,IIF(b.lemes=12,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Diciembre
  from TCL001 as a Inner join TCL004 as b on b.letcl1 =a.lanumi
  inner join TCL002 as c on c.ldnumi =b.letcl2  and c.ldtcl1cli =a.lanumi and b.letcl2 =c.ldnumi inner join 
  TCE004 as d on d.ednumi =b.letce4pro and d.ednumi =5 and a.lansoc >0
  inner join TCL0011 as e on e.lbnumi =a.lanumi and e.lblin =c.ldtcl11veh
  inner join TCS01 as aa on  a.lansoc =aa.cfnsoc 
order by aa.cfapat  asc 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=23 --Listar Todos los socios con meses para generar el seguimiento de descuentos
	BEGIN
		BEGIN TRY
	  select  a.lansoc ,CONCAT (a.lanom ,' ',a.laapat ,' ',a.laamat ) as nombre,
  IIF(b.leano =@ano,IIF(b.lemes=1,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Enero,
  IIF(b.leano =@ano,IIF(b.lemes=2,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Febrero,
  IIF(b.leano =@ano,IIF(b.lemes=3,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Marzo,
  IIF(b.leano =@ano,IIF(b.lemes=4,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Abril,
  IIF(b.leano =@ano,IIF(b.lemes=5,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Mayo,
  IIF(b.leano =@ano,IIF(b.lemes=6,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Junio,
  IIF(b.leano =@ano,IIF(b.lemes=7,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Julio,
  IIF(b.leano =@ano,IIF(b.lemes=8,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Agosto,
  IIF(b.leano =@ano,IIF(b.lemes=9,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Septiembre,
  IIF(b.leano =@ano,IIF(b.lemes=10,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Octubre,
  IIF(b.leano =@ano,IIF(b.lemes=11,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Noviembre,
  IIF(b.leano =@ano,IIF(b.lemes=12,Concat('Fecha: ',c.ldfdoc ,' Placa: ',e.lbplac ),' '),' ') as Diciembre
  from TCL001 as a Inner join TCL004 as b on b.letcl1 =a.lanumi
  inner join TCL002 as c on c.ldnumi =b.letcl2  and c.ldtcl1cli =a.lanumi and b.letcl2 =c.ldnumi inner join 
  TCE004 as d on d.ednumi =b.letce4pro and d.ednumi =5 and a.lansoc =@ldnsoc 
  inner join TCL0011 as e on e.lbnumi =a.lanumi and e.lblin =c.ldtcl11veh 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END

IF @tipo=24 --Listar Todos los socios con meses para generar el seguimiento de descuentos
	BEGIN
		BEGIN TRY
	 select  a.lansoc ,CONCAT (a.lanom ,' ',a.laapat ,' ',a.laamat ) as nombre,
  '' as Enero,
  '' as Febrero,
  '' as Marzo,
  '' as Abril,
 '' as Mayo,
'' as Junio,
  '' as Julio,
  '' as Agosto,
  '' as Septiembre,
 '' as Octubre,
  '' as Noviembre,
  '' as Diciembre
  from TCL001 as a where a.lansoc =@ldnsoc  order by lanom asc
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=25 --Listar Todos los socios con meses para generar el seguimiento de descuentos
	BEGIN
		BEGIN TRY
	select ldnumi ,ldcprod ,ldcdprod1,ldprec ,ldprev  ,ldgr1,grupo.cedesc1 as GrupoProducto ,ldumed 
			,ldsmin ,ldap,CAST(IIF(ldap=1,1,0) as bit) as estado,ldimg 
			, CAST('' as Image) as img,ldfact ,ldhact ,lduact,ISNULL(ti.iccven,0 ) as inventario
		from TCL003 left join TC0051 as grupo on grupo.cecod1 =16 and grupo .cecod2 =1
			and grupo .cenum =ldgr1 left join TC0051 as umedida on
			umedida .cecod1 =16 and umedida .cecod2 =2 and umedida .cedesc1 =ldumed
			inner join TI001 as ti on ti.iccprod =ldnumi 
			and ldnumi  not in( select td.lctcl3pro    from @TCL0021 as td where td.lctcl3pro  >0) 
			order by ldnumi asc 

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END



IF @tipo=26 --Listar TODOS LAS RECEPCION SIN VENTAS
	BEGIN
		BEGIN TRY
	select a.lfnumi ,cliente.latipo as tipoCliente,a.lftcl1soc,cliente.lanom as nombre ,a.lffecha ,a.lfcl1veh,
		vehiculo.lbplac as placa,vehiculo .lbtip1_4 ,MarcaCliente .cedesc1 ,a.lfcomb ,a.lfobs ,
		a.lftipo ,a.lftam ,a.lffact ,a.lfhact ,a.lfuact ,cliente.lansoc ,
		isnull(socio .cftsoc,0) as tipo,IIF(Exists(select * from TCE000 where ensocacb=cliente.lanumi),1,0) as acb,cast(0 as bit ) as estado
from TCL006 as a 
inner join TCL001 as cliente on cliente.lanumi =a.lftcl1soc and (a.lfnumi not in (
			select lav.ldnord from TCL002  as lav))
inner join TCL0011 as vehiculo on vehiculo .lblin  =a.lfcl1veh and
		cliente .lanumi =vehiculo .lbnumi 
		inner join TC0051 as MarcaCliente on MarcaCliente .cecod1 =1 and MarcaCliente .cecod2 =1
			and MarcaCliente .cenum = vehiculo .lbmar 
			 and isnull(lfest,0) =0
			left join TCS01 as socio on socio .cfnsoc =cliente .lansoc 
			where  a.lfcomb >=0
		 order by lfnumi desc

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END



IF @tipo=27 --Listar SERVICIOS DE RECEPCION
	BEGIN
		BEGIN TRY
	select  a.ednumi,b.eqnumi as NumiDetalleServicio ,a.edcod ,a.eddesc, b.eqprecio ,b.eqmes 
		,b.eqano,a.edtipo ,a.edest,q.cedesc1 ,a.edfact ,a.edhact ,a.eduact
		from TCE004 as a,TCE0042 as b ,TC0051 as q ,TCL0064 as c where edtipo =@edtipo  and edest =1 and eqtce4 =ednumi and
		eqtip1_4 =@lbtip1_4  --2=Mediano 1=Pequeño 3=Grande
		and b.eqano in(select Max(d.eqano )  from TCE0042 as d where d.eqtce4 =a.ednumi and d.eqtip1_4 =@lbtip1_4)
		 and b.eqmes in(select Max(c.eqmes)   from TCE0042 as c where c.eqtce4 =a.ednumi  and c.eqtip1_4 =@lbtip1_4 and c.eqano =b.eqano )
		and q.cecod1 =1 and q.cecod2 =4 and q.cenum =@lbtip1_4
		and c.liserv =a.ednumi and c.litcl6numi =@lfnumi 
			order by ednumi  desc

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END


IF @tipo=28 --Listar SERVICIOS DE RECEPCION
	BEGIN
		BEGIN TRY
select lib.cenum ,lib.cedesc1 ,(select Sum(detalle.lcptot ) 
from TCL002 as ven,TCL0021 as detalle where ven .ldfdoc >= @ldfechaI  and ven .ldfdoc <=@ldfechaF  
and ven.ldnumi =detalle .lcnumi and ven.ldtven =lib.cenum ) as total
from TC0051 as lib where lib.cecod1 =14 and lib.cecod2 =3
and lib.cenum in (
select   venta .ldtven 
from TCL002 as venta where venta .ldfdoc >= @ldfechaI and venta .ldfdoc <=@ldfechaF)

		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),3,@newFecha,@newHora,@lduact)
		END CATCH

END
 --OPENROWSET(Bulk 'C:\Photo\DSC_000873.jpg', SINGLE_BLOB) AS BLOB
End







