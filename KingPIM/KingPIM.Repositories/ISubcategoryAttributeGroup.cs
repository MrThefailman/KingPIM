using KingPIM.Models.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface ISubcategoryAttributeGroup
    {
        IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; }
        IEnumerable<SubcategoryAttributeGroup> GetSubcategoryAttributeGroups();

        void CreateSubcategoryAttributeGroup(int AttrGroupId, int SubCatId);
    }
}
