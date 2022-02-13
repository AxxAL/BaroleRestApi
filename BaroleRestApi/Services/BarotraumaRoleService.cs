using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BaroleRestApi.Models;

namespace BaroleRestApi.Services
{
    public static class BarotraumaRoleService
    {
        private static List<BarotraumaRole> Roles { get; set; } = new List<BarotraumaRole>();

        static BarotraumaRoleService()
        {
            List<BarotraumaRole> newRoles = new List<BarotraumaRole>()
            {
                new BarotraumaRole()
                {
                    Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Title = "The Bodyguard",
                    BarotraumaJob = "Security Guard",
                    Goal = "Protect the captain at all costs.",
                    WinCondition = "Keep the captain alive, even if he loses his position as captain. If the captain dies, you lose."
                },
                new BarotraumaRole()
                {
                    Id = Guid.Parse("feb86904-fe49-43a8-ad6c-0fc00aa7041d"),
                    Title = "The Dictator",
                    BarotraumaJob = "Captain",
                    Goal = "Create the most oppressive regime you can. Use security to beat the crew into submission. Make the crew offer offerings to you. Suppress revolts.",
                    WinCondition = "Obtain one item in offering from all but two crew members. They must state \"This is an offering to our great captain overlord\" Should a crew member die without offering anything, you can get that offering from their respawned body.",
                    AdditionalInfo = "Straight-Edge. Drugs are ILLEGAL amongst non medical personnel. Alcohol is ILLEGAL amongst the crew. Security is set to MIXED (Lethal and Non Lethal)."
                }
            };
            AddCollection(newRoles);
        }

        /*
         * Search for a role.
         */
        public static BarotraumaRole? Get(Guid id)
        {
            return Roles.FirstOrDefault(r => r.Id == id);
        }
        
        /*
         * Gets all roles.
         */
        public static List<BarotraumaRole>? GetAll()
        {
            return Roles;
        }
        
        /*
         * Add a role to the service.
         * Returns instance of role.
         */
        public static BarotraumaRole? Add(BarotraumaRole barotraumaRole)
        {
            Roles.Add(barotraumaRole);
            return barotraumaRole;
        }
        
        /*
         * Adds collection of roles.
         */
        public static void AddCollection(IEnumerable<BarotraumaRole> roles)
        {
            Roles.AddRange(roles);
        }
        
        /*
         * Delete a role.
         * Returns instance of deleted role.
         */
        public static BarotraumaRole? Remove(Guid id)
        {
            BarotraumaRole? role = Get(id);
            if (role == null) return null;
            Roles.Remove(role);
            return role;
        }

        /*
         * Update a role.
         * Returns instance of updated role if updated successfully.
         */
        public static BarotraumaRole? Put(Guid id, BarotraumaRole barotraumaRole)
        {
            for (int i = 0; i < Roles.Count; i++)
            {
                if (Roles[i].Id != id) continue;
                Roles[i] = barotraumaRole;
                return barotraumaRole;
            }
            return null;
        }
    }
}