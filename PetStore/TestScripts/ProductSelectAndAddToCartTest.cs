using OpenQA.Selenium;
using PetStore.HelperClass;
using PetStore.PageObjects;
using PetStore.Utilities;
using Serilog;

namespace PetStore.TestScripts
{
    [TestFixture]
    internal class ProductSelectAndAddToCartTest : CoreCodes
    {
        [Test, Order(1)]
        public void ProductSelectTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "FoundationTest";

            List<SearchDatas> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                try
                {
                    string? userName = excelData?.UserName;
                    string? password = excelData?.Password;
                    ProductSelectAndAddToCart psct = new (driver);   
                    psct.ProductSelect(userName,password);
                   
                    Assert.That(driver.Url, Does.Contain("petstore"));
                    TakeScreenShot();
                    test = extent.CreateTest("Product Selection Test Passed");
                    var sts = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    test.AddScreenCaptureFromBase64String(sts);
                }
                catch (AssertionException ex)
                {
                    TakeScreenShot();
                    test = extent.CreateTest("Product Selection Test Failed");
                    var sts1 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    test.AddScreenCaptureFromBase64String(sts1);
                }
            }
        }
    }
}
