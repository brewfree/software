using System;

namespace BrewFree.ReadModels
{
    public class BrewerReadModel
    {
        public Guid Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string Name { get; set; }
    }
}
