using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_LR1
{
    public class States
    {
        public int CurrentCount = 0;
        //public SmallBottle SmallBottle = new SmallBottle();
        //public MediumBottle MediumBottle = new MediumBottle();
        //public LargeBottle LargeBottle = new LargeBottle();
        public int SelectedBottle = 0;
        public bool isCardPut = false;
        public int SelectedVolume = 0;
        public string CurrentMessage = "Выберите объем или вставьте карту";
        public States()
        {
        }


    }
    public class SmallBottle
    {
        public int IsFull = 0;
        public bool IsSelected = false;
    }
    public class MediumBottle
    {
        public int IsFull = 0;
        public bool IsSelected = false;
    }
    public class LargeBottle
    {
        public int IsFull = 0;
        public bool IsSelected = false;
    }

    
}
