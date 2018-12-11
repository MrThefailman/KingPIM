using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KingPIM.Repositories
{
    public class AttributeGroupRepository : IAttributeGroupRepository
    {
        private ApplicationDbContext ctx;
        public AttributeGroupRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        // Reads all attribute groups
        public IEnumerable<AttributeGroup> AttributeGroups => ctx.AttributeGroups.Include(x => x.ProductAttributes);
        public IEnumerable<AttributeGroup> GetAttributeGroups()
        {
            return AttributeGroups;
        }

        // Adds attribute groups to DB
        public int CreateAttributeGroup(MainPageViewModel vm)
        {
            if (vm.AttributeGroupName != null)
            {


                var part = vm.AttributeGroupName.Split("%");

                var groupName = part[0];
                var GroupDescription = part[1];

                // If it exists already, don't save
                int id = 0;
                var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Name.Equals(groupName));
                if (vm.Id == 0 && ctxAttrGroup == null)
                {
                    var newAttrGroup = new AttributeGroup
                    {
                        Name = groupName,
                        Description = GroupDescription,
                        ProductAttributes = null
                    };
                    ctx.AttributeGroups.Add(newAttrGroup);

                    ctx.SaveChanges();
                    id = newAttrGroup.Id;
                }
                else
                {
                    id = ctxAttrGroup.Id;
                }
                return id;
            }
            return 0;
        }
        // Deletes the attributegroup
        public AttributeGroup DeleteAttributeGroup(int attributeGroupId)
        {
            var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id.Equals(attributeGroupId));
            if (ctxAttrGroup != null)
            {
                ctx.AttributeGroups.Remove(ctxAttrGroup);
                ctx.SaveChanges();
            }
            return ctxAttrGroup;
        }

        // Updates the attributegroup
        public void EditAttributeGroup(MainPageViewModel ag)
        {
            var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id.Equals(ag.AttributeGroupId));

            if (ctxAttrGroup != null)
            {
                ctxAttrGroup.Name = ag.Name;
                ctxAttrGroup.Description = ag.Description;
            }
        }
    }
}
