using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp2007Assignment2.admin
{
    public partial class notes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getNotes()
        {


        }

        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdNotes.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getNotes();
        }
    }
}