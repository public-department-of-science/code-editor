using FastColoredTextBoxNS;

namespace Code.Editor
{
    internal class ReadOnlyStyle : Style
    {
        public override void Draw(Graphics gr, Point position, FastColoredTextBoxNS.Range range)
        {
            //get size of rectangle
            Size size = GetSizeOfRange(range);
            //create rectangle
            Rectangle rect = new Rectangle(position, size);
            //inflate it
            rect.Inflate(2, 2);
            //get rounded rectangle
            var path = GetRoundedRectangle(rect, 7);
            //draw rounded rectangle
            gr.DrawPath(Pens.Red, path);
        }
    }
}
