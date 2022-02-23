using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.TechBiz.BS;
using Arquitetura.TechBiz.Utils;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente que customiza o GridView.
    /// </summary>
    [ToolboxData("<{0}:TDataPager runat=\"server\"></{0}:TDataPager>")]
    public sealed class TDataPager : DataPager
    {

        public TDataPager()
        {
            this.CreateFields();
        }

        public override void SetPageProperties(int startRowIndex, int maximumRows, bool databind)
        {
            if (this.Fields.Count == 3)
            {
                var btnFirst = ((NextPreviousPagerField)this.Fields[0]);
                var btnLast = ((NextPreviousPagerField)this.Fields[2]);

                if (startRowIndex > 0)
                {
                    btnFirst.ButtonCssClass = "";
                }
                else
                {
                    btnFirst.ButtonCssClass = "displayNone";
                }

                if ((startRowIndex + maximumRows) == this.TotalRowCount)
                {
                    btnLast.ButtonCssClass = "displayNone";
                }
                else
                {
                    btnLast.ButtonCssClass = "";
                }
            }

            base.SetPageProperties(startRowIndex, maximumRows, databind);
        }



        private void CreateFields()
        {
            NextPreviousPagerField fieldBefore = new NextPreviousPagerField();
            fieldBefore.ButtonType = ButtonType.Link;
            fieldBefore.FirstPageText = "Primeira";
            fieldBefore.PreviousPageText = "Anterior";
            fieldBefore.ShowFirstPageButton = true;
            fieldBefore.ShowPreviousPageButton = true;
            fieldBefore.ShowNextPageButton = false;
            fieldBefore.ShowLastPageButton = false;
            fieldBefore.ButtonCssClass = "displayNone";
            this.Fields.Add(fieldBefore);

            NumericPagerField numericField = new NumericPagerField();
            this.Fields.Add(numericField);


            NextPreviousPagerField fieldAfter = new NextPreviousPagerField();
            fieldAfter.ButtonType = ButtonType.Link;
            fieldAfter.NextPageText = "Próxima";
            fieldAfter.LastPageText = "Última";
            fieldAfter.ShowFirstPageButton = false;
            fieldAfter.ShowPreviousPageButton = false;
            fieldAfter.ShowNextPageButton = true;
            fieldAfter.ShowLastPageButton = true;
            this.Fields.Add(fieldAfter);

        }
    }
}
