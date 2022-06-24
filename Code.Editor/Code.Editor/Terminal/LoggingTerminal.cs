using FastColoredTextBoxNS;

namespace Code.Editor.Terminal
{
    public partial class LoggingTerminal : Form
    {
        TextStyle infoStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        TextStyle warningStyle = new TextStyle(Brushes.BurlyWood, null, FontStyle.Regular);
        TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);

        public LoggingTerminal()
        {
            InitializeComponent();
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            switch (DateTime.Now.Millisecond % 3)
            {
                case 0: Log(DateTime.Now + " Error\r\n", errorStyle); break;
                case 1: Log(DateTime.Now + " Warning\r\n", warningStyle); break;
                case 2: Log(DateTime.Now + " Info\r\n", infoStyle); break;
            }
        }

        private void Log(string text, Style style)
        {
            //some stuffs for best performance
            loggingTerminalArea.BeginUpdate();
            loggingTerminalArea.Selection.BeginUpdate();
            //remember user selection
            var userSelection = loggingTerminalArea.Selection.Clone();
            //add text with predefined style
            loggingTerminalArea.TextSource.CurrentTB = loggingTerminalArea;
            loggingTerminalArea.AppendText(text, style);
            //restore user selection
            if (!userSelection.IsEmpty || userSelection.Start.iLine < loggingTerminalArea.LinesCount - 2)
            {
                loggingTerminalArea.Selection.Start = userSelection.Start;
                loggingTerminalArea.Selection.End = userSelection.End;
            }
            else
                loggingTerminalArea.GoEnd();//scroll to end of the text
            //
            loggingTerminalArea.Selection.EndUpdate();
            loggingTerminalArea.EndUpdate();
        }

        private void btGotToEnd_Click(object sender, EventArgs e)
        {
            loggingTerminalArea.GoEnd();
        }
    }
}
