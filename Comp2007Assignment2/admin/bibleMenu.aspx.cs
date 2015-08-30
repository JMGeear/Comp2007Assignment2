using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                //get userID from asp db
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);
                var userID = User.Identity.GetUserId();

                //using userID to get user information fname and lname
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    blogUser id = (from objs in db.blogUsers
                                   where objs.userID == userID
                                   select objs).FirstOrDefault();

                    lblUserId.Text = "Welcome " + id.fName;

                }

            }

        }
    
}