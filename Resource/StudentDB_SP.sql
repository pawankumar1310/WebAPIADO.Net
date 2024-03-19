

CREATE PROCEDURE InsertStudent

    @Student_ID NVARCHAR(10),

    @gender NVARCHAR(10) ,

    @Nationlity NVARCHAR(50),

    @PlaceOfBirth NVARCHAR(50),

    @StageID NVARCHAR(50),

    @GradeID NVARCHAR(5),

    @SectionID NVARCHAR(50),

    @Topic NVARCHAR(50),

    @Semester NVARCHAR(10),

    @Relation NVARCHAR(50),

    @RaisedHands INT,

    @VisitedResources INT,

    @AnnouncementsView INT,

    @Discussion INT,

    @ParentAnsweringSurvey NVARCHAR(10),

    @ParentschoolSatisfaction NVARCHAR(3),

    @StudentAbsenceDays NVARCHAR(8),

    @StudentMarks INT,

    @Classes NVARCHAR(50)

AS

BEGIN

    INSERT INTO Student(

        Student_ID, gender, NationalITy, PlaceOfBirth, StageID, GradeID, SectionID, Topic, Semester, 

        Relation, RaisedHands, VisitedResources, AnnouncementsView, Discussion, ParentAnsweringSurvey, 

        ParentschoolSatisfaction, StudentAbsenceDays, Student_Marks, Class

    )

    VALUES (

        @Student_ID, @gender, @Nationlity, @PlaceOfBirth, @StageID, @GradeID, @SectionID, @Topic, 

        @Semester, @Relation, @RaisedHands, @VisitedResources, @AnnouncementsView, @Discussion, 

        @ParentAnsweringSurvey, @ParentschoolSatisfaction, @StudentAbsenceDays, @StudentMarks, @Classes

    )

END



 

 

CREATE PROCEDURE UpdateStudent

    @Student_ID NVARCHAR(10),

    @gender NVARCHAR(10) ,

    @Nationlity NVARCHAR(50),

    @PlaceOfBirth NVARCHAR(50),

    @StageID NVARCHAR(50),

    @GradeID NVARCHAR(5),

    @SectionID NVARCHAR(50),

    @Topic NVARCHAR(50),

    @Semester NVARCHAR(10),

    @Relation NVARCHAR(50),

    @RaisedHands INT,

    @VisitedResources INT,

    @AnnouncementsView INT,

    @Discussion INT,

    @ParentAnsweringSurvey NVARCHAR(10),

    @ParentschoolSatisfaction NVARCHAR(3),

    @StudentAbsenceDays NVARCHAR(8),

    @StudentMarks INT,

    @Classes NVARCHAR(50)

AS

BEGIN

    UPDATE Student

    SET 

        gender = @gender,

        NationalITy = @Nationlity,

        PlaceOfBirth = @PlaceOfBirth,

        StageID = @StageID,

        GradeID = @GradeID,

        SectionID = @SectionID,

        Topic = @Topic,

        Semester = @Semester,

        Relation = @Relation,

        RaisedHands = @RaisedHands,

        VisitedResources = @VisitedResources,

        AnnouncementsView = @AnnouncementsView,

        Discussion = @Discussion,

        ParentAnsweringSurvey = @ParentAnsweringSurvey,

        ParentschoolSatisfaction = @ParentschoolSatisfaction,

        StudentAbsenceDays = @StudentAbsenceDays,

        Student_Marks = @StudentMarks,

        Class = @Classes

    WHERE Student_ID = @Student_ID

END

 

drop procedure UpdateStudent;

 

 

CREATE PROCEDURE GetAllStudents

AS

BEGIN

    SELECT * FROM Student; 

END

 

CREATE PROCEDURE GetStudentByID

    @Student_ID NVARCHAR(10)

AS

BEGIN

    SELECT * FROM Student WHERE Student_ID = @Student_ID; 

END

 

 

CREATE PROCEDURE DeleteStudentByID

    @Student_ID NVARCHAR(10)

AS

BEGIN

    DELETE FROM Student

    WHERE Student_ID = @Student_ID;

END;


alter PROCEDURE UpdateStudent

    @Student_ID NVARCHAR(10),

    @gender NVARCHAR(10) ,

    @Nationlity NVARCHAR(50),

    @PlaceOfBirth NVARCHAR(50),

    @StageID NVARCHAR(50),

    @GradeID NVARCHAR(5),

    @SectionID NVARCHAR(50),

    @Topic NVARCHAR(50),

    @Semester NVARCHAR(10),

    @Relation NVARCHAR(50),

    @RaisedHands INT,

    @VisitedResources INT,

    @AnnouncementsView INT,

    @Discussion INT,

    @ParentAnsweringSurvey NVARCHAR(10),

    @ParentschoolSatisfaction NVARCHAR(4),

    @StudentAbsenceDays NVARCHAR(8),

    @StudentMarks INT,

    @Classes NVARCHAR(50)

AS

BEGIN

    UPDATE Student

    SET 

        gender = @gender,

        NationalITy = @Nationlity,

        PlaceOfBirth = @PlaceOfBirth,

        StageID = @StageID,

        GradeID = @GradeID,

        SectionID = @SectionID,

        Topic = @Topic,

        Semester = @Semester,

        Relation = @Relation,

        RaisedHands = @RaisedHands,

        VisitedResources = @VisitedResources,

        AnnouncementsView = @AnnouncementsView,

        Discussion = @Discussion,

        ParentAnsweringSurvey = @ParentAnsweringSurvey,

        ParentschoolSatisfaction = @ParentschoolSatisfaction,

        StudentAbsenceDays = @StudentAbsenceDays,

        Student_Marks = @StudentMarks,

        Class = @Classes

    WHERE Student_ID = @Student_ID

END



ALTER PROCEDURE InsertStudent

    @Student_ID NVARCHAR(10),

    @gender NVARCHAR(10) ,

    @Nationlity NVARCHAR(50),

    @PlaceOfBirth NVARCHAR(50),

    @StageID NVARCHAR(50),

    @GradeID NVARCHAR(5),

    @SectionID NVARCHAR(50),

    @Topic NVARCHAR(50),

    @Semester NVARCHAR(10),

    @Relation NVARCHAR(50),

    @RaisedHands INT,

    @VisitedResources INT,

    @AnnouncementsView INT,

    @Discussion INT,

    @ParentAnsweringSurvey NVARCHAR(10),

    @ParentschoolSatisfaction NVARCHAR(4),

    @StudentAbsenceDays NVARCHAR(8),

    @StudentMarks INT,

    @Classes NVARCHAR(50)

AS

BEGIN

    INSERT INTO Student(

        Student_ID, gender, NationalITy, PlaceOfBirth, StageID, GradeID, SectionID, Topic, Semester, 

        Relation, RaisedHands, VisitedResources, AnnouncementsView, Discussion, ParentAnsweringSurvey, 

        ParentschoolSatisfaction, StudentAbsenceDays, Student_Marks, Class

    )

    VALUES (

        @Student_ID, @gender, @Nationlity, @PlaceOfBirth, @StageID, @GradeID, @SectionID, @Topic, 

        @Semester, @Relation, @RaisedHands, @VisitedResources, @AnnouncementsView, @Discussion, 

        @ParentAnsweringSurvey, @ParentschoolSatisfaction, @StudentAbsenceDays, @StudentMarks, @Classes

    )

END

--- create table StudentExtra ----

CREATE TABLE StudentExtra (
    Student_ID NVARCHAR(10) PRIMARY KEY,
    gender NVARCHAR(1),
    NationalITy NVARCHAR(50),
    PlaceofBirth NVARCHAR(50),
    StageID NVARCHAR(50),
    GradeID NVARCHAR(5),
    SectionID NVARCHAR(1),
    Topic NVARCHAR(50),
    Semester NVARCHAR(1),
    Relation NVARCHAR(50),
    raisedhands INT,
    VisITedResources INT,
    AnnouncementsView INT,
    Discussion INT,
    ParentAnsweringSurvey NVARCHAR(10),
    ParentschoolSatisfaction NVARCHAR(3),
    StudentAbsenceDays NVARCHAR(8),
    Student_Marks INT,
    Class NVARCHAR(1),
	IsBoolean int,
	Datetimes datetime
);

 -- Alter column ParentschoolSatisfaction  ---
ALTER TABLE StudentExtra
ALTER COLUMN ParentschoolSatisfaction NVARCHAR(5);
