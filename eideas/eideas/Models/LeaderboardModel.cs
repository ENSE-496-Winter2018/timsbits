using System;
using System.Collections.Generic;
using eideas.Areas.Identity.Data;
using eideas.Data;
using Microsoft.AspNetCore.Identity;

namespace eideas.Models
{
    public class LeaderboardModel
    {
        public int points { get; set; }
        public string Name { get; set; }
        public LeaderboardModel()
        {
        }
        public LeaderboardModel(int p, string n)
        {
        	points = p;
        	Name = n;
        }
    }
}