using System;

namespace EtteplanTehtava.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Desc { get; set; }
        public string MaintClass { get; set; }
        public DateTime Added { get; set; }
        public string State { get; set; }
    }
}