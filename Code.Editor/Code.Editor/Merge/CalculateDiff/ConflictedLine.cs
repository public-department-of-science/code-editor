using Code.Editor.Merge.CalculateDiff;

namespace Code.Editor.Merge
{

    #region Merge stuffs

    namespace DiffMergeStuffs
    {
        /// <summary>
        /// Строка, содержащая несколько конфликтных версий
        /// </summary>
        public class ConflictedLine : Line
        {
            public readonly Lines version1;
            public readonly Lines version2;

            public ConflictedLine(Lines version1, Lines version2)
                : base("?")
            {
                this.version1 = version1;
                this.version2 = version2;
            }
        }
    }
    #endregion
}
