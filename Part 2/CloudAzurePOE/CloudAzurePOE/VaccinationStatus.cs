using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAzurePOE
{
    public class VaccinationStatus
    {
        //Declaring Variables
        string id;
        string passport;
        string vaccinationCentre;
        string vaccinationdate;
        string vaccinationSerialNumber;
        string VaccinationBarcode;



        public string Id { get => id; set => id = value; }
        public string Passport { get => passport; set => passport = value; }
        public string VaccinationCentre { get => vaccinationCentre; set => vaccinationCentre = value; }
        public string Vaccinationdate { get => vaccinationdate; set => vaccinationdate = value; }
        public string VaccinationSerialNumber { get => vaccinationSerialNumber; set => vaccinationSerialNumber = value; }
        public string VaccinationBarcode1 { get => VaccinationBarcode; set => VaccinationBarcode = value; }
    }
}
