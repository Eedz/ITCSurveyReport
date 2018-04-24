using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCSurveyReport
{
    public class ReportLayout
    {
        PaperSizes paperSize;
        FileFormats fileFormat;
        TableOfContents toc;
        bool coverPage;
        bool blankColumn;

        public ReportLayout()
        {
            paperSize = PaperSizes.Letter;
            fileFormat = FileFormats.DOC;
            toc = TableOfContents.None;
            coverPage = false;
            blankColumn = false;
        }


        public PaperSizes PaperSize { get => paperSize; set => paperSize = value; }
        
    

        public FileFormats FileFormat { get => fileFormat; set => fileFormat = value; }
        public TableOfContents ToC { get => toc; set => toc = value; }
        public bool CoverPage { get => coverPage; set => coverPage = value; }
        public bool BlankColumn { get => blankColumn; set => blankColumn = value; }
    }
}
