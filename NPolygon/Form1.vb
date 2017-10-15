Imports System.Threading.Tasks

Public Class Form1
    Dim isClick As Boolean = False
    Dim previousPoint As Drawing.Point

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.oPlot.Model = New OxyPlot.PlotModel()
        Me.oPlot.Model.PlotType = OxyPlot.PlotType.XY
        Init(-3, 3, -3, 3)
    End Sub

    Public Sub Init(ByVal xMin As Double, ByVal xMax As Double, ByVal yMin As Double, ByVal yMax As Double)
        Me.oPlot.Model.Series.Clear()
        Me.oPlot.Model.Axes.Clear()

        'plot setting
        Me.oPlot.BackColor = Color.White
        Me.oPlot.Model.PlotMargins = New OxyPlot.OxyThickness(0, 0, 0, 0)
        Me.oPlot.Model.Padding = New OxyPlot.OxyThickness(0, 0, 0, 0)

        'set view
        Dim x = New OxyPlot.Axes.LinearAxis()
        x.Position = OxyPlot.Axes.AxisPosition.Top
        x.Minimum = xMin
        x.Maximum = xMax
        x.PositionAtZeroCrossing = True
        x.AxislineStyle = OxyPlot.LineStyle.Automatic
        x.AxislineColor = OxyPlot.OxyColors.Black
        Me.oPlot.Model.Axes.Add(x)

        Dim y = New OxyPlot.Axes.LinearAxis()
        y.Position = OxyPlot.Axes.AxisPosition.Right
        y.Minimum = yMin
        y.Maximum = yMax
        y.PositionAtZeroCrossing = True
        y.AxislineStyle = OxyPlot.LineStyle.Automatic
        y.AxislineColor = OxyPlot.OxyColors.Black
        Me.oPlot.Model.Axes.Add(y)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        Me.oPlot.Model.Series.Clear()

        With Nothing
            Dim n As Double = 3.0
            Dim t = Math.PI
            Dim p_t = Math.Tan((2.0 / n) * Math.Atan(Math.Tan((n / 2.0) * (t - (Math.PI / 2.0) * sign(Math.Cos(t))))))
            Dim f_t = Math.Sqrt(1.0 + p_t * p_t)
            Dim x_t = f_t * Math.Cos(t)
            Dim y_t = -f_t * sign(Math.Cos(t)) * Math.Sin(t)
            Dim h = 1
        End With

        Try
            Dim n = Double.Parse(tbxN.Text())
            If n <= 2 Then
                Return
            End If

            Dim allPoints = New OxyPlot.Series.ScatterSeries()
            allPoints.MarkerType = OxyPlot.MarkerType.Circle
            allPoints.MarkerSize = 1
            allPoints.MarkerStroke = OxyPlot.OxyColors.Green

            Dim resoulution = Double.Parse(tbxResolution.Text())

            If _cbxParametricPlot.Checked = True Then
                '-----------------------------------------------------
                'parametric plot
                '-----------------------------------------------------
                Dim plotF = New OxyPlot.Series.FunctionSeries(Function(t As Double) As Double
                                                                  Dim p_t = Math.Tan((2.0 / n) * Math.Atan(Math.Tan((n / 2.0) * (t - (Math.PI / 2.0) * sign(Math.Cos(t))))))
                                                                  Dim f_t = Math.Sqrt(1.0 + p_t * p_t)
                                                                  Dim x_t = f_t * Math.Cos(t)
                                                                  Return x_t
                                                              End Function,
                                                              Function(t As Double) As Double
                                                                  Dim p_t = Math.Tan((2.0 / n) * Math.Atan(Math.Tan((n / 2.0) * (t - (Math.PI / 2.0) * sign(Math.Cos(t))))))
                                                                  Dim f_t = Math.Sqrt(1.0 + p_t * p_t)
                                                                  Dim y_t = -f_t * sign(Math.Cos(t)) * Math.Sin(t)
                                                                  Return y_t
                                                              End Function,
                                                              0, 2.0 * Math.PI, resoulution, "N Polygon")
                Me.oPlot.Model.Series.Add(plotF)
                Me.oPlot.InvalidatePlot(True)
            Else
                '-----------------------------------------------------
                'plot point
                '-----------------------------------------------------
                Dim stepWidth As Double = resoulution
                Dim rangeMin As Double = -2.0 - (stepWidth * 2)
                Dim rangeMax As Double = 2.0 + (stepWidth * 2)
                Dim plotCondition As Double = stepWidth * 1.1

                'single thread
                'For x As Double = rangeMin To rangeMax Step stepWidth
                '    For y As Double = rangeMin To rangeMax Step stepWidth
                '        Dim temp = f(x, y, n)
                '        If temp >= -plotCondition AndAlso temp <= plotCondition Then
                '            allPoints.Points.Add(New OxyPlot.Series.ScatterPoint(x, y))
                '        End If
                '    Next
                'Next

                'multi thread
                Dim allPoints2 = New OxyPlot.Series.ScatterSeries()
                allPoints2.MarkerType = OxyPlot.MarkerType.Circle
                allPoints2.MarkerSize = 1
                allPoints2.MarkerStroke = OxyPlot.OxyColors.Green
                Parallel.Invoke(Sub()
                                    For x As Double = rangeMin To 0 Step stepWidth
                                        For y As Double = rangeMin To rangeMax Step stepWidth
                                            Dim temp = f(x, y, n)
                                            '0±plotConditionの範囲内であれば点をうつ
                                            If temp >= -plotCondition AndAlso temp <= plotCondition Then
                                                allPoints.Points.Add(New OxyPlot.Series.ScatterPoint(x, y))
                                            End If
                                        Next
                                    Next
                                End Sub,
                                Sub()
                                    For x As Double = 0 To rangeMax Step stepWidth
                                        For y As Double = rangeMin To rangeMax Step stepWidth
                                            Dim temp = f(x, y, n)
                                            '0±plotConditionの範囲内であれば点をうつ
                                            If temp >= -plotCondition AndAlso temp <= plotCondition Then
                                                allPoints2.Points.Add(New OxyPlot.Series.ScatterPoint(x, y))
                                            End If
                                        Next
                                    Next
                                End Sub)

                Me.oPlot.Model.Series.Add(allPoints)
                Me.oPlot.Model.Series.Add(allPoints2)
                Me.oPlot.InvalidatePlot(True)
            End If
        Catch ex As Exception
            'do nothing
        End Try
    End Sub

    Private Function fc(x As Double, y As Double) As Double
        Return 1 - x * x - y * y
    End Function

    ''' <summary>
    ''' 正n角形の式 MathPower2017
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="n"></param>
    ''' <returns></returns>
    Private Function f(x As Double, y As Double, n As Double) As Double
        '=0になるよう変形
        Dim temp = p(x, y, n)
        Dim val = x * x + y * y - 1.0 - temp * temp

        If Double.IsNaN(val) = True Then
            Return 1
        End If
        Return val
    End Function

    Private Function p(x As Double, y As Double, n As Double) As Double
        Dim a1 = Math.Atan(x / y) - (Math.PI / 2.0) * sign(y)
        Dim a3 = Math.Tan((n / 2.0) * a1)
        Dim a4 = (2.0 / n) * Math.Atan(a3)
        Dim a5 = Math.Tan(a4)
        Return a5
    End Function

    Private Function sign(x As Double) As Double
        If x < 0 Then
            Return 1.0
        ElseIf x > 0 Then
            Return -1.0
        Else
            Return 0
        End If
    End Function

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles ctrlPanel.MouseDown
        isClick = True
        previousPoint = e.Location
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles ctrlPanel.MouseMove
        If isClick Then
            Dim movePoint As Drawing.Point
            movePoint.X = ctrlPanel.Location.X + e.X - previousPoint.X
            movePoint.Y = ctrlPanel.Location.Y + e.Y - previousPoint.Y
            ctrlPanel.Location = movePoint
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles ctrlPanel.MouseUp
        isClick = False
    End Sub
End Class
