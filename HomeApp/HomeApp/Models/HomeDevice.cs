using System;

namespace HomeApp.Models
{
    class HomeDevice
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public HomeDevice(string name, string image = null, string description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
            Description = description;
        }
    }
}