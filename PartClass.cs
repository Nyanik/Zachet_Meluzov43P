using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectLearn
{
    public partial class Service
    {
        
        public SolidColorBrush DisColor
        {
            get
            {
                    switch (Discount.Value !=0)
                    {
                    case true:
                        return Brushes.LightGreen;
                    default:
                        return Brushes.White;
                    }
                
               
            }
     
        }
    }
}
