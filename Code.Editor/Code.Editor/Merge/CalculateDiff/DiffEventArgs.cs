namespace Code.Editor.Merge
{
    public class DiffEventArgs<T> : EventArgs
    {
        public DiffType DiffType { get; set; }

        public T LineValue { get; private set; }
        public int LeftIndex { get; private set; }
        public int RightIndex { get; private set; }

        public DiffEventArgs(DiffType diffType, T lineValue, int leftIndex, int rightIndex)
        {
            this.DiffType = diffType;
            this.LineValue = lineValue;
            this.LeftIndex = leftIndex;
            this.RightIndex = rightIndex;
        }
    }
}