Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.Editors

Public Class F0_AlumnosCertiNotasTeorico
#Region "ATRIBUTOS"
    Dim _asignar As Boolean
    Dim _modificar As Boolean
    Dim _notaAprobTeorico As Double = gd_notaAproTeo
    Dim _notaAprobPractico As Double = gd_notaAproPrac
    Dim _notaAprobTeoricoH As Double = gd_notaAproTeoH
#End Region

#Region "METODOS"
    Private Sub _prIniciarTodo()
        btnImprimir.Visible = False
        Me.Text = "n o t a s    d e l    e x a m e n    t e o r i c o".ToUpper
        Me.WindowState = FormWindowState.Maximized
        SuperTabPrincipal.SelectedTabIndex = 0
        SupTabItemBusqueda.Visible = False

        btnGrabar.Enabled = False

        pondeTeo1.Visible = False
        pondeTeo2.Visible = False
        pondePrac1.Visible = False
        pondePrac2.Visible = False

        _prCargarGridAlumnos()


    End Sub

    Private Sub _prSetNotaAprobado(lbl As ReflectionLabel, nota As Double)
        lbl.BackgroundStyle.BorderColor = Color.GreenYellow
        lbl.Text = _fnGetStringAprobado(nota)
    End Sub

    Private Sub _prSetNotaReprobado(lbl As ReflectionLabel, nota As Double)
        lbl.BackgroundStyle.BorderColor = Color.OrangeRed
        lbl.Text = _fnGetStringReprobado(nota)
    End Sub

    Private Sub _prSetNotaAprobado(nota As Double)
        lblTeo1.BackgroundStyle.BorderColor = Color.GreenYellow
        lblTeo1.Text = _fnGetStringAprobado(nota)
    End Sub

    Private Sub _prSetNotaReprobado(nota As Double)
        lblTeo1.BackgroundStyle.BorderColor = Color.OrangeRed
        lblTeo1.Text = _fnGetStringReprobado(nota)
    End Sub

    Private Function _fnGetStringAprobado(nota As Double) As String
        Return "<font size=" & Chr(34) & "+10" & Chr(34) & "><font color=" & Chr(34) & "#00E676" & Chr(34) & ">" & nota.ToString & "</font></font>"
    End Function

    Private Function _fnGetStringReprobado(nota As Double) As String
        Return "<font size=" & Chr(34) & "+10" & Chr(34) & "><font color=" & Chr(34) & "#F44336" & Chr(34) & ">" & nota.ToString & "</font></font>"
    End Function

    Private Sub _prGrabarTodasLasNotas()
        _prGrabarNotas(grTeo1)
        _prGrabarNotas(grTeo2)

        Dim categoriaLicencia As String = grAlumnos.GetValue("emcatlic")

        If categoriaLicencia = 6 Then
            'no grabo notas practicas
        Else
            _prGrabarNotas(grPrac1)
            _prGrabarNotas(grPrac2)
        End If


        If IsDBNull(grAlumnos.GetValue("numiCert")) = False Then
            Dim numiCert As Integer = grAlumnos.GetValue("numiCert")

            If numiCert > 0 Then
                Dim dtExamenTeo, dtExamenPrac As DataTable
                Dim notaTeo, notaMec, notaPrac, notaFin As Double
                Dim numiAlum, nroFact As String
                numiAlum = grAlumnos.GetValue("emalum")
                nroFact = grAlumnos.GetValue("emznfact")

                dtExamenTeo = L_prCertificadosAlumnosGetUltimaClaseTeorica(numiAlum, nroFact)
                If categoriaLicencia = 6 Then
                    notaPrac = 0
                Else
                    dtExamenPrac = L_prCertificadosAlumnosGetUltimaClasePractica(numiAlum, nroFact)
                    notaPrac = dtExamenPrac.Rows(0).Item("emnota")
                End If



                notaTeo = L_prCertificadosAlumnosGetNotaEvaluacionTeorica(dtExamenTeo.Rows(0).Item("emnumi").ToString).Rows(0).Item("nota")
                If categoriaLicencia = 6 Then
                    notaMec = 0
                Else
                    notaMec = L_prCertificadosAlumnosGetNotaEvaluacionConocMecanica(dtExamenTeo.Rows(0).Item("emnumi").ToString).Rows(0).Item("nota")

                End If
                notaFin = notaPrac + notaTeo + notaMec

                'actualizo las notas en la tabla de certificados
                L_prCertificadosAlumnosModificar(numiCert, notaTeo, notaMec, notaPrac, notaFin)
                End If
            End If



        _prCargarGridAlumnos()
        tbTodos.Value = False
        SupTabItemRegistro.Visible = True
        SupTabItemBusqueda.Visible = False
        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub _prCargarGridAlumnos(Optional todos As Boolean = False)

        Dim dtGrid As DataTable
        If todos = True Then
            dtGrid = L_prExamenAlumnoCertiGeneralProgramadosParaPonerNotasTeoricoTODOS()

        Else
            dtGrid = L_prExamenAlumnoCertiGeneralProgramadosParaPonerNotasTeorico()
        End If
        grAlumnos.DataSource = dtGrid
        grAlumnos.RetrieveStructure()

        'dar formato a las columnas
        'With grAlumnos.RootTable.Columns("emnumi")
        '    .Visible = False
        'End With
        'With grAlumnos.RootTable.Columns("emobs")
        '    .Visible = False
        'End With
        With grAlumnos.RootTable.Columns("emcatlic")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("cedesc1")
            .Caption = "cat. lic.".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAlumnos.RootTable.Columns("emznfact")
            .Caption = "nro. fact.".ToUpper
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("emalum")
            .Caption = "COD. ALUM".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("elci")
            .Caption = "CI".ToUpper
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("elnom")
            .Caption = "nombre".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAlumnos.RootTable.Columns("elapep")
            .Caption = "ape. pat.".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        With grAlumnos.RootTable.Columns("elapem")
            .Caption = "ape. mat.".ToUpper
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        End With

        'With grAlumnos.RootTable.Columns("cedesc1")
        '    .Caption = "cat. lic.".ToUpper
        '    .Width = 150
        '    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        'End With

        With grAlumnos.RootTable.Columns("elfot")
            .Visible = False
        End With

        'With grAlumnos.RootTable.Columns("emestado")
        '    .Visible = False
        'End With

        With grAlumnos.RootTable.Columns("elesc")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("elesc2")
            .Caption = "ESC.".ToUpper
            .Width = 50
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        End With

        With grAlumnos.RootTable.Columns("estado")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("grabado")
            .Visible = False
        End With

        With grAlumnos.RootTable.Columns("numiCert")
            .Visible = False
        End With


        'Habilitar Filtradores
        With grAlumnos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
            .ContextMenuStrip = cmOpciones
        End With

        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(grAlumnos.RootTable.Columns("grabado"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen
        grAlumnos.RootTable.FormatConditions.Add(fc)

    End Sub



    Private Sub _prSalirGrabar()
        'If btnGrabar.Enabled = True Then
        '    btnGrabar.Enabled = False
        '    btnModificar.Enabled = True
        '    'btnAsignar.Enabled = True

        '    gpNotas.Visible = False
        '    btPonerNotas.Enabled = True
        '    btnGrabar.Enabled = False

        '    _prCargarGridAlumnos()
        'Else
        '    Me.Close()
        'End If

        SuperTabPrincipal.SelectedTabIndex = 0


    End Sub

    Private Sub _prSalir()
        Me.Close()
    End Sub



    'Private Sub _prGrabarAsignados()


    '    Dim dtRegistros As DataTable
    '    dtRegistros = CType(grAlumnos.DataSource, DataTable).DefaultView.ToTable(True, "ejnumi", "ejalum", "ejfecha", "ejestado", "ejchof", "ejnota", "ejfact", "ejhact", "ejuact", "estado")
    '    Dim resp As Boolean = L_prPreExamenGrabarAsignados(dtRegistros)
    '    If resp Then
    '        ToastNotification.Show(Me, "Se registro exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
    '        btnGrabar.Enabled = False
    '        'btnAsignar.Enabled = True
    '        _prCargarGridAlumnos()
    '    End If

    'End Sub

    'Private Sub _prGrabarModificion()

    '    Dim dtRegistros As DataTable
    '    dtRegistros = CType(grAlumnos.DataSource, DataTable).DefaultView.ToTable(True, "ejnumi", "ejalum", "ejfecha", "ejestado", "ejchof", "ejnota", "ejfact", "ejhact", "ejuact", "estado")
    '    Dim resp As Boolean = L_prPreExamenModificar(dtRegistros)
    '    If resp Then
    '        ToastNotification.Show(Me, "Se modifico exitosamente".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
    '        btnGrabar.Enabled = False
    '        'btnAsignar.Enabled = True
    '        btnModificar.Enabled = True

    '        _prCargarGridAlumnos()
    '    End If

    'End Sub

    Private Sub _prModificar()
        'btnAsignar.Enabled = False
        btnGrabar.Enabled = True

        btnModificar.Enabled = False
        _modificar = True
        _asignar = False

    End Sub

    Private Sub _prAsignarNotas()
        '_asignar = True
        '_prSetNotaReprobado(0)
        'gpNotas.Visible = True
        '_prCargarGridNotas()
        'btnGrabar.Enabled = True
        'btPonerNotas.Enabled = False

        'para poner las cosas en orden para hacer la asignacion de notas
        SupTabItemBusqueda.Visible = True
        SupTabItemRegistro.Visible = False
        SuperTabPrincipal.SelectedTabIndex = 1
        _prCargarNotas()
    End Sub
    Private Sub _prCargarNotas()
        Dim nroFact As String = grAlumnos.GetValue("emznfact")
        Dim numiAlum As String = grAlumnos.GetValue("emalum")

        Dim categoriaLicencia As String = grAlumnos.GetValue("emcatlic")

        Dim dtRegTeo As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 1)
        Dim dtRegPrac As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 2)
        Dim numiRegTeo1, numiRegTeo2, numiRegPrac1, numiRegPrac2 As String
        Dim catLicTeo1, catLicTeo2, catLicPrac1, catLicPrac2 As String
        Dim dtTeo1, dtTeo2, dtPrac1, dtPrac2 As DataTable
        dtTeo1 = Nothing
        dtTeo2 = Nothing
        dtPrac1 = Nothing
        dtPrac2 = Nothing

        If dtRegTeo.Rows.Count > 0 Then
            If dtRegTeo.Rows.Count = 1 Then
                numiRegTeo1 = dtRegTeo.Rows(0).Item("emnumi")

                catLicTeo1 = dtRegTeo.Rows(0).Item("emcatlic")

                dtTeo1 = L_prNotasPreguntasPorRegInscripcion(numiRegTeo1, 1, catLicTeo1)

                _prCargarGridNotas(grTeo1, lblTeo1, dtTeo1)
                GroupBoxTeo2.Visible = False
                grTeo1.Tag = numiRegTeo1
            Else
                numiRegTeo1 = dtRegTeo.Rows(0).Item("emnumi")
                numiRegTeo2 = dtRegTeo.Rows(1).Item("emnumi")

                catLicTeo1 = dtRegTeo.Rows(0).Item("emcatlic")
                catLicTeo2 = dtRegTeo.Rows(1).Item("emcatlic")

                dtTeo1 = L_prNotasPreguntasPorRegInscripcion(numiRegTeo1, 1, catLicTeo1)
                dtTeo2 = L_prNotasPreguntasPorRegInscripcion(numiRegTeo2, 1, catLicTeo2)

                _prCargarGridNotas(grTeo1, lblTeo1, dtTeo1)
                _prCargarGridNotas(grTeo2, lblTeo2, dtTeo2)
                grTeo1.Tag = numiRegTeo1
                grTeo2.Tag = numiRegTeo2

            End If

        End If

        If categoriaLicencia = 6 Then
            grPrac1.DataSource = Nothing
            grPrac2.DataSource = Nothing
        Else
            If dtRegPrac.Rows.Count > 0 Then
                If dtRegPrac.Rows.Count = 1 Then
                    numiRegPrac1 = dtRegPrac.Rows(0).Item("emnumi")

                    catLicPrac1 = dtRegTeo.Rows(0).Item("emcatlic")

                    dtPrac1 = L_prNotasPreguntasPorRegInscripcion(numiRegPrac1, 2, catLicPrac1)

                    _prCargarGridNotas(grPrac1, lblPrac1, dtPrac1)
                    GroupBoxPrac2.Visible = False
                    grPrac1.Tag = numiRegPrac1
                Else
                    numiRegPrac1 = dtRegPrac.Rows(0).Item("emnumi")
                    numiRegPrac2 = dtRegPrac.Rows(1).Item("emnumi")

                    catLicPrac1 = dtRegPrac.Rows(0).Item("emcatlic")
                    catLicPrac2 = dtRegPrac.Rows(1).Item("emcatlic")

                    dtPrac1 = L_prNotasPreguntasPorRegInscripcion(numiRegPrac1, 2, catLicPrac1)
                    dtPrac2 = L_prNotasPreguntasPorRegInscripcion(numiRegPrac2, 2, catLicPrac2)

                    _prCargarGridNotas(grPrac1, lblPrac1, dtPrac1)
                    _prCargarGridNotas(grPrac2, lblPrac2, dtPrac2)
                    grPrac1.Tag = numiRegPrac1
                    grPrac2.Tag = numiRegPrac2
                End If

            End If
        End If





    End Sub

   
    Private Sub _prCargarGridNotas(ByRef gr As DataGridView, lbl As ReflectionLabel, dt As DataTable)
        'Dim dt As New DataTable
        'dt = L_prPreguntaGeneral2(1, 1)

        gr.DataSource = dt

        'dar formato a las columnas
        With gr.Columns("ennumi")
            .Width = 50
            .Visible = False
        End With

        With gr.Columns("entipo")
            .Width = 60
            .Visible = False
        End With

        With gr.Columns("enlic")
            .Width = 60
            .Visible = False
        End With

        With gr.Columns("endesc")
            .ReadOnly = True
            .HeaderText = "pregunta".ToUpper
            .Width = 600
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With gr.Columns("enval")
            .ReadOnly = True
            .HeaderText = "ponderacion".ToUpper
            .Width = 120
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        With gr.Columns("nota")
            .DefaultCellStyle.BackColor = Color.AliceBlue
            .HeaderText = "Nota".ToUpper
            .Width = 50
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        With gr.Columns("ok")
            .DefaultCellStyle.BackColor = Color.AliceBlue
            .HeaderText = "ok".ToUpper
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        With gr
            .AllowUserToAddRows = False
        End With

        'Seleccionar todas las preguntas si es que es uno nuevo de grabado de notas
        Dim grabado As Integer = grAlumnos.GetValue("grabado")
        If grabado = 0 Then
            Dim sw As Boolean = True
            Select Case gr.Name
                Case "grTeo1"
                    sw = False
                Case "grTeo2"
                    sw = False
            End Select

            'If sw Then 'selecciono todo si solo es notas practicas
            '    For Each fila As DataRow In dt.Rows
            '        fila.Item("ok") = 1
            '        fila.Item("nota") = fila.Item("enval")
            '    Next
            'End If
        Else 'para poner su check en el practico si tiene nota en la pregunta
            Dim sw As Boolean = True
            Select Case gr.Name
                Case "grTeo1"
                    sw = False
                Case "grTeo2"
                    sw = False
            End Select

            If sw Then 'si es fuera grid practico
                For Each fila As DataRow In dt.Rows
                    If fila.Item("nota") = 0 Then

                    Else
                        fila.Item("ok") = 1
                    End If
                Next
            End If
        End If

        'poner la columna extra para las notas teoricas
        Dim sw1 As Boolean = False
        Select Case gr.Name
            Case "grTeo1"
                sw1 = True
            Case "grTeo2"
                sw1 = True
        End Select
        If sw1 Then
            dt.Columns.Add("cant", GetType(Integer))
            With gr.Columns("cant")
                .DefaultCellStyle.BackColor = Color.AliceBlue
                .HeaderText = "cant.".ToUpper
                .Width = 50
                '.DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            'pongo la cantidad de preguntas respondidas en teorica
            If grabado = 1 Then
                For Each fila As DataRow In dt.Rows
                    Dim nota As Double = fila.Item("nota")
                    Dim ponderacion As Double = fila.Item("enval")
                    fila.Item("cant") = nota / ponderacion
                Next
            End If
        End If

        

        'sumar la nota
        _prSumarNota(gr)


    End Sub

    Private Sub _prSumarNota()
        Dim sumNota As Double = 0
        For i = 0 To grTeo1.Rows.Count - 1
            sumNota = sumNota + grTeo1.Rows(i).Cells("nota").Value
        Next
        If sumNota >= _notaAprobTeorico Then
            _prSetNotaAprobado(sumNota)

        Else
            _prSetNotaReprobado(sumNota)
        End If

    End Sub

    Private Sub _prSumarNota(gr As DataGridView)
        Dim lbl As ReflectionLabel = Nothing
        Dim tb As TextBoxX = Nothing
        Dim tipoExamen = 1
        Select Case gr.Name
            Case "grTeo1"
                lbl = lblTeo1
                tb = tbNotaTeo1
                tipoExamen = 1
            Case "grTeo2"
                lbl = lblTeo2
                tb = tbNotaTeo2
                tipoExamen = 1
            Case "grPrac1"
                lbl = lblPrac1
                tb = tbNotaPrac1
                tipoExamen = 2
            Case "grPrac2"
                lbl = lblPrac2
                tb = tbNotaPrac2
                tipoExamen = 2
        End Select
        Dim sumNota As Double = 0
        For i = 0 To gr.Rows.Count - 1
            sumNota = sumNota + gr.Rows(i).Cells("nota").Value
        Next
        If tipoExamen = 1 Then
            Dim categoriaLicencia As String = grAlumnos.GetValue("emcatlic")

            If categoriaLicencia = 6 Then
                If sumNota >= _notaAprobTeoricoH Then
                    _prSetNotaAprobado(lbl, sumNota)
                Else
                    _prSetNotaReprobado(lbl, sumNota)
                End If
            Else
                If sumNota >= _notaAprobTeorico Then
                    _prSetNotaAprobado(lbl, sumNota)

                Else
                    _prSetNotaReprobado(lbl, sumNota)
                End If
            End If

        Else
            If sumNota >= _notaAprobPractico Then
                _prSetNotaAprobado(lbl, sumNota)

            Else
                _prSetNotaReprobado(lbl, sumNota)
            End If
        End If

        tb.Text = sumNota.ToString("0.00")

    End Sub
    Private Sub _prGrabarNotas()
        btnImprimir.Focus()
        Dim numiPregunta, numiAlum, numiExamen, nota As String
        numiAlum = grAlumnos.GetValue("emalum")
        numiExamen = grAlumnos.GetValue("emnumi")
        L_prNotasPreguntaEliminarNotasDeExamen(numiExamen)
        Dim sumNota As Double = 0
        For i = 0 To grNotas.Rows.Count - 1
            sumNota = sumNota + grNotas.Rows(i).Cells("nota").Value
            nota = grNotas.Rows(i).Cells("nota").Value
            numiPregunta = grNotas.Rows(i).Cells("ennumi").Value
            L_prNotasPreguntaGrabar(numiPregunta, nota, numiExamen)
        Next

        If sumNota >= _notaAprobTeorico Then
            L_prExamenAlumnoCertiModificarEstado(numiExamen, 2)
            ''L_prExamenAlumnoCertiGrabar("", numiAlum, Now.Date.ToString("yyyy/MM/dd"), 0, 0, 0, 2, grAlumnos.GetValue("emznfact"), grAlumnos.GetValue("emobs"), grAlumnos.GetValue("emcatlic"), "1")
        Else
            L_prExamenAlumnoCertiModificarEstado(numiExamen, 3)
        End If
        ToastNotification.Show(Me, "Se registro exitosamente las notas del alumno".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        _prSalir()
    End Sub

    Private Sub _prGrabarNotas(gr As DataGridView)
        btnImprimir.Focus()
        Dim numiPregunta, numiAlum, numiExamen, nota As String
        numiAlum = grAlumnos.GetValue("emalum")
        numiExamen = gr.Tag
        L_prNotasPreguntaEliminarNotasDeExamen(numiExamen)

        Dim tipoExamen = 1
        Select Case gr.Name
            Case "grTeo1"
                tipoExamen = 1
            Case "grTeo2"
                tipoExamen = 1
            Case "grPrac1"
                tipoExamen = 2
            Case "grPrac2"
                tipoExamen = 2
        End Select

        Dim sumNota As Double = 0
        For i = 0 To gr.Rows.Count - 1
            sumNota = sumNota + gr.Rows(i).Cells("nota").Value
            nota = gr.Rows(i).Cells("nota").Value
            numiPregunta = gr.Rows(i).Cells("ennumi").Value
            L_prNotasPreguntaGrabar(numiPregunta, nota, numiExamen)
        Next

        If tipoExamen = 1 Then
            Dim categoriaLicencia As String = grAlumnos.GetValue("emcatlic")
            If categoriaLicencia = 6 Then
                If sumNota >= _notaAprobTeoricoH Then
                    L_prExamenAlumnoCertiModificarEstado(numiExamen, 2)
                    ''L_prExamenAlumnoCertiGrabar("", numiAlum, Now.Date.ToString("yyyy/MM/dd"), 0, 0, 0, 2, grAlumnos.GetValue("emznfact"), grAlumnos.GetValue("emobs"), grAlumnos.GetValue("emcatlic"), "1")
                Else
                    L_prExamenAlumnoCertiModificarEstado(numiExamen, 3)
                End If
            Else
                If sumNota >= _notaAprobTeorico Then
                    L_prExamenAlumnoCertiModificarEstado(numiExamen, 2)
                    ''L_prExamenAlumnoCertiGrabar("", numiAlum, Now.Date.ToString("yyyy/MM/dd"), 0, 0, 0, 2, grAlumnos.GetValue("emznfact"), grAlumnos.GetValue("emobs"), grAlumnos.GetValue("emcatlic"), "1")
                Else
                    L_prExamenAlumnoCertiModificarEstado(numiExamen, 3)
                End If
            End If

        Else
            If sumNota >= _notaAprobPractico Then
                L_prExamenAlumnoCertiModificarEstado(numiExamen, 2)
                ''L_prExamenAlumnoCertiGrabar("", numiAlum, Now.Date.ToString("yyyy/MM/dd"), 0, 0, 0, 2, grAlumnos.GetValue("emznfact"), grAlumnos.GetValue("emobs"), grAlumnos.GetValue("emcatlic"), "1")
            Else
                L_prExamenAlumnoCertiModificarEstado(numiExamen, 3)
            End If
        End If

        L_prExamenAlumnoCertiModificarNota(numiExamen, sumNota)
        ToastNotification.Show(Me, "Se registro exitosamente las notas del alumno".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)
        _prSalirGrabar()
    End Sub

    Private Sub _prPonerAlumnoComoFaltante()
        Dim nroFact As String = grAlumnos.GetValue("emznfact")
        Dim numiAlum As String = grAlumnos.GetValue("emalum")
        'traigo sus registros
        Dim dtRegTeo As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 1)
        Dim dtRegPrac As DataTable = L_prExamenAlumnoCertiGeneralRegistrosPorNroFactura(nroFact, numiAlum, 2)
        Dim numiRegTeo, numiRegPrac As String


        If dtRegTeo.Rows.Count > 0 Then
            numiRegTeo = dtRegTeo.Rows(dtRegTeo.Rows.Count - 1).Item("emnumi")
            L_prExamenAlumnoCertiModificarEstado(numiRegTeo, 4) 'cambio a el estado a con falta o inaxistencia
        End If

        If dtRegPrac.Rows.Count > 0 Then
            numiRegPrac = dtRegPrac.Rows(dtRegPrac.Rows.Count - 1).Item("emnumi")
            L_prExamenAlumnoCertiModificarEstado(numiRegPrac, 4) 'cambio a el estado a con falta o inaxistencia

        End If

        ToastNotification.Show(Me, "Se registro exitosamente el estado como SNP".ToUpper, My.Resources.GRABACION_EXITOSA, 5000, eToastGlowColor.Green, eToastPosition.TopCenter)

    End Sub

#End Region

    Private Sub F0_PreExamen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub



    Private Sub grAsignacion_KeyDown(sender As Object, e As KeyEventArgs) Handles grAlumnos.KeyDown

        'e.KeyCode = Keys.Control + Keys.Enter
        If e.KeyData = Keys.Control + Keys.Enter And grAlumnos.Row >= 0 Then
            If (grAlumnos.CurrentColumn.Key = "ejchof") Or (grAlumnos.CurrentColumn.Key = "panom2") Then
                'grabar horario
                Dim frmAyuda As Modelos.ModeloAyuda
                Dim dt As DataTable = L_prPersonaAyudaGeneralPorSucursal(gi_userSuc, gi_LibPERSTIPOInstructor)
                Dim listEstCeldas As New List(Of Modelos.Celda)
                listEstCeldas.Add(New Modelos.Celda("panumi", True, "Codigo".ToUpper, 70))
                listEstCeldas.Add(New Modelos.Celda("panom", True, "nombre".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("paape", True, "apellido".ToUpper, 200))
                listEstCeldas.Add(New Modelos.Celda("panom1", True, "Nombre completo".ToUpper, 300))

                frmAyuda = New Modelos.ModeloAyuda(200, 200, dt, "Seleccione el estudiante a quien se programara el horario".ToUpper, listEstCeldas)
                frmAyuda.ShowDialog()

                If frmAyuda.seleccionado = True Then
                    Dim numiInst As String = frmAyuda.filaSelect.Cells("panumi").Value
                    Dim nombreInst As String = frmAyuda.filaSelect.Cells("panom1").Value
                    grAlumnos.SetValue("ejchof", numiInst)
                    grAlumnos.SetValue("panom2", nombreInst)
                    grAlumnos.SetValue("estado", 2)
                End If
            End If

        End If
    End Sub

    Private Sub grAsignacion_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grAlumnos.EditingCell
        If btnGrabar.Enabled = False Then
            e.Cancel = True
        Else
            If e.Column.Key <> "ejfecha" And e.Column.Key <> "ckeck" And e.Column.Key <> "ejestado2" And e.Column.Key <> "ejnota" Then
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _prSalir()
    End Sub



    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _asignar = True Then
            _prGrabarNotas()
        Else

            'If _modificar = True Then
            '    _prGrabarModificion()
            'End If

        End If

    End Sub

    Private Sub grAsignacion_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles grAlumnos.CellEdited


        If e.Column.Key = "ckeck" Then
            grAlumnos.SetValue("estado", 1)
        End If

        If e.Column.Key = "ejestado2" Then
            Dim estado As String = grAlumnos.GetValue("ejestado2")
            Dim numiEst As Integer
            Select Case estado
                Case "PROGRAMADO"
                    numiEst = 0
                Case "APROBADO"
                    numiEst = 1
                Case "REPROBADO"
                    numiEst = 2
                Case "FALTA"
                    numiEst = 3
                Case "PERMISO"
                    numiEst = 4

            End Select
            grAlumnos.SetValue("ejestado", numiEst)
        End If

        If _modificar = True Then
            grAlumnos.SetValue("estado", 2)
        End If


    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _prModificar()
    End Sub

    Private Sub btPonerNotas_Click(sender As Object, e As EventArgs) Handles btPonerNotas.Click
        _prAsignarNotas()
    End Sub

    Private Sub ASIGNARNOTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ASIGNARNOTAToolStripMenuItem.Click
        _prPonerAlumnoComoFaltante()
    End Sub

    Private Sub grNotas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grNotas.CellEndEdit, grTeo1.CellEndEdit, grTeo2.CellEndEdit, grPrac1.CellEndEdit, grPrac2.CellEndEdit
        Dim gr As DataGridView = CType(sender, DataGridView)

        Dim tbPonde As DoubleInput = Nothing
        Dim esTeo As Boolean = False
        Select Case gr.Name
            Case "grTeo1"
                tbPonde = pondeTeo1
                esTeo = True
            Case "grTeo2"
                tbPonde = pondeTeo2
                esTeo = True
            Case "grPrac1"
                tbPonde = pondePrac1
            Case "grPrac2"
                tbPonde = pondePrac2
        End Select

        If gr.Columns(e.ColumnIndex).Name = "ok" Then
            Dim check As Boolean = gr.Rows(e.RowIndex).Cells("ok").Value
            If check Then
                'Dim notaPond As Double = tbPonde.Value
                Dim notaPond As Double = gr.Rows(e.RowIndex).Cells("enval").Value
                gr.Rows(e.RowIndex).Cells("nota").Value = notaPond
            Else

                gr.Rows(e.RowIndex).Cells("nota").Value = 0
            End If
            _prSumarNota(gr)
        End If

        If gr.Columns(e.ColumnIndex).Name = "nota" Then
            If esTeo = False Then 'significa que esta insertando en notas practicas
                Dim notaPond As Double = gr.Rows(e.RowIndex).Cells("enval").Value
                Dim nota As Double = gr.Rows(e.RowIndex).Cells("nota").Value
                If nota > notaPond Then
                    gr.Rows(e.RowIndex).Cells("nota").Value = 0
                End If
            Else 'esta ingresando en notas teoricas,entonces tengo que hacer el calculo de acuerdo a la cantidad de preguntas respondidas
                Dim notaPond As Double = gr.Rows(e.RowIndex).Cells("enval").Value
                Dim nota As Double = gr.Rows(e.RowIndex).Cells("nota").Value
                'gr.Rows(e.RowIndex).Cells("nota").Value = nota * notaPond

                'If nota > notaPond Then
                '    gr.Rows(e.RowIndex).Cells("nota").Value = 0
                'Else
                '    gr.Rows(e.RowIndex).Cells("nota").Value = nota * notaPond
                'End If
            End If

            gr.Rows(e.RowIndex).Cells("ok").Value = False
            _prSumarNota(gr)
        End If

        If gr.Columns(e.ColumnIndex).Name = "cant" Then
            Dim notaPond As Double = gr.Rows(e.RowIndex).Cells("enval").Value
            Dim cantResp As Double = gr.Rows(e.RowIndex).Cells("cant").Value
            gr.Rows(e.RowIndex).Cells("nota").Value = cantResp * notaPond

            gr.Rows(e.RowIndex).Cells("ok").Value = False
            _prSumarNota(gr)
        End If

    End Sub

    'If grNotas.Columns(e.ColumnIndex).Name = "ok" Then
    'Dim check As Boolean = grNotas.Rows(e.RowIndex).Cells("ok").Value
    '        If check Then
    'Dim notaPond As Double = grNotas.Rows(e.RowIndex).Cells("enval").Value
    '            grNotas.Rows(e.RowIndex).Cells("nota").Value = notaPond
    '        Else

    '            grNotas.Rows(e.RowIndex).Cells("nota").Value = 0
    '        End If
    '        _prSumarNota()
    '    End If

    '    If grNotas.Columns(e.ColumnIndex).Name = "nota" Then
    'Dim notaPond As Double = grNotas.Rows(e.RowIndex).Cells("enval").Value
    'Dim nota As Double = grNotas.Rows(e.RowIndex).Cells("nota").Value
    '        If nota > notaPond Then
    '            grNotas.Rows(e.RowIndex).Cells("nota").Value = 0
    '        End If

    '        grNotas.Rows(e.RowIndex).Cells("ok").Value = False
    '        _prSumarNota()
    '    End If

    Private Sub btnGrabarNota_Click(sender As Object, e As EventArgs) Handles btnGrabarNota.Click
        _prGrabarTodasLasNotas()
    End Sub

    Private Sub GroupPanel7_Click(sender As Object, e As EventArgs) Handles GroupPanel7.Click

    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        SupTabItemRegistro.Visible = True
        SupTabItemBusqueda.Visible = False
        SuperTabPrincipal.SelectedTabIndex = 0

    End Sub

    Private Sub tbTodos_ValueChanged(sender As Object, e As EventArgs) Handles tbTodos.ValueChanged
        If tbTodos.Value = True Then
            _prCargarGridAlumnos(True)

        Else
            _prCargarGridAlumnos()

        End If
    End Sub

    Private Sub btMarcarTodosPractico1_Click(sender As Object, e As EventArgs) Handles btMarcarTodosPractico1.Click
        If IsNothing(grPrac1.DataSource) = False Then
            Dim dt As DataTable = CType(grPrac1.DataSource, DataTable)
            For Each fila As DataRow In dt.Rows
                fila.Item("ok") = 1
                fila.Item("nota") = fila.Item("enval")
            Next

            _prSumarNota(grPrac1)
        End If
    End Sub

    Private Sub btMarcarTodosPractico2_Click(sender As Object, e As EventArgs) Handles btMarcarTodosPractico2.Click
        If IsNothing(grPrac2.DataSource) = False Then
            Dim dt As DataTable = CType(grPrac2.DataSource, DataTable)
            For Each fila As DataRow In dt.Rows
                fila.Item("ok") = 1
                fila.Item("nota") = fila.Item("enval")
            Next

            _prSumarNota(grPrac2)

        End If

    End Sub
End Class