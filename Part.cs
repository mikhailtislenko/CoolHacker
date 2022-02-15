namespace CoolHacker
{
    abstract internal class Part
    {
        public Part(string Name, string PCType, string Socket, string RamType, string RamCapasity, string VCInterface, string DiscInterface)
        {
            this.Name = Name;
            this.PCType = PCType;
            this.Socket = Socket;
            this.RamType = RamType;
            this.RamCapasity = RamCapasity;
            this.VCInterface = VCInterface;
            this.DiscInterface = DiscInterface;
        }

        public string Name { get; }
        public string PCType { get; }
        public string Socket { get; }
        public string RamType { get; }
        public string RamCapasity { get; }
        public string VCInterface { get; }
        public string DiscInterface { get; }


    }
}
