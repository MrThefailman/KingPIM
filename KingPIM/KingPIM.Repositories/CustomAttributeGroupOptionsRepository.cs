using KingPIM.Data;
using KingPIM.Models.Models;
using KingPIM.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public class CustomAttributeGroupOptionsRepository : ICustomAttributeGroupOptionsRepository
    {
        private ApplicationDbContext ctx;
        public CustomAttributeGroupOptionsRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<PreDifinedOptions> PreDifinedOptions => ctx.preDifinedOptions;
        public IEnumerable<PreDifinedOptions> GetPreDifinedOptions()
        {
            return PreDifinedOptions;
        }
        public void CreatePreDefinedOption(MainPageViewModel vm, int NewId)
        {
            if (vm.Id == 0 && NewId != 0)
            {
                var customName = vm.AttributeName.Split("%");
                var options = customName[1];
                var optionValues = options.Split("|");

                foreach (var option in optionValues)
                {
                    var newOption = new PreDifinedOptions
                    {
                        Name = option,
                        ProductAttributeId = NewId
                    };
                    ctx.preDifinedOptions.Add(newOption);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
