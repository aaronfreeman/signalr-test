using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        private Dictionary<long,Person> people = new Dictionary<long,Person> {
            {1, new Person {Id = 1, Name = "John"}},
            {2, new Person {Id = 2, Name = "Tracy"}},
            {3, new Person {Id = 3, Name = "BJ"}}
        };

        public Person LookupPerson(long id) 
        {
            return people.ContainsKey(id) ? people[id] : new Person();
        }
    }
}