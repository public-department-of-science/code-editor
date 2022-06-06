using FastColoredTextBoxNS;

namespace Code.Editor
{
    public class InvisibleCharsRenderer : Style
    {
        private const char emptySymbol = ' ';
        private Pen pen;

        public InvisibleCharsRenderer(Pen pen)
        {
            this.pen = pen;
        }

        public override void Draw(Graphics graphics, Point position, FastColoredTextBoxNS.Range range)
        {
            var textBox = range.tb;
            using (Brush brush = new SolidBrush(pen.Color))
            {
                foreach (var place in range)
                {
                    switch (textBox[place].c)
                    {
                        case emptySymbol:
                            var point = textBox.PlaceToPoint(place);
                            point.Offset(textBox.CharWidth / 2, textBox.CharHeight / 2);
                            graphics.DrawLine(pen, point.X, point.Y, point.X + 1, point.Y);
                            break;
                    }

                    if (textBox[place.iLine].Count - 1 == place.iChar)
                    {
                        var point = textBox.PlaceToPoint(place);
                        point.Offset(textBox.CharWidth, 0);
                        graphics.DrawString("¶", textBox.Font, brush, point);
                    }
                }
            }
        }
    }
}