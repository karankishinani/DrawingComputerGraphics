Imports System.Collections
Public Class frmPrincipal

    Dim GFX As Graphics = Graphics.FromImage(BMP)
    Dim GFX2 As Graphics = Graphics.FromImage(BMP2)
    Dim elegido As String
    Sub coordenada_real(ByRef x As Integer, ByRef y As Integer)
        x = x + 320
        y = 240 - y - 1
    End Sub
    Sub ordenar_coord(ByRef x1 As Integer, ByRef y1 As Integer, ByRef x2 As Integer, ByRef y2 As Integer)
        Dim x, y As Integer
        If x1 > x2 Then
            x = x2
            y = y2
            x2 = x1
            y2 = y1
            x1 = x
            y1 = y
        End If
    End Sub
    Function obtener_octante(ByVal m As Single, ByVal x1 As Integer, ByVal x2 As Integer, ByVal y1 As Integer, ByVal y2 As Integer)
        Dim octante As Integer
        If 0 <= m And m <= 1 And x1 < x2 Then
            octante = 0
        ElseIf 1 < m And y1 < y2 Then
            octante = 1
        ElseIf -1 > m And y1 < y2 Then
            octante = 2
        ElseIf 0 >= m And m >= -1 And x2 < x1 Then
            octante = 3
        ElseIf 0 < m And m <= 1 And x2 < x1 Then
            octante = 4
        ElseIf 1 < m And y2 < y1 Then
            octante = 5
        ElseIf -1 > m And y2 < y1 Then
            octante = 6
        ElseIf 0 > m And m >= -1 And x1 < x2 Then
            octante = 7
        End If
        Return octante
    End Function

    Sub cambiarDeOctanteCeroA(ByVal octante As Integer, ByRef x As Integer, ByRef y As Integer)
        Dim temp As Integer
        Select Case octante
            Case 0 ' (x,y)
            Case 1 ' (y,x)
                temp = x
                x = y
                y = temp
            Case 2 '(-y,x)
                temp = x
                x = -y
                y = temp
            Case 3 ' (-x,y)
                x = -x
            Case 4 ' (-x,-y)
                x = -x
                y = -y
            Case 5 ' (-y,-x)
                temp = x
                x = -y
                y = -temp
            Case 6 ' (y,-x)
                temp = x
                x = y
                y = -temp
            Case 7 ' (x,-y)
                y = -y
        End Select
    End Sub
    Sub cambiarAOctanteCeroDe(ByVal octante As Integer, ByRef x As Integer, ByRef y As Integer)
        Dim temp As Integer
        Select Case octante
            Case 0 ' (x,y)
            Case 1 ' (y,x)
                temp = x
                x = y
                y = temp
            Case 2 '(y,-x)
                temp = x
                x = y
                y = -temp
            Case 3 ' (-x,y)
                x = -x
            Case 4 ' (-x,-y)
                x = -x
                y = -y
            Case 5 ' (-y,-x)
                temp = x
                x = -y
                y = -temp
            Case 6 ' (-y,x)
                temp = x
                x = -y
                y = temp
            Case 7 ' (x,-y)
                y = -y
        End Select
    End Sub
    Sub dda(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal color As Color)
        Dim delta_x, delta_y, x, y As Single
        Dim k, real_x, real_y, i As Integer

        ' almacenar extremo izquierdo en x1, y1
        ordenar_coord(x1, y1, x2, y2)

        ' calcular delta_x, delta_y
        delta_y = y2 - y1
        delta_x = x2 - x1

        ' determinar el valor de k
        k = Math.Max(Math.Abs(delta_x), Math.Abs(delta_y))

        ' valor inicial
        x = x1
        y = y1

        ' colocar el pixel inicial
        real_x = x ' el valor de x
        real_y = y ' el valor de y
        coordenada_real(real_x, real_y) ' obtener coordenada
        BMP.SetPixel(real_x, real_y, color) ' poner pixel
        PictureBox1.Image = BMP

        For i = 0 To k - 1 Step 1
            ' calcular los incrementos de x, y
            x = x + delta_x / k
            y = y + delta_y / k

            ' convertir los valores de las coordenadas a las reales
            real_x = Math.Round(x, 0, MidpointRounding.AwayFromZero) ' redondar el valor de x
            real_y = Math.Round(y, 0, MidpointRounding.AwayFromZero) ' redondear el valor de y
            coordenada_real(real_x, real_y)
            ' colocar el pixel
            BMP.SetPixel(real_x, real_y, color)
            PictureBox1.Image = BMP
        Next
    End Sub
    Sub bresenham(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal color As Color)
        Dim m As Single
        Dim delta_x, delta_y, x, y, real_x, real_y, p, k, i, octante As Integer
        Dim formula1 As Integer ' 2*delta_y
        Dim formula2 As Integer ' 2*delta_y - 2*delta_x

        ' calcular la pendiente
        m = (y2 - y1) / (x2 - x1)

        ' obtener octante
        octante = obtener_octante(m, x1, x2, y1, y2)

        ' cambiar coordenadas a octante 0 de octante actual
        cambiarAOctanteCeroDe(octante, x1, y1)
        cambiarAOctanteCeroDe(octante, x2, y2)

        ' calcular delta_x, delta_y, 2*delta y, 2*delta y - 2*delta x
        delta_y = y2 - y1
        delta_x = x2 - x1
        formula1 = 2 * delta_y
        formula2 = 2 * delta_y - 2 * delta_x

        ' determinar el valor inicial de p = 2*delta y - delta x
        p = 2 * delta_y - delta_x

        ' determinar el valor de k
        k = Math.Max(Math.Abs(delta_x), Math.Abs(delta_y))

        ' valor inicial
        x = x1
        y = y1

        ' colocar el pixel inicial
        real_x = x ' el valor de x
        real_y = y ' el valor de y
        cambiarDeOctanteCeroA(octante, real_x, real_y) ' punto en el octante correspondiente
        coordenada_real(real_x, real_y) ' obtener coordenada
        BMP.SetPixel(real_x, real_y, color) ' poner pixel
        PictureBox1.Image = BMP

        For i = 0 To k - 1 Step 1
            If p < 0 Then ' Si p < 0 entonces (x + 1, y) y p = p + 2*delta_y
                x = x + 1
                p = p + formula1
            Else ' En caso contrario (x + 1, y + 1) y p = p + 2*delta_y - 2*delta_x
                x = x + 1
                y = y + 1
                p = p + formula2
            End If

            ' convertir los valores de las coordenadas a las reales

            ' 1. obtener valores
            real_x = x ' el valor de x
            real_y = y ' el valor de y

            ' 2. cambiar coordenada de octante 0 a octante actual
            cambiarDeOctanteCeroA(octante, real_x, real_y)

            ' 3. obtener la coordanada real
            coordenada_real(real_x, real_y)

            ' colocar el pixel
            BMP.SetPixel(real_x, real_y, color)
            PictureBox1.Image = BMP
        Next
    End Sub
    Sub putCirclePixel(ByVal x As Integer, ByVal y As Integer, ByVal x_c As Integer, ByVal y_c As Integer, ByVal color As Color)
        ' La funcion coloca el punto con simetria en todos los 8 octantes del circulo
        ' 1. Primero asigna a (x_real,y_real) los puntos de simetria para los otros siete octantes
        '    para el punto (x,y) suministrado el cual se encuentra en el octante 7
        ' 2. Mover cada posicion del pixel calculada con centro en el origen (0,0) a (x_c, y_c)
        '    Es decir, x = x + x_c y y = y + y_c
        ' 3. Obtener las coordenadas de la pantalla real
        ' 4. Poner el pixel

        Dim x_real, y_real As Integer
        ' octante 7
        x_real = x
        y_real = y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' octante 0
        x_real = y
        y_real = x
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' octante 1
        x_real = y
        y_real = -x
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' octante 2
        x_real = x
        y_real = -y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        'octante 3
        x_real = -x
        y_real = -y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' octante 4
        x_real = -y
        y_real = -x
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' octante 5
        x_real = -y
        y_real = x
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' octante 6
        x_real = -x
        y_real = y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP
    End Sub

    Sub circle(ByVal x_c As Integer, ByVal y_c As Integer, ByVal radius As Integer, ByVal color As Color)
        Dim p, x, y As Integer
        Try
            ' se obtiene el primer punto de la circunferencia centrada en el origen como (0,radius)
            x = 0
            y = radius

            ' coloca el pixel con simetria en todos los 8 octantes del circulo
            putCirclePixel(x, y, x_c, y_c, color)

            ' se calcula el valor inicial del parámetro de decision como p_0 = 1 - radius
            p = 1 - radius

            While x <= y ' repetir hasta x <= y
                If p < 0 Then ' si p es negativo
                    x += 1 ' siguiente punto es (x+1, y)
                    p = p + 2 * x + 1 ' p = p + 2x + 1
                Else ' si p es cero o positivo
                    ' (x+1, y-1)
                    x += 1
                    y -= 1
                    p = p + 2 * x + 1 - 2 * y ' p = p + 2x + 1 - 2y
                End If
                ' coloca el pixel con simetria en todos los 8 octantes del circulo
                putCirclePixel(x, y, x_c, y_c, color)
            End While
        Catch ex As Exception
            MsgBox("El radio excede el tamaño permitido en pantalla")
        End Try
    End Sub
    Sub putEllipsePixel(ByVal x As Integer, ByVal y As Integer, ByVal x_c As Integer, ByVal y_c As Integer, ByVal color As Color)
        ' La funcion coloca el punto con simetria en todos los 4 cuadrantes
        ' 1. Primero asigna a (x_real,y_real) los puntos de simetria para los otros tres cuadrantes
        '    para el punto (x,y) suministrado el cual se encuentra en el cuadrante 1
        ' 2. Mover cada posicion del pixel calculada con centro en el origen (0,0) a (x_c, y_c)
        '    Es decir, x = x + x_c y y = y + y_c
        ' 3. Obtener las coordenadas de la pantalla real
        ' 4. Poner el pixel

        Dim x_real, y_real As Integer

        ' cuadrante 1
        x_real = x
        y_real = y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' cuadrante 2
        x_real = x
        y_real = -y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' cuadrante 3
        x_real = -x
        y_real = -y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP

        ' cuadrante 4
        x_real = -x
        y_real = y
        x_real += x_c
        y_real += y_c
        coordenada_real(x_real, y_real)
        BMP.SetPixel(x_real, y_real, color)
        PictureBox1.Image = BMP
    End Sub
    Sub ellipse(ByVal x_c As Integer, ByVal y_c As Integer, ByVal r_x As Integer, ByVal r_y As Integer, ByVal color As Color)
        ' Obtener el primer punto sobre una elipse centrada en el origen
        Dim x, y As Integer
        Dim p1, p2 As Double
        Try
            x = 0
            y = r_y

            ' Coloca el primer pixel con simetria en los 4 cuadrantes
            putEllipsePixel(x, y, x_c, y_c, color)

            ' ----- Region 1 -----

            ' Calcular el valor inicial del parámetro de decisión en la región 1 mediante la fórmula
            p1 = r_y ^ 2 - r_x ^ 2 * r_y + 1 / 4 * r_x ^ 2

            ' Repetir hasta que 2 * r_y^2 * x >= 2 * r_x^2 * y

            While Not 2 * r_y ^ 2 * x >= 2 * r_x ^ 2 * y
                ' En cada posición x dentro de la región, si p1 < 0 el siguiente punto es
                ' (x + 1, y) y p1 = p1 + 2 * r_y^2 * x + r_y^2
                If p1 < 0 Then
                    x = x + 1
                    p1 = p1 + 2 * r_y ^ 2 * x + r_y ^ 2
                    ' Coloca el pixel con simetria en los 4 cuadrantes
                    putEllipsePixel(x, y, x_c, y_c, color)
                Else
                    ' en caso contrario el siguiente punto es (x + 1, y - 1)
                    ' p1 = p1 + 2 * r_y^2 * x - 2 * r_x^2 * y + r_y ^2
                    x = x + 1
                    y = y - 1
                    p1 = p1 + 2 * r_y ^ 2 * x - 2 * r_x ^ 2 * y + r_y ^ 2
                    ' Coloca el pixel con simetria en los 4 cuadrantes
                    putEllipsePixel(x, y, x_c, y_c, color)
                End If
            End While

            ' ----- Region 2 -----

            ' Calcular el valor inicial de parámetro de decisión en la región 2 mediante la fórmula
            ' los valores de x, y iniciales son la ultima posición calculada para la región 1
            p2 = r_y ^ 2 * (x + 1 / 2) ^ 2 + r_x ^ 2 * (y - 1) ^ 2 - r_x ^ 2 * r_y ^ 2

            ' Repetir hasta que y = 0

            While Not y = 0
                ' En cada posición y de la región 2, si p2 > 0 el siguiente punto es
                ' (x, y - 1) y p2 = p2 - 2 * r_x^2 * y + r_x^2
                If p2 > 0 Then
                    y = y - 1
                    p2 = p2 - 2 * r_x ^ 2 * y + r_x ^ 2
                    ' Coloca el pixel con simetria en los 4 cuadrantes
                    putEllipsePixel(x, y, x_c, y_c, color)
                Else
                    ' En caso contrario el siguiente punto es (x + 1, y - 1)
                    ' p2 = p2 + 2 * r_y^2 * x - 2 * r_x^2* y + r_x^2 
                    x = x + 1
                    y = y - 1
                    p2 = p2 + 2 * r_y ^ 2 * x - 2 * r_x ^ 2 * y + r_x ^ 2
                    ' Coloca el pixel con simetria en los 4 cuadrantes
                    putEllipsePixel(x, y, x_c, y_c, color)
                End If
            End While
        Catch ex As Exception
            MsgBox("El radio excede el tamaño permitido en pantalla")
        End Try
    End Sub
    
    Function max_arraylist(ByVal list As ArrayList)
        Dim max As Integer = 0
        For Each i In list
            If max < i Then
                max = i
            End If
        Next
        Return max
    End Function
    Function min_arraylist(ByVal list As ArrayList)
        Dim max As Integer = 0
        For Each i In list
            If max > i Then
                max = i
            End If
        Next
        Return max
    End Function
    Sub relleno_rectangulo(ByVal color As Color)
        Dim y_max, y_min, x_max, x_min, y, x, x_real, y_real As Integer
        y_max = max_arraylist(y_points)
        y_min = min_arraylist(y_points)
        x_max = max_arraylist(x_points)
        x_min = min_arraylist(x_points)
        For y = y_min To y_max + 1
            For x = x_min To x_max + 1
                x_real = x
                y_real = y
                coordenada_real(x_real, y_real)
                BMP.SetPixel(x_real, y_real, color)
            Next
        Next
    End Sub
    Sub polygon(ByVal color As Color, ByVal rellenar As Boolean)
        Dim i As Integer
        For i = 0 To x_points.Count - 2
            ' linea entre cada par de juego de puntos (x,y)
            bresenham(x_points(i), y_points(i), x_points(i + 1), y_points(i + 1), color)
        Next
        ' linea entre el último y el primer juego de puntos (x,y)
        bresenham(x_points(x_points.Count - 1), y_points(y_points.Count - 1), x_points(0), y_points(0), color)

        If rellenar Then
            rellenar_poligono(color)
        End If
    End Sub
    Sub rellenar_poligono(ByVal color As Color)
        ' RELLENO DEL POLIGONO
        Dim real_x_points, real_y_points As New ArrayList
        ' Duplicar lista de vertices x, y
        For i = 0 To x_points.Count - 1
            real_x_points.Add(x_points(i))
            real_y_points.Add(y_points(i))
        Next
        ' Convertir todos los puntos x, y a las coordenadas reales de la pantalla de Visual Basic
        For i = 0 To x_points.Count - 1
            coordenada_real(real_x_points(i), real_y_points(i))
        Next
        ' rellenar tabla TA
        fillTA(TA, real_x_points, real_y_points)
        ' crear tabla TAA y rellenar 
        polyfill(TA, color, BMP)
    End Sub
    Sub floodfill(ByVal _x As Integer, ByVal _y As Integer, ByVal old_color As Color, ByVal new_color As Color)
        Dim coord As Coordenada
        Dim x, y As Integer
        ' Si ambos colores son iguales Return.
        If old_color.ToArgb() = new_color.ToArgb() Then
            Return
        End If
        btnDibujar.Enabled = False
        Dim cola As New Queue(Of Coordenada)
        cola.Enqueue(New Coordenada(_x, _y))
        While cola.Count <> 0
            coord = cola.Dequeue()
            x = coord.getx()
            y = coord.gety()
            If BMP.GetPixel(x, y).ToArgb() = old_color.ToArgb() Then
                If x + 1 <= BMP.Width - 1 And y + 1 <= BMP.Height - 1 And x - 1 >= 0 And y - 1 >= 0 Then
                    BMP.SetPixel(x, y, new_color)
                    cola.Enqueue(New Coordenada(x, y + 1))
                    cola.Enqueue(New Coordenada(x, y - 1))
                    cola.Enqueue(New Coordenada(x + 1, y))
                    cola.Enqueue(New Coordenada(x - 1, y))
                End If
            End If
        End While
        PictureBox1.Image = BMP
        btnDibujar.Enabled = True
    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GFX.FillRectangle(Brushes.Black, 0, 0, BMP.Width, BMP.Height)
        GFX2.FillRectangle(Brushes.Transparent, 0, 0, BMP2.Width, BMP2.Height)
        GFX2.DrawLine(Pens.White, CInt(BMP2.Width / 2), 0, CInt(BMP2.Width / 2), BMP2.Height)
        GFX2.DrawLine(Pens.White, 0, CInt(BMP2.Height / 2) - 1, BMP2.Width, CInt(BMP2.Height / 2) - 1)
        PictureBox1.Image = BMP
        PictureBox2.Parent = PictureBox1
        PictureBox2.BackColor = Drawing.Color.Transparent
        PictureBox2.Location = New Point(PictureBox2.Left - PictureBox1.Left, PictureBox2.Top - PictureBox1.Top)
        PictureBox2.Image = BMP2
    End Sub

    Private Sub btnBorrarDibujo_Click(sender As Object, e As EventArgs) Handles btnBorrarDibujo.Click
        GFX.FillRectangle(Brushes.Black, 0, 0, BMP.Width, BMP.Height)
        PictureBox1.Image = BMP
    End Sub

    Private Sub AlgoritmoDDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDDA.Click
        elegido = "DDA"
        btnDibujar.Text = "Dibujar"
        lblRadio1.Visible = False
        lblRadio2.Visible = False
        lblIngCoord.Visible = True
        lblX1.Text = "X1"
        lblY1.Text = "Y1"
        lblIngCoord.Text = "Ingrese las coordenadas de la línea a dibujar con DDA:"
        lblX1.Visible = True
        lblX2.Visible = True
        lblY1.Visible = True
        lblY2.Visible = True
        nmuX1.Visible = True
        nmuX2.Visible = True
        nmuY1.Visible = True
        nmuY2.Visible = True
        nmuRadio1.Visible = False
        nmuRadio2.Visible = False
        lblColor.Visible = True
        cboColor.Visible = True
        btnBorrarDibujo.Visible = True
        btnDibujar.Visible = True
        btnEsconder.Visible = True
        btnAgregar.Visible = False
        btnLimpiar.Visible = False
        lstPuntos.Visible = False
        chkRellenarFigura.Visible = False
    End Sub

    Private Sub AlgoritmoBresenhamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsBresenham.Click
        elegido = "Bresenham"
        btnDibujar.Text = "Dibujar"
        lblRadio1.Visible = False
        lblRadio2.Visible = False
        lblIngCoord.Visible = True
        lblX1.Text = "X1"
        lblY1.Text = "Y1"
        lblIngCoord.Text = "Ingrese las coordenadas de la línea a dibujar con Bresenham:"
        lblX1.Visible = True
        lblX2.Visible = True
        lblY1.Visible = True
        lblY2.Visible = True
        nmuX1.Visible = True
        nmuX2.Visible = True
        nmuY1.Visible = True
        nmuY2.Visible = True
        nmuRadio1.Visible = False
        nmuRadio2.Visible = False
        lblColor.Visible = True
        cboColor.Visible = True
        btnBorrarDibujo.Visible = True
        btnDibujar.Visible = True
        btnEsconder.Visible = True
        btnAgregar.Visible = False
        btnLimpiar.Visible = False
        lstPuntos.Visible = False
        chkRellenarFigura.Visible = False
    End Sub
    Private Sub tsCirculo_Click(sender As Object, e As EventArgs) Handles tsCirculo.Click
        elegido = "Circle"
        btnDibujar.Text = "Dibujar"
        lblRadio1.Visible = True
        lblRadio1.Text = "Radio"
        lblRadio2.Visible = False
        lblX1.Text = "X"
        lblY1.Text = "Y"
        lblIngCoord.Visible = True
        lblIngCoord.Text = "Ingrese las coordenadas del centro de la circunferencia a dibujar:"
        lblX1.Visible = True
        lblX2.Visible = False
        lblY1.Visible = True
        lblY2.Visible = False
        nmuX1.Visible = True
        nmuX2.Visible = False
        nmuY1.Visible = True
        nmuY2.Visible = False
        nmuRadio1.Visible = True
        nmuRadio2.Visible = False
        lblColor.Visible = True
        cboColor.Visible = True
        btnBorrarDibujo.Visible = True
        btnDibujar.Visible = True
        btnEsconder.Visible = True
        btnAgregar.Visible = False
        btnLimpiar.Visible = False
        lstPuntos.Visible = False
        chkRellenarFigura.Visible = False
    End Sub
    Private Sub tsElipse_Click(sender As Object, e As EventArgs) Handles tsElipse.Click
        elegido = "Ellipse"
        btnDibujar.Text = "Dibujar"
        lblRadio1.Visible = True
        lblRadio2.Visible = True
        lblRadio1.Text = "Radio1"
        lblX1.Text = "X"
        lblY1.Text = "Y"
        lblIngCoord.Visible = True
        lblIngCoord.Text = "Ingrese las coordenadas del centro de la elipse a dibujar:"
        lblX1.Visible = True
        lblX2.Visible = False
        lblY1.Visible = True
        lblY2.Visible = False
        nmuX1.Visible = True
        nmuX2.Visible = False
        nmuY1.Visible = True
        nmuY2.Visible = False
        nmuRadio1.Visible = True
        nmuRadio2.Visible = True
        lblColor.Visible = True
        cboColor.Visible = True
        btnBorrarDibujo.Visible = True
        btnDibujar.Visible = True
        btnEsconder.Visible = True
        btnAgregar.Visible = False
        btnLimpiar.Visible = False
        lstPuntos.Visible = False
        chkRellenarFigura.Visible = False
    End Sub
    Sub colorCode(ByRef color As Color, ByVal value As Integer)
        Select Case value
            Case 0
                color = color.White
            Case 1
                color = color.Gray
            Case 2
                color = color.Red
            Case 3
                color = color.Pink
            Case 4
                color = color.Orange
            Case 5
                color = color.Yellow
            Case 6
                color = color.Green
            Case 7
                color = color.SkyBlue
            Case 8
                color = color.Cyan
            Case 9
                color = color.Blue
            Case 10
                color = color.Violet
            Case 11
                color = color.Black
            Case Else
                color = color.White
        End Select
    End Sub
    Private Sub btnDibujar_Click(sender As Object, e As EventArgs) Handles btnDibujar.Click
        Dim color As Color
        ' Determinar el color
        colorCode(color, cboColor.SelectedIndex)
        If elegido = "DDA" Then
            dda(nmuX1.Value, nmuY1.Value, nmuX2.Value, nmuY2.Value, color)
        ElseIf elegido = "Bresenham" Then
            bresenham(nmuX1.Value, nmuY1.Value, nmuX2.Value, nmuY2.Value, color)
        ElseIf elegido = "Circle" Then
            circle(nmuX1.Value, nmuY1.Value, nmuRadio1.Value, color)
        ElseIf elegido = "Ellipse" Then
            ellipse(nmuX1.Value, nmuY1.Value, nmuRadio1.Value, nmuRadio2.Value, color)
        ElseIf elegido = "Polygon" Then
            ' Validar que ingrese por lo menos 3 puntos
            If lstPuntos.Items.Count >= 3 Then
                polygon(color, chkRellenarFigura.Checked)
            Else
                MsgBox("Debe ingresar por lo menos 3 puntos.")
            End If
        ElseIf elegido = "Fill" Then
            ' Obtener las coordenadas reales de la pantalla para hacer el relleno
            Dim x, y As Integer
            x = nmuX1.Value
            y = nmuY1.Value
            coordenada_real(x, y)
            floodfill(x, y, BMP.GetPixel(x, y), color)
        End If
        ' Reiniciar valores de campos de lectura de valores
        nmuX1.Value = 0
        nmuX2.Value = 0
        nmuY1.Value = 0
        nmuY2.Value = 0
        nmuRadio1.Value = 1
        nmuRadio2.Value = 1

    End Sub

    Private Sub tsPoligono_Click(sender As Object, e As EventArgs) Handles tsPoligono.Click
        elegido = "Polygon"
        btnDibujar.Text = "Dibujar"
        x_points.Clear()
        y_points.Clear()
        lstPuntos.Items.Clear()
        lblRadio1.Visible = False
        lblRadio2.Visible = False
        lblIngCoord.Visible = True
        lblX1.Text = "X"
        lblY1.Text = "Y"
        lblIngCoord.Text = "Ingrese las coordenadas de los puntos del polígono:"
        lblX1.Visible = True
        lblX2.Visible = False
        lblY1.Visible = True
        lblY2.Visible = False
        nmuX1.Visible = True
        nmuX2.Visible = False
        nmuY1.Visible = True
        nmuY2.Visible = False
        nmuRadio1.Visible = False
        nmuRadio2.Visible = False
        lblColor.Visible = True
        cboColor.Visible = True
        btnBorrarDibujo.Visible = True
        btnDibujar.Visible = True
        btnEsconder.Visible = True
        btnAgregar.Visible = True
        btnLimpiar.Visible = True
        lstPuntos.Visible = True
        chkRellenarFigura.Visible = True
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        x_points.Add(nmuX1.Value)
        y_points.Add(nmuY1.Value)
        lstPuntos.Items.Add(nmuX1.Value & ", " & nmuY1.Value)
        lstPuntos.SelectedIndex += 1
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        x_points.Clear()
        y_points.Clear()
        lstPuntos.Items.Clear()
    End Sub

    Private Sub tsRelleno_Click(sender As Object, e As EventArgs) Handles tsRelleno.Click
        elegido = "Fill"
        btnDibujar.Text = "Rellenar"
        lblRadio1.Visible = False
        lblRadio2.Visible = False
        lblX1.Text = "X"
        lblY1.Text = "Y"
        lblIngCoord.Visible = True
        lblIngCoord.Text = "Ingrese la coordenada del punto de relleno:"
        lblX1.Visible = True
        lblX2.Visible = False
        lblY1.Visible = True
        lblY2.Visible = False
        nmuX1.Visible = True
        nmuX2.Visible = False
        nmuY1.Visible = True
        nmuY2.Visible = False
        nmuRadio1.Visible = False
        nmuRadio2.Visible = False
        lblColor.Visible = True
        cboColor.Visible = True
        btnBorrarDibujo.Visible = True
        btnDibujar.Visible = True
        btnEsconder.Visible = True
        btnAgregar.Visible = False
        btnLimpiar.Visible = False
        lstPuntos.Visible = False
        chkRellenarFigura.Visible = False
    End Sub

    Private Sub btnEsconder_Click(sender As Object, e As EventArgs) Handles btnEsconder.Click
        If PictureBox2.Visible Then
            PictureBox2.Visible = False
            btnEsconder.Text = "Mostrar Ejes"
        Else
            PictureBox2.Visible = True
            btnEsconder.Text = "Esconder Ejes"
        End If
    End Sub
End Class
Class Coordenada
    Dim x As Integer
    Dim y As Integer
    'Constructor
    Public Sub New(ByVal _x As Integer, ByVal _y As Integer)
        x = _x
        y = _y
    End Sub
    Function getx()
        Return x
    End Function
    Function gety()
        Return y
    End Function
End Class

Public Class TA_node
    Public y_max As Integer
    Public x_min As Single
    Public m_numerator As Integer
    Public m_denominator As Integer
    Public y_min As Integer
    Public nextTA As TA_node
    'Constructor
    Sub New(ByVal _y_max As Integer, _x_min As Integer, _m_numerator As Integer, _m_denominator As Integer, _y_min As Integer)
        y_max = _y_max
        y_min = _y_min
        x_min = _x_min
        m_numerator = _m_numerator
        m_denominator = _m_denominator
        nextTA = Nothing
    End Sub

    Function inverse_m() As Single
        Return Convert.ToSingle(m_denominator) / m_numerator
    End Function
End Class

Class TA_list
    Dim list As New ArrayList
    ' Constructor
    Sub New()
        Dim i As Integer
        For i = 0 To BMP.height - 1
            list.Add(Nothing)
        Next
    End Sub

    Sub add(ByVal scanline As Integer, ByRef node As TA_node)
        Dim actualnode As TA_node
        If list(scanline) Is Nothing Then
            list(scanline) = node
        Else
            actualnode = list(scanline)
            While Not actualnode.nextTA Is Nothing
                actualnode = actualnode.nextTA
            End While
            actualnode.nextTA = node
            node.nextTA = Nothing
        End If
    End Sub

    Sub delete(ByVal scanline As Integer, ByRef node As TA_node)
        Dim prevnode As TA_node = Nothing
        Dim currnode As TA_node = list(scanline)

        If Not currnode Is Nothing Then 'if the node is not null
            While Not currnode.nextTA Is Nothing 'while currnode is not the last node
                If currnode Is node Then
                    If prevnode Is Nothing Then ' if currnode is first
                        If Not currnode.nextTA Is Nothing Then 'if the first node is not last node
                            list(scanline) = currnode.nextTA
                        End If
                    Else 'if is a middle node
                        prevnode.nextTA = currnode.nextTA
                    End If
                End If
                prevnode = currnode
                currnode = currnode.nextTA
            End While
            'when its last node
            If currnode Is node And currnode.nextTA Is Nothing Then
                If prevnode Is Nothing Then 'if it is the first node
                    list(scanline) = Nothing
                Else
                    prevnode.nextTA = Nothing
                End If
            End If
        End If
    End Sub

    Function first_y() As Integer
        Dim i As Integer
        Dim item As TA_Node
        For i = 0 To list.Count - 1
            item = list(i)
            If Not item Is Nothing Then
                Return i
            End If
        Next
        Return 0
    End Function

    Function isEmpty() As Boolean
        Dim item As TA_Node
        For Each item In list
            If Not item Is Nothing Then
                Return False
            End If
        Next
        Return True
    End Function

    Function getList() As Arraylist
        Return list
    End Function

    Sub printScanLine(ByVal scanline As Integer)
        Dim node As TA_Node = list(scanline)
        If Not node Is Nothing Then
            While Not node.nextTA Is Nothing
                Console.Write(node.y_max & node.x_min & node.inverse_m & node.y_min & " | ")
                node = node.nextTA
            End While
            Console.Write(node.y_max & node.x_min & node.inverse_m & node.y_min & " | ")
        Else
            Console.Write("Nothing")
        End If
        Console.Write(vbCrLf)
    End Sub
End Class

Module ModTA
    Public BMP As New Drawing.Bitmap(640, 480)
    Public BMP2 As New Drawing.Bitmap(640, 480)
    Public TA As New TA_list()
    Public x_points As New ArrayList()
    Public y_points As New ArrayList()
    Sub fillTA(ByRef TA As TA_list, ByVal x_points As ArrayList, ByVal y_points As ArrayList)
        ' for each line in scanline
        Dim scanline As Integer
        Dim i As Integer
        Dim k As Integer
        For scanline = 0 To BMP.height - 1
            ' if the y coordinate of the edge is on the scanline
            For i = 0 To y_points.Count - 1
                If scanline = y_points(i) Then
                    'find connecting point on the left
                    k = modulo((i - 1), y_points.Count)
                    ' if the y coordinate of that point is greater
                    If y_points(k) > y_points(i) Then
                        ' Add the node with max(current-edge-y, left-connecting-y), current-edge-x, slope numerator and denominator in that scanline
                        TA.add(scanline, New TA_node(Math.Max(y_points(i), y_points(k)), x_points(i), y_points(i) - y_points(k), x_points(i) - x_points(k), Math.Min(y_points(i), y_points(k))))
                    End If

                    'find connecting point on the right
                    k = modulo((i + 1), y_points.Count)
                    ' if the y coordinate of that point is greater
                    If y_points(k) > y_points(i) Then
                        ' Add the node with max(current-edge-y, right-connecting-y), current-edge-x, slope numerator and denominator in that scanline
                        TA.add(scanline, New TA_node(Math.Max(y_points(i), y_points(k)), x_points(i), y_points(i) - y_points(k), x_points(i) - x_points(k), Math.Min(y_points(i), y_points(k))))
                    End If
                End If
            Next
        Next
    End Sub

    Sub bubblesort(ByRef alist As ArrayList)
        Dim passnum As Integer
        Dim i As Integer
        Dim temp As TA_node
        For passnum = alist.Count - 1 To 0 Step -1
            For i = 0 To passnum - 1
                If alist(i).x_min > alist(i + 1).x_min Then
                    temp = alist(i)
                    alist(i) = alist(i + 1)
                    alist(i + 1) = temp
                End If
            Next
        Next
    End Sub

    Public Function modulo(ByVal x As Integer, ByVal y As Integer) As Integer
        Return x - y * Math.Floor(x / y)

    End Function

    Sub polyfill(ByRef TA As TA_list, ByVal color As Color, ByRef BMP As Bitmap)
        Dim y As Integer
        Dim lista_TA As New ArrayList
        Dim i As Integer
        Dim item As TA_node
        Dim node As TA_node
        '1. Poner y al valor mas pequeño de la coordenada y que esté en la TA (primera cubeta no vacía)
        y = TA.first_y()

        '2. Inicializar la TAA a vacío
        Dim TAA As New ArrayList

        '3. Reperir hasta que la TAA y TA estén vacios
        While Not (TAA.Count = 0 And TA.isEmpty())
            'a) Mover de la cubeta TA y a la TAA aquellas aristas cuya y_min = y (aristas de entrada)
            lista_TA = TA.getList()
            For i = y To lista_TA.Count - 1
                item = lista_TA(i)
                If Not item Is Nothing Then
                    node = item
                    While Not node.nextTA Is Nothing
                        If node.y_min = y Then
                            TAA.Add(node)
                            TA.delete(i, node)
                        End If
                        node = node.nextTA
                    End While
                    If node.y_min = y Then
                        TAA.Add(node)
                        TA.delete(i, node)
                    End If
                End If
            Next

            ' b) Quitar de la TAA aquellas entradas para las cuales y = y_max (las aristas no involucrados 
            '    en la siguiente línea de escaneo), entonces se ordena la TAA en x
            Dim removeList As New ArrayList
            For Each node In TAA
                If y = node.y_max Then
                    removeList.Add(node)
                End If
            Next

            For Each node In removeList
                TAA.Remove(node)
            Next

            ' ordenamiento con burbuja
            bubblesort(TAA)

            ' c) Rellenar los pixeles deseados sobre la línea de escaneo y usando pares de coordenadas x de la TAA
            i = 0
            Dim x, x1, x2 As Integer
            For Each node In TAA
                If i Mod 2 = 0 Then
                    'MsgBox("(" & (Math.Ceiling(node.x_min)) & ", " & y & ") ")
                    x1 = Math.Ceiling(node.x_min)
                Else
                    'MsgBox("(" & (Math.Floor(node.x_min)) & ", " & y & ") ")
                    x2 = Math.Floor(node.x_min)
                    For x = x1 To x2
                        BMP.SetPixel(x, y, color)
                    Next
                End If
                i = i + 1
            Next
            Console.Write(vbCrLf)

            ' d) Incrementa y en 1 (siguiente linea de escaneo)
            y = y + 1

            ' e) Para cada arista no vertical que puede en la TAA, poner al día x para la nueva y
            For Each node In TAA
                node.x_min = node.x_min + node.inverse_m()
            Next
        End While
    End Sub

    Sub printTA(ByRef TA As TA_list)
        Console.Write(" --- TA ---")
        Dim i As Integer
        For i = 0 To TA.getList().Count - 1
            TA.printScanLine(i)
        Next
    End Sub

    Sub coordenada_real(ByRef x As Integer, ByRef y As Integer)
        x = x + 320
        y = 240 - y - 1
    End Sub

End Module

