using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel2json
{
    class TsDefineGenerator
    {
        struct FieldDef
        {
            public string Name;
            public string Type;
        }

        string m_Code;

        public string Code
        {
            get
            {
                return this.m_Code;
            }
        }

        public TsDefineGenerator(string excelName, ExcelLoader excel)
        {
            //-- 创建代码字符串
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//");
            sb.AppendLine("//表格约定：第一行是变量名称，第二行是变量类型");
            sb.AppendFormat("// Generate From {0}.xlsx", excelName);
            sb.AppendLine();
            sb.AppendLine();
            
            /*
            for (int i = 0; i < excel.Sheets.Count; i++)
            {
                DataTable sheet = excel.Sheets[i];
                sb.Append(_exportSheet(sheet));
            }*/

            sb.AppendLine();
            sb.AppendLine("// End of Auto Generated Code");

            m_Code = sb.ToString();
        }

        public void SaveToFile(string filePath, Encoding encoding)
        {
            //-- 保存文件
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter writer = new StreamWriter(file, encoding))
                    writer.Write(m_Code);
            }
        }
    }
}
