using ExcelDataReader;
using PetStore.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Utilities
{
    internal class ExcelUtils
    {
        public static List<SearchDatas> ReadExcelData(string excelFilePath, string? sheetName)
        {
            List<SearchDatas> excelDataList = new List<SearchDatas>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables[sheetName];
                    if (dataTable != null)
                    {

                        foreach (DataRow row in dataTable.Rows)
                        {
                            SearchDatas excelData = new SearchDatas
                            {
                                UserName = GetValueOrDefault(row, "userName") ,
                                Password = GetValueOrDefault(row, "password") 
                            };
                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }
            return excelDataList;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
