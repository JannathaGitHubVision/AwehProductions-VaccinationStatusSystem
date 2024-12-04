using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPOEPart2
{
    public class ValidationChecker
    {
        /// <summary>
        /// Checking for Validation passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        public string IsValidPassport(string passport)
        {
            if (passport == null)
            {
                Console.WriteLine("Passport cannot be null.");
                Console.WriteLine();
                return null;
            }
            else if (passport.Length != 8)
            {
                 Console.WriteLine("Passport must be in 8 characters.");
                Console.WriteLine();
                return null;
            }
            else if (!char.IsLetter(passport[0]))
            {
                 Console.WriteLine("The first character of a Passport must be a Letter");
                Console.WriteLine();
                return null;
            }
            else
            {
                for (int i = 1; i < passport.Length; i++)
                {
                    if (!char.IsDigit(passport[i]))
                    {
                         Console.WriteLine("Please don't forget to provide the rest of the passport characters must be numbers");
                        Console.WriteLine();
                        return null;
                    }
                }
            }
            return passport;
        }

        /// <summary>
        /// Checking validation of ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string IsValidID(string ID)
        {
            if (ID == null)
            {
                Console.WriteLine("ID cannot be null."); 
                Console.WriteLine();
                return null;

            }
            else if (ID.Length != 13)
            {
                 Console.WriteLine("ID must be in 13 characters."); 
                Console.WriteLine();
                return null;

            }
            else
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    if (!char.IsDigit(ID[i]))
                    {
                         Console.WriteLine("Please make sure to provide the ID must be numeric");
                        Console.WriteLine();
                        return null;
                    }
                }
            }
            return ID;
        }

        /// <summary>
        /// Checking validation for Barcode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string ValidateBarCode(string code)
        {
            if (code == null)
            {
                Console.WriteLine("Barcode cannot be null.");
                Console.WriteLine();
                return null;
            }
            else if (code.Length != 13)
            {
                Console.WriteLine("Please make sure the Barcode number must be 13 characters long");
                Console.WriteLine();
                return null;
            }
            else
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (!char.IsDigit(code[i]))
                    {
                        Console.WriteLine("Please make sure the Barcode number is numeric");
                        Console.WriteLine();
                        return null;
                    }
                }
            }

            return code;
        }

        /// <summary>
        /// Checking validation for serial number
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public string ValidateSerialNumber(string serialNumber)
        {
            if (serialNumber == null)
            {
                Console.WriteLine("Serial Number cannot be null.");
                Console.WriteLine();
                return null;
            }
            else if (serialNumber.Length != 10)
            {
                Console.WriteLine("Please make sure the serial number must be 10 characters long");
                Console.WriteLine();
                return null;
            }
            else
            {
                for (int i = 0; i < serialNumber.Length; i++)
                {
                    if (!char.IsDigit(serialNumber[i]))
                    {
                        Console.WriteLine("Please make sure the serial number is numeric");
                        Console.WriteLine();
                        return null;
                    }
                }
            }

            return serialNumber;
        }

        /// <summary>
        /// Checking validation for data handling
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string DateHandling(string value)
        {
            if (value == null)
            {
                Console.WriteLine("Date of Vaccination cannot be  null.");
                Console.WriteLine();
                return null;

            }
            if (DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out _))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Please provide the Date in this format 'dd/MM/yy'");
                Console.WriteLine();
                return null;
            }
        }


        /// <summary>
        /// Checking validation for validateCentre
        /// </summary>
        /// <param name="vaccinationCentre"></param>
        /// <returns></returns>
        public string ValidateCentre(string vaccinationCentre)
        {
            if (string.IsNullOrEmpty(vaccinationCentre))
            {
                 Console.WriteLine("The vacinationCentre value is invalid or empty");
                Console.WriteLine();
                return null;
            }
            return vaccinationCentre;
        }
    }
}
