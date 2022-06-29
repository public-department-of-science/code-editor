using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

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
                case 0: LogInformation(DateTime.Now + " Trace\r\n", InformationType.Trace); break;
                case 1: LogInformation(DateTime.Now + " Debug\r\n", InformationType.Debug); break;
                case 2: LogInformation(DateTime.Now + " Info\r\n", InformationType.Information); break;
                case 3: LogInformation(DateTime.Now + " Warning\r\n", InformationType.Warning); break;
                case 4: LogInformation(DateTime.Now + " Error\r\n", InformationType.Error); break;
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

        private void LogInformation(string text, InformationType informationType)
        {
            // some stuffs for best performance
            loggingTerminalArea.BeginUpdate();
            loggingTerminalArea.Selection.BeginUpdate();

            var userSelection = loggingTerminalArea.Selection.Clone();
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

        private void btnStartLogging_Click(object sender, EventArgs e)
        {
            timer.Start();

            checkListFilterBoxParams.Enabled = false;
            txtBoxFilterLogsText.Enabled = false;
            chkBoxIsCaseSensitive.Enabled = false;
        }

        private void btnStopLogging_Click(object sender, EventArgs e)
        {
            timer.Stop();

            checkListFilterBoxParams.Enabled = true;
            txtBoxFilterLogsText.Enabled = true;
            chkBoxIsCaseSensitive.Enabled = true;
        }

        private void txtBoxFilterLogsText_TextChanged(object sender, EventArgs e)
        {
            loggingTerminalArea.ClearUndo();

            if (string.IsNullOrWhiteSpace(txtBoxFilterLogsText.Text) == true)
            {
                var textSourceFilter = loggingTerminalArea.TextSource as TextSourceLineFilter;
                if (textSourceFilter == null)
                {
                    throw new Exception("Critical files filter is null exception.");
                }
                textSourceFilter.ContainsSegmentSymbols = string.Empty;
                textSourceFilter.IsCaseSensitive = false;
                textSourceFilter.FilterLines();
            }
            else
            {
                var textSourceFilter = loggingTerminalArea.TextSource as TextSourceLineFilter;
                if (textSourceFilter == null)
                {
                    throw new Exception("Critical files filter is null exception.");
                }
                textSourceFilter.ContainsSegmentSymbols = txtBoxFilterLogsText.Text;
                textSourceFilter.IsCaseSensitive = chkBoxIsCaseSensitive.Checked;
                textSourceFilter.FilterLines();
            }
        }

        private void LoggingTerminal_Shown(object sender, EventArgs e)
        {
            var ts = new TextSourceLineFilter(txtBoxFilterLogsText.Text, loggingTerminalArea);
            loggingTerminalArea.TextSource = ts;
            loggingTerminalArea.Text = "";
            loggingTerminalArea.ClearUndo();
        }
    }
}