using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;


using Comp2007Assignment2.Models;
using System.Web.ModelBinding;

namespace Comp2007Assignment2
{
	public partial class register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {

                    user u = new user();

                    u.fName = txtFName.Text;
                    u.lName = txtLName.Text;
                    u.username = txtUsername.Text;
                    u.password = txtPassword.Text;

                    db.users.Add(u);
                    db.SaveChanges();

                
            } 
        }
	}
}