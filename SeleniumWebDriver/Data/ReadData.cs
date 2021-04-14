using Microsoft.Office.Interop.Excel;
using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumWebDriver
{
    public static class ReadData
    {       
        public static String[,] GetDataFromExcelFile()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string vXlpath = Path.Combine(executableLocation, @"Data\TestData.xlsx");

            int vSheetNum = 1;
            Application vXlApp;
            Workbook vXlWorkBook;
            Worksheet vXlWorkSheet;
            Range vXlrange;

            vXlApp = new Excel.Application();
            vXlWorkBook = vXlApp.Workbooks.Open(@vXlpath);
            vXlWorkSheet = vXlWorkBook.Sheets[vSheetNum];

            vXlrange = vXlWorkSheet.UsedRange;

            int vRowCnt = vXlrange.Rows.Count;
            int vColCnt = vXlrange.Columns.Count;

            String[,] vXlData = new String[vRowCnt, vColCnt];

            for (int i = 1; i <= vRowCnt; i++)
            {
                for (int j = 1; j <= vColCnt; j++)
                {
                    vXlData[i - 1, j - 1] = Convert.ToString(vXlrange.Cells[i, j].Value2);
                }
            }

            vXlWorkBook.Close(true, null, null);
            vXlApp.Quit();

            Marshal.ReleaseComObject(vXlWorkSheet);
            Marshal.ReleaseComObject(vXlWorkBook);
            Marshal.ReleaseComObject(vXlApp);

            return vXlData;
        }        
    }
}
