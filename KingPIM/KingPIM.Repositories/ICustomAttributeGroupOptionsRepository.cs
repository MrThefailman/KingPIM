using KingPIM.Models.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface ICustomAttributeGroupOptionsRepository
    {
        IEnumerable<PreDifinedOptions> PreDifinedOptions { get; }
        IEnumerable<PreDifinedOptions> GetPreDifinedOptions();
        void CreatePreDefinedOption(MainPageViewModel vm, int NewId);
    }
}
