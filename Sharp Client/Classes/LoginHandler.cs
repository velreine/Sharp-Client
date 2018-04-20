using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharp_Client.Classes
{
    class LoginHandler
    {

        public static Session CreateSession()
        {
            return new Session { state = Session.State.SESSION_CLOSED };
        }

        public static bool UserLogin(string username, string password)
        {
            

            var session = CreateSession();
            SessionHandler sh = new SessionHandler();
            sh.ChangeState(session, Session.State.SESSION_OPEN);
            // TODO: Add code to lookup user and password here.

            SharpDatabase database = new SharpDatabase();

            //User user = database.Tables.User.GetUserByID(1);
            User user = database.Tables.User.GetUserWhere("Username", username);

            if (user.Username == username && user.Password == password)
            {
                // 1.5 Change Session status to authenticated.
                sh.ChangeState(session, Session.State.SESSION_AUTHENTICATED);
                // 1.6 Status changed to Authenticated.
                return true;
                
               
            }

            MessageBox.Show("Invalid login!");
            sh.ChangeState(session, Session.State.SESSION_CLOSED);
            return false;
        }



    }

}
