namespace PlumbingCompany.Viewmodels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            EmpFullName = "New Employee";
            EmpImg = "../Img/Employees/00_Default.png";
        }

        public EmployeeViewModel(int empId, string firstName, string lastName, int jobs, string empImg)
        {
            this.EmpID = empId;
            this.EmpFullName = firstName + " " + lastName;
            this.EmpActiveJobs = "Active Jobs: " + jobs;
            this.EmpImg = empImg;
        }

        public int EmpID { get; set; }
        public string EmpFullName { get; set; }
        public string EmpActiveJobs { get; set; }
        public string EmpImg { get; set; }

    }
}
