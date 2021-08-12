using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace WorkWithExcel
{
  class Program
  {
    const decimal MAX_PRICE = 10000m;

    static void Main(string[] args)
    {
      var sourceProducts = new List<Product>()
      {
        new Product("product1", 54),
        new Product("product2", 542125),
        new Product("product3", 65),
        new Product("product4", 5478),
        new Product("product5", 21222),
        new Product("product6", 12545),
        new Product("product7", 66)
      };

      var preparedProducts = sourceProducts
        .FindAll(x => x.Price < MAX_PRICE)
        .OrderBy(x => x.Name)
        .ToList();

      ExportToExcel(preparedProducts, AppDomain.CurrentDomain.BaseDirectory + Guid.NewGuid() + ".xlsx");


      Console.ReadKey();
    }


    static void ExportToExcel(List<Product> products, string path)
    {
      var excel = new Excel.Application();
      var workbooks = excel.Workbooks;
      var workbook = (Excel._Workbook)workbooks.Add();
      var worksheets = workbook.Worksheets;
      var worksheet = (Excel._Worksheet) worksheets.Item[1];
      worksheet.Cells[1, 1] = "Наименование товара";
      worksheet.Cells[1, 2] = "Цена товара";     

      for (int i = 0; i < products.Count; i++)
      {
        worksheet.Cells[i + 2, 1] = products[i].Name;
        worksheet.Cells[i + 2, 2] = products[i].Price;
      }

      workbook.SaveAs(path);
      workbook.Close();
      excel.Quit();

      
      Marshal.ReleaseComObject(worksheet);
      Marshal.ReleaseComObject(worksheets);
      Marshal.ReleaseComObject(workbook);
      Marshal.ReleaseComObject(workbooks);
      Marshal.ReleaseComObject(excel);
    }
  }
}
