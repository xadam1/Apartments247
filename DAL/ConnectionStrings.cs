namespace DAL
{
    public partial class ApartmentsDbContext
    {
        public static class ConnectionStrings
        {
            public static string LocalDB = @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI";

            public static string SharedServer = @"Data Source=cassiopeia.serveirc.com\SQLEXPRESS,1433; Initial Catalog = ApartmentsDB; Integrated Security = FALSE; User ID = Apartments247; password=Janči-je-naprostý-Somár";
        }
    }
}
