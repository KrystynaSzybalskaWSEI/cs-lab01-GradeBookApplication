using GradeBook.Enums;

namespace GradeBook.GradeBooks {
    class RankedGradeBook : BaseGradeBook {
        public RankedGradeBook(string name) : base(name) {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            return base.GetLetterGrade(averageGrade);
        }
    }
}
