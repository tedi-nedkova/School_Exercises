using FormulaOne_2._0.Data;
using FormulaOne_2._0.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_2._0.Controllers
{
    public class TeamController
    {
        private FormulaOneExtendedContext Context { get; set; } = new FormulaOneExtendedContext();
        public async Task<List<Team>> GetAllTeams()
        {
            var teams = await Context.Teams
                .Select(t => new Team
                {
                    TeamName = t.TeamName,
                    Country = t.Country,
                    FoundationYear = t.FoundationYear
                })
                .ToListAsync();

            return teams;
        }

        public async Task<Team> GetTeamById(int id)
        {
            var team = await Context.Teams
                .FindAsync(id);

            return team;
        }

        public async Task<List<Team>> GetTeamsByCountry(string country)
        {
            var teams = await Context.Teams
                .Where(t => t.Country == country)
                .Select(t => new Team
                {
                    TeamName = t.TeamName,
                    Country = t.Country,
                    FoundationYear = t.FoundationYear
                })
                .ToListAsync();

            return teams;
        }

        public async Task<Team> GetOldestTeam()
        {
            var team = await Context.Teams
               .OrderBy(t => t.FoundationYear)
               .FirstAsync();

            return team;
        }

    }
}
