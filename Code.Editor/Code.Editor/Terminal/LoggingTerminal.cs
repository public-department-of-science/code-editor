using FastColoredTextBoxNS;

namespace Code.Editor.Terminal
{
    public partial class LoggingTerminal : Form
    {
        static TextStyle traceStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        static TextStyle debugStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        static TextStyle infoStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        static TextStyle warningStyle = new TextStyle(Brushes.BurlyWood, null, FontStyle.Italic);
        static TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Bold);

        public LoggingTerminal()
        {
            InitializeComponent();
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            switch (DateTime.Now.Millisecond % 5)
            {
                case 0: Log(DateTime.Now + " Trace\r\n", InformationType.Trace); break;
                case 1: Log(DateTime.Now + " Debug\r\n", InformationType.Debug); break;
                case 2: Log(DateTime.Now + " Info\r\n", InformationType.Information); break;
                case 3: Log(DateTime.Now + " Warning\r\n", InformationType.Warning); break;
                case 4: Log(DateTime.Now + " Error\r\n", InformationType.Error); break;
            }
        }

        public enum InformationType
        {
            Trace = 0,
            Debug = 1,
            Information = 2,
            Warning = 3,
            Error = 4,
        }

        private Style GetStyleByInformationType(InformationType informationType)
        {
            switch (informationType)
            {
                case InformationType.Trace: return traceStyle;
                case InformationType.Debug: return debugStyle;
                case InformationType.Information: return infoStyle;
                case InformationType.Warning: return warningStyle;
                case InformationType.Error: return errorStyle;
                default: return debugStyle;
            }
        }

        private void Log(string text, InformationType informationType)
        {
            // some stuffs for best performance
            loggingTerminalArea.BeginUpdate();
            loggingTerminalArea.Selection.BeginUpdate();
            // remember user selection
            var userSelection = loggingTerminalArea.Selection.Clone();
            // add text with predefined style
            loggingTerminalArea.TextSource.CurrentTB = loggingTerminalArea;

            var currentInfoType = GetStyleByInformationType(informationType);
            loggingTerminalArea.AppendText(text, currentInfoType);

            if (!userSelection.IsEmpty || userSelection.Start.iLine < loggingTerminalArea.LinesCount - 2)
            {
                loggingTerminalArea.Selection.Start = userSelection.Start;
                loggingTerminalArea.Selection.End = userSelection.End;
            }
            else
            {
                loggingTerminalArea.GoEnd();
            }

            loggingTerminalArea.Selection.EndUpdate();
            loggingTerminalArea.EndUpdate();
        }

        private void btGotToEnd_Click(object sender, EventArgs e)
        {
            loggingTerminalArea.GoEnd();
        }

        private void btnEmptifyWindow_Click(object sender, EventArgs e)
        {
            loggingTerminalArea.Clear();
        }

        private void filterBoxParams_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (string item in checkListFilterBoxParams.CheckedItems)
            {
                //  item;
            }
        }
    }
}