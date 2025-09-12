using System.Data;

namespace DatabaseInterfaceNamespace
{
    public interface IDatabaseMangement
    {
        DataSet GetStudents(string UserName, string Password, bool Update);
        DataSet GetSubjects(string UserName, string Password, bool Update);
        DataSet GetDegrees(string UserName, string Password, bool Update);
        void updateStudents(DataSet ds);
        void updateSubjects(DataSet ds);
        void updateDegrees(DataSet ds);
    }
}
