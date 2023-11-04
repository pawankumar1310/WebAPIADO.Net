using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml;
using WebAPIADO.Net.Models;

namespace WebAPIADO.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
                _configuration = configuration;
        }

        [Route("getAllStudentData")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudentData()
        {
            try
            {
                DataTable dataTable = new DataTable();
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings"));
                SqlCommand command = new SqlCommand("Select * from Student", sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                List<Student> students = new List<Student>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    students.Add(new Student
                    {
                        StudentId = dataRow["Student_ID"].ToString(),
                        Gender = Convert.ToChar(dataRow["gender"]),
                        NationalIty = dataRow["NationalITy"].ToString(),
                        PlaceofBirth = dataRow["PlaceofBirth"].ToString(),
                        StageId = dataRow["StageID"].ToString(),
                        GradeId = dataRow["GradeID"].ToString(),
                        SectionId = Convert.ToChar(dataRow["SectionID"]),
                        Topic = dataRow["Topic"].ToString(),
                        Semester = Convert.ToChar(dataRow["Semester"]),
                        Relation = dataRow["Relation"].ToString(),
                        Raisedhands = int.Parse(dataRow["raisedhands"].ToString()),
                        VisItedResources = int.Parse(dataRow["VisITedResources"].ToString()),
                        AnnouncementsView = int.Parse(dataRow["AnnouncementsView"].ToString()),
                        Discussion = int.Parse(dataRow["Discussion"].ToString()),
                        ParentAnsweringSurvey = dataRow["ParentAnsweringSurvey"].ToString(),
                        ParentschoolSatisfaction = dataRow["ParentschoolSatisfaction"].ToString(),
                        StudentAbsenceDays = dataRow["StudentAbsenceDays"].ToString(),
                        StudentMarks = int.Parse(dataRow["Student_Marks"].ToString()),
                        Class = Convert.ToChar(dataRow["Class"])
                    });
                }
                return Ok(students);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("getAllStudentDatas")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudentDatas()
        {
            try
            {
                List<Student> students = new List<Student>();
                string connectionString = "Server=DESKTOP-RUJ2TUO;Database=StudentDbDemo;Trusted_Connection=true;TrustServerCertificate=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Student", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student student = new Student
                                {
                                    StudentId = reader["Student_ID"].ToString(),
                                    Gender = reader["gender"].ToString()[0],
                                    NationalIty = reader["NationalIty"].ToString(),
                                    PlaceofBirth = reader["PlaceofBirth"].ToString(),
                                    StageId = reader["StageID"].ToString(),
                                    GradeId = reader["GradeID"].ToString(),
                                    SectionId = reader["SectionID"].ToString()[0],
                                    Topic = reader["Topic"].ToString(),
                                    Semester = reader["Semester"].ToString()[0],
                                    Relation = reader["Relation"].ToString(),
                                    Raisedhands = Convert.ToInt32(reader["raisedhands"]),
                                    VisItedResources = Convert.ToInt32(reader["VisITedResources"]),
                                    AnnouncementsView = Convert.ToInt32(reader["AnnouncementsView"]),
                                    Discussion = Convert.ToInt32(reader["Discussion"]),
                                    ParentAnsweringSurvey = reader["ParentAnsweringSurvey"].ToString(),
                                    ParentschoolSatisfaction = reader["ParentschoolSatisfaction"].ToString(),
                                    StudentAbsenceDays = reader["StudentAbsenceDays"].ToString(),
                                    StudentMarks = Convert.ToInt32(reader["Student_Marks"]),
                                    Class = reader["Class"].ToString()[0]

                                    // Set other properties here
                                };
                                students.Add(student);
                            }
                        }
                    }
                }

                return Ok(students);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("AddStudentData")]
        [HttpPost]
        public async Task<IActionResult> AddStudentData(Student student)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings"));

                SqlCommand command = new SqlCommand("insert into Student values " +
                    "('" + student.StudentId + "'," +
                    "'" + student.Gender + "'," +
                    "'" + student.NationalIty + "'," +
                    "'" + student.PlaceofBirth + "'," +
                    " '" + student.StageId + "'," +
                    "'" + student.GradeId + "'," +
                    "'" + student.SectionId + "'," +
                    "'" + student.Topic + "'," +
                    "'" + student.Semester + "'," +
                    "'" + student.Relation + "'," +
                    "'" + student.Raisedhands + "'," +
                    " '" + student.VisItedResources + "'," +
                    "'" + student.AnnouncementsView + "'," +
                    "'" + student.Discussion + "'," +
                    "'" + student.ParentAnsweringSurvey + "'," +
                    "'" + student.ParentschoolSatisfaction + "'," +
                    "'" + student.StudentAbsenceDays + "'," +
                    "'" + student.StudentMarks + "'," +
                    "'" + student.Class + "' )", sqlConnection);
                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("getStudentDataById")]
        [HttpGet]

        public async Task<IActionResult> GetStudentById(string  studentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Student_ID = @studentId", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@studentId", SqlDbType.NVarChar)).Value = studentId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Student student = new Student
                                {
                                    StudentId = reader.GetString(reader.GetOrdinal("Student_ID")),
                                    Gender = reader.GetString(reader.GetOrdinal("gender"))[0],
                                    NationalIty = reader.GetString(reader.GetOrdinal("NationalITy")),
                                    PlaceofBirth = reader.GetString(reader.GetOrdinal("PlaceofBirth")),
                                    StageId = reader.GetString(reader.GetOrdinal("StageID")),
                                    GradeId = reader.GetString(reader.GetOrdinal("GradeID")),
                                    SectionId = reader.GetString(reader.GetOrdinal("SectionID"))[0],
                                    Topic = reader.GetString(reader.GetOrdinal("Topic")),
                                    Semester = reader.GetString(reader.GetOrdinal("Semester"))[0],
                                    Relation = reader.GetString(reader.GetOrdinal("Relation")),
                                    Raisedhands = reader.GetInt32(reader.GetOrdinal("raisedhands")),
                                    VisItedResources = reader.GetInt32(reader.GetOrdinal("VisITedResources")),
                                    AnnouncementsView = reader.GetInt32(reader.GetOrdinal("AnnouncementsView")),
                                    Discussion = reader.GetInt32(reader.GetOrdinal("Discussion")),
                                    ParentAnsweringSurvey = reader.GetString(reader.GetOrdinal("ParentAnsweringSurvey")),
                                    ParentschoolSatisfaction = reader.GetString(reader.GetOrdinal("ParentschoolSatisfaction")),
                                    StudentAbsenceDays = reader.GetString(reader.GetOrdinal("StudentAbsenceDays")),
                                    StudentMarks = reader.GetInt32(reader.GetOrdinal("Student_Marks")),
                                    Class = reader.GetString(reader.GetOrdinal("Class"))[0],
                                    // Set other properties here
                                };
                                return Ok(student);
                            }
                        }
                    }
                }

                return Ok(false); // Return null if no record is found
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("FindStudentById")] //GET
        [HttpGet]
        public async Task<IActionResult> FindStudentById(string id)
        {
            SqlConnection connString = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings"));
            DataTable dtb = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Student where Student_ID=@StudentID", connString);
            cmd.Parameters.AddWithValue("@StudentID ", id);
            try
            {
                connString.Open();
                SqlDataAdapter  adap = new SqlDataAdapter(cmd);
                adap.Fill(dtb);
                DataRow dr = dtb.Rows[0];
                Student lstprofile = new Student

                {

                    StudentId = dr["Student_ID"].ToString(),

                    Gender = dr["gender"].ToString().ToString()[0],

                    NationalIty = dr["NationalITy"].ToString(),

                    PlaceofBirth = dr["PlaceOfBirth"].ToString(),

                    StageId = dr["StageID"].ToString(),

                    GradeId = dr["GradeID"].ToString(),

                    SectionId = dr["SectionID"].ToString()[0],

                    Topic = dr["Topic"].ToString(),

                    Semester = dr["Semester"].ToString()[0],

                    Relation = dr["Relation"].ToString(),

                    Raisedhands = Convert.ToInt32(dr["raisedhands"]),

                    VisItedResources = Convert.ToInt32(dr["VisITedResources"]),

                    AnnouncementsView = Convert.ToInt32(dr["AnnouncementsView"]),

                    Discussion = Convert.ToInt32(dr["Discussion"]),

                    ParentAnsweringSurvey = dr["ParentAnsweringSurvey"].ToString(),

                    ParentschoolSatisfaction = dr["ParentschoolSatisfaction"].ToString(),

                    StudentAbsenceDays = dr["StudentAbsenceDays"].ToString(),

                    StudentMarks = Convert.ToInt32(dr["Student_Marks"]),

                    Class = dr["Class"].ToString()[0]

                };
                if (dtb.Rows.Count > 0)
                {
                    return Ok(lstprofile);
                }
                else
                    return Ok("Not Found!");
            }
            catch (Exception ef)
            {
                return Ok(ef.Message);
            }
            finally { connString.Close(); }
        }


        [Route("deleteStudentData")]
        [HttpDelete]

        public async Task<IActionResult> DeleteStudentData(string studentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Student_ID = @studentId", connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);

                        int rowsAffected = command.ExecuteNonQuery();

                        return Ok(rowsAffected > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [HttpPut("updateStudentData/{id}")]
        public IActionResult UpdateData(string id, [FromBody] Student updatedStudent)
        {
            try
            {

                if (updatedStudent == null || string.IsNullOrWhiteSpace(id))
                {
                    return BadRequest("Invalid data or ID.");
                }
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
                {
                    connection.Open();

                    string updateSql = "UPDATE Student SET " +
                    "Student_ID = @StudentID, " +
                    "gender = @Gender, " +
                    "NationalITy = @Nationality, " +
                    "PlaceofBirth = @PlaceOfBirth, " +
                    "StageID = @StageID, " +
                    "GradeID = @GradeID, " +
                    "SectionID = @SectionID, " +
                    "Topic = @Topic, " +
                    "Semester = @Semester, " +
                    "Relation = @Relation, " +
                    "raisedhands = @RaisedHands, " +
                    "VisITedResources = @VisitedResources, " +
                    "AnnouncementsView = @AnnouncementsView, " +
                    "Discussion = @Discussion, " +
                    "ParentAnsweringSurvey = @ParentAnsweringSurvey, " +
                    "ParentschoolSatisfaction = @ParentSchoolSatisfaction, " +
                    "StudentAbsenceDays = @StudentAbsenceDays, " +
                    "Student_Marks = @StudentMarks, " +
                    "Class = @Class " +
                    "WHERE Student_ID = @StudentID";

                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", id);
                        command.Parameters.AddWithValue("@Gender", updatedStudent.Gender);
                        command.Parameters.AddWithValue("@Nationality", updatedStudent.NationalIty);
                        command.Parameters.AddWithValue("@PlaceOfBirth", updatedStudent.PlaceofBirth);
                        command.Parameters.AddWithValue("@StageID", updatedStudent.StageId);
                        command.Parameters.AddWithValue("@GradeID", updatedStudent.GradeId);
                        command.Parameters.AddWithValue("@SectionID", updatedStudent.SectionId);
                        command.Parameters.AddWithValue("@Topic", updatedStudent.Topic);
                        command.Parameters.AddWithValue("@Semester", updatedStudent.Semester);
                        command.Parameters.AddWithValue("@Relation", updatedStudent.Relation);
                        command.Parameters.AddWithValue("@RaisedHands", updatedStudent.Raisedhands);
                        command.Parameters.AddWithValue("@VisitedResources", updatedStudent.VisItedResources);
                        command.Parameters.AddWithValue("@AnnouncementsView", updatedStudent.AnnouncementsView);
                        command.Parameters.AddWithValue("@Discussion", updatedStudent.Discussion);
                        command.Parameters.AddWithValue("@ParentAnsweringSurvey", updatedStudent.ParentAnsweringSurvey);
                        command.Parameters.AddWithValue("@ParentSchoolSatisfaction", updatedStudent.ParentschoolSatisfaction);
                        command.Parameters.AddWithValue("@StudentAbsenceDays", updatedStudent.StudentAbsenceDays);
                        command.Parameters.AddWithValue("@StudentMarks", updatedStudent.StudentMarks);
                        command.Parameters.AddWithValue("@Class", updatedStudent.Class);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Data updated successfully.");
                        }
                        else
                        {
                            return NotFound("Data not found or no changes were made.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
