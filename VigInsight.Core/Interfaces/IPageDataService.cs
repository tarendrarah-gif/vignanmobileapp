using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IPageDataService
    {
        object GetPageData(int pageId);
        Page2Model GetPage2Data();
        Page3Model GetPage3Data();
        Page5Model GetPage5Data();
        Page7Model GetPage7Data();
        Page10Model GetPage10Data();
        Page11Model GetPage11Data();
        Page14Model GetPage14Data();
        Page15Model GetPage15Data();
        Page18Model GetPage18Data();
        Page20Model GetPage20Data();
        Page21Model GetPage21Data();
        Page26Model GetPage26Data();
        Page29Model GetPage29Data();
        Page32Model GetPage32Data();
        Page34Model GetPage34Data();
        Page44Model GetPage44Data();
        Page53Model GetPage53Data();
    }
}
