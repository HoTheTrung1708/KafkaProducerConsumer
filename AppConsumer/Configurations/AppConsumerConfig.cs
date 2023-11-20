namespace AppConsumer.Configurations
{
    public class AppConsumerConfig
    {
        public string          BootstrapServers           { get; set; }
        public string          GroupId                    { get; set; }
        public AutoOffsetReset AutoOffsetReset            { get; set; }
        public bool            EnableAutoCommit           { get; set; }
        public string          Topic                      { get; set; }

        public ConsumerConfig GetConsumerConfig() 
        {
            return new ConsumerConfig
            {
                BootstrapServers = BootstrapServers,
                GroupId          = GroupId,
                AutoOffsetReset  = AutoOffsetReset,
                EnableAutoCommit = EnableAutoCommit
            };
        }
    }
}
