using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace iTextDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DLL 下载地址:http://sourceforge.net/projects/itextsharp/files/itextsharp/

            #region//第一步定义一个Document，并设置页面大小为A4，竖向
            Document doc = new Document(PageSize.A4);
            #endregion

            #region//第二步创建Writer实例
            PdfWriter.GetInstance(doc, new FileStream("D:\\Hello.pdf", FileMode.Create));
            #endregion

            #region 设置PDF的头信息，一些属性设置，在Document.Open 之前完成
            doc.AddAuthor("作者aehyok");
            doc.AddCreationDate();
            doc.AddCreator("创建aehyok");
            doc.AddSubject("Asp.Net Mvc 使用 itextsharp 类库创建PDF文件的例子");
            doc.AddTitle("此PDF由aehyok创建，嘿嘿");
            doc.AddKeywords("Asp.Net Mvc,PDF,iTextSharp,aehyok");
            //自定义头 
            doc.AddHeader("Expires", "0");
            #endregion

            #region//第三步打开document
            doc.Open();
            #endregion

            #region//载入字体
            //"UniGB-UCS2-H" "UniGB-UCS2-V"是简体中文，分别表示横向字 和 // 纵向字 //" STSong-Light"是字体名称 
            BaseFont baseFT = BaseFont.CreateFont(@"c:\windows\fonts\SIMHEI.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT); //写入一个段落, Paragraph 
            #endregion

            #region///第四步添加内容
            doc.Add(new Paragraph("您好， PDF !", font));
            #endregion

            #region//第五步关闭document
            doc.Close();
            #endregion

            //打开PDF，看效果 
            Process.Start("D:\\Hello.pdf");
        }
    }
}
