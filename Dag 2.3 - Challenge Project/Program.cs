/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
int examAssignments = 5;

var Students = new Dictionary<string, int[]>
{
    {"Sophia", new int[] { 90, 86, 87, 98, 100, 94, 90 } },
    {"Andrew", new int[] { 92, 89, 81, 96, 90, 89 } },
    {"Emma"  , new int[] { 90, 85, 87, 98, 68, 89, 89, 89 } },
    {"Logan" , new int[] { 90, 95, 87, 88, 96, 96 } }
};

string currentStudentLetterGrade = "";

// display the header row for scores/grades
Console.Clear();
Console.WriteLine("Student\t     Exam Score \tOverall Grade\t  \t Extra Credit \n");

foreach (var (name, grades) in Students)
{

    decimal sumAssignmentScores = 0;

    decimal OverallGrade = 0;

    decimal examScore = 0;

    decimal ExtraCredit = 0;

    int gradedAssignments = 0;

    for (int i = 0; i < grades.Length; i++)
    {
        if (i < 5)
        {
            examScore += (decimal)grades[i] / 5;
        }
        else
        {
            ExtraCredit += grades[i] / (grades.Length - 5);
        }
    }

    foreach (int score in grades)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
            sumAssignmentScores += score;

        else
            sumAssignmentScores += (decimal)score / 10;
    }

    OverallGrade = (decimal)(sumAssignmentScores) / examAssignments;

    decimal EXPoints = OverallGrade - examScore;

    var gradeRanges = new Dictionary<int, string>
{
    {  97, "A+" },
    {  93, "A" },
    {  90, "A-" },
    {  87, "B+" },
    {  83, "B" },
    {  80, "B-" },
    {  77, "C+" },
    {  73, "C" },
    {  70, "C-" },
    {  67, "D+" },
    {  63, "D" },
    {  60, "D-" }
};

    // Find the letter grade for the current student's grade
    foreach (var (grade, letterGrade) in gradeRanges)
    {
        if (OverallGrade >= grade)
        {
            currentStudentLetterGrade = letterGrade;
            break; // Exit the loop once the grade is found
        }
    }

    Console.WriteLine($"{name}\t\t{examScore}\t\t{OverallGrade}\t{currentStudentLetterGrade}\t\t {ExtraCredit} ({EXPoints} pts) ");
}

Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();


