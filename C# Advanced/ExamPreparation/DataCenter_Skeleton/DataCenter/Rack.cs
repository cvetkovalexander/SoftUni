 using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => this.Servers.Count;

        public Rack(int slots)
        {
            this.Slots = slots;
            this.Servers = new();
        }

        public void AddServer(Server server)
        {
            if (this.Servers.Count < this.Slots && !this.Servers.Any(x => x.SerialNumber == server.SerialNumber))
            {
                this.Servers.Add(server);
            }
        }
        public bool RemoveServer(string serialNum)
        {
            Server serverToRemove = Servers.FirstOrDefault(s => s.SerialNumber == serialNum);

            if (serverToRemove != null)
            {
                Servers.Remove(serverToRemove);
                return true;
            }

            return false;
        }

        public string GetHighestPowerUsage()
        {
            //Server server = this.Servers.OrderByDescending(s => s.PowerUsage).FirstOrDefault();
            //return server.ToString();
        
            return this.Servers.OrderByDescending(s => s.PowerUsage).FirstOrDefault().ToString();
        }

        public int GetTotalCapacity() => this.Servers.Sum(s => s.Capacity);

        public string DeviceManager()
        {
            StringBuilder result = new();
            result.AppendLine($"{this.Servers.Count} servers operating:");
            foreach (Server server in this.Servers)
            {
                result.AppendLine(server.ToString());
            }

            return result.ToString().Trim();
        }
    }
}