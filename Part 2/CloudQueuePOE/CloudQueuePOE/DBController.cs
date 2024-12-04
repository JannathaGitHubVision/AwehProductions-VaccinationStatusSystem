using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudQueuePOE
{
    public class DBController
    {
        SqlConnection con; //used to connect to your database via the conneciton 
        SqlCommand cmd;

        //That is my SQL connnection of Azure SQL Database
        public DBController()
        {
            con = new SqlConnection("Server=tcp:dbs-vc-cldv6211-st10053561.database.windows.net,1433;Initial Catalog=db-vc-cldv6211-st10053561;Persist Security Info=False;User ID=ST10053561;Password=Visionflex27;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
        }

        //It stores values of 'VaccinationStatus' and store it in a Azure SQL Database
        public void Addvalues(VaccinationStatus status)
        {
            con.Open();

            string passport = status.Passport;
            string id = status.Id;
            string vaccinationCentre = status.VaccinationCentre;
            string vaccinationDate = status.Vaccinationdate;
            string vaccinationSerialNumber = status.VaccinationSerialNumber;
            string vaccinationBarcode = status.VaccinationBarcode1;

            cmd = new SqlCommand($"INSERT INTO VaccineInfo (VaccineID, Passport, VaccinationCentre, VaccinationDate, VaccinationSerialNumber, VaccinationBarcode)" +
                $"VALUES ('{id}','{passport}', '{vaccinationCentre}', '{vaccinationDate}', '{vaccinationSerialNumber}', '{vaccinationBarcode}')", con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
