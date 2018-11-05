using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface IAttributeGroupRepository
    {
        IEnumerable<AttributeGroup> AttributeGroups { get; }
        IEnumerable<AttributeGroup> GetAttributeGroups();

        void CreateAttribute(MainPageViewModel vm);

        AttributeGroup DeleteAttributeGroup(int attributeGroupId);

        void EditAttributeGroup(MainPageViewModel ag);
    }
}
