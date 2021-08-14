using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Game : IEntity
    {
        public int GameId { get; set; }
        public string Descriptions { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
