﻿using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count
            => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players
            => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            var playerUsername = this.players.FirstOrDefault(p => p.Username == player.Username);

            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (players.Contains(playerUsername))
            {
                throw new ArgumentException($"Player {playerUsername} already exists!");
            }

            this.players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

           return this.players.Remove(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username == username);

            return player;
        }
    }
}