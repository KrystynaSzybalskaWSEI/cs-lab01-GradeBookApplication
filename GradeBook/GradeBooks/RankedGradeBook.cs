using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks {
    public class RankedGradeBook : BaseGradeBook {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int twentyPercent = Students.Count / 5;
            int betterStudentsCount = Students.Count(student => student.AverageGrade >= averageGrade);
            
            if (betterStudentsCount <= twentyPercent) return 'A';
            if (betterStudentsCount <= 2*twentyPercent) return 'B';
            if (betterStudentsCount <= 3*twentyPercent) return 'C';
            if (betterStudentsCount <= 4*twentyPercent) return 'D';
            return 'F';
        }

        public override void CalculateStatistics() {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            } else {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name) {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            } else {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
