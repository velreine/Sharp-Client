using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool IsLoginCorrect = true;

            var session = CreateSession();
            SessionHandler sh = new SessionHandler();
            sh.ChangeState(session, Session.State.SESSION_OPEN);
            // TODO: Add code to lookup user and password here.

            
            if (IsLoginCorrect)
            {
                // 1.5 Change Session status to authenticated.
                sh.ChangeState(session, Session.State.SESSION_AUTHENTICATED);
                // 1.6 Status changed to Authenticated.
                return true;
                
               
            }

            sh.ChangeState(session, Session.State.SESSION_CLOSED);
            return false;
        }

    }

}
