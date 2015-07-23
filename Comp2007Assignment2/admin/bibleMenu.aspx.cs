using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference our entity framework models
using Comp2007Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Comp2007Assignment2
{
    public partial class bibleMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

    
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userID = User.Identity.GetUserId();

            using (DefaultConnection db = new DefaultConnection())
            {
                user id = (from objs in db.users
                           where objs.userID == userID
                           select objs).FirstOrDefault();

                lblUserId.Text = "Welcome " + id.fName;
            }

            //fill the grid
            if (!IsPostBack)
            {
                Session["sortColumn"] = "bookNum";
                Session["sortDirection"] = "ASC";
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
                string sortString = Session["sortColumn"].ToString() + " " + Session["sortDirection"].ToString();
                grdBible.DataSource = bible.AsQueryable().OrderBy(sortString).ToList();
                grdBible.DataBind();
            }
        }

        protected void grdBible_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdBible.PageIndex = e.NewPageIndex;
            GetBible();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdBible.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetBible();
        }

        protected void grdBible_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["sortColumn"] = e.SortExpression;

            if (Session["sortDirection"].ToString() == "ASC")
            {
                Session["sortDirection"] = "DESC";
            }
            else
            {
                Session["sortDirection"] = "ASC";
            }
            GetBible();
        }

    }
}