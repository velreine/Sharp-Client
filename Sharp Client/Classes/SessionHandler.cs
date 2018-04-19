using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp_Client.Classes
{
    class SessionHandler
    {


        public SessionHandler()
        {

        }
        
        public void ChangeState(Session _session, Session.State _state)
        {
            _session.state = _state;
        }


    }

    class Session
    {
        public State state;

        public Session()
        {

        }
        public enum State
        {
            SESSION_CLOSED,
            SESSION_OPEN,
            SESSION_AUTHENTICATED
        };


    }
}
