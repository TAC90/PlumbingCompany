namespace PlumbingCompany.Viewmodels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            CusFullName = "New Customer";
            CusImg = "../Img/Customers/00_Default.png";
        }
        public CustomerViewModel(int cusId, string firstName, string lastName, string cusImg)
        {
            this.CusID = cusId;
            this.CusFullName = $"{firstName} {lastName}";
            this.CusImg = cusImg;
        }
        public int CusID { get; set; }
        public string CusFullName { get; set; }
        public string CusActiveJobs { get; set; }
        public string CusImg { get; set; }
    }

}
