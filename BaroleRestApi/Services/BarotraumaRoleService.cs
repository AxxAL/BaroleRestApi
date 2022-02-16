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
         * Gets all roles.
         */
        public  List<BarotraumaRole> GetAll()
        {
            return context.BarotraumaRoles
                .AsNoTracking()
                .ToList();
        }
        
        /*
         * Add a role to the service.
         * Returns instance of role.
         */
        public BarotraumaRole? Add(BarotraumaRole barotraumaRole)
        {
            bool alreadyExists = context.BarotraumaRoles.Find(barotraumaRole.Id) != null;
            if (alreadyExists)
            {
                return null;
            }
            
            BarotraumaRole result = context.BarotraumaRoles.Add(barotraumaRole).Entity;
            context.SaveChanges();
            
            return result;
        }
        
        /*
         * Adds collection of roles.
         */
        public List<BarotraumaRole> AddCollection(IEnumerable<BarotraumaRole> newRoles)
        {
            context.BarotraumaRoles.AddRange(newRoles);
           context.SaveChanges();
           
           return (List<BarotraumaRole>) newRoles;
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