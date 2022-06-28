using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace Code.Editor.Terminal
{
    public class TextSourceWithLineFiltering : TextSource
    {
        private List<int> toSourceIndex = new List<int>();
        private string _lineFilterRegex;

        public TextSourceWithLineFiltering(FastColoredTextBox tb) : base(tb)
        {
        }

        public string LineFilterRegex
        {
            get
            {
                return _lineFilterRegex;
            }
            set
            {
                _lineFilterRegex = value;
                UpdateFilter();
            }
        }

        private void UpdateFilter()
        {
            toSourceIndex.Clear();

            var count = base.lines.Count;
            var regex = new Regex(LineFilterRegex);
            for (int i = 0; i < count; i++)
            {
                if (regex.IsMatch(lines[i].Text))
                {
                    toSourceIndex.Add(i);
                }
            }

            CurrentTB.NeedRecalc(true);
            CurrentTB.Invalidate();
        }

        public override int Count
        {
            get
            {
                return toSourceIndex.Count;
            }
        }

        public override Line this[int i]
        {
            get
            {
                return base[toSourceIndex[i]];
            }
            set
            {
                base[toSourceIndex[i]] = value;
            }
        }

        public override void InsertLine(int index, Line line)
        {
            if (index >= toSourceIndex.Count)
            {
                var c = lines.Count;
                while (index >= toSourceIndex.Count)
                {
                    toSourceIndex.Add(c++);
                }
            }
            else
            {
                var srcIndex = toSourceIndex[index];
                toSourceIndex.Insert(index, srcIndex);
                for (int i = index + 1; i < toSourceIndex.Count; i++)
                {
                    toSourceIndex[i]++;
                }
            }

            index = toSourceIndex[index];
            base.InsertLine(index, line);
        }

        public override void RemoveLine(int index, int count)
        {
            for (int ii = index + count - 1; ii >= index; ii--)
            {
                var srcIndex = toSourceIndex[ii];
                base.RemoveLine(srcIndex, 1);

                toSourceIndex.RemoveAt(ii);

                for (int i = index; i < toSourceIndex.Count; i++)
                {
                    toSourceIndex[i]--;
                }
            }
        }

        public override int GetLineLength(int i)
        {
            return base.GetLineLength(toSourceIndex[i]);
        }

        public override bool LineHasFoldingStartMarker(int iLine)
        {
            return base.LineHasFoldingStartMarker(toSourceIndex[iLine]);
        }

        public override bool LineHasFoldingEndMarker(int iLine)
        {
            return base.LineHasFoldingEndMarker(toSourceIndex[iLine]);
        }
    }
}