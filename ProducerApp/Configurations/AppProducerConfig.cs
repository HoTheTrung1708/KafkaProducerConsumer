namespace ProducerApp.Configurations
{
    public class AppProducerConfig
    {//B1 
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }

        public ProducerConfig GetProducerConfig ()
        {
            return new ProducerConfig
            {
                BootstrapServers = BootstrapServers
            };
        }
    }
}
