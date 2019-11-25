Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar

Public Class PR_CronoClasesPracticas

#Region "Metodos privados"
    Private Sub _prIniciarTodo()
        _PMIniciarTodo()
        Me.Text = "R E P O R T E     D E    S E G U I M I E N T O    D E    C L A S E S    P R A C T I C A S"
        tbFiltrarInst.Value = False
        tbInstr.Enabled = False
        MReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        _prCargarComboSucursal()
        _prCargarComboInstructores()
    End Sub
    Public Sub _prCargarComboInstructores()
        Dim dt As New DataTable
        dt = L_prPersonaAyudaGeneralPorSucursal(tbSuc.Value, gi_LibPERSTIPOInstructor) 'gi_userSuc

        With tbInstr
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("panumi").Width = 70
            .DropDownList.Columns("panumi").Caption = "COD"

            .DropDownList.Columns.Add("panom1").Width = 200
            .DropDownList.Columns("panom1").Caption = "NOMBRE COMPLETO"

            .ValueMember = "panumi"
            .DisplayMember = "panom1"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub _prCargarComboSucursal()
        Dim dt As New DataTable
        dt = L_prSucursalAyuda()

        With tbSuc
            .DropDownList.Columns.Clear()

            .DropDownList.Columns.Add("canumi").Width = 70
            .DropDownList.Columns("canumi").Caption = "COD"

            .DropDownList.Columns.Add("cadesc").Width = 200
            .DropDownList.Columns("cadesc").Caption = "descripcion".ToUpper

            .ValueMember = "canumi"
            .DisplayMember = "cadesc"
            .DataSource = dt
            .Refresh()
        End With

        If dt.Rows.Count > 0 Then
            tbSuc.Value = gi_userSuc
            If gb_userTodasSuc = False Then
                tbSuc.ReadOnly = True
            End If

        End If

    End Sub
    Private Sub _prCargarReporte()
        If tbSuc.SelectedIndex < 0 Then
            ToastNotification.Show(Me, "seleccione sucursal!".ToUpper, My.Resources.INFORMATION, 2000, eToastGlowColor.Blue, eToastPosition.BottomLeft)
            Exit Sub
        End If
        Dim dtInstructoresHoras As New DataTable
        If tbFiltrarInst.Value = True Then
            If tbInstr.SelectedIndex < 0 Then
                ToastNotification.Show(Me, "Seleccione Instructor!".ToUpper, My.Resources.INFORMATION, 2000, eToastGlowColor.Blue, eToastPosition.BottomLeft)
                Exit Sub
            Else

                Dim fecha As String = tbFecha.Value.ToString("yyyy/MM/dd")

                dtInstructoresHoras = L_prClasesPracGetEstructuraHorariosPorInstructor(tbFecha.Value.ToString("yyyy/MM/dd"), tbSuc.Value, tbInstr.Value, gi_LibHORARIOTipoPractEscuela)
                'Dim numiInstPiv As Integer = dtInstructoresHoras.Rows(0).Item("egchof")
                Dim n As Integer = dtInstructoresHoras.Rows.Count
                Dim i As Integer = 0

                Dim k As Integer = 0
                Dim dtHorasGrabadas As DataTable = L_prClasesPracDetGetHorasPorInst(fecha, tbInstr.Value)



                For j = 0 To n - 1
                    Dim hora As String = dtInstructoresHoras.Rows(i).Item("cchora")
                    If dtHorasGrabadas.Rows.Count > 0 Then
                        If hora = dtHorasGrabadas.Rows(k).Item("ehhor") Then
                            dtInstructoresHoras.Rows(i).Item("nro") = j + 1
                            dtInstructoresHoras.Rows(i).Item("cbnom2") = dtHorasGrabadas.Rows(k).Item("cbnom2")
                            If (dtHorasGrabadas.Rows(k).Item("egest") = 2) Then
                                dtInstructoresHoras.Rows(i).Item("nroClase") = "R" + dtHorasGrabadas.Rows(k).Item("nroClase").ToString
                            Else
                                dtInstructoresHoras.Rows(i).Item("nroClase") = dtHorasGrabadas.Rows(k).Item("nroClase").ToString
                            End If

                            '---------------------------------------------------------
                            'PARA ACTUALIZAR BIEN EL NUMERO DE CLASE
                            Dim dtFechasAntDeOtroInstructor As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesMenorAUnaFechaYHoraX(tbInstr.Value, dtHorasGrabadas.Rows(k).Item("egalum"), fecha) ', dtFechas.Rows(0).Item("ehhor")
                            If dtFechasAntDeOtroInstructor.Rows.Count > 0 Then
                                Dim num As Integer = dtHorasGrabadas.Rows(k).Item("nroClase")
                                num = num + dtFechasAntDeOtroInstructor.Rows.Count
                                If (dtHorasGrabadas.Rows(k).Item("egest") = 2) Then
                                    dtInstructoresHoras.Rows(i).Item("nroClase") = "R" + num.ToString
                                Else
                                    dtInstructoresHoras.Rows(i).Item("nroClase") = num.ToString
                                End If
                            End If
                            '---------------------------------------------------------
                            If k < dtHorasGrabadas.Rows.Count - 1 Then
                                k = k + 1
                            End If
                        Else
                            dtInstructoresHoras.Rows(i).Item("nro") = j + 1
                            dtInstructoresHoras.Rows(i).Item("cbnom2") = "-------------"
                        End If
                    Else
                        dtInstructoresHoras.Rows(i).Item("nro") = j + 1
                        dtInstructoresHoras.Rows(i).Item("cbnom2") = "-------------"
                    End If


                    i = i + 1
                Next


            End If
        Else 'todos los instructores
            Dim fecha As String = tbFecha.Value.ToString("yyyy/MM/dd")

            dtInstructoresHoras = L_prClasesPracGetEstructuraHorarios(tbFecha.Value.ToString("yyyy/MM/dd"), tbSuc.Value, gi_LibHORARIOTipoPractEscuela)
            Dim listInstructores As DataTable = L_prPersonaAyudaGeneralPorSucursal(tbSuc.Value, gi_LibPERSTIPOInstructor)
            'Dim numiInstPiv As Integer = dtInstructoresHoras.Rows(0).Item("egchof")
            Dim n As Integer = dtInstructoresHoras.Rows.Count \ listInstructores.Rows.Count
            Dim i As Integer = 0
            For Each fila As DataRow In listInstructores.Rows
                Dim k As Integer = 0
                Dim dtHorasGrabadas As DataTable = L_prClasesPracDetGetHorasPorInst(fecha, fila.Item("panumi"))
                For j = 0 To n - 1
                    Dim hora As String = dtInstructoresHoras.Rows(i).Item("cchora")
                    If dtHorasGrabadas.Rows.Count > 0 Then
                        If hora = dtHorasGrabadas.Rows(k).Item("ehhor") Then
                            dtInstructoresHoras.Rows(i).Item("nro") = j + 1
                            dtInstructoresHoras.Rows(i).Item("cbnom2") = dtHorasGrabadas.Rows(k).Item("cbnom2")
                            If (dtHorasGrabadas.Rows(k).Item("egest") = 2) Then
                                dtInstructoresHoras.Rows(i).Item("nroClase") = "R" + dtHorasGrabadas.Rows(k).Item("nroClase").ToString
                            Else
                                dtInstructoresHoras.Rows(i).Item("nroClase") = dtHorasGrabadas.Rows(k).Item("nroClase").ToString
                            End If
                            '---------------------------------------------------------
                            'PARA ACTUALIZAR BIEN EL NUMERO DE CLASE
                            Dim dtFechasAntDeOtroInstructor As DataTable = L_prClasesPracDetFechasPorAlumnoYFechaGeneralContablesMenorAUnaFechaYHoraX(fila.Item("panumi"), dtHorasGrabadas.Rows(k).Item("egalum"), fecha) ', dtFechas.Rows(0).Item("ehhor")
                            If dtFechasAntDeOtroInstructor.Rows.Count > 0 Then
                                Dim num As Integer = dtHorasGrabadas.Rows(k).Item("nroClase")
                                num = num + dtFechasAntDeOtroInstructor.Rows.Count
                                If (dtHorasGrabadas.Rows(k).Item("egest") = 2) Then
                                    dtInstructoresHoras.Rows(i).Item("nroClase") = "R" + num.ToString
                                Else
                                    dtInstructoresHoras.Rows(i).Item("nroClase") = num.ToString
                                End If
                            End If
                            '---------------------------------------------------------
                            If k < dtHorasGrabadas.Rows.Count - 1 Then
                                k = k + 1
                            End If
                        Else
                            dtInstructoresHoras.Rows(i).Item("nro") = j + 1
                            dtInstructoresHoras.Rows(i).Item("cbnom2") = "-------------"
                        End If
                    Else
                        dtInstructoresHoras.Rows(i).Item("nro") = j + 1
                        dtInstructoresHoras.Rows(i).Item("cbnom2") = "-------------"
                    End If


                    i = i + 1
                Next
            Next
        End If


        If (dtInstructoresHoras.Rows.Count > 0) Then
            Dim objrep As New R_CronoClasesPracticas


            objrep.SetDataSource(dtInstructoresHoras)
            MReportViewer.ReportSource = objrep

            objrep.SetParameterValue("Fecha", tbFecha.Value.Date.ToString("dd-MM-yyyy"))

            MReportViewer.Show()
            MReportViewer.BringToFront()
        Else
            ToastNotification.Show(Me, "NO HAY DATOS PARA LOS PARAMETROS SELECCIONADOS..!!!",
                                       My.Resources.INFORMATION, 2000,
                                       eToastGlowColor.Blue,
                                          eToastPosition.BottomLeft)
            MReportViewer.ReportSource = Nothing
        End If
    End Sub
#End Region


    Private Sub PR_CronoClasesPracticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub tbFiltrarInst_ValueChanged(sender As Object, e As EventArgs) Handles tbFiltrarInst.ValueChanged
        tbInstr.Enabled = tbFiltrarInst.Value
    End Sub

    Private Sub tbSuc_ValueChanged(sender As Object, e As EventArgs) Handles tbSuc.ValueChanged
        If tbSuc.SelectedIndex >= 0 Then
            _prCargarComboInstructores()
        End If
    End Sub
End Class