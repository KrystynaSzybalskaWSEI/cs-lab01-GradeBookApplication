using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks {
    class RankedGradeBook : BaseGradeBook {
        public RankedGradeBook(string name) : base(name) {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5) {
                throw new InvalidOperationException();
            }

            char letter_grade = 'A';
            int twenty_percent = Students.Count / 5;
            int better_students_count = 0;
            Students.Sort();
            Students.Reverse();

            while (averageGrade < Students[better_students_count].AverageGrade) {
                better_students_count++;
            }

            if (better_students_count > twenty_percent) {
                if (better_students_count > 2*twenty_percent) {
                    if (better_students_count > 3*twenty_percent) {
                        if (better_students_count > 4 * twenty_percent) {
                            letter_grade = 'F';
                        }
                        letter_grade = 'D';
                    }
                    letter_grade = 'C';
                }
                letter_grade = 'B';
            }

            return letter_grade;
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
