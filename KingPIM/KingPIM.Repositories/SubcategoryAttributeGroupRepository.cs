using System;
using System.Collections.Generic;
using System.Text;
using KingPIM.Data;
using KingPIM.Models.Models;
using KingPIM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KingPIM.Repositories
{
    public class SubcategoryAttributeGroupRepository : ISubcategoryAttributeGroup
    {
        private ApplicationDbContext ctx;
        public SubcategoryAttributeGroupRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        // Reads all subcategory attributegroups
        public IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups => ctx.SubcategoryAttributeGroups.Include(x => x.AttributeGroup).Include(x => x.AttributeGroup.ProductAttributes);
        public IEnumerable<SubcategoryAttributeGroup> GetSubcategoryAttributeGroups()
        {
            return SubcategoryAttributeGroups;
        }

        public void CreateSubcategoryAttributeGroup(int AttrGroupId, int SubCatId)
        {
            if(AttrGroupId != 0 && SubCatId != 0)
            {
                var newSubcatAttrGroup = new SubcategoryAttributeGroup
                {
                    AttributeGroupId = AttrGroupId,
                    SubcategoryId = SubCatId
                };
                ctx.SubcategoryAttributeGroups.Add(newSubcatAttrGroup);
                ctx.SaveChanges();
            }
        }
    }
}
