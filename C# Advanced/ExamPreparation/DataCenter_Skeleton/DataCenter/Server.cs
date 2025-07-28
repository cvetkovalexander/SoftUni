namespace DataCenter
{
    public class Server
    {
        public override string ToString()
        {
            return $"Server {this.SerialNumber}: {this.Model}, {this.Capacity}TB, {this.PowerUsage}W";
        }

        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int PowerUsage { get; set; }

        public Server(string num, string model, int capacity, int usage)
        {
            this.PowerUsage = usage;
            this.SerialNumber = num;
            this.Model = model;
            this.Capacity = capacity;
        }
    }
}