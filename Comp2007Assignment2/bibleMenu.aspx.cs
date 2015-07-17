using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference our entity framework models
using Comp2007Assignment2.Models;
using System.Web.ModelBinding;

namespace Comp2007Assignment2
{
    public partial class bibleMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill the grid
            if (!IsPostBack)
            {
                GetBible();
            }
        }
        protected void GetBible()
        {

            //connect using our connection string from web.config and EF context class
            using (DefaultConnection conn = new DefaultConnection())
            {
                //use link to query the Departments model
                var bible = from b in conn.BibleBasicEnglishes
                           select b;

                //bind the query result to the gridview
                grdBible.DataSource = bible.ToList();
                grdBible.DataBind();
            }
        }


    }
}