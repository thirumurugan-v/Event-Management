﻿using Event.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Event.Domain.Models.EventAggregate;

namespace Event.Infrastructure.Context
{
    public class EventContext : DbContext
    {
        public DbSet<Domain.Models.EventAggregate.Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<ParticipationStatus> ParticipationStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipationStatusEntityTypeConfiguration());
        }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
    }
}
