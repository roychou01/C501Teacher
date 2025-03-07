namespace MyWebAPI.Services
{
    //8.1.2 在資料夾中建立SomeService.cs類別並實作內容
    public class SomeService
    {
        string[] Id = { "A01", "A02", "A03" };
        string[] Name = { "王小明", "王中明", "王大明" };
        int[] Age = { 33, 26, 29 };


        public string[] getStudents()
        {
            string[] students = new string[Age.Length];

            for (int i = 0; i < Age.Length; i++)
            {
                students[i] = $"{Id[i]}-{Name[i]} - {Age[i]}";
            }

            return students;
        }

        public string getStudent(string id)
        {

            int i = Array.IndexOf(Id, id);
            if (i < 0)
            {
                return "";
            }

            string student = $"{Id[i]}-{Name[i]} - {Age[i]}";


            return student;
        }

    }
}
