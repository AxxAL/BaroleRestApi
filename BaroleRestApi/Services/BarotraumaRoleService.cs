using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BaroleRestApi.Data;
using BaroleRestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BaroleRestApi.Services
{
    public class BarotraumaRoleService
    {
        private readonly BarotraumaRoleContext context;

        public BarotraumaRoleService(BarotraumaRoleContext context)
        {
            this.context = context;
        }

        /*
         * Search for a role.
         */
        public BarotraumaRole? Get(Guid id)
        {
            return context.BarotraumaRoles
                .SingleOrDefault(r => r.Id == id);
        }
        
        /*
         * Gets a list of all roles.
         */
        public List<BarotraumaRole> GetAll()
        {
            return context.BarotraumaRoles
                .AsNoTracking()
                .ToList();
        }

        /*
         * Searches for roles based on title and returns list of matching results.
         */
        public List<BarotraumaRole> SearchByTitle(string title)
        {
            return new List<BarotraumaRole>(context.BarotraumaRoles.Where(role => role.Title.Contains(title)));
        }
        
        /*
         * Add a role to the service.
         * Returns instance of role added.
         */
        public BarotraumaRole? Add(BarotraumaRole barotraumaRole)
        {
            // TODO: Fix. Can't compare ids because the new role's id isn't generated yet...
            if (context.BarotraumaRoles.Where(role => role.Title.Equals(barotraumaRole.Title)).Count() > 0)
            {
                return null;
            }
            
            BarotraumaRole result = context.BarotraumaRoles.Add(barotraumaRole).Entity;
            context.SaveChanges();

            return result;
        }
        
        /*
         * Adds collection of roles.
         * Returns instance of roles added.
         */
        public List<BarotraumaRole> AddCollection(IEnumerable<BarotraumaRole> newRoles)
        {
            List<BarotraumaRole> barotraumaRoles = newRoles.ToList();

            // TODO: Fix. Can't compare ids because the new roles' ids aren't generated yet...
            foreach (var role in barotraumaRoles)
            {
                if (context.BarotraumaRoles.Find(role.Id) != null)
                {
                    barotraumaRoles.Remove(role);
                }
            }
            
            context.BarotraumaRoles.AddRange(barotraumaRoles);
            context.SaveChanges();
           
           return barotraumaRoles;
        }
        
        /*
         * Delete a role.
         * Returns instance of deleted role.
         */
        public BarotraumaRole? Remove(Guid id)
        {
            BarotraumaRole? role = context.BarotraumaRoles.Find(id);
            
            if (role != null)
            {
                context.BarotraumaRoles.Remove(role);
                context.SaveChanges();
            }

            return role;
        }

        /*
         * Update a role.
         * Returns instance of updated role.
         */
        public BarotraumaRole? Put(Guid id, BarotraumaRole barotraumaRole)
        {
            BarotraumaRole? role = context.BarotraumaRoles.Find(id);
            
            if (role != null)
            {
                role = barotraumaRole;
                context.SaveChanges();
            }
            
            return role;
        }
    }
}