using FastColoredTextBoxNS;

namespace Code.Editor.Terminal
{
    public class TextSourceLineFilter : TextSource
    {
        private List<int> filteredLines = new List<int>();
        public string ContainsSegmentSymbols { get; set; }
        public bool IsCaseSensitive { get; set; }

        public TextSourceLineFilter(string containsSegmentSymbols, FastColoredTextBox tb) : base(tb)
        {
            ContainsSegmentSymbols = containsSegmentSymbols;
        }

        public override int Count
        {
            get
            {
                return filteredLines.Count;
            }
        }

        public override Line this[int i]
        {
            get
            {
                try
                {
                    return base[filteredLines[i]];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Critical issue", MessageBoxButtons.OK);
                    return base[0];
                }
            }
            set
            {
                base[filteredLines[i]] = value;
            }
        }

        public void FilterLines(HashSet<LoggingTerminal.InformationType>? selectedFlags)
        {
            filteredLines.Clear();

            var count = base.lines.Count;
            var cultureComparison = StringComparison.CurrentCulture;
            if (IsCaseSensitive == false)
            {
                cultureComparison = StringComparison.CurrentCultureIgnoreCase;
            }

            for (int i = 0; i < count; i++)
            {
                if (string.IsNullOrWhiteSpace(ContainsSegmentSymbols) && selectedFlags == null)
                {
                    filteredLines.AddRange(lines.Select(x => x.UniqueId).ToList());
                    break;
                }
                if (selectedFlags != null && selectedFlags.Count != 0)
                {
                    foreach (var item in selectedFlags)
                    {
                        var selectedFlagAsString = item.ToString();
                        if (string.IsNullOrWhiteSpace(ContainsSegmentSymbols) == true)
                        {
                            var isSelectedFlagFound = lines[i].Text.ToString().Contains(selectedFlagAsString, cultureComparison);
                            if (isSelectedFlagFound)
                            {
                                filteredLines.Add(i);
                            }
                        }
                        else
                        {
                            var isLineSymbolsContains = lines[i].Text.ToString().Contains(ContainsSegmentSymbols, cultureComparison);
                            var isSelectedFlagFound = lines[i].Text.ToString().Contains(selectedFlagAsString, cultureComparison);
                            if (isLineSymbolsContains && isSelectedFlagFound)
                            {
                                filteredLines.Add(i);
                            }
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(ContainsSegmentSymbols))
                    {
                        filteredLines.AddRange(lines.Select(x => x.UniqueId).ToList());
                        break;
                    }
                    if (lines[i].Text.ToString().Contains(ContainsSegmentSymbols, cultureComparison))
                    {
                        filteredLines.Add(i);
                    }
                }
            }

            if (filteredLines.Count == 0)
            {
                filteredLines.Add(lines.Count - 1);
            }

            CurrentTB.NeedRecalc(true);
            CurrentTB.Invalidate();
        }

        public override void InsertLine(int index, Line line)
        {
            if (index >= filteredLines.Count)
            {
                var c = lines.Count;
                while (index >= filteredLines.Count)
                {
                    filteredLines.Add(c++);
                }
            }
            else
            {
                var srcIndex = filteredLines[index];
                filteredLines.Insert(index, srcIndex);
                for (int i = index + 1; i < filteredLines.Count; i++)
                {
                    filteredLines[i]++;
                }
            }

            index = filteredLines[index];
            base.InsertLine(index, line);
        }

        public override void RemoveLine(int index, int count)
        {
            for (int ii = index + count - 1; ii >= index; ii--)
            {
                var srcIndex = filteredLines[ii];
                base.RemoveLine(srcIndex, 1);

                filteredLines.RemoveAt(ii);

                for (int i = index; i < filteredLines.Count; i++)
                {
                    filteredLines[i]--;
                }
            }
        }

        public override int GetLineLength(int i)
        {
            return base.GetLineLength(filteredLines[i]);
        }

        public override bool LineHasFoldingStartMarker(int iLine)
        {
            return base.LineHasFoldingStartMarker(filteredLines[iLine]);
        }

        public override bool LineHasFoldingEndMarker(int iLine)
        {
            return base.LineHasFoldingEndMarker(filteredLines[iLine]);
        }
    }
}