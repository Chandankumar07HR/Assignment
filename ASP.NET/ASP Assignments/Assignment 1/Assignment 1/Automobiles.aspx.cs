using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Automobiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          
        }

        protected void btnShowCost_Click(object sender, EventArgs e)
        {

            string SelectedItem = dropdown.SelectedValue;
            string cost = string.Empty;
            if (SelectedItem == "1")
            {

                cost = "13000";

            }

            else if (SelectedItem == "2")
            {

                cost = "60000";
            }

            else if (SelectedItem == "3")
            {

                cost = "45000";
            }

            string Item = dropdown.SelectedItem.Text;

            lableCost.Text = $"Cost of {Item}: {cost}";

        }

        protected void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedItem = dropdown.SelectedValue;
           
            if (selectedItem == "1")
            {
                image.ImageUrl = $"images/oppo.png";
            }

            else if (selectedItem == "2")
            {
                image.ImageUrl = $"Images/Iphone 13.png";

            }

            else if (selectedItem == "3")
            {
                image.ImageUrl = $"Images/Samsung.png";

            }
            else
            {

                image.ImageUrl = $"Images/{"Images/normal.jpg"}";
            }
        }
    }
}