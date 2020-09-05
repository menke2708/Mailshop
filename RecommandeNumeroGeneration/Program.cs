using OfficeOpenXml;
using System.IO;
using System;

namespace RecommandeNumeroGeneration
{
    class Program
    {
        public static int[] factors = { 8, 6, 4, 2, 3, 5, 9, 7 };

        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet ws = ExcelPkg.Workbook.Worksheets.Add("Registered Numbers");

            string identificationNumberRecommande = "RR";
            string clientNumber = args[0];
            string currentNumber = "";
            string checkDigit = "";
            string registeredNumber = "";
            string countryCode = args[1];
            int min = Int32.Parse(args[2]);
            int max = Int32.Parse(args[3]);
            string pathOfFile = args[4];

            for (int i = min; i <= max; i++)
            {
                currentNumber = i.ToString().PadLeft(4, '0');
                checkDigit = GetCheckDigitWithUPUAlgorithm(clientNumber + currentNumber);
                registeredNumber = identificationNumberRecommande + clientNumber + currentNumber + checkDigit + countryCode;
                Console.WriteLine(identificationNumberRecommande + clientNumber + currentNumber + checkDigit + countryCode);
                ws.Cells[i, 1].Value = registeredNumber;
                ws.Cells[i, 1].AutoFitColumns();
            }

            ws.Protection.IsProtected = false;
            ws.Protection.AllowSelectLockedCells = false;
            ExcelPkg.SaveAs(new FileInfo(pathOfFile));
        }

        private static string GetCheckDigitWithUPUAlgorithm(string number)
        {
            int result_sum = 0;
            int result_multiplication = 0;
            int result_modulo = 0;
            int digit = 0;
            int final_result_tocheck = 0;


            for (int i = 0; i < 8; i++)
            {
                digit = Int32.Parse(number.Substring(i, 1));

                result_multiplication = digit * factors[i];

                result_sum = result_sum + result_multiplication;
            }

            result_modulo = result_sum % 11;

            final_result_tocheck = 11 - result_modulo;

            if (final_result_tocheck >= 1 && final_result_tocheck <= 9)
            {
                return final_result_tocheck.ToString();
            }

            if (final_result_tocheck == 10)
            {
                return "0";
            }
            else if (final_result_tocheck == 11)
            {
                return "5";
            }
            else
            {
                return "-";
            }

        }
    }
}
