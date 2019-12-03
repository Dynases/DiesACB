USE [DBDies]
GO

/****** Object:  View [dbo].[Vr_ServiciosLavadero]    Script Date: 3/12/2019 06:04:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vr_ServiciosLavadero]
AS
select modulo.cedesc1 as modulo,libreria .cedesc1 as TipoCliente,servicio.ednumi ,servicio .eddesc as servicio ,'NORMAL' as tipo,servicio .edprec as precio
from TCE004 as servicio
inner join TC0051 as libreria on libreria .cecod1 =14 and libreria.cecod2 =4 and libreria .cenum =servicio .tipo 
inner join TC0051 as modulo on modulo .cecod1 =6 and modulo .cecod2 =1 and modulo.cenum =servicio .edtipo 
where servicio.edtipo <>3
union

select  modulo .cedesc1 as modulo ,libreria .cedesc1 as TipoCliente,a.ednumi,a.eddesc as servicio,q.cedesc1 as tipo , isnull((
select top 1 detalle.eqprecio 
from TCE0042 as detalle where detalle .eqtce4 =a.ednumi and 
 detalle.eqano in(select Max(d.eqano )  from TCE0042 as d where d.eqtce4 =a.ednumi and d.eqtip1_4=q.cenum )
 and detalle .eqmes in (select Max(c.eqmes)   from TCE0042 as c where c.eqtce4 =a.ednumi  and c.eqtip1_4 =q.cenum  and c.eqano =detalle .eqano  )),0)as precio
		from TCE004 as a inner join TC0051 as q on edtipo =3  and edest =1
		and q.cecod1 =1 and q.cecod2 =4 
		inner join TC0051 as libreria on libreria .cecod1 =14 and libreria.cecod2 =4 and libreria .cenum =a .tipo 
      inner join TC0051 as modulo on modulo .cecod1 =6 and modulo .cecod2 =1 and modulo.cenum =a .edtipo 


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vr_ServiciosLavadero'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vr_ServiciosLavadero'
GO


