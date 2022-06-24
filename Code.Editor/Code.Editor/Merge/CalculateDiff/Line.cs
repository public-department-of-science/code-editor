namespace Code.Editor.Merge.CalculateDiff
{
    /// <summary>
    /// Line of file
    /// </summary>
    public class Line
    {
        /// <summary>
        /// Source string
        /// </summary>
        public readonly string line;

        /// <summary>
        /// Inserted strings
        /// </summary>
        public Lines subLines;

        /// <summary>
        /// Line state
        /// </summary>
        public DiffType state;

        public Line(string line)
        {
            this.line = line;
        }

        /// <summary>
        /// Equals
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(line, ((Line)obj).line);
        }

        public static bool operator ==(Line line1, Line line2)
        {
            return Equals(line1.line, line2.line);
        }

        public static bool operator !=(Line line1, Line line2)
        {
            return !Equals(line1.line, line2.line);
        }

        public override string ToString()
        {
            return line;
        }
    }
}
