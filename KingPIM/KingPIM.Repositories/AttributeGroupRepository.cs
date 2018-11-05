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
        public void CreateAttribute(MainPageViewModel vm)
        {
            if(vm.Id == 0)
            {
                var newAttrGroup = new AttributeGroup
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    ProductAttributes = null
                };
                ctx.AttributeGroups.Add(newAttrGroup);
            }
            ctx.SaveChanges();
        }

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
        
        public void EditAttributeGroup(MainPageViewModel ag)
        {
            var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id.Equals(ag.attributeGroupId));

            if(ctxAttrGroup != null)
            {
                ctxAttrGroup.Name = ag.Name;
                ctxAttrGroup.Description = ag.Description;
            }
        }
    }
}
