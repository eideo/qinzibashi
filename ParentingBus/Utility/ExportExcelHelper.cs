using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace Utility
{
    public class ExportExcelHelper
    {
        public static void ExportExcel(string fileName, DataTable dataTable)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            ExportExcel(fileName, dataSet);
        }

        public static void ExportExcel(string fileName, DataSet dataSet)
        {
            if (dataSet.Tables.Count == 0)
            {
                return;
            }

            using (MemoryStream stream = DataTable2ExcelStream(dataSet))
            {
                FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                stream.WriteTo(fs);
                fs.Flush();
                fs.Close();
            }
        }

        private static MemoryStream DataTable2ExcelStream(DataSet dataSet)
        {
            MemoryStream stream = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(stream,
                SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());

            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable dataTable = dataSet.Tables[i];
                WorksheetPart worksheetPart = document.WorkbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheet sheet = new Sheet
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = (UInt32)(i + 1),
                    Name = dataTable.TableName
                };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                Row headerRow = CreateHeaderRow(dataTable.Columns);
                sheetData.Append(headerRow);

                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    sheetData.Append(CreateRow(dataTable.Rows[j], j + 2));
                }

                
            }

            document.Close();

            return stream;
        }

        private static Row CreateHeaderRow(DataColumnCollection columns)
        {
            Row header = new Row();
            for (int i = 0; i < columns.Count; i++)
            {
                //Cell cell = CreateCell(i + 1, 1, columns[i].ColumnName, CellValues.String);
                Cell cell = CreateCell(i + 1, 1, ExportExcelAllUtils.GetText(ExportExcelAllUtils.GetEnumType(columns[i].ColumnName)), CellValues.String);
                header.Append(cell);
            }
            return header;
        }

        private static Row CreateRow(DataRow dataRow, int rowIndex)
        {
            Row row = new Row();
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                Cell cell = CreateCell(i + 1, rowIndex, dataRow[i], GetType(dataRow.Table.Columns[i].DataType));
                row.Append(cell);
            }
            return row;
        }

        private static Cell CreateCell(int columnIndex, int rowIndex, object cellValue, CellValues cellValues)
        {
            Cell cell = new Cell
            {
                //CellReference = GetCellReference(columnIndex) + rowIndex,
                //CellValue = new CellValue { Text = cellValue.ToString() },
                //DataType = new EnumValue<CellValues>(cellValues),
                //StyleIndex = 0
                CellReference = GetCellReference(columnIndex) + rowIndex,
                DataType = CellValues.InlineString,
                InlineString = new InlineString() { Text = new Text(cellValue.ToString()) },
                StyleIndex = 0
            };

            return cell;
        }

        private static string GetCellReference(int colIndex)
        {
            int dividend = colIndex;
            string columnName = String.Empty;

            while (dividend > 0)
            {
                int modifier = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modifier) + columnName;
                dividend = (dividend - modifier) / 26;
            }

            return columnName;
        }

        private static CellValues GetType(Type type)
        {
            if (type == typeof(decimal))
            {
                return CellValues.Number;
            }
            //if ((type == typeof(DateTime)))
            //{
            //    return CellValues.Date;
            //}
            return CellValues.SharedString;
        }

    }

    public enum ExportExcelAllType
    {
        GoodsId,
        GoodsName,
        ActShowCount,
        PeopleCount,
        SellingPrice,
        TotalIncome,
        PlatformCost,
        ResponsiblePersonProfit,
        SumShareProfit,
        OtherCost,
        TotalPrice,
        TotalProfit,
        OrderId,
        Count,
        VisitTime,
        UserId,
        OrderPrice,
        OrderStatus,
        CreateTime
    }

    public class ExportExcelAllUtils
    {
        public static string GetValue(ExportExcelAllType type)
        {
            if (type == ExportExcelAllType.GoodsId)
            {
                return "GoodsId";
            }
            else if (type == ExportExcelAllType.GoodsName)
            {
                return "GoodsName";
            }
            else if (type == ExportExcelAllType.ActShowCount)
            {
                return "ActShowCount";
            }
            else if (type == ExportExcelAllType.PeopleCount)
            {
                return "PeopleCount";
            }
            else if (type == ExportExcelAllType.SellingPrice)
            {
                return "SellingPrice";
            }
            else if (type == ExportExcelAllType.TotalIncome)
            {
                return "TotalIncome";
            }
            else if (type == ExportExcelAllType.PlatformCost)
            {
                return "PlatformCost";
            }
            else if (type == ExportExcelAllType.ResponsiblePersonProfit)
            {
                return "ResponsiblePersonProfit";
            }
            else if (type == ExportExcelAllType.SumShareProfit)
            {
                return "SumShareProfit";
            }
            else if (type == ExportExcelAllType.OtherCost)
            {
                return "OtherCost";
            }
            else if (type == ExportExcelAllType.TotalPrice)
            {
                return "TotalPrice";
            }
            else if (type == ExportExcelAllType.TotalProfit)
            {
                return "TotalProfit";
            }
            else if (type == ExportExcelAllType.OrderId)
            {
                return "OrderId";
            }
            else if (type == ExportExcelAllType.Count)
            {
                return "Count";
            }
            else if (type == ExportExcelAllType.VisitTime)
            {
                return "VisitTime";
            }
            else if (type == ExportExcelAllType.UserId)
            {
                return "UserId";
            }
            else if (type == ExportExcelAllType.OrderPrice)
            {
                return "OrderPrice";
            }
            else if (type == ExportExcelAllType.OrderStatus)
            {
                return "OrderStatus";
            }
            else if (type == ExportExcelAllType.CreateTime)
            {
                return "CreateTime";
            }
            else
            {
                throw new Exception();
            }
        }

        public static string GetText(ExportExcelAllType type)
        {
            if (type == ExportExcelAllType.GoodsId)
            {
                return "活动编号";
            }
            else if (type == ExportExcelAllType.GoodsName)
            {
                return "活动名称";
            }
            else if (type == ExportExcelAllType.ActShowCount)
            {
                return "场次";
            }
            else if (type == ExportExcelAllType.PeopleCount)
            {
                return "总人数";
            }
            else if (type == ExportExcelAllType.SellingPrice)
            {
                return "单价";
            }

            else if (type == ExportExcelAllType.TotalIncome)
            {
                return "总收入";
            }
            else if (type == ExportExcelAllType.PlatformCost)
            {
                return "平台服务费";
            }
            else if (type == ExportExcelAllType.ResponsiblePersonProfit)
            {
                return "站长服务费";
            }
            else if (type == ExportExcelAllType.SumShareProfit)
            {
                return "分销渠道费";
            }
            else if (type == ExportExcelAllType.OtherCost)
            {
                return "其他费用";
            }
            else if (type == ExportExcelAllType.TotalPrice)
            {
                return "总费用";
            }
            else if (type == ExportExcelAllType.TotalProfit)
            {
                return "总利润";
            }
            else if (type == ExportExcelAllType.OrderId)
            {
                return "订单编号";
            }
            else if (type == ExportExcelAllType.Count)
            {
                return "数量";
            }
            else if (type == ExportExcelAllType.VisitTime)
            {
                return "参加时间";
            }
            else if (type == ExportExcelAllType.UserId)
            {
                return "用户编号";
            }
            else if (type == ExportExcelAllType.OrderPrice)
            {
                return "订单价格";
            }
            else if (type == ExportExcelAllType.OrderStatus)
            {
                return "订单状态";
            }
            else if (type == ExportExcelAllType.CreateTime)
            {
                return "创建时间";
            }
            else
            {
                throw new Exception();
            }
        }

        public static ExportExcelAllType GetEnumType(string typeStr)
        {
            ExportExcelAllType retval = ExportExcelAllType.GoodsId;

            if (Equals(ExportExcelAllType.GoodsId, typeStr))
            {
                retval = ExportExcelAllType.GoodsId;
            }
            else if (Equals(ExportExcelAllType.GoodsName, typeStr))
            {
                retval = ExportExcelAllType.GoodsName;
            }
            else if (Equals(ExportExcelAllType.ActShowCount, typeStr))
            {
                retval = ExportExcelAllType.ActShowCount;
            }
            else if (Equals(ExportExcelAllType.PeopleCount, typeStr))
            {
                retval = ExportExcelAllType.PeopleCount;
            }
            else if (Equals(ExportExcelAllType.SellingPrice, typeStr))
            {
                retval = ExportExcelAllType.SellingPrice;
            }
            else if (Equals(ExportExcelAllType.TotalIncome, typeStr))
            {
                retval = ExportExcelAllType.TotalIncome;
            }
            else if (Equals(ExportExcelAllType.PlatformCost, typeStr))
            {
                retval = ExportExcelAllType.PlatformCost;
            }
            else if (Equals(ExportExcelAllType.ResponsiblePersonProfit, typeStr))
            {
                retval = ExportExcelAllType.ResponsiblePersonProfit;
            }
            else if (Equals(ExportExcelAllType.SumShareProfit, typeStr))
            {
                retval = ExportExcelAllType.SumShareProfit;
            }
            else if (Equals(ExportExcelAllType.OtherCost, typeStr))
            {
                retval = ExportExcelAllType.OtherCost;
            }
            else if (Equals(ExportExcelAllType.TotalPrice, typeStr))
            {
                retval = ExportExcelAllType.TotalPrice;
            }
            else if (Equals(ExportExcelAllType.TotalProfit, typeStr))
            {
                retval = ExportExcelAllType.TotalProfit;
            }
            else if (Equals(ExportExcelAllType.OrderId, typeStr))
            {
                retval = ExportExcelAllType.OrderId;
            }
            else if (Equals(ExportExcelAllType.Count, typeStr))
            {
                retval = ExportExcelAllType.Count;
            }
            else if (Equals(ExportExcelAllType.VisitTime, typeStr))
            {
                retval = ExportExcelAllType.VisitTime;
            }
            else if (Equals(ExportExcelAllType.UserId, typeStr))
            {
                retval = ExportExcelAllType.UserId;
            }
            else if (Equals(ExportExcelAllType.OrderPrice, typeStr))
            {
                retval = ExportExcelAllType.OrderPrice;
            }
            else if (Equals(ExportExcelAllType.OrderStatus, typeStr))
            {
                retval = ExportExcelAllType.OrderStatus;
            }
            else if (Equals(ExportExcelAllType.CreateTime, typeStr))
            {
                retval = ExportExcelAllType.CreateTime;
            }
            return retval;
        }

        public static bool Equals(ExportExcelAllType type, string typeStr)
        {
            if (string.IsNullOrEmpty(typeStr)) return false;
            if (string.Equals(GetValue(type).ToLower(), typeStr.ToLower()))
            {
                return true;
            }
            return false;
        }

        public static bool Equals(string typeStr, ExportExcelAllType type)
        {
            return Equals(type, typeStr);
        }
    }
}
