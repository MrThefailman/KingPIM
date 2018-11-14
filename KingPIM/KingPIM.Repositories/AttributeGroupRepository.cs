using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.ViewModels;

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
        public IEnumerable<AttributeGroup> AttributeGroups => ctx.AttributeGroups;
        public IEnumerable<AttributeGroup> GetAttributeGroups()
        {
            return AttributeGroups;
        }

        // Adds attribute groups to DB
        public int CreateAttributeGroup(MainPageViewModel vm)
        {
            var part = vm.AttributeGroupName.Split("%");

            var groupName = part[0];
            var GroupDescription = part[1];

            int id = 0;
            var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id.Equals(vm.AttributeGroupId));
            if(vm.Id == 0 && ctxAttrGroup == null || vm.Id != ctxAttrGroup.Id)
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
            return id;
        }
         // Deletes the attributegroup
        public AttributeGroup DeleteAttributeGroup(int attributeGroupId)
        {
            var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id.Equals(attributeGroupId));
            if(ctxAttrGroup != null)
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

            if(ctxAttrGroup != null)
            {
                ctxAttrGroup.Name = ag.Name;
                ctxAttrGroup.Description = ag.Description;
            }
        }
    }
}
