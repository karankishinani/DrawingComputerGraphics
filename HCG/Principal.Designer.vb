<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnBorrarDibujo = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsLinea = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsDDA = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsBresenham = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCirculo = New System.Windows.Forms.ToolStripButton()
        Me.tsElipse = New System.Windows.Forms.ToolStripButton()
        Me.tsPoligono = New System.Windows.Forms.ToolStripButton()
        Me.tsRelleno = New System.Windows.Forms.ToolStripButton()
        Me.cboColor = New System.Windows.Forms.ComboBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.lblIngCoord = New System.Windows.Forms.Label()
        Me.lblX1 = New System.Windows.Forms.Label()
        Me.lblX2 = New System.Windows.Forms.Label()
        Me.lblY2 = New System.Windows.Forms.Label()
        Me.lblY1 = New System.Windows.Forms.Label()
        Me.btnDibujar = New System.Windows.Forms.Button()
        Me.nmuX1 = New System.Windows.Forms.NumericUpDown()
        Me.nmuX2 = New System.Windows.Forms.NumericUpDown()
        Me.nmuY2 = New System.Windows.Forms.NumericUpDown()
        Me.nmuY1 = New System.Windows.Forms.NumericUpDown()
        Me.lblRadio1 = New System.Windows.Forms.Label()
        Me.lblRadio2 = New System.Windows.Forms.Label()
        Me.nmuRadio1 = New System.Windows.Forms.NumericUpDown()
        Me.nmuRadio2 = New System.Windows.Forms.NumericUpDown()
        Me.lstPuntos = New System.Windows.Forms.ListBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.chkRellenarFigura = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnEsconder = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.nmuX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmuX2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmuY2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmuY1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmuRadio1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmuRadio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(19, 145)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(640, 480)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnBorrarDibujo
        '
        Me.btnBorrarDibujo.Location = New System.Drawing.Point(576, 118)
        Me.btnBorrarDibujo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBorrarDibujo.Name = "btnBorrarDibujo"
        Me.btnBorrarDibujo.Size = New System.Drawing.Size(83, 23)
        Me.btnBorrarDibujo.TabIndex = 2
        Me.btnBorrarDibujo.Text = "Borrar Dibujo"
        Me.btnBorrarDibujo.UseVisualStyleBackColor = True
        Me.btnBorrarDibujo.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLinea, Me.tsCirculo, Me.tsElipse, Me.tsPoligono, Me.tsRelleno})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.Size = New System.Drawing.Size(677, 39)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsLinea
        '
        Me.tsLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsLinea.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDDA, Me.tsBresenham})
        Me.tsLinea.Image = CType(resources.GetObject("tsLinea.Image"), System.Drawing.Image)
        Me.tsLinea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLinea.Name = "tsLinea"
        Me.tsLinea.Size = New System.Drawing.Size(45, 36)
        Me.tsLinea.Text = "Linea"
        '
        'tsDDA
        '
        Me.tsDDA.Name = "tsDDA"
        Me.tsDDA.Size = New System.Drawing.Size(190, 22)
        Me.tsDDA.Text = "Algoritmo DDA"
        '
        'tsBresenham
        '
        Me.tsBresenham.Name = "tsBresenham"
        Me.tsBresenham.Size = New System.Drawing.Size(190, 22)
        Me.tsBresenham.Text = "Algoritmo Bresenham"
        '
        'tsCirculo
        '
        Me.tsCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsCirculo.Image = CType(resources.GetObject("tsCirculo.Image"), System.Drawing.Image)
        Me.tsCirculo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCirculo.Name = "tsCirculo"
        Me.tsCirculo.Size = New System.Drawing.Size(36, 36)
        Me.tsCirculo.Text = "Circunferencia"
        '
        'tsElipse
        '
        Me.tsElipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsElipse.Image = CType(resources.GetObject("tsElipse.Image"), System.Drawing.Image)
        Me.tsElipse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsElipse.Name = "tsElipse"
        Me.tsElipse.Size = New System.Drawing.Size(36, 36)
        Me.tsElipse.Text = "Elipse"
        '
        'tsPoligono
        '
        Me.tsPoligono.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPoligono.Image = CType(resources.GetObject("tsPoligono.Image"), System.Drawing.Image)
        Me.tsPoligono.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPoligono.Name = "tsPoligono"
        Me.tsPoligono.Size = New System.Drawing.Size(36, 36)
        Me.tsPoligono.Text = "Poligono"
        '
        'tsRelleno
        '
        Me.tsRelleno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRelleno.Image = CType(resources.GetObject("tsRelleno.Image"), System.Drawing.Image)
        Me.tsRelleno.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRelleno.Name = "tsRelleno"
        Me.tsRelleno.Size = New System.Drawing.Size(36, 36)
        Me.tsRelleno.Text = "Relleno"
        '
        'cboColor
        '
        Me.cboColor.FormattingEnabled = True
        Me.cboColor.Items.AddRange(New Object() {"Blanco", "Gris", "Rojo", "Rosado", "Naranja", "Amarillo", "Verde", "Celeste", "Cyan", "Azul", "Violeta", "Negro"})
        Me.cboColor.Location = New System.Drawing.Point(384, 63)
        Me.cboColor.Margin = New System.Windows.Forms.Padding(2)
        Me.cboColor.Name = "cboColor"
        Me.cboColor.Size = New System.Drawing.Size(94, 21)
        Me.cboColor.TabIndex = 4
        Me.cboColor.Text = "Blanco"
        Me.cboColor.Visible = False
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(334, 66)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(34, 13)
        Me.lblColor.TabIndex = 5
        Me.lblColor.Text = "Color:"
        Me.lblColor.Visible = False
        '
        'lblIngCoord
        '
        Me.lblIngCoord.AutoSize = True
        Me.lblIngCoord.Location = New System.Drawing.Point(12, 44)
        Me.lblIngCoord.Name = "lblIngCoord"
        Me.lblIngCoord.Size = New System.Drawing.Size(126, 13)
        Me.lblIngCoord.TabIndex = 10
        Me.lblIngCoord.Text = "Ingrese las coordenadas:"
        Me.lblIngCoord.Visible = False
        '
        'lblX1
        '
        Me.lblX1.AutoSize = True
        Me.lblX1.Location = New System.Drawing.Point(12, 66)
        Me.lblX1.Name = "lblX1"
        Me.lblX1.Size = New System.Drawing.Size(20, 13)
        Me.lblX1.TabIndex = 11
        Me.lblX1.Text = "X1"
        Me.lblX1.Visible = False
        '
        'lblX2
        '
        Me.lblX2.AutoSize = True
        Me.lblX2.Location = New System.Drawing.Point(12, 92)
        Me.lblX2.Name = "lblX2"
        Me.lblX2.Size = New System.Drawing.Size(20, 13)
        Me.lblX2.TabIndex = 13
        Me.lblX2.Text = "X2"
        Me.lblX2.Visible = False
        '
        'lblY2
        '
        Me.lblY2.AutoSize = True
        Me.lblY2.Location = New System.Drawing.Point(166, 92)
        Me.lblY2.Name = "lblY2"
        Me.lblY2.Size = New System.Drawing.Size(20, 13)
        Me.lblY2.TabIndex = 17
        Me.lblY2.Text = "Y2"
        Me.lblY2.Visible = False
        '
        'lblY1
        '
        Me.lblY1.AutoSize = True
        Me.lblY1.Location = New System.Drawing.Point(166, 66)
        Me.lblY1.Name = "lblY1"
        Me.lblY1.Size = New System.Drawing.Size(20, 13)
        Me.lblY1.TabIndex = 15
        Me.lblY1.Text = "Y1"
        Me.lblY1.Visible = False
        '
        'btnDibujar
        '
        Me.btnDibujar.Location = New System.Drawing.Point(405, 118)
        Me.btnDibujar.Name = "btnDibujar"
        Me.btnDibujar.Size = New System.Drawing.Size(75, 23)
        Me.btnDibujar.TabIndex = 18
        Me.btnDibujar.Text = "Dibujar"
        Me.btnDibujar.UseVisualStyleBackColor = True
        Me.btnDibujar.Visible = False
        '
        'nmuX1
        '
        Me.nmuX1.Location = New System.Drawing.Point(58, 64)
        Me.nmuX1.Maximum = New Decimal(New Integer() {319, 0, 0, 0})
        Me.nmuX1.Minimum = New Decimal(New Integer() {320, 0, 0, -2147483648})
        Me.nmuX1.Name = "nmuX1"
        Me.nmuX1.Size = New System.Drawing.Size(99, 20)
        Me.nmuX1.TabIndex = 19
        Me.nmuX1.Visible = False
        '
        'nmuX2
        '
        Me.nmuX2.Location = New System.Drawing.Point(58, 90)
        Me.nmuX2.Maximum = New Decimal(New Integer() {319, 0, 0, 0})
        Me.nmuX2.Minimum = New Decimal(New Integer() {320, 0, 0, -2147483648})
        Me.nmuX2.Name = "nmuX2"
        Me.nmuX2.Size = New System.Drawing.Size(99, 20)
        Me.nmuX2.TabIndex = 20
        Me.nmuX2.Visible = False
        '
        'nmuY2
        '
        Me.nmuY2.Location = New System.Drawing.Point(212, 90)
        Me.nmuY2.Maximum = New Decimal(New Integer() {239, 0, 0, 0})
        Me.nmuY2.Minimum = New Decimal(New Integer() {240, 0, 0, -2147483648})
        Me.nmuY2.Name = "nmuY2"
        Me.nmuY2.Size = New System.Drawing.Size(99, 20)
        Me.nmuY2.TabIndex = 22
        Me.nmuY2.Visible = False
        '
        'nmuY1
        '
        Me.nmuY1.Location = New System.Drawing.Point(212, 64)
        Me.nmuY1.Maximum = New Decimal(New Integer() {239, 0, 0, 0})
        Me.nmuY1.Minimum = New Decimal(New Integer() {240, 0, 0, -2147483648})
        Me.nmuY1.Name = "nmuY1"
        Me.nmuY1.Size = New System.Drawing.Size(99, 20)
        Me.nmuY1.TabIndex = 21
        Me.nmuY1.Visible = False
        '
        'lblRadio1
        '
        Me.lblRadio1.AutoSize = True
        Me.lblRadio1.Location = New System.Drawing.Point(12, 92)
        Me.lblRadio1.Name = "lblRadio1"
        Me.lblRadio1.Size = New System.Drawing.Size(41, 13)
        Me.lblRadio1.TabIndex = 23
        Me.lblRadio1.Text = "Radio1"
        Me.lblRadio1.Visible = False
        '
        'lblRadio2
        '
        Me.lblRadio2.AutoSize = True
        Me.lblRadio2.Location = New System.Drawing.Point(166, 92)
        Me.lblRadio2.Name = "lblRadio2"
        Me.lblRadio2.Size = New System.Drawing.Size(41, 13)
        Me.lblRadio2.TabIndex = 24
        Me.lblRadio2.Text = "Radio2"
        Me.lblRadio2.Visible = False
        '
        'nmuRadio1
        '
        Me.nmuRadio1.Location = New System.Drawing.Point(58, 90)
        Me.nmuRadio1.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.nmuRadio1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmuRadio1.Name = "nmuRadio1"
        Me.nmuRadio1.Size = New System.Drawing.Size(99, 20)
        Me.nmuRadio1.TabIndex = 25
        Me.nmuRadio1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmuRadio1.Visible = False
        '
        'nmuRadio2
        '
        Me.nmuRadio2.Location = New System.Drawing.Point(212, 90)
        Me.nmuRadio2.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.nmuRadio2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmuRadio2.Name = "nmuRadio2"
        Me.nmuRadio2.Size = New System.Drawing.Size(99, 20)
        Me.nmuRadio2.TabIndex = 26
        Me.nmuRadio2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmuRadio2.Visible = False
        '
        'lstPuntos
        '
        Me.lstPuntos.FormattingEnabled = True
        Me.lstPuntos.Location = New System.Drawing.Point(515, 12)
        Me.lstPuntos.Name = "lstPuntos"
        Me.lstPuntos.Size = New System.Drawing.Size(120, 95)
        Me.lstPuntos.TabIndex = 27
        Me.lstPuntos.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(67, 101)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(102, 23)
        Me.btnAgregar.TabIndex = 28
        Me.btnAgregar.Text = "Agregar Punto"
        Me.btnAgregar.UseVisualStyleBackColor = True
        Me.btnAgregar.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(175, 101)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 23)
        Me.btnLimpiar.TabIndex = 29
        Me.btnLimpiar.Text = "Limpiar Puntos"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
        '
        'chkRellenarFigura
        '
        Me.chkRellenarFigura.AutoSize = True
        Me.chkRellenarFigura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRellenarFigura.Location = New System.Drawing.Point(337, 90)
        Me.chkRellenarFigura.Name = "chkRellenarFigura"
        Me.chkRellenarFigura.Size = New System.Drawing.Size(136, 24)
        Me.chkRellenarFigura.TabIndex = 30
        Me.chkRellenarFigura.Text = "Rellenar Figura"
        Me.chkRellenarFigura.UseVisualStyleBackColor = True
        Me.chkRellenarFigura.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Location = New System.Drawing.Point(19, 145)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(640, 480)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 31
        Me.PictureBox2.TabStop = False
        '
        'btnEsconder
        '
        Me.btnEsconder.Location = New System.Drawing.Point(482, 118)
        Me.btnEsconder.Name = "btnEsconder"
        Me.btnEsconder.Size = New System.Drawing.Size(92, 23)
        Me.btnEsconder.TabIndex = 32
        Me.btnEsconder.Text = "Esconder Ejes"
        Me.btnEsconder.UseVisualStyleBackColor = True
        Me.btnEsconder.Visible = False
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 636)
        Me.Controls.Add(Me.btnEsconder)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.chkRellenarFigura)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lstPuntos)
        Me.Controls.Add(Me.nmuRadio2)
        Me.Controls.Add(Me.nmuRadio1)
        Me.Controls.Add(Me.lblRadio2)
        Me.Controls.Add(Me.lblRadio1)
        Me.Controls.Add(Me.nmuY2)
        Me.Controls.Add(Me.nmuY1)
        Me.Controls.Add(Me.nmuX2)
        Me.Controls.Add(Me.nmuX1)
        Me.Controls.Add(Me.btnDibujar)
        Me.Controls.Add(Me.lblY2)
        Me.Controls.Add(Me.lblY1)
        Me.Controls.Add(Me.lblX2)
        Me.Controls.Add(Me.lblX1)
        Me.Controls.Add(Me.lblIngCoord)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.cboColor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnBorrarDibujo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proyecto 1 - Algoritmos de Discretización"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.nmuX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmuX2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmuY2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmuY1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmuRadio1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmuRadio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBorrarDibujo As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsLinea As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsDDA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsBresenham As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCirculo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsElipse As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPoligono As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents lblIngCoord As System.Windows.Forms.Label
    Friend WithEvents lblX1 As System.Windows.Forms.Label
    Friend WithEvents lblX2 As System.Windows.Forms.Label
    Friend WithEvents lblY2 As System.Windows.Forms.Label
    Friend WithEvents lblY1 As System.Windows.Forms.Label
    Friend WithEvents btnDibujar As System.Windows.Forms.Button
    Friend WithEvents nmuX1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmuX2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmuY2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmuY1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRadio1 As System.Windows.Forms.Label
    Friend WithEvents lblRadio2 As System.Windows.Forms.Label
    Friend WithEvents nmuRadio1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmuRadio2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents tsRelleno As System.Windows.Forms.ToolStripButton
    Friend WithEvents lstPuntos As System.Windows.Forms.ListBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents chkRellenarFigura As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnEsconder As System.Windows.Forms.Button

End Class
