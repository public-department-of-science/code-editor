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
                case 2: LogInformation(DateTime.Now + " Info\r\n", InformationType.Info); break;
                case 3: LogInformation(DateTime.Now + " Warning\r\n", InformationType.Warning); break;
                case 4: LogInformation(DateTime.Now + " Error\r\n", InformationType.Error); break;
            }
        }

        public enum InformationType
        {
            Undefined = -1,
            Trace = 0,
            Debug = 1,
            Info = 2,
            Warning = 3,
            Error = 4,
        }

        private Style GetStyleByInformationType(InformationType informationType)
        {
            switch (informationType)
            {
                case InformationType.Trace: return traceStyle;
                case InformationType.Debug: return debugStyle;
                case InformationType.Info: return infoStyle;
                case InformationType.Warning: return warningStyle;
                case InformationType.Error: return errorStyle;

                case InformationType.Undefined:
                default: return debugStyle;
            }
        }

        private InformationType GetInformationTypeByString(string informationType)
        {
            switch (informationType)
            {
                case nameof(InformationType.Trace): return InformationType.Trace;
                case nameof(InformationType.Debug): return InformationType.Debug;
                case nameof(InformationType.Info): return InformationType.Info;
                case nameof(InformationType.Warning): return InformationType.Warning;
                case nameof(InformationType.Error): return InformationType.Error;

                default: return InformationType.Undefined;
            }
        }

        private void LogInformation(string text, InformationType informationType)
        {
            chkBoxIsCaseSensitive.Checked = false;
            txtBoxFilterLogsText.Text = string.Empty;

            checkListFilterBoxParams.ClearSelected();
            for (int i = 0; i < checkListFilterBoxParams.Items.Count; i++)
            {
                checkListFilterBoxParams.SetItemChecked(i, false);
            }

            RunFiltration();

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
            LoggingTerminal_Shown(sender, e);
        }

        private void filterBoxParams_SelectedValueChanged(object sender, EventArgs e)
        {
            HashSet<InformationType> selectedFlags = new HashSet<InformationType>();
            foreach (string selectedFlag in checkListFilterBoxParams.CheckedItems)
            {
                var infoType = GetInformationTypeByString(selectedFlag);
                if (infoType != InformationType.Undefined && selectedFlags.Contains(infoType) == false)
                {
                    selectedFlags.Add(infoType);
                }
            }
            RunFiltration(selectedFlags);
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
            RunFiltration();
        }

        private void RunFiltration(HashSet<InformationType>? selectedFlags = default)
        {
            if (string.IsNullOrWhiteSpace(txtBoxFilterLogsText.Text) == true)
            {
                var textSourceFilter = loggingTerminalArea.TextSource as TextSourceLineFilter;
                if (textSourceFilter == null)
                {
                    throw new Exception("Critical files filter is null exception.");
                }
                textSourceFilter.ContainsSegmentSymbols = string.Empty;
                textSourceFilter.IsCaseSensitive = false;
                textSourceFilter.FilterLines(selectedFlags);
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
                textSourceFilter.FilterLines(selectedFlags);
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