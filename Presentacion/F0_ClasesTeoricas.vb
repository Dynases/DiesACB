Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class F0_ClasesTeoricas

#Region "ATRIBUTOS"
    Dim _cantClasesTeo As Integer
    Dim _cantClasesSim As Integer

#End Region

#Region "METODOS PRIVADOS"

    Private Sub _prIniciarTodo()
        Me.Text = "c o n t r o l    d e    c l a s e s    t e o r i c a s".ToUpper
        Me.WindowState = FormWindowState.Maximized
        Dim dtCantClassTeo As DataTable = L_prTCE000General()

        _cantClasesTeo = dtCantClassTeo.Rows(0).Item("eteo")
        _cantClasesSim = dtCantClassTeo.Rows(0).Item("esimul")


        _prCargarGridClases(tbNroGrupo.Text)
    End Sub

    Private Sub _prGrabarModificacion()
        Dim dtGrid As DataTable = CType(grAsignacion.DataSource, DataTable)
        Dim dtRegistros As New DataTable
        dtRegistros.Columns.Add("ekline")
        dtRegistros.Columns.Add("ekalum")
        dtRegistros.Columns.Add("eknum")
        dtRegistros.Columns.Add("ekfecha")
        dtRegistros.Columns.Add("ekestado")
        dtRegistros.Columns.Add("ektipo")
        dtRegistros.Columns.Add("ekest")

        For Each fila As DataRow In dtGrid.Rows
            Dim numiAlum As Integer = fila.Item("cbnumi")
            Dim estadoReg As Integer = fila.Item("ekest")
            For i = 1 To _cantClasesTeo
                Dim estado As Integer
                If fila.Item("t" + Str(i).Trim).ToString = "True" Then
                    estado = 1
                Else
                    estado = 0
                End If

                dtRegistros.Rows.Add(0, numiAlum, i, "2017-01-01", estado, 1, estadoReg)
            Next

            For i = 1 To _cantClasesSim
                Dim estado As Integer
                If fila.Item("s" + Str(i).Trim).ToString = "True" Then
                    estado = 1
                Else
                    estado = 0
                End If

                dtRegistros.Rows.Add(0, numiAlum, i, "2017-01-01", estado, 2, estadoReg)
            Next

        Next

        Dim res As Boolean = L_prClasesTeoricoModificar(dtRegistros)
        If res = True Then
            ToastNotification.Show(Me, " Grabado con Exito.".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
            _prCargarGridClases(tbNroGrupo.Text)
        End If



    End Sub
    Private Sub _prCargarGridClases(nroGrupo As String)

        Dim dtGrid As DataTable = L_prClasesTeoricoAlumnosFiltradosGeneral(nroGrupo)

        'cargar las columnas de las clases practicas
        For i = 1 To _cantClasesTeo
            dtGrid.Columns.Add("t" + Str(i).Trim, Type.GetType("System.Boolean"))
            For Each fila As DataRow In dtGrid.Rows
                fila.Item("t" + Str(i).Trim) = 0
            Next
        Next

        'cargar las columnas de las clases teoricas
        For i = 1 To _cantClasesSim
            dtGrid.Columns.Add("s" + Str(i).Trim, Type.GetType("System.Boolean"))
            For Each fila As DataRow In dtGrid.Rows
                fila.Item("s" + Str(i).Trim) = 0
            Next
        Next

        dtGrid.Columns.Add("ekest", Type.GetType("System.Int32"))

        grAsignacion.DataSource = dtGrid
        grAsignacion.RetrieveStructure()

        With grAsignacion.RootTable.Columns("cbnumi")
            .Caption = "COD. ALUM".ToUpper
            .Width = 40
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .EditType = EditType.NoEdit
        End With

        With grAsignacion.RootTable.Columns("cbnom2")
            .Caption = "alumno".ToUpper
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .EditType = EditType.NoEdit
        End With

        For i = 1 To _cantClasesTeo
            With grAsignacion.RootTable.Columns("t" + Str(i).Trim)
                .Width = 40
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .Caption = "CT" + Str(i)
                .CellStyle.BackColor = Color.AliceBlue
            End With
        Next

        For i = 1 To _cantClasesSim
            With grAsignacion.RootTable.Columns("s" + Str(i).Trim)
                .Width = 40
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .Caption = "CS" + Str(i)
                .CellStyle.BackColor = Color.LightSeaGreen
            End With
        Next

        With grAsignacion.RootTable.Columns("ekest")
            .Visible = False
        End With

        'CARGAR DATOS QUE YA ESTAN REGISTRADOS
        For Each fila As DataRow In dtGrid.Rows
            Dim numiAlum As String = fila.Item("cbnumi").ToString
            Dim dtGrabados As DataTable = L_prClasesTeoricoAlumnosGeneral(numiAlum)
            fila.Item("ekest") = 0
            For Each fila2 As DataRow In dtGrabados.Rows
                Dim numClase As String = "t" + fila2.Item("eknum").ToString
                Dim estClase As Integer = fila2.Item("ekestado")
                fila.Item(numClase) = estClase
                fila.Item("ekest") = 1
            Next

        Next

        'CARGAR DATOS QUE YA ESTAN REGISTRADOS
        For Each fila As DataRow In dtGrid.Rows
            Dim numiAlum As String = fila.Item("cbnumi").ToString
            Dim dtGrabados As DataTable = L_prClasesSimuladorAlumnosGeneral(numiAlum)
            fila.Item("ekest") = 0
            For Each fila2 As DataRow In dtGrabados.Rows
                Dim numClase As String = "s" + fila2.Item("eknum").ToString
                Dim estClase As Integer = fila2.Item("ekestado")
                fila.Item(numClase) = estClase
                fila.Item("ekest") = 1
            Next

        Next



        'Habilitar Filtradores
        With grAsignacion
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With

    End Sub

    Private Sub _prImprimir()

        Dim objrep As New R_EscuelaClasesTeo
        Dim dt As New DataTable
        dt = L_prClasesTeoricoReporte(tbNroGrupo.Text)

        'CARGAR DATOS QUE YA ESTAN REGISTRADOS
        For Each fila As DataRow In dt.Rows
            Dim numiAlum As String = fila.Item("cbnumi").ToString
            Dim dtGrabados As DataTable = L_prClasesTeoricoAlumnosGeneral(numiAlum)
            For Each fila2 As DataRow In dtGrabados.Rows
                Dim numClase As String = "t" + fila2.Item("eknum").ToString
                Dim estClase As Integer = fila2.Item("ekestado")

                fila.Item(numClase) = IIf(estClase = 1, "X", "")
            Next

        Next
        If dt.Rows.Count = 0 Then
            Return
        End If

        'ahora lo mando al visualizador
        P_Global.Visualizador = New Visualizador
        objrep.SetDataSource(dt)
        P_Global.Visualizador.CRV1.ReportSource = objrep 'Comentar
        P_Global.Visualizador.Show() 'Comentar
        P_Global.Visualizador.BringToFront() 'Comentar

        'imprimir
        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    objrep.SetDataSource(dt)
        '    objrep.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        '    objrep.PrintToPrinter(1, False, 1, 10)
        'End If
    End Sub
#End Region

    Private Sub F0_ClasesTeoricas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        _prGrabarModificacion()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub tbNroGrupo_TextChanged(sender As Object, e As EventArgs) Handles tbNroGrupo.TextChanged
        _prCargarGridClases(tbNroGrupo.Text)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        _prImprimir()
    End Sub
End Class