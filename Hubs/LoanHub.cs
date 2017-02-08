using Microsoft.AspNetCore.SignalR;

namespace signalr_test.Hubs
{
    public class LoanHub : Hub
    {
        public void JoinLoan(string loanNumber)
        {
            Groups.Add(Context.ConnectionId, loanNumber);
        }

        public void Send(string loanNumber, string name)
        {
            if(loanNumber != null) 
            {
                Clients.Group(loanNumber).broadcastMessage(name);
            }
        }
    }
}