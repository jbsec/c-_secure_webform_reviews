        if (cookie == null || cookie.Value != "pro")
        {
            UserMsg.Text = "You don't have access to the feature request feature";
            FeatureRequest.Visible = false;
            return false;
        }

        return true;
		
# the code above is insecure because the cookie is shown to the user,
# it could be changed to say otherwise.

# the below code can be replaced

 protected void Page_Load(object sender, EventArgs e)
    {
        //Set default user account type
        if (Request.Cookies["UserType"] == null)
        {
            HttpCookie userTypeCookie = new HttpCookie("UserType");
            DateTime now = DateTime.Now;

            userTypeCookie.Value = "standard";
            userTypeCookie.Expires = now.AddMinutes(1440);

            Response.Cookies.Add(userTypeCookie);
        }

        IsProUser();
    }

    protected bool IsProUser()
    {
        HttpCookie cookie = Request.Cookies["UserType"];

        if (cookie == null || cookie.Value != "pro")
			
# to this below code

        if(Session["UserType"] == null)
            Session["UserType"] = "standard";

        IsProUser();
    }

    protected bool IsProUser()
    {
        if (Session["UserType"] == null || Session["UserType"] != "pro")
	}	
#################

# below is some insecure code

            //MD5 of valid vouchers
            var validCodes = [
                "6481f9fcf04a04973b21d93318f2e21e",
                "dc057b6be62c2239f995b4dbf17abfeb",
                "c4a7226eeb547ae443318b9fa28b7ab0"
            ]

            //Has a valid voucher code been provided?
            if(validCodes.indexOf(md5(voucherValue)) > -1)
                return true;
			
# ABOVE: Never give away MD5 codes to the user. The client can crack the hashes and find out
# which are valid.

# The below code reviews MD5.


    <script src="md5.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        /*
         * Validate voucher client side to reduce server load
        */
        function validateForm() {
            var voucherValue = document.getElementById("VoucherCode").value;

            //MD5 of valid vouchers
            var validCodes = [
                "6481f9fcf04a04973b21d93318f2e21e",
                "dc057b6be62c2239f995b4dbf17abfeb",
                "c4a7226eeb547ae443318b9fa28b7ab0"
            ]

            //Has a valid voucher code been provided?
            if(validCodes.indexOf(md5(voucherValue)) > -1)
                return true;

            alert("I'm sorry, but that isn't a valid voucher code");
            return false;
        }
    </script>

# This whole JavaScript can be replaced with this:

  <asp:Button runat="server" Text="Buy lifetime membership" OnClick="UpgradeAccountType_Click" />
  
 # 



















