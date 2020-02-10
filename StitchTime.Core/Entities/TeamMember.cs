﻿namespace StitchTime.Core.Entities
{
    public class TeamMember : IEntity<int>
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
