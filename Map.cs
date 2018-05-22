using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilerNS;

namespace GameNS
{
    public class Map
    {

        public List<MapItem> Items { get; set; }
        public List<MapItem> Updates = new List<MapItem>();


        public Map(string[] level)
        {
            this.ResetMap(level);
        }

        public void Update(int x, int y, char sign) // passes thorugh the values to update the positions of player and the thing it moved.
        {

            var updateItem = this.Items.FirstOrDefault(item => item.CordX == x && item.CordY == y);
            if (updateItem == null)
            {
                //throw error
            }
            else
            {
                updateItem.Sign = sign;
                Updates.Add(updateItem);
            }
        }

        public void ResetMap(string[] level)
        {
            this.Items = new List<MapItem>();
            int x = 0;
            foreach (string row in level)
            {
                int y = 0;
                foreach (char sign in row)
                {
                    Items.Add(new MapItem(x, y, sign));
                    y++;
                }
                x++;
            }
        }

    }
}
