using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GradientButton : Button {

    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);

        using (LinearGradientBrush brush = new LinearGradientBrush(
                   this.ClientRectangle,
                   Color.FromArgb(191, 79, 195, 246),  // Color inicial
                   Color.FromArgb(191, 1, 194, 169),   // Color final
                   45f))                              // Ángulo del gradiente
               {
            // Rellenar el fondo del botón con el gradiente
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // Dibujar el texto del botón
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle,
            this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }


}
