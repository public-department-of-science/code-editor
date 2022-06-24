using Code.Editor.Merge.CalculateDiff;
using Code.Editor.Merge.DiffMergeStuffs;
using System.Text;

namespace Code.Editor.Merge
{
    /// <summary>
    /// File as list of lines
    /// </summary>
    public class Lines : List<Line>, IEquatable<Lines>
    {
        //эта строка нужна для хранения строк, вставленных в самом начале, до первой строки исходного файла
        private Line fictiveLine = new Line("===fictive line===") { state = DiffType.Deleted };

        public Lines()
        {
        }


        public Lines(int capacity)
            : base(capacity)
        {
        }

        public Line this[int i]
        {
            get
            {
                if (i == -1) return fictiveLine;
                return base[i];
            }

            set
            {
                if (i == -1) fictiveLine = value;
                base[i] = value;
            }
        }

        /// <summary>
        /// Load from file
        /// </summary>
        public static Lines Load(string fileName, Encoding enc = null)
        {
            Lines lines = new Lines();
            foreach (var line in File.ReadAllLines(fileName, enc ?? Encoding.Default))
                lines.Add(new Line(line));

            return lines;
        }

        /// <summary>
        /// Merge lines
        /// </summary>
        public void Merge(Lines lines)
        {
            SimpleDiff<Line> diff = new SimpleDiff<Line>(this, lines);
            int iLine = -1;

            diff.LineUpdate += (o, e) =>
            {
                if (e.DiffType == DiffType.Inserted)
                {
                    if (this[iLine].subLines == null)
                        this[iLine].subLines = new Lines();
                    e.LineValue.state = DiffType.Inserted;
                    this[iLine].subLines.Add(e.LineValue);
                }
                else
                {
                    iLine++;
                    this[iLine].state = e.DiffType;
                    if (iLine > 0 &&
                        this[iLine - 1].state == DiffType.Deleted &&
                        this[iLine - 1].subLines == null &&
                        e.DiffType == DiffType.None)
                        this[iLine - 1].subLines = new Lines();
                }
            };
            //запускаем алгоритм нахождения максимальной подпоследовательности (LCS)
            diff.RunDiff();
        }

        /// <summary>
        /// Clone
        /// </summary>
        public Lines Clone()
        {
            Lines result = new Lines(this.Count);
            foreach (var line in this)
                result.Add(new Line(line.line));

            return result;
        }

        /// <summary>
        /// Is lines equal?
        /// </summary>
        public bool Equals(Lines other)
        {
            if (Count != other.Count)
                return false;
            for (int i = 0; i < Count; i++)
                if (this[i] != other[i])
                    return false;
            return true;
        }

        /// <summary>
        /// Transform tree to list
        /// </summary>
        public Lines Expand()
        {
            return Expand(-1, Count - 1);
        }

        /// <summary>
        /// Transform tree to list
        /// </summary>
        public Lines Expand(int from, int to)
        {
            Lines result = new Lines();
            for (int i = from; i <= to; i++)
            {
                if (this[i].state != DiffType.Deleted)
                    result.Add(this[i]);
                if (this[i].subLines != null)
                    result.AddRange(this[i].subLines.Expand());
            }

            return result;
        }
    }
}