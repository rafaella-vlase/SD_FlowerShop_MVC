using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FlowerShop.Model
{
    public class FlowerStatistics : Subject
    {
        private string criterion;
        private DataTable flowerList;
        private Dictionary<string, uint> result;


        public FlowerStatistics(DataTable flowerList)
        {
            this.flowerList = flowerList;
            this.criterion = "Flower name";
            this.obsList = new List<Observable>();
            this.resultDetermination();
        }

        public string Criterion
        {
            get { return criterion; }
            set { criterion = value; this.resultDetermination(); this.Notify(); }
        }

        public Dictionary<string, uint> Result
        {
            get { return result; }
        }

        private void resultDetermination()
        {
            this.result = new Dictionary<string, uint>();
            if (this.criterion == "Flower Name")
                this.resultDeterminationFlowerName();
            else if (this.criterion == "Color")
                this.resultDeterminationColor();
        }

        private void resultDeterminationFlowerName() 
        {
            foreach(DataRow row in this.flowerList.Rows)
            {
                string flowerName = row["flowerName"].ToString();
                string key = flowerName;
                if (this.result.ContainsKey(key))
                {
                    this.result[key]++;
                }else this.result[key] = 1;
            }
        }

        private void resultDeterminationColor() 
        {
            foreach(DataRow row in this.flowerList.Rows)
            {
                string color = row["color"].ToString();
                string key = color;
                if (this.result.ContainsKey(key))
                {
                    this.result[key]++;
                } else this.result[key] = 1;
            }
        }
    }
}
