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

        //[Route("getAllStudentData")]
        //[HttpGet]
        //public async Task<IActionResult> GetAllStudentData()
        //{
        //    try
        //    {
        //        List<Student> students = new List<Student>();
        //        string connectionString = "Server=DESKTOP-RUJ2TUO;Database=StudentDbDemo;Trusted_Connection=true;TrustServerCertificate=true;";
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            using (SqlCommand command = new SqlCommand("SELECT * FROM Student", connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Student student = new Student
        //                        {
        //                            StudentId = reader.GetOrdinal("Student_ID").ToString(),
        //                            //StudentId = reader.GetInt32(reader.GetOrdinal("Student_ID")).ToString(),
        //                            Gender = Convert.ToChar(reader.GetOrdinal("gender")),
        //                            NationalIty = reader.GetOrdinal("NationalITy").ToString()

        //                            // Set other properties here
        //                        };
        //                        students.Add(student);
        //                    }
        //                }
        //            }
        //        }

        //        return Ok(students);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        //[Route("getStudentDataById")]
        //[HttpGet("{Id}")]
        [Route("AddStudentData")]
        [HttpPost]
        public async Task<IActionResult> AddStudentData(Student student)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings"));
                string insertSql = "INSERT INTO Student VALUES ()";


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

    }
}
